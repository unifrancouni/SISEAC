using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using SISEAC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Chat.Hubs
{
    public class ChatHub : Hub
    {
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
        public static List<Client> ConnectedUsers { get; set; } = new List<Client>();

        public void Connect(string username)
        {
            Client c = new Client()
            {
                Username = username,
                ID = Context.ConnectionId,
                codcargo = obtenerCargo(username)
            };
            ConnectedUsers.Add(c);

            ActualizarLista();

            
        }

        public string obtenerCargo(string user) {

            var db = new EntStdUniAtd();

            var cod = db.spGetCargoCuenta().Where(c=>c.sNombreUsuario.ToLower().Equals(user.ToLower())).Select(c => c.sCodigoInterno).FirstOrDefault();

            return cod;
        }

        public void ActualizarLista()
        {
            List<string> idsactivos = new List<string>();
            foreach (Client i in ConnectedUsers.ToList<Client>())
            {
                if (i.Username.Equals("general"))
                {
                    idsactivos.Add(i.ID);
                }
            }

            string cu = JsonConvert.SerializeObject(ConnectedUsers);

            foreach (string i in idsactivos)
                Clients.Client(i).updateUsers(cu);
        }


        public static void SendNotificacion(string tipo_notificacion, string titulo, string texto, string codcargo)
        {

            List<string> signalids = new List<string>();

            foreach (Client i in ConnectedUsers)
            {
                if (i.codcargo.Equals(codcargo))
                {
                    signalids.Add(i.ID);
                }
            }

            foreach (string i in signalids)
                hubContext.Clients.Client(i).sendNotificacion(tipo_notificacion, titulo, texto);
        }
        public void SendNotificacion(string tipo_notificacion, string titulo, string texto, string codcargo, string usuario)
        {
            
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var disconnectedUser = ConnectedUsers.FirstOrDefault(c => c.ID.Equals(Context.ConnectionId));
            ConnectedUsers.Remove(disconnectedUser);

            ActualizarLista();


            return base.OnDisconnected(stopCalled);
        }

    }


    public class Client
    {
        public string Username { get; set; }
        public string ID { get; set; }
        public string codcargo { get; set; }
    }


}

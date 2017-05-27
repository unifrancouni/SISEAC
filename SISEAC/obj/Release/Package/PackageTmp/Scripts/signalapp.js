
function signalR(user, baseurl) {

    $(function () {

        var chat = $.connection.chatHub;
        $.connection.hub.url = baseurl+"signalr";

        $.connection.hub.logging = true;

        chat.client.updateUsers = function (connectedusers) {
            $('#users').html(connectedusers);
        }

        chat.client.sendNotificacion = function (tipo, titulo, texto) {
            //Agregar a la lista de notificaciones
            $('#Notificaciones').append('<li><a href="#"><div><i class="fa fa-envelope fa-fw"></i>' + texto + '<span class="pull-right text-muted small"><br>0 minutes ago</span></div></a></li>');

            //Verificar y aumentar contador
            var cnl = $('#CantidadNotificaciones').html();
            if (cnl === "")
                cnl = 0;
            $('#CantidadNotificaciones').html(parseInt(cnl) + 1);
            $('#CantidadNotificaciones').attr('style', 'visibility: visible');

            //Lanzar Notificacion
            toastr.options.timeOut = 10000;
            toastr.options.progressBar = true;
            toastr["info"](texto, titulo);
        }

        $.connection.hub.start().done(function () {
            chat.server.connect(user);
        });
    });



    $("#lNotificaciones").click(function () {
        $('#CantidadNotificaciones').html(0);
        $('#CantidadNotificaciones').attr('style', 'visibility: hidden')
    });

}
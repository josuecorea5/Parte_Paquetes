
$(document).ready(function () {
    $('#a-paquete').addClass('active');

    $('#sizePage').change(function () {
        filterPaginate("sizePage", $(this).val())
    });
    $('.page-link').click(function () {
        filterPaginate("currentPage", $(this).data("page"))
    });
    $('#searchString').on('keyup', function (e) {
        if (e.key === "Enter" || e.keyCode == 13) {
            filterPaginate("searchString", $(this).val());
        }
    });
    dtUsers = (url) => {
        $.ajax({
            type: "GET",
            url: url,
            contentType: false,
            processData: false,
            headers: {
                '@tokenSet.HeaderName': '@tokenSet.RequestToken'
            },
            success: function (data) {
                const { info } = data;
                const { id, nombre_Paquete, tipo_Paquete, peso_Paquete, fecha_Entrega, envio_Especial, monto_Pagar_Prop } = info;

                $("#Nombre_Paquete").val(nombre_Paquete);
                $("#Tipo_Paquete").val(tipo_Paquete);
                $("#Peso_Paquete").val(peso_Paquete);
                $("#Fecha_Entrega").val(fecha_Entrega);
                $("#Envio_Especial").val(envio_Especial);
                $("#Monto_Pagar").val(monto_Pagar_Prop);

                Mostrar_Modal(id);
            },
        })
    }
    function Mostrar_Modal(id) {
        let url = new URL(window.location.href);
        let urlEdit = url.origin + url.pathname + `/Update?Id=${id}`;
        $(".modal-footer")
            .append(
                `<a href="${urlEdit}" class="btn btn-outline-success">
                        <i class="fas fa-pencil-alt"></i>
                        Editar
                    </a>`
            );
        $("#Modal_Detalles").modal("show");
    }
    $('#Modal_Detalles').on('hidden.bs.modal', function () {
        $(".modal-footer").empty();
    })
});
//Global
let tablaTrabajadores = $("#tablaTrabajadores");

$(document).ready(function () {

    //Listado
    GetAll();

    //Fin Listado

    //Nuevo

    $("#btnNuevo").click(function () {
        $("#TituloModal").text("Nuevo Trabajador");
        $("#btnGuardar").fadeIn(0);
        $("#btnActualizar").fadeOut(0);
        $("#Modal_Mantenimiento").modal("show");
    })

    $("#btnGuardar").click(function () {
        Create();
    });

    //Fin Nuevo

    //Actualizar

    $("#tablaTrabajadores").on("click", ".btnAbrir", function () {

        $("#TituloModal").text("Editar Trabajador");
        $("#btnGuardar").fadeOut(0);
        $("#btnActualizar").fadeIn(0);

        let id = $(this).attr("data-id");
        Get(id);

    })

    $("#btnActualizar").click(function () {
        Update();
    });


    //Cancelar

    $(".cerrar").click(function () {
        Limpiar();

    });

    //Fin Cancelar

    GetAllDepartamento("#cboDepartamento");
    //GetAllTipoEstudio("#cboTipoEstudio");

})

//Listado

function GetAll() {

    $.ajax({
        type: 'GET',
        url: `../Trabajadores/GetAll`,
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        beforeSend: function () {
        },
        success: function (response) {
            if (response.resultado) {
                PintaTabla(response.data);
            } else {
                console.log(response);
            }
        },
        error: function (xhr, status, error) {
        },
        complete: function () {
        }
    });

}

function PintaTabla(data) {

    tablaTrabajadores.DataTable({
        responsive: true,
        pagingType: "full_numbers",
        data: data,
        destroy: true,
        columns: [
            { data: 'tipoDocumento' },
            { data: 'numeroDocumento' },
            { data: 'nombres' },
            { data: 'sexo' },
            { data: 'departamento' },
            { data: 'provincia' },
            { data: 'distrito' },
            { data: 'id' }
        ],
        columnDefs: [
            {
                targets: 0,
                render: function (data, type, full, meta) {
                    return `<center>${data}</center>`
                },
            },
            {
                targets: 1,
                render: function (data, type, full, meta) {
                    return `<center>${data}</center>`
                },
            },
            {
                targets: 2,
                render: function (data, type, full, meta) {

                    return `<center>${data}</center>`
                },
            },
            {
                targets: 3,
                render: function (data, type, full, meta) {

                    return `<center>${data}</center>`
                },
            },
            {
                targets: 4,
                render: function (data, type, full, meta) {

                    return `<center>${data}</center>`
                },
            },
            {
                targets: 5,
                render: function (data, type, full, meta) {

                    return `<center>${data}</center>`
                },
            },
            {
                targets: -1,
                render: function (data, type, full, meta) {
                    return `<div class="text-center">
                                        <div class="btn-group">
                                            <button data-id="${data}" class="btn btn-primary btnAbrir">EDITAR</button>
                                            <button class="btn btn-danger " Onclick="Delete(${data})">BORRAR</button>
                                        </div>
                                    </div>`
                },
            }
        ],
        "ordering": true
      
    });

}

//Fin Listado

//Crear

function Create() {

    let validation = true;

    let Data = {
        "TipoDocumento": $("#TipoDocumento").val(),
        "NumeroDocumento": $("#NumeroDocumento").val(),
        "Nombres": $("#Nombres").val(),
        "Sexo": $("#Sexo").val(),
        "IdDepartamento": parseInt($("#cboDepartamento").val()),
        "IdProvincia": parseInt($("#cboProvincia").val()),
        "IdDistrito": parseInt($("#cboDistrito").val())
    };

    if (Data.TipoDocumento.length == 0) {
        swal("El campo TipoDocumento esta vacio", "", "error");
        validation = false;
    }
    if (Data.NumeroDocumento.length == 0) {
        swal("El campo NumeroDocumento esta vacio", "", "error");
        validation = false;
    }
    if (Data.Nombres.length == 0) {
        swal("El campo Nombres esta vacio", "", "error");
        validation = false;
    }
    if (Data.Sexo.length == 0) {
        swal("El campo Sexo esta vacio", "", "error");
        validation = false;
    }
    if (Data.IdDepartamento == -1) {
        swal("El combo Departamento no ha sido seleccionado", "", "error");
        validation = false;
    }
    if (Data.IdProvincia == -1) {
        swal("El combo Provincia no ha sido seleccionado", "", "error");
        validation = false;
    }
    if (Data.IdDistrito == -1) {
        swal("El combo Distrito no ha sido seleccionado", "", "error");
        validation = false;
    }

    if (validation) {
        swal({
            title: "¿Estas Seguro?",
            text: "No podras revertir este cambio",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {

                    $.ajax({
                        type: 'POST',
                        url: `../Trabajadores/Create`,
                        data: JSON.stringify(Data),
                        contentType: "application/json; charset=utf-8",
                        async: true,
                        cache: false,
                        beforeSend: function () {
                        },
                        success: function (response) {
                            if (response.resultado) {
                                $("#Modal_Mantenimiento").modal("hide");
                                GetAll();
                                swal("Registro Exitoso", "", "success");
                                Limpiar();
                            } else {
                                swal(`${response.data}`, "", "error");
                                console.log(response);
                            }
                        },
                        error: function (xhr, status, error) {
                        },
                        complete: function () {
                        }
                    });
                }
            });
    }
}

//Fin Crear

//Actualizar

function Get(id) {
    $.ajax({
        type: 'GET',
        url: `../Trabajadores/Get?id=${id}`,
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        beforeSend: function () { },
        success: function (response) {
            if (response.resultado) {

                let obj = response.data;

                if (obj != null) {
                    $("#txtId").val(obj.id);
                    $("#TipoDocumento").val(obj.tipoDocumento);
                    $("#NumeroDocumento").val(obj.numeroDocumento);
                    $("#Nombres").val(obj.nombres);
                    $("#Sexo").val(obj.sexo);

                    $("#cboDepartamento").val(obj.idDepartamento);
                    GetProvinciaByDepartamento("#cboProvincia", obj.idDepartamento, obj.idProvincia);
                    GetDistritoByProvincia("#cboDistrito", obj.idProvincia, obj.idDistrito);

                    $("#Modal_Mantenimiento").modal("show");
                } else {
                    swal("No se encontro el trabajador", "", "warning");
                }


            } else {
                console.log(response);
            }
        },
        error: function () { },
        complete: function () { }
    });

}

function Update() {

    let validation = true;

    let Data = {
        "Id": parseInt($("#txtId").val()),
        "TipoDocumento": $("#TipoDocumento").val(),
        "NumeroDocumento": $("#NumeroDocumento").val(),
        "Nombres": $("#Nombres").val(),
        "Sexo": $("#Sexo").val(),
        "IdDepartamento": parseInt($("#cboDepartamento").val()),
        "IdProvincia": parseInt($("#cboProvincia").val()),
        "IdDistrito": parseInt($("#cboDistrito").val())
    };

    if (Data.TipoDocumento.length == 0) {
        swal("El campo TipoDocumento esta vacio", "", "error");
        validation = false;
    }
    if (Data.NumeroDocumento.length == 0) {
        swal("El campo NumeroDocumento esta vacio", "", "error");
        validation = false;
    }
    if (Data.Nombres.length == 0) {
        swal("El campo Nombres esta vacio", "", "error");
        validation = false;
    }
    if (Data.Sexo.length == 0) {
        swal("El campo Sexo esta vacio", "", "error");
        validation = false;
    }
    if (Data.IdDepartamento == -1) {
        swal("El combo Departamento no ha sido seleccionado", "", "error");
        validation = false;
    }
    if (Data.IdProvincia == -1) {
        swal("El combo Provincia no ha sido seleccionado", "", "error");
        validation = false;
    }
    if (Data.IdDistrito == -1) {
        swal("El combo Distrito no ha sido seleccionado", "", "error");
        validation = false;
    }

    if (validation) {
        swal({
            title: "¿Estas Seguro?",
            text: "No podras revertir este cambio",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {

                    $.ajax({
                        type: 'PUT',
                        url: `../Trabajadores/Update`,
                        data: JSON.stringify(Data),
                        contentType: "application/json; charset=utf-8",
                        async: true,
                        cache: false,
                        beforeSend: function () {
                        },
                        success: function (response) {
                            if (response.resultado) {
                                $("#Modal_Mantenimiento").modal("hide");
                                GetAll();
                                swal("Actualización Exitosa", "", "success");
                                Limpiar();
                            } else {
                                swal(`${response.data}`, "", "error");
                                console.log(response);
                            }
                        },
                        error: function (xhr, status, error) {
                        },
                        complete: function () {
                        }
                    });
                }
            });
    }
 
}


//Fin Actualizar

function Delete(id) {

    swal({
        title: "¿Estas Seguro?",
        text: "No podras revertir este cambio",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: 'Delete',
                    url: `../Trabajadores/Delete?id=${id}`,
                    contentType: "application/json; charset=utf-8",
                    async: true,
                    cache: false,
                    beforeSend: function () { },
                    success: function (response) {
                        if (response.resultado) {

                            swal("Se elimino Correctamente", "", "success");
                            GetAll();

                        } else {
                            console.log(response);
                            swal("No se elimino el trabajador", "", "error");
                        }
                      
                    },
                    error: function () { },
                    complete: function () { }
                });
               
            }
        });
}



//Utilitario




function GetAllDepartamento(componente) {

    $.ajax({
        type: 'GET',
        url: `../Departamento/GetAll`,
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        beforeSend: function () {
        },
        success: function (response) {

            $(componente).empty();
            $(componente).append(` <option value="-1">--SELECIONE--</option>`);

            if (response.resultado) {

                response.data.forEach(function (value, index) {
                    $(componente).append(`<option value="${value.id}">${value.nombreDepartamento}</option>`);
                })

                $(componente).change(function () {

                    GetProvinciaByDepartamento("#cboProvincia", this.value);
                    GetDistritoByProvincia("#cboDistrito", 0);
                })

            } else {
                console.log(response);
            }
        },
        error: function (xhr, status, error) {
        },
        complete: function () {
        }
    });

}

function GetProvinciaByDepartamento(componente, IdDepartamento, seleccionado = null) {

    $.ajax({
        type: 'GET',
        url: `../Provincia/GetAllByIdDepartamento?IdDepartamento=${IdDepartamento}`,
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        beforeSend: function () {
        },
        success: function (response) {

            $(componente).empty();
            $(componente).append(` <option value="-1">--SELECIONE--</option>`);

            if (response.resultado) {

                response.data.forEach(function (value, index) {
                    $(componente).append(`<option value="${value.id}">${value.nombreProvincia}</option>`);
                })

                $(componente).change(function () {

                    GetDistritoByProvincia("#cboDistrito", this.value);

                })

                if (seleccionado != null) {
                    $("#cboProvincia").val(seleccionado);
                }

            } else {
                console.log(response);
            }
        },
        error: function (xhr, status, error) {
        },
        complete: function () {
        }
    });

}

function GetDistritoByProvincia(componente, IdProvincia, seleccionado = null) {

    $.ajax({
        type: 'GET',
        url: `../Distrito/GetAllByIdProvincia?IdProvincia=${IdProvincia}`,
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        beforeSend: function () {
        },
        success: function (response) {

            $(componente).empty();
            $(componente).append(`<option value="-1">--SELECIONE--</option>`);

            if (response.resultado) {

                response.data.forEach(function (value, index) {
                    $(componente).append(`<option value="${value.id}">${value.nombreDistrito}</option>`);
                })


                if (seleccionado != null) {
                    $("#cboDistrito").val(seleccionado);
                }

            } else {
                console.log(response);
            }
        },
        error: function (xhr, status, error) {
        },
        complete: function () {
        }
    });

}

function Limpiar() {
    $("#TipoDocumento").val("");
    $("#NumeroDocumento").val("");
    $("#Nombres").val("");
    $("#Sexo").val("");

    $("#cboDepartamento").val(-1).trigger("change");
    $("#Modal_Mantenimiento").modal("hide");
}

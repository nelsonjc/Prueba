var IDEmployeeUpdate = -1;

function GetAllEmployee(request) {
    var response = $.ajax({
        url: "Employee/GetAll",
        type: "GET"
    });

    return request(response);
}

function LoadAllEmployee() {
    GetAllEmployee(function (requestGetAll) {
        requestGetAll.done(function (responseGetAll) {
            if (responseGetAll.success) {
                $("#tblEmployee").dataTable().fnDestroy();
                $('#tblEmployee').dataTable({
                    data: responseGetAll.data,
                    columns: [
                        {
                            "data": "idEmployee",
                            "render": function (data, type, row) {
                                return '<a class="btn btn-outline-primary" id=' + data + ' href="javascript:EditEmployee(' + data + ');"><i class="fas fa-edit"></i></a>';
                            }
                        },
                        { "data": "nameDocumentType" },
                        { "data": "documentNumber" },
                        {
                            "data": "name",
                            "render": function (data, type, row) {
                                var fullName = data;
                                if (row.secondName != null && row.secondName != undefined && row.secondName.length > 0) {
                                    fullName += ' ' + row.secondName;
                                }
                                return fullName;
                            }
                        },
                        {
                            "data": "surname",
                            "render": function (data, type, row) {
                                var fullName = data;
                                if (row.secondSurname != null && row.secondSurname != undefined && row.secondSurname.length > 0) {
                                    fullName += ' ' + row.secondSurname;
                                }
                                return fullName;
                            }
                        },
                        { "data": "nameArea" },
                        { "data": "nameSubArea" }
                    ]
                });
            }
            else {
                AlertError(responseGetAll.error.userMessage);
            }
        }).fail(function () {
            ErrorMessage("Error de conexión");
        });
    });
}

function GetArea(request) {
    var response = $.ajax({
        url: "Area/GetAll",
        type: "GET"
    });

    return request(response);
}

function GetListDocument(request) {
    var response = $.ajax({
        url: "DataList/GetByType",
        data: {
            "nameTypeList": "TIPODOCUMENTO"
        },
        type: "GET"
    });

    return request(response);
}

function GetSubAreas(IDArea, Request) {
    var response = $.ajax({
        url: "Area/GetSubAreaByIDArea",
        data: {
            "IDArea": IDArea
        },
        type: "GET"
    });

    return Request(response);
}

function GetEmployeeByID(IDEmployee, request) {
    var result = $.ajax({
        url: "Employee/GetByID",
        data: { "IDEmployee": IDEmployee },
        type: "GET"
    });

    return request(result);
}

function EditEmployee(IDEmployee) {
    IDEmployeeUpdate = IDEmployee;
    //1. Obtengo El Empleado
    GetEmployeeByID(IDEmployeeUpdate, function (requestEmployee) {
        requestEmployee.done(function (result) {
            if (result.success) {
                GetListDocument(function (requestListDocument) {
                    requestListDocument.done(function (response) {
                        if (response.success) {

                            $("#ddlDocumentType").empty();
                            var options = "<option value=-1>Seleccione</option>";

                            response.data.forEach(function (data, index) {

                                options += '<option value="' + data.id + '">' + data.name + '</option>';
                            });

                            $("#ddlDocumentType").append(options);
                            $("#ddlDocumentType").val(result.data.idDocumentType);
                            $("#txtDocumentNumber").val(result.data.documentNumber);
                            $("#txtName").val(result.data.name);
                            $("#txtSecondName").val(result.data.secondName);
                            $("#txtSurName").val(result.data.surname);
                            $("#txtSecondSurname").val(result.data.secondSurname);

                            GetArea(function (requestAre) {

                                requestAre.done(function (responseArea) {
                                    if (responseArea.success) {

                                        $("#ddlArea").empty();

                                        var options = "<option value=-1>Seleccione</option>";

                                        responseArea.data.forEach(function (data, index) {
                                            options += '<option value="' + data.idArea + '">' + data.name + '</option>';
                                        });

                                        $("#ddlArea").append(options);
                                        $("#ddlArea").val(result.data.idArea);

                                        GetSubAreas(result.data.idArea, function (requestSubAreas) {
                                            requestSubAreas.done(function (resultSubArea) {
                                                if (resultSubArea.success) {

                                                    $("#ddlSubArea").empty();

                                                    var options = "<option value=-1>Seleccione</option>";

                                                    resultSubArea.data.forEach(function (data, index) {
                                                        options += '<option value="' + data.idSubArea + '">' + data.nameSubArea + '</option>';
                                                    });

                                                    $("#ddlSubArea").append(options);
                                                    $("#ddlSubArea").val(result.data.idSubArea);
                                                    $("#EmployeeTitle").html("<strom>Actualización de Empleado</strom>");
                                                    $('#modalEmployee').modal('show');
                                                }
                                                else {
                                                    AlertError(resultSubArea.error.userMessage);
                                                }
                                            }).fail(function () {
                                                ErrorMessage("Error de conexión");
                                            });
                                        });
                                    }
                                    else {
                                        AlertError(response.error.userMessage);
                                    }
                                }).fail(function () {
                                    ErrorMessage("Error de conexión");
                                });
                            });




                        }
                        else {
                            AlertError(response.error.userMessage);
                        }
                    }).fail(function () {
                        ErrorMessage("Error de conexión");
                    });
                });
            }

            else {
                AlertError(result.error.userMessage);
            }

        }).fail(function () {
            ErrorMessage("Error de conexión");
        });

    });


}

function GetJSONEmployee() {
    var employee = {};
    employee.idDocumentType = $("#ddlDocumentType").val();
    employee.documentNumber = $("#txtDocumentNumber").val();
    employee.name = $("#txtName").val();
    employee.secondName = $("#txtSecondName").val();
    employee.surname = $("#txtSurName").val();
    employee.secondSurname = $("#txtSecondSurname").val();
    employee.idArea = $("#ddlArea").val();
    employee.idSubArea = $("#ddlSubArea").val();
    return employee;
}

function Update(IDEmployee) {

    var employee = GetJSONEmployee();
    employee.idEmployee = IDEmployee;

    var jsonEmployee = JSON.stringify(employee);

    $.ajax({
        url: "Employee/Update",
        data: JSON.parse(jsonEmployee),
        type: "POST"
    }).done(function (response) {
        if (response.success) {
            $('#modalEmployee').modal('hide');
            AlertSuccess("Empleado actualizado con exito!");
            CleanModal();
            IDEmployeeUpdate = -1;
        }
        else {
            AlertError(response.error.userMessage);
        }
    }).fail(function () {
        ErrorMessage("Error de conexión");
    });
}

function Create() {

    var employee = GetJSONEmployee();
    var jsonEmployee = JSON.stringify(employee);

    $.ajax({
        url: "Employee/Create",
        data: JSON.parse(jsonEmployee),
        type: "POST"
    }).done(function (response) {
        if (response.success) {
            $('#modalEmployee').modal('hide');
            AlertSuccess("Empleado Creado con exito!");
            CleanModal();
        }
        else {
            AlertError(response.error.userMessage);
        }
    }).fail(function () {
        ErrorMessage("Error de conexión");
    });
}

function Autocommplete() {
    var employee = {};
    employee.fullName = $("#txtSearchByName").val();
    employee.documentNumber = $("#txtSearchByDocNumber").val();
    var jsonEmployee = JSON.stringify(employee);

    $.ajax({
        url: "Employee/Autocomplete",
        data: JSON.parse(jsonEmployee),
        type: "GET"
    }).done(function (response) {
        if (response.success) {
            $("#tblEmployee").dataTable().fnDestroy();
            $('#tblEmployee').dataTable({
                data: response.data,

                columns: [
                    {
                        "data": "idEmployee",
                        "render": function (data, type, row) {
                            return '<a class="btn btn-outline-primary" id=' + data + ' href="javascript:EditEmployee(' + data + ');"><i class="fas fa-edit"></i></a>';
                        }
                    },
                    { "data": "nameDocumentType" },
                    { "data": "documentNumber" },
                    {
                        "data": "name",
                        "render": function (data, type, row) {
                            var fullName = data;
                            if (row.secondName != null && row.secondName != undefined && row.secondName.length > 0) {
                                fullName += ' ' + row.secondName;
                            }
                            return fullName;
                        }
                    },
                    {
                        "data": "surname",
                        "render": function (data, type, row) {
                            var fullName = data;
                            if (row.secondSurname != null && row.secondSurname != undefined && row.secondSurname.length > 0) {
                                fullName += ' ' + row.secondSurname;
                            }
                            return fullName;
                        }
                    },
                    { "data": "nameArea" },
                    { "data": "nameSubArea" }
                ]
            });
        }
        else {
            AlertError(response.error.userMessage);
        }
    }).fail(function () {
        ErrorMessage("Error de conexión");
    });
}

function CargarListaDocumentos() {
    GetListDocument(function (request) {
        request.done(function (response) {
            if (response.success) {

                $("#ddlDocumentType").empty();
                var options = "<option value=-1>Seleccione</option>";

                response.data.forEach(function (data, index) {

                    options += '<option value="' + data.id + '">' + data.name + '</option>';
                });

                $("#ddlDocumentType").append(options);
            }
            else {
                AlertError(response.error.userMessage);
            }
        }).fail(function () {
            ErrorMessage("Error de conexión");
        });
    });
}

function CargarAreas() {
    GetArea(function (request) {
        request.done(function (response) {
            if (response.success) {

                $("#ddlArea").empty();

                var options = "<option value=-1>Seleccione</option>";

                response.data.forEach(function (data, index) {
                    options += '<option value="' + data.idArea + '">' + data.name + '</option>';
                });

                $("#ddlArea").append(options);
            }
            else {
                AlertError(response.error.userMessage);
            }
        }).fail(function () {
            ErrorMessage("Error de conexión");
        });
    });

}

function CargarSubAreas(IDArea) {
    GetSubAreas(IDArea, function (request) {
        request.done(function (response) {
            if (response.success) {

                $("#ddlSubArea").empty();

                var options = "<option value=-1>Seleccione</option>";

                response.data.forEach(function (data, index) {
                    options += '<option value="' + data.idSubArea + '">' + data.nameSubArea + '</option>';
                });

                $("#ddlSubArea").append(options);
            }
            else {
                AlertError(response.error.userMessage);
            }
        }).fail(function () {
            ErrorMessage("Error de conexión");
        });
    });
}

function ValidateEmployee() {

    var message = "";
    var isValid = true;

    if ($("#ddlDocumentType").val() === null || $("#ddlDocumentType").val() <= 0) {
        message += "<span>&bull; El campo <strong>Tipo de Doc.</strong> es requerido</span><hr/>";
    }

    if ($("#txtDocumentNumber").val().length === 0 || $("#txtDocumentNumber").val() === "") {
        message += "<span>&bull; El campo <strong>Nit</strong> es requerido</span><hr/>";
    }

    if ($("#txtName").val().length === 0 || $("#txtName").val() === "") {
        message += "<span>&bull; El campo <strong>Nombre</strong> es requerido</span><hr/>";
    }

    if ($("#txtSurName").val().length === 0 || $("#txtSurName").val() === "") {
        message += "<span>&bull; El campo <strong>Apellido</strong> es requerido</span><hr/>";
    }

    if ($("#ddlArea").val() === null || $("#ddlArea").val() <= 0) {
        message += "<span>&bull; El campo <strong>Área</strong> es requerido</span><hr/>";
    }

    if ($("#ddlSubArea").val() === null || $("#ddlSubArea").val() <= 0) {
        message += "<span>&bull; El campo <strong>SubÁrea</strong> es requerido</span><hr/>";
    }

    if (message.length > 0) {
        AlertErrorValidator(message);
        isValid = false;
    }

    return isValid;

}

function CleanModal() {

    $("ddlDocumentType").empty();
    $("#ddlDocumentType").append("<option value=-1>Seleccione</option>");
    $("#txtDocumentNumber").val("");
    $("#txtName").val("");
    $("#txtSecondName").val("");
    $("#txtSurName").val("");
    $("#txtSecondSurname").val("");
    $("ddlArea").empty();
    $("#ddlArea").append("<option value=-1>Seleccione</option>");
    $("#ddlSubArea").empty();
    $("#ddlSubArea").append("<option value=-1>Seleccione</option>");
}

$(document).ready(function () {
    $("#btnNewEmployee").on("click", function () {
        CargarListaDocumentos();
        CargarAreas();

        $("#EmployeeTitle").html("<strom>Nuevo Empleado</strom>");
        $('#modalEmployee').modal('show');
    });

    $("#btnSendEmployee").on("click", function () {
        if (ValidateEmployee()) {
            if (IDEmployeeUpdate > 0) {
                Update(IDEmployeeUpdate);
            }
            else {
                Create();
            }
        }
    });

    $("#btnCloseModal").on("click", function () {
        setTimeout(
            function () {
                CleanModal();
            }, 500);
        
    });

    $('#ddlArea').on('change', function () {
        if (this.value > 0) {
            CargarSubAreas(this.value);
        }
        else {
            $("#ddlSubArea").empty();
            $("#ddlSubArea").append("<option value=-1>Seleccione</option>");
        }
    });

    $("#txtSearchByName").keyup(function () {
        if (this.value.length >= 3) {
            Autocommplete();
        }
        else if (this.value.length == 0 && $("#txtSearchByDocNumber").val().length == 0) {
            LoadAllEmployee();
        }
    });

    $("#txtSearchByDocNumber").keyup(function () {
        if (this.value.length >= 3) {
            Autocommplete();
        }
        else if (this.value.length == 0 && $("#txtSearchByName").val().length == 0) {
            LoadAllEmployee();
        }
    });

    LoadAllEmployee();
});
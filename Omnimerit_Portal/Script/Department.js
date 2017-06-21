$(document).ready(function () {

    Init();


});
var Department;
function Error() {

}
function Init() {

    post("GetDepartment", Success, Success)
}
function Success(data) {

    Department = data;
    var iconrender = function (data, type, row) {

        return '<span class="glyphicon glyphicon-edit " onclick="Edit(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" onclick="Delete(' + row.Id + ')"></span>';

    }
    $('#tabular').DataTable({

        "data": data,
        "aoColumns": [

             { "mData": "Name", "sTitle": "Name" },
             
              { "mData": "Code", "sTitle": "Code" },
              {

                  "render": iconrender
              }


        ]
    });
}


function Edit(rowData) {


    $.each(Department, function (index, value) {
        if (value.Id == rowData) {
            $('#Id').val(value.Id);
            $('#departmentname').val(value.Name);
           
            $('#departmentcode').val(value.Code);

        }
    });
}

function Delete(rowData) {
    if (confirm("Please Confirm to Delete")) {
        var data = { Id: rowData };

        $.ajax({
            method: 'post',
            url: 'DeleteDepartment',

            data: data,

            success: Deletesuccess,
            error: Deleteerror
        });
    }


}
function Deletesuccess() {
    alert("successfully deleted");

    var table = $('#tabular').DataTable();
    table.destroy();
    $('#tabular').empty();
    Init();



}
function Deleteerror() {
    alert("error deleted");
}

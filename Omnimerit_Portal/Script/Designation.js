$(document).ready(function () {

    Init();


});
var Designation;
function Error() {

}
function Init() {

    post("GetDesignation", Success, Success)
}
function Success(data) {

    Designation = data;
    var iconrender = function (data, type, row) {

        return '<span class="glyphicon glyphicon-edit " onclick="Edit(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" onclick="Delete(' + row.Id + ')"></span>';

    }
    $('#tabular').DataTable({

        "data": data,
        "aoColumns": [

             { "mData": "Name", "sTitle": "Name" },
            
              {

                  "render": iconrender
              }


        ]
    });
}


function Edit(rowData) {


    $.each(Designation, function (index, value) {
        if (value.Id == rowData) {
            $('#Id').val(value.Id);
            $('#designationname').val(value.Name);
           

        }
    });
}

function Delete(rowData) {
    if (confirm("Please Confirm to Delete")) {
        var data = { Id: rowData };

        $.ajax({
            method: 'post',
            url: 'DeleteDesignation',

            data: data,

            success: Deletesuccess,
            error: Deleteerror
        });
    }


}
function Deletesuccess() {
    alert("Successfully deleted");

    var table = $('#tabular').DataTable();
    table.destroy();
    $('#tabular').empty();
    Init();
   



}
function Deleteerror() {
    alert("error deleted");
}

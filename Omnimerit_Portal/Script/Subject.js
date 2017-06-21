$(document).ready(function () {

    Init();


});
var Subject;
function Error() {

}
function Init() {

    post("GetSubject", Success, Success)
}
function Success(data) {

    Subject = data;
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


    $.each(Subject, function (index, value) {
        if (value.Id == rowData) {
            $('#Id').val(value.Id);
            $('#name').val(value.Name);
            
            $('#code').val(value.Code);

        }
    });
}

function Delete(rowData) {
    if (confirm("Please Confirm to Delete")) {
        var data = { Id: rowData };

        $.ajax({
            method: 'post',
            url: 'DeleteSubject',

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

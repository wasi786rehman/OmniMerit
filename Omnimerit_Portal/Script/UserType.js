$(document).ready(function () {

    Init();


});
var UserType;
function Error() {

}
function Init() {

    post("GetUserType", Success, Success)
}
function Success(data) {
    debugger;
    UserType = data;
    var iconrender = function (data, type, row) {

        return '<span class="glyphicon glyphicon-edit " onclick="Edit(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" onclick="Delete(' + row.Id + ')"></span>';

    }
    $('#tabular').DataTable({

        "data": data,
        "aoColumns": [

            
            
              { "mData": "User_Type1", "sTitle": "User" },
              {

                  "render": iconrender
              }


        ]
    });
}


function Edit(rowData) {


    $.each(UserType, function (index, value) {
        if (value.Id == rowData) {
            $('#Id').val(value.Id);
            $('#usertype').val(value.User_Type1);
            

        }
    });
}

function Delete(rowData) {
    if (confirm("Please Confirm to Delete")) {
        var data = { Id: rowData };

        $.ajax({
            method: 'post',
            url: 'DeleteUserType',

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

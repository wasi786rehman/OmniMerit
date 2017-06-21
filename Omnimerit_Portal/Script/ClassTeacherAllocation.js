$(document).ready(function () {

    Init();


});
var ClassTeacherAllocation;
function Error() {

}
function Init() {

    post("GetClassTeacherAllocation",Success, Success)
}
function Success(data) {

    Course = data;
    var iconrender = function (data, type, row) {

        return '<span class="glyphicon glyphicon-edit " onclick="Edit(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" onclick="DeleteCourse(' + row.Id + ')"></span>';

    }
    $('#tabular').DataTable({

        "data": data,
        "aoColumns": [

             { "mData": "Name", "sTitle": "Name" },
             { "mData": "Description", "sTitle": "Description" },
              { "mData": "Code", "sTitle": "Code" },
              {

                  "render": iconrender
              }


        ]
    });
}


function Edit(rowData) {


    $.each(ClassTeacherAllocation, function (index, value) {
        if (value.Id == rowData) {
            $('#Id').val(value.Id);
            $('#coursename').val(value.Name);
            $('#description').val(value.Description);
            $('#code').val(value.Code);

        }
    });
}

function Delete(rowData) {
    if (confirm("Please Confirm to Delete")) {
        var data = { Id: rowData };

        $.ajax({
            method: 'post',
            url: 'DeleteClassTeacherAllocation',

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

$(document).ready(function () {
BankDetailInit();
});
var BankDetail;
function Error() {
}
function BankDetailInit() {

    post("GetBankDetail", BankDetailSuccess, BankDetailSuccess)
}
function BankDetailSuccess(data) {

    BankDetail = data;
    var iconrender = function (data, type, row) {

        return '<span class="glyphicon glyphicon-edit " onclick="EditBankDetail(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" onclick="DeleteBankDetail(' + row.Id + ')"></span>';

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


function EditBankDetail(rowData) {


    $.each(BankDetail, function (index, value) {
        if (value.Id == rowData) {
            $('#Id').val(value.Id);
            $('#coursename').val(value.Name);
           

        }
    });
}

function DeleteBankDetail(rowData) {
    if (confirm("Please Confirm to Delete")) {
        var data = { Id: rowData };

        $.ajax({
            method: 'post',
            url: 'DeleteBankDetail',

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
    CourseInit();



}
function Deleteerror() {
    alert("error deleted");
}

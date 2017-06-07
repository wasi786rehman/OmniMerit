$(document).ready(function () {

 
    Init();


});
var data;
function Error() {

}
function Init() {

    post("GetBatch", Success, Success)
}
function Success(data) {
    debugger;
    
    var data = JSON.parse(data);
    Batch = data;
    var iconrender = function (data, type, row) {

        return '<span class="glyphicon glyphicon-edit " onclick="Edit(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" onclick="Delete(' + row.Id + ')"></span>';

    }
    $('#tabular').DataTable({

        "data": data,
       
        "aoColumns": [
           
             { "mData": "Name", "sTitle": "Name" },
             { "mData": "Start_date", "sTitle": "Start Date", "type": "date " },
              { "mData": "End_date", "sTitle": "End Date" },
            
             
              {

                  "render": iconrender
              }


        ]
    });
}


function Edit(rowData) {

   
    debugger;
    $.each(Batch, function (index, value) {
        if (value.Id == rowData) {
            
            $('#Start_date').val(value.Start_date);
            $('#Name').val(value.Name);
            $('#End_date').val(value.End_date);
            $('#Max_Student').val(value.Max_Student);
            $('#Course').val(value.Course);
           
        }
    });
}

function Delete(rowData) {
    if (confirm("Please Confirm to Delete")) {
        var data = { Id: rowData };

        $.ajax({
            method: 'post',
            url: 'DeleteBatch',

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

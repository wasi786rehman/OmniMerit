$(document).ready(function () {
    debugger;
    post("GetCourse",  callback, callback)
});
function callback(data)
{
    alert(data);

    $('#tabular').DataTable({
       
        "data":data,
        "aoColumns": [

             { "mData": "Name", "sTitle": "Name" },
             { "mData": "Description", "sTitle": "Description" },
              { "mData": "Code", "sTitle": "Code" }
           

        ]
    });
}
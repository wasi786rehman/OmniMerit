$(document).ready(function () {
    debugger;
    post("GetCourse",  callback, callback)
});
function callback(data)
{
    alert(data);

    
   
    $('#tabular').DataTable({
        //"scrollX": true,
        //"paging": false,
        //"ordering": false,
        //"info": false,
        //"decimal": "2",
        //"bPaginate": false,
        //"bLengthChange": false,
        //"bFilter": true,
        //"bInfo": false,
        //"bAutoWidth": false,
        //"iDisplayLength": 5,
        "data":data,
        "aoColumns": [

             { "mData": "Name", "sTitle": "Name" },
             { "mData": "Description", "sTitle": "Description" },
              { "mData": "Code", "sTitle": "Code" }
           

        ]
    });
}
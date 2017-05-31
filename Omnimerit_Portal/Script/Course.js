$(document).ready(function () {
    debugger;
    CourseInit();
});
var Course;
function Error()
{

}
function CourseInit()
{
    debugger;
    post("GetCourse", CourseSuccess, CourseSuccess)
}
function CourseSuccess(data)
{
    alert(data);
    Course = data;
   var iconrender= function (data, type, row) {
        debugger;
        return '<span class="glyphicon glyphicon-remove-sign" onclick="EditCourse('+row.Id+')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-edit" onclick="DeleteCourse('+row.Id+')"></span>';
                     
    }
    $('#tabular').DataTable({
       
        "data":data,
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


function EditCourse(rowData)
{
    debugger;
   
    $.each(Course, function( index, value ) {
        if(value.Id==rowData)
        {
            $('#coursename').val(value.Name);
            $('#description').val(value.Description);
            $('#code').val(value.Code);
           
        }
    });
}
function DeleteCourse(rowData)
{
    alert("delete");
}
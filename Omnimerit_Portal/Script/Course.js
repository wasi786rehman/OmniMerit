$(document).ready(function () {
    
    CourseInit();
});
var Course;
function Error()
{

}
function CourseInit()
{
    
    post("GetCourse", CourseSuccess, CourseSuccess)
}
function CourseSuccess(data)
{
  
    Course = data;
   var iconrender= function (data, type, row) {
        
        return '<span class="glyphicon glyphicon-edit " onclick="EditCourse(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" onclick="DeleteCourse(' + row.Id + ')"></span>';
                     
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
    
   
    $.each(Course, function( index, value ) {
        if(value.Id==rowData)
        {
            $('#Id').val(value.Id);
            $('#coursename').val(value.Name);
            $('#description').val(value.Description);
            $('#code').val(value.Code);
           
        }
    });
}
function DeleteCourse(rowData)
{
    debugger;
    alert("delete");
    var courseobj = {};
    //$.each(Course, function (index, value) {
    //    if (value.Id == rowData) {
    //        courseobj.Id = value.Id
           
    //    }
    //});
    var data = {Id:rowData};

    $.ajax({
        method:'post',
        url: 'Delete',
       // contentType: "json",
        data: data,
        //dataType: "json",
        success: Deletesuccess,
        error: Deleteerror
    });
    
}
function Deletesuccess()
{
    alert("success deleted");
}
function Deleteerror()
{
    alert("error deleted");
}

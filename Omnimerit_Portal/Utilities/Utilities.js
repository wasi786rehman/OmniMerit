function post(url,data,successcallback,errorcallback)
{
    
    $.ajax({
        url: url,
        contentType: "json",
        data:data,
        //dataType: "json",
        success: successcallback,
        error: errorcallback
    });

}

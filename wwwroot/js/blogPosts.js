//$(function () {

//    var results = new Array();

//    var emp1 = { "ID": "12", "Name": "Manas" };
//    results.push(emp1);

//    var emp2 = { "ID": "2", "Name": "Tester" };
//    results.push(emp2);

//    // Without array you can use like to construct JSON object  
//    // var results = { empList : [{ "ID": "1", "Name": "Manas" },   
//    //                            { "ID": "2", "Name": "Tester" }]

//    var postData = { empList: results };

//    $.ajax({
//        url: 'Blog/AddNewCommentToPost',
//        data: JSON.stringify(postData),
//        type: 'POST',
//        contentType: 'application/json',
//        dataType: 'json',
//        beforeSend: function () {
//            Show(); // Show loader icon  
//        },
//        success: function (result) {
//            alert(result);
//        },
//        complete: function () {
//            Hide(); // Hide loader icon  
//        },
//        failure: function (jqXHR, textStatus, errorThrown) {
//            alert("Status: " + jqXHR.status + "; Error: " + jqXHR.responseText); // Display error message  
//        }
//    });
//});

//$(document).ready(function () {
//    $("#div_Loader").hide();
//});

//function Show() {
//    $('#div_Loader').show();
//}

//function Hide() {
//    $('#div_Loader').hide();
//} 
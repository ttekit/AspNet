$(document).ready(() => {
    $.ajax({
        type: "post",
        url: "/Blog/AddNewCommentToPost",
        success: (response) => {
            let $container = $(".blogContainer");
            response.forEach((item, index) => {

            })
        }

    })
})
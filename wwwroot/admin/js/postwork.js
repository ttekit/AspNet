window.addEventListener("load", function () {
    let $btnsContainer = $(".post-manage");
    let $btnsEdit = $btnsContainer.find(".blog-edit-button");
    let $btnsDelete = $btnsContainer.find(".blog-delete-button");

    $btnsEdit.on("click", function (e) {
        $postId = $(e.target).closest("div").find(".id").text();
        window.location = "/admin/editPost?postId=" + $postId;
    })

    $btnsDelete.on("click", function (e) {
        let $container = $(e.target).closest("div");
        let $postId = $container.find(".id").text();

        $.ajax({
            url: "/admin/deleteOnePost",
            method: "POST",
            data: {
                "postId": $postId
            },
            success: (data) => {
                if (data == "True") {
                    $container.parent("div").parent("div").remove();
                }
            },
            error: (msg) => {
                alert(msg);
            }
        })
    })
});
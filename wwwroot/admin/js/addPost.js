window.addEventListener("load", () => {

    let files;
    let fileInput = $('input[type=file]');
    let categories = "";

    fileInput.on('change', prepareUpload);

    function prepareUpload(event) {
        files = event.target.files;
    }


    $(".addNewCategoryBtn").on("click", (e) => {
        let $button = $(e.target);
        if ($button.hasClass("pressed")) {
            categories = "";
            $button.attr("class", "addNewCategoryBtn");
        } else {
            if (categories === "") {
                categories = $button.text();
                $button.addClass("pressed");
            }
        }
    });

    $(document).on('click',
        '#submit',
        function () {

            let formData = new FormData();

            if (files != null) {
                formData.append('logo', files[0]);
            }
            formData.append('Name', $("[name='name']").val());
            formData.append('Content', $("[name='content']").val());
            formData.append('Category', categories);

            $.ajax({
                url: '/admin/addNewPostAct',
                type: 'POST',
                data: formData,
                cache: false,
                processData: false,
                contentType: false,
                success: function (data) {
                    console.log(data);
                    Swal.fire("Poof! Your post is on checking!", {
                        icon: "success",
                    }).then(() => {
                        location.href = "/Blog/";
                    });

                },
                error: function (err, errmsg) {
                    Swal.fire({
                        title: "Error",
                        text: "Try later pls: " + errmsg,
                        icon: "error"
                    })
                },
                beforeSend: function () {
                    $('#preloader').fadeIn(500);
                },
                complete: function () {
                    $('#preloader').fadeOut(500);
                },
            });

            return false;
        });
})

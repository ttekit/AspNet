window.addEventListener("load", () => {

    let categories = "";
    let categoryBtn = $(".addNewCategoryBtn");

    for (let i = 0; i < categoryBtn.length; i++) {
        if (categoryBtn[i].classList.contains("pressed")) {
            categories = categoryBtn[i].innerHTML;
        }
    }

    categoryBtn.on("click", (e) => {
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


    let files = $("input[type=file]").files;
    $('input[type=file]').on('change', prepareUpload);

    function prepareUpload(event) {
        files = event.target.files;
    }


    $(document).on('click',
        '#submit',
        function () {
            let formData = new FormData();
            let correctCount = 0;

            if (categories == "") {
                Swal.fire({
                    title: "Error",
                    text: "Category must be not null!",
                    icon: "error",
                    buttons: true,
                    dangerMode: true,
                })
                correctCount = 0;
            } else {
                correctCount++;
            }


            if (correctCount != 0) {
                formData.append('Name', $("[name='title']").val());
                formData.append('Content', $("#summernote").val());
                formData.append('Id', $("[name='id']").val());
                formData.append('Category', categories);
                if (files != null) {
                    formData.append('Logo', files[0]);
                }


                $.ajax({
                    url: '/admin/updateProduct',
                    type: 'POST',
                    data: formData,
                    cache: false,
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        Swal.fire({
                            title: "Are you sure?",
                            text: "Are you sure you want to share " + data,
                            icon: "success",
                            buttons: true,
                            dangerMode: true,
                        })
                            .then((willDelete) => {
                                if (willDelete) {
                                    Swal.fire("Poof! Your post is on checking!", {
                                        icon: "success",
                                    }).then(() => {
                                        location.href = "/Admin/editBlog";
                                    });
                                } else {
                                    Swal.fire("Ok :( ");
                                }
                            });

                    },
                    error: function (request, errmsg) {
                        Swal.fire({
                            title: "Error",
                            text: request.responseText,
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

            }
            return false;

        })
});
 
window.addEventListener("load", () => {
    $(".submit").on("click", (e) => {
        let container = e.target.parentElement.parentElement;
        let data = {
            Id: $(container).find("input[name^='Id']").val(),
            GroupName: $(container).find("input[name^='Group']").val(),
        };
        console.log(data);
        $.ajax({
            url: '/admin/updateGroupData',
            type: 'POST',
            data: data,
            success: function (data) {
                console.log(data);
                Swal.fire({
                    title: "Success!",
                    text: "Group saved!",
                    icon: "success",
                });
            },
            error: function (err, errmsg) {
                Swal.fire({
                    title: "Error!",
                    text: "Pls try later!",
                    icon: "error",
                });
            }
        });
    })

    $(".remove").on("click", (e) => {

        Swal.fire({
            title: 'Do you want to delete?',
            showDenyButton: true,
            confirmButtonText: 'Delete',
            denyButtonText: `Cancel`,
        }).then((result) => {
            if (result.isConfirmed) {


                let container = e.target.parentElement.parentElement;
                let data = {
                    Id: $(container).find("input[name^='Id']").val(),
                    GroupId: $(container).find("[name^='Group']").val(),
                };
                console.log(data);
                $.ajax({
                    url: '/admin/removeGroup',
                    type: 'POST',
                    data: data,
                    success: function (data) {
                        Swal.fire({
                            title: "Success!",
                            text: "Option deleted!",
                            icon: "success",
                        });
                        container.remove();
                    },
                    error: function (jqXHR, errmsg) {
                        Swal.fire({
                            title: "Error!",
                            text: "Pls try later!" ,
                            icon: "error",
                        });
                        console.log(jqXHR);
                    }
                });
            }
        })
    })

    $(".addNewGroup").on("click", (e) => {
        $.ajax({
            url: '/admin/getOptionsGroupData',
            type: 'GET',
            success: function (data) {
                console.log(data);
                if (data != null) {
                    Swal.fire({
                        title: 'Add new group',
                        html: `<input type="text" id="GroupName" class="swal2-input" placeholder="Group name">
                         `,
                        confirmButtonText: 'Confirm',
                        focusConfirm: false,
                        preConfirm: () => {
                            const GroupName = Swal.getPopup().querySelector('#GroupName').value;
                            if (!GroupName) {
                                Swal.showValidationMessage(`Please enter groupName`)
                            }
                            return {GroupName: GroupName}
                        }
                    }).then((result) => {
                        $.ajax({
                            url: '/admin/addNewGroup',
                            type: 'POST',
                            data: result.value,
                            success: function (data) {
                                Swal.fire(
                                    'Success',
                                    'Option added',
                                    'success'
                                )
                            },
                            error: function (err, errmsg) {
                                console.log(err.responseText);
                            }
                        });
                    })

                }
            },
            error: function (err, errmsg) {
                console.log(err.responseText);
            }
        });

    })
})
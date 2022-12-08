window.addEventListener("load", () => {

    $(".submit").on("click", (e) => {
        let container = e.target.parentElement.parentElement;
        let data = {
            Id: $(container).find("input[name^='Id']").val(),
            GroupId: $(container).find("[name^='Group']").val(),
            Value: $(container).find("input[name^='Value']").val(),
            Href: $(container).find("input[name^='Href']").val(),
            Icon: $(container).find("input[name^='Icon']").val(),
        };

        $.ajax({
            url: '/admin/updateOptionData',
            type: 'POST',
            data: data,
            success: function (wdata) {
                console.log(wdata);
                Swal.fire({
                    title: "Success!",
                    text: "Option saved!",
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
            title: 'Do you want to save the changes?',
            showDenyButton: true,
            confirmButtonText: 'Delete',
            denyButtonText: `Cancel`,
        }).then((result) => {
            if (result.isConfirmed) {


                let container = e.target.parentElement.parentElement;
                let data = {
                    Id: $(container).find("input[name^='Id']").val(),
                    GroupId: $(container).find("[name^='Group']").val(),
                    Value: $(container).find("input[name^='Value']").val(),
                    Href: $(container).find("input[name^='Href']").val(),
                    Icon: $(container).find("input[name^='Icon']").val(),
                };
                console.log(data);
                $.ajax({
                    url: '/admin/removeOption',
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

    $(".addNewOption").on("click", (e) => {
        $.ajax({
            url: '/admin/getOptionsGroupData',
            type: 'GET',
            success: function (data) {
                console.log(data);
                if (data != null) {
                    let options = "";
                    for (let i = 0; i < data.length; i++) {
                        options += `<option class="swal2-option" value=${data[i].id}>${data[i].groupName}</option>`
                    }
                    console.log(options);
                    Swal.fire({
                        title: 'Add new option',
                        html: `<input type="text" id="Value" class="swal2-input" placeholder="Value">
                               <input type="text" id="Href" class="swal2-input" placeholder="Href">
                               <input type="text" id="Icon" class="swal2-input" placeholder="Icon">
                               <select id="Group" class="swal2-select" placeholder="Group">
                    ${options}
                    </select>
                    `,
                        confirmButtonText: 'Confirm',
                        focusConfirm: false,
                        preConfirm: () => {
                            const Value = Swal.getPopup().querySelector('#Value').value
                            const Href = Swal.getPopup().querySelector('#Href').value
                            const Icon = Swal.getPopup().querySelector('#Icon').value
                            const GroupId = Swal.getPopup().querySelector('#Group').value;
                            if (!Value || !Href || !GroupId) {
                                Swal.showValidationMessage(`Please enter value and href(if it is empty, just enter /)`)
                            }
                            return { Value: Value, Href: Href, Icon: Icon, GroupId: GroupId }
                        }
                    }).then((result) => {
                        $.ajax({
                            url: '/admin/addNewOption',
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
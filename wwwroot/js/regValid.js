$('#register-form').submit(function () {

    let div = $("#register-form");
    let error_arr = [];

    let allInputs = div.find('input');

    let name = allInputs[0].value;
    let email = allInputs[1].value;
    let password = allInputs[2].value;
    let passwordConfirm = allInputs[3].value;

    const emailRegEx = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/;

    if (name.length < 2) {
        error_arr.push("name is too short");
    }
    if (name.length > 50) {
        error_arr.push("name is too long");
    }

    if (!emailRegEx.test(email)) {
        error_arr.push("email is incorrect");
    }
    if (password != passwordConfirm) {
        error_arr.push("passwords are not the same one!");
    }


    if (error_arr.length == 0) {
        return true; 
    }
    else {
        let $errorDiv = div.find("#error-div");
        $($errorDiv).append(`
                <div class="alert alert-warning alert-dismissible fade show" role="alert">
                  <strong>Holy guacamole!</strong> ${error_arr}
                    <button type="button" id="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
        `);

        document.getElementById('close').onclick = function () {
            this.parentNode.remove();
            return false;
        };
        return false;
    }
});
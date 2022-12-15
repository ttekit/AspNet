$(document).ready(() => {

    let postId = $("#postId").text();

    let appendSubComments = function ($cont) {
        console.log("id: " + $cont.find("#id").text());
        $.ajax({
            url: "/blog/getSubComments",
            method: "POST",
            data: {
                "parId": $cont.find("#id").text()
            },
            success: (data) => {
                if (data == "[]") {
                    Swal.fire("No answers");
                }
                let comments = JSON.parse(data);

                for (let i = 0; i < comments.length; i++) {
                    $cont.append(getOneChildBlock(comments[i]));
                }
            },
            error: (msg) => {
                alert(msg);
            },
        })
    }

    let getSubCommentForm = function ($messageForm) {
        let $data;
        $data = $(`<form action="saveComment" method="post" id="comment-form" class="form-horizontal form-wizzard">
                            <h3 class="h3">Answer a comment</h3>
                            <div class="row">
                                <div class="col-lg-6 col-md-4 col-sm-12 col-xs-12">
                                    <div class="form-group">
                                        <input name="login" class="form-control" placeholder="Enter your name ..."/>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-4 col-sm-12 col-xs-12">
                                    <div class="form-group">
                                        <input name="email" type="email" class="form-control" placeholder="Enter your email ..."/>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <textarea name="message" rows="8" class="form-control" placeholder="Your comment ..."></textarea>
                            </div>
                            <div class="form-group">
                                <input type="submit" value="Answer comment" class="btn btn-default sumbit-btn"/>
                            </div>
                        </form>`);
        $data.submit(dataSubmitFunc)

        function dataSubmitFunc(e) {

            e.preventDefault();

            let $nameInput = $data.find("input[name*='login']");
            let $emailInput = $data.find("input[name*='email']");
            let $messageInput = $data.find("textarea[name*='message']");

            let userMessage = {
                Name: $nameInput.val(),
                Email: $emailInput.val(),
                Message: $messageInput.val(),
                postId: postId,
                commentId: $messageForm.find("#id").text()
            }
            $.ajax({
                url: "/blog/AddNewCommentToPost",
                method: "POST",
                data: userMessage,
                beforeSend: function () {
                    $('#preloader').fadeIn(500);
                },
                complete: function () {
                    location.reload();
                },
                error: (msg) => {
                    alert(msg);
                }
            })

            $data.remove();
            //           $parent.find(".comment-answer-btn").removeClass("hidden");

        }

        return $data;
    }


    let getOneChildBlock = function (data) {
        let $block = $(`<li>
                                        <div class="avatar">
                                            <img src="/images/misc/avatar-2.jpg" alt="" />
                                        </div>
                                        <div class="comment-info">
                                            <div class="d-none" id="id">${data.Id}</div>
                                            <span class="c_name">${data.Name}</span>
                                            <span class="c_date id-color">${data.Date}</span>

                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="comment">
                                            ${data.Message}
                                        </div>
                                        <div class="btn-cont">
                                            <button class="ans-btn">answ</button>
                                            <button class="get-ans-btn">get answ</button>
                                        </div>
                                    </li>`);

        $block.find(".ans-btn").on("click", function (e) {
            $(e.target).remove();
            $block.append(getSubCommentForm($block));
        });
        $block.find(".get-ans-btn").on("click", function (e) {
            $(e.target).addClass("hidden");
            appendSubComments($block);
        })

        return $block;
    }

    $(".ans-btn").on("click", (e) => {
        $(e.target.parentElement.parentElement).append(getSubCommentForm($(e.target.parentElement.parentElement)));
    })

    $(".get-ans-btn").on("click", (e) => {
        let cont = $(e.target.parentElement.parentElement);
        appendSubComments(cont);
    })

})
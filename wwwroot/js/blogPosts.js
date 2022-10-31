$(document).ready(() => {
    $.ajax({
        type: "post",
        dataType: "json",
        url: "/Blog/GetAllPosts",
        success: (response) => {
            let $container = $(".blogContainer");
            response.forEach((item, index) => {
                $container.append(`<div class="col-lg-4 col-md-6 mb20">
                    <div class="de-event-item">
                        <div class="d-content">
                            <div class="d-image">
                                <span class="d-image-wrap"><img alt="${item.imgAlt}" src="${item.imgSrc}" class="lazy"></span>
                            </div>
                            <div class="d-text">
                                <a href="01_rockfest-blog-single.html"><h4>${item.title}</h4></a>
                                <p>${item.content}</p>
                            </div>
                        </div>
                    </div>
                </div>`)
            })
        }

    })
})
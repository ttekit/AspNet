$(document).ready(() => {
    let catBtn = $(".catButton");
    catBtn.on("click", function (e) {
        let catName = e.target.innerHTML;
        $.ajax({
            url: "/Blog/GetCatsPosts",
            method: "GET",
            data: {
                "catName": catName
            },
            success: (data) => {
                let cont = $(".blogContainer");
                cont.empty();
                data.forEach((val, key) => {
                    cont.append(`
                        <div class="col-lg-4 col-md-6 mb20">
                            <div class="de-event-item">
                                <div class="d-content">
                                    <div class="d-image">
                                        <span class="d-image-wrap"><img alt="${val.imgAlt}" src="${val.imgSrc}" class="lazy"></span>
                                    </div>
                                    <div class="d-text">
                                        <a href="Blog/Post/${val.id}"><h4>${val.title}</h4></a>
                                        <p>${val.content}</p>
                                    </div>
                                </div>
                            </div>
                        </div>`);
                })
            },
            error: (err) => {
                console.log(err)
            }


        })
        console.log(catName);
    })
})
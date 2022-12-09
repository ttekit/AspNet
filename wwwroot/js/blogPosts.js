$(document).ready(() => {
    let getPostBlock = (val) => {
        return $(`      <div class="col-lg-4 col-md-6 mb20">
                            <div class="de-event-item">
                                <div class="d-content">
                                    <div class="d-image">
                                        <span class="d-image-wrap"><img alt="${val.imgAlt}" src="${val.imgSrc}" class="lazy"></span>
                                    </div>
                                    <div class="d-text">
                                        <a href="Blog/Post/${val.id}"><h4>${val.title}</h4></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                `);
    }
    let cont = $(".blogContainer");
    let catBtn = $(".catButton");

    catBtn.on("click", function (e) {
        let catBtn = $(e.target);
        cont.empty();
        if(!catBtn.hasClass("activeCat")){
            catBtn.addClass("activeCat");
        }
        else{
            catBtn.removeClass("activeCat");
        }
        let allActiveBtns = $(".activeCat");

        allActiveBtns.each((key, btn)=>{
            console.log(btn.innerHTML);
            $.ajax({
                url: "/Blog/GetCatsPosts",
                method: "GET",
                data: {
                    "catName":  btn.innerHTML
                },
                success: (data) => {
                    data.forEach((val, key) => {
                        cont.append(getPostBlock(val));
                    })
                },
                error: (err) => {
                    console.log(err)
                }
            })
        })
    })
})
let cont = $(".blogContainer");
let catBtn = $(".catButton");
let pagBtn = $(".count-link");
let prewPageButton = $(".prew-pagination");
let numericPageButtons = $(".numeric-pagination");
let numericButtonsContainer = $(".numeric-pagination-container");
let nextPageButton = $(".next-pagination");

let page = 0;
let limit = 12;
let catId;

let allPostsCount = $(".postsCount").text();
$(".postsCount").remove();


let getPostBlock = (val) => {
    let block = $(`      <div class="col-lg-4 col-md-6 mb20">
                            <div class="de-event-item">
                                <div class="d-content">
                                    <div class="d-image">
                                        <span class="d-image-wrap"><img alt="${val.imgAlt}" src="${val.imgSrc}" class="lazy"></span>
                                    </div>
                                    <div class="d-text">
                                        <a href="Blog/Post/${val.id}"><h4>${val.title}</h4></a> >
                                    </div>
                                </div>
                            </div>
                        </div>
                `);
    return block;
}

let refreshContainer = () => {
    $.ajax({
        url: "/Blog/GetCatsPosts",
        method: "GET",
        data: {
            "CurrentCount": limit,
            "CategoryId": catId,
            "Page": page
        },
        success: (data) => {
            if (data.length > 0) {
                data.forEach((val, key) => {
                    cont.append(getPostBlock(val));
                })
            }
            else {
                cont.append("<div class='empty-error-text'>Empty ;(</div>");
            }
        },
        error: (err) => {
            console.log(err)
        }
    });
}

let numericPageButtonHandler = (e) => {
    page = e.target.innerHTML-1;
    cont.empty();
    refreshContainer();
}

let refreshPaginationContainer = () => {
    numericButtonsContainer.empty();
    for (let i = 0; i < allPostsCount/limit; i++){
        let btn = $(`<li class="page-item"><button class="page-link numeric-pagination">${i+1}</button></li>`);
        btn.find("button").on("click", (e)=>{
            numericPageButtonHandler(e);
        })
        numericButtonsContainer.append(btn)
    }
}

let getCategory = function (catName, callback) {
    $.ajax({
        url: "/Blog/GetCategoryData",
        method: "GET",
        data: {
            "categoryName": catName,
        },
        success: (data) => {
            catId = data.id;
            allPostsCount = data.categoryCount;
            if(typeof(callback) == "function"){
                callback();
            }
        },
        error: (err) => {
            console.log(err)
        }
    });
}


catBtn.on("click", (e)=> {
    if (e.target.classList.contains("activeCat")) {
        e.target.classList.remove("activeCat");
    } else {
        if ($(".activeCat").length == 0) {
            let catBtn = $(e.target);
            cont.empty();
            getCategory(e.target.innerHTML, ()=>{
                page = 0;

                e.target.classList.add("activeCat");
                refreshContainer();
                refreshPaginationContainer();
            })
        }
    }
})

pagBtn.on("click", (e)=> {
    if (!e.target.classList.contains("activeCount")) {
        limit = e.target.innerHTML;
        page = 0;

        $(".active").removeClass("activeCount");
        e.target.parentElement.classList.add("activeCount");
        cont.empty();
        refreshContainer();
        refreshPaginationContainer();
    }
})


numericPageButtons.on("click", (e)=>{
    numericPageButtonHandler(e);
})

nextPageButton.on("click", (e) => {
    if (page + 1 < (allPostsCount / limit)) {
        page++;
        cont.empty();
        refreshContainer();
    }
})

prewPageButton.on("click", (e) => {
    if (page > 0) {
        page--;
        cont.empty();
        refreshContainer();
    }
})


refreshPaginationContainer();
if (allPostsCount == 0) {
    refreshContainer();
}

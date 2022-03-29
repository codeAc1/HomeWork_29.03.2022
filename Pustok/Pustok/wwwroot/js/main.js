$(document).ready(function () {
    $(document).on("click", "#productdetailId" function (e) {
        e.preventDefault();
        let url = this.attr("href")
        console.log(url);
    })
})
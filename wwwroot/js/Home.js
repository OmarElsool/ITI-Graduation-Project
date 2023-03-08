window.addEventListener("load", function () {
    //let imgArray = ["./Images/pexels-henda-watani-320014.jpg", "./Images/pexels-eberhard-grossgasteiger-1624256.jpg","./Images/pexels-patrick-gamelkoorn-13708903.jpg"];
    //let nextBtn = document.querySelector(".carousel-control-next");
    //let prevBtn = querySelector(".carousel-control-prev");
    //let imgToSlide = document.querySelector(".img-content");
    //let index = 0;

    //nextBtn.onclick = function(){
    //    index++;
    //    if(index >= imgArray.length){
    //        index = 0;
    //    }
    //    imgToSlide.src=`${imgArray[index]}`;
    //}

    //prevBtn.onclick = function(){
    //    index--;
    //    if(index < 0){
    //        index = imgArray.length-1;
    //    }
    //    imgToSlide.src=`${imgArray[index]}`;
    //}

})
let index = 0
function next(id, ...src) {
    index++;
    if (index == src.length) {
        index = 0;
    }
    document.getElementById(id).src = `~/Images/mansionsPhotos/@src[${index}]`;
    console.log(`${document.getElementById(id).src}`)
}
//function prev(id, count) {
//    index--;
//    if (index == 0) {
//        index = count-1;
//    }
//    document.getElementById(id).src = `~/Images/mansionsPhotos/@src[${index}].MansionPhoto`;
//}
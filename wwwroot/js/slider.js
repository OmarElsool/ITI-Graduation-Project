let previousSlidingBtn = document.querySelector(".previousBtn")
let nextSlidingBtn = document.querySelector(".nextBtn");
let SubmitSlidingBtn = document.querySelector(".SubmitBtn");
let hiddenGuestsInput = document.querySelector(".hidden-Guests-input");
let hiddenBedroomInput = document.querySelector(".hidden-Bedroom-input");
let hiddenBedInput = document.querySelector(".hidden-Bed-input");
let hiddenBathroomInput = document.querySelector(".hidden-Bathroom-input");

let sliderPages = document.querySelectorAll(".cs-slider-wrapper");
let sliderArr = [];
sliderPages.forEach(element => {
    sliderArr.push(element);
});
const currentEle = function () {
    let currentElement = 0
    sliderArr.forEach(element => {
        if (!element.classList.contains('cs-hide')) {
            currentElement = sliderArr.indexOf(element);

        }
    })
    return currentElement;
}
const nextSlide = function () {
    let currentPage = currentEle();
    let counter = currentPage;
    sliderArr[counter + 1].classList.remove('cs-hide');
    sliderArr[counter].classList.add('cs-hide');
    previousSlidingBtn.classList.remove('cs-hide');
    if (counter >= sliderArr.length - 2) {
        nextSlidingBtn.classList.add('cs-hide');
        SubmitSlidingBtn.classList.remove('cs-hide');
    }

}
const perviousSlide = function () {
    let currentPage = currentEle();
    let counter = currentPage;
    if (counter <= 1) {
        previousSlidingBtn.classList.add('cs-hide');
    } else {
        previousSlidingBtn.classList.remove('cs-hide');
    }
    sliderArr[counter - 1].classList.remove('cs-hide');
    sliderArr[counter].classList.add('cs-hide');

    if (counter <= sliderArr.length) {
        nextSlidingBtn.classList.remove('cs-hide');
        SubmitSlidingBtn.classList.add('cs-hide');
    }
}

nextSlidingBtn.onclick = function () {
    nextSlide();
}
previousSlidingBtn.onclick = function () {
    perviousSlide();
}





//second page


function toggleSelected(card) {
    if (card.classList.contains('selected')) {
        card.classList.remove('selected');
    } else {
        card.classList.add('selected');
    }
}


//fifth

let count = 0;
let count1 = 0;
let count2 = 0;
let count3 = 0;


// Counter 1 
function Counertfunc() {
    count++
    if (count < 17) {
        let span = document.querySelector(".counter");
        span.innerHTML = count;
    }
    else {
        let btn1 = document.getElementById("btn1");
        btn1.disable = true;
    }
    hiddenGuestsInput.value = count;
}
function CounertfuncDown() {
    if (count > 0) {
        count--
        let span = document.querySelector(".counter");
        span.innerHTML = count;
    }
    else {
        let btn2 = document.getElementById("btn2");
        btn2.disable = true;
    }
    hiddenGuestsInput.value = count;
}
// Counter 2 
function Counertfunc1() {
    count1++
    if (count1 < 51) {
        let span = document.getElementsByClassName("counter")[1];
        span.innerHTML = count1;
    }
    else {
        let btn3 = document.getElementById("btn3");
        btn3.disable = true;
    }
    hiddenBedroomInput.value = count1;
}
function CounertfuncDown1() {
    if (count1 > 0) {
        count1--
        let span = document.getElementsByClassName("counter")[1];
        span.innerHTML = count1;
    }
    else {
        let btn4 = document.getElementById("btn4");
        btn4.disable = true;
    }
    hiddenBedroomInput.value = count1;
}
// Counter 3
function Counertfunc2() {
    count2++
    if (count2 < 51) {
        let span = document.getElementsByClassName("counter")[2];
        span.innerHTML = count2;
    }
    else {
        let btn5 = document.getElementById("btn5");
        btn5.disable = true;
    }
    hiddenBedInput.value = count2;
}
function CounertfuncDown2() {
    if (count2 > 0) {
        count2--
        let span = document.getElementsByClassName("counter")[2];
        span.innerHTML = count2;
    }
    else {
        let btn6 = document.getElementById("btn6");
        btn6.disable = true;
    }
    hiddenBedInput.value = count2;
}
// Counter 4
function Counertfunc3() {
    count3++
    if (count3 < 51) {
        let span = document.getElementsByClassName("counter")[3];
        span.innerHTML = count3;
    }
    else {
        let btn7 = document.getElementById("btn7");
        btn7.disable = true;
    }
    hiddenBathroomInput.value = count3;
}
function CounertfuncDown3() {
    if (count3 > 0) {
        count3--
        let span = document.getElementsByClassName("counter")[3];
        span.innerHTML = count3;
    }
    else {
        let btn8 = document.getElementById("btn8");
        btn8.disable = true;
    }
    hiddenBathroomInput.value = count3
}





//seven


const input = document.querySelector('#fileInput');
const container = document.querySelector('#image-container');
const body = document.querySelector('body');

input.addEventListener('change', handleFiles);

function handleFiles() {
    const files = this.files;

    // Check if files were uploaded and remove the background image if present
    if (files.length > 0) {
        body.classList.add('no-background');
    }
    document.getElementById('upload-status').textContent = '';

    for (let i = 0; i < files.length; i++) {
        const img = document.createElement('img');
        img.src = URL.createObjectURL(files[i]);

        // Create a container div for each image
        const imgContainer = document.createElement('div');
        imgContainer.classList.add('image-container');

        // Add the image element and container div to the container
        imgContainer.appendChild(img);
        container.appendChild(imgContainer);

        // Create a delete icon for each image
        const deleteIcon = document.createElement('div');
        deleteIcon.classList.add('delete-icon');
        deleteIcon.innerHTML = '&#x2715;';

        // Add a click event listener to the delete icon
        deleteIcon.addEventListener('click', () => {
            // Remove the image container from the container
            container.removeChild(imgContainer);
            // Revoke the temporary URL for the image file
            URL.revokeObjectURL(img.src);

            // Check if no images are left and restore the background image if needed
            if (container.children.length === 0) {
                body.classList.remove('no-background');
            }
        });

        // Add the delete icon to the image container
        imgContainer.appendChild(deleteIcon);



    }

    let y = document.getElementsByClassName('image-container')[0].children[0].src;
    let last = document.querySelector(".lastimg");
    last.src = y;





}
const fileInput = document.getElementById('fileInput');
fileInput.addEventListener('change', function () {
    const selectedFiles = fileInput.files.length;
    if (selectedFiles < 5) {
        alert('Please select at least 5 photos.');
        fileInput.value = ''; // clear the input
    }
});



//title view 
function validate() {
    const areatextarea = document.querySelector("#summary");
    const areatext = document.querySelector("#summary").value.length;
    const textcount = document.querySelector("#textcount");
    const wordcount = document.querySelector("#words_count");
    textcount.innerHTML = areatext;


    if (areatext > 50) {
        textcount.classList.add("text-danger");
        areatextarea.classList.add("textarea_danger");
    } else {
        textcount.classList.remove("text-danger");
        areatextarea.classList.remove("textarea_danger");
    }

    if (areatext < 1) {
        wordcount.classList.add("d-none");
    } else {
        wordcount.classList.remove("d-none");
    }
}

//description


function valid() {
    const area = document.querySelector("#desc");
    const areat = document.querySelector("#desc").value.length;
    const textcoun = document.querySelector("#text");
    const wordcoun = document.querySelector("#words");
    textcoun.innerHTML = areat;


    if (areat > 50) {
        textcoun.classList.add("text-danger");
        area.classList.add("textarea_danger");
    } else {
        textcoun.classList.remove("text-danger");
        area.classList.remove("textarea_danger");
    }

    if (areat < 1) {
        wordcoun.classList.add("d-none");
    } else {
        wordcoun.classList.remove("d-none");
    }
}


//pricerange

let counter = 10;
let priceInput = document.querySelector(".price-input");

//counter.addEventListener("change", function (e) {
//    priceInput.value = e.value;
//})

function Increment() {
    counter = counter + 5
    if (counter < 1000) {
        let span = document.querySelector(".c");
        span.innerHTML = "$" + counter;
    }
    else {
        let firstbtn = document.getElementById("firstbtn");
        firstbtn.disable = true;
    }
    priceInput.value = counter;
}
function Decrement() {
    if (counter > 10) {
        counter = counter - 5
        let span = document.querySelector(".c");
        span.innerHTML = "$" + counter;
    }
    else {
        let secondbtn = document.getElementById("secondbtn");
        secondbtn.disable = true;
    }
    priceInput.value = counter;
}

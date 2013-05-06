document.addEventListener("DOMContentLoaded", function () {
    countdown(year, month, day, hour, minute);
}, false);

function setImage(img, height) {
    var elem = document.getElementById('bg');
    if (elem) {
        elem.style.height = height;
        elem.src = img;
    }
}
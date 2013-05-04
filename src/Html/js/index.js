document.addEventListener("DOMContentLoaded", function () {
    countdown(year, month, day, hour, minute);
}, false);

function setImage(values) {
    document.getElementById('bg').src = values;
}
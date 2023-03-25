var i = 0;
function afiseaza() {
    if (!i) {
        document.getElementById('text ascuns').style.display = "block";
        document.getElementById('puncte').style.display = "none";
        document.getElementById('read-more-btn').innerHTML = "Citește mai puțin";
        i = 1;
    }
    else {
        document.getElementById('text ascuns').style.display = "none";
        document.getElementById('puncte').style.display = "block";
        document.getElementById('read-more-btn').innerHTML = "Citește mai mult";
        i = 0;
    }
}
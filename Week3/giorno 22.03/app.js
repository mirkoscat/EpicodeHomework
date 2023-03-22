
var inputArea = document.getElementById("area")

function dig(n) {
    inputArea.value = inputArea.value + n

}

function risultato() {
    var c = inputArea.value;
    if (c) {
        inputArea.value = eval(c);
    }
}
function reset() {
    //cancello tutto
    inputArea.value = '';
}

function cancella() {
    //cancello l'ultimo carattere
    var a = inputArea.value;
    inputArea.value = a.substring(0, a.length - 1);
}
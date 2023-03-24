"use strict";
// Seleziona l'elemento paragrafo con id "testo"
const testo = document.getElementById('testo');
// Seleziona il bottone con id "bottone" e afferma che è di tipo HTMLButtonElement
const bottone = document.getElementById('bottone');
// Aggiunge l'evento "click" al bottone
bottone.addEventListener('click', function () {
    // Cambia il testo dell'elemento paragrafo selezionato utilizzando l'attributo innerHTML
    if (testo) {
        testo.innerHTML = 'Nuovo testo  in <strong>Typescript</strong>';
    }
});

function to20(numero) {
    var values = ["", "uno", "due", "tre", "quattro", "cinque", "sei", "sette", "otto", "nove", "dieci", "undici", "dodici", "tredici", "quattordici", "quindici", "sedici", "diciassette", "diciotto", "diciannove"]
    return values[numero]
}
function to100(numero) {
    if (numero < 20) return to20(numero)
    var values = [, , "venti", "trenta", "quaranta", "cinquanta", "sessanta", "settanta", "ottanta", "novanta", "cento"]
    return values[(Math.floor(numero / 10))] + to20(numero % 10)
}//fino a 1000 ok
function to1000(numero) {
    
    if (numero < 100) return to100(numero)
    var values = [, "cento", "duecento", "trecento", "quattrocento", "cinquecento", "seicento", "settecento", "ottocento", "novecento", "mille"]

    return values[(Math.floor(numero / 100))] + to100(numero % 100)
}
//fino a 10k ok
function to10k(numero) {
   
    if (numero <= 1000) return to1000(numero)
    var value = "mila"
    return to20(Math.floor(numero / 1000)) + value + to1000(numero % 1000)
}
/*
//fino a 100k
function to100k(numero) {
    
    if (numero <= 10000) return to10k(numero)
    var value = "mila"
    if(numero < 20000)
    return to20(Math.floor(numero)) + value + to100(numero % 100)+ to100(numero % 100)+ to20(numero )
}

function to1kk(numero) {
    if (numero <= 100000) return to100k(numero)
    var value = "milioni"
    return to20(Math.floor(numero /1000000))+value+ to1000(numero % 100)
}*/

for (let i = 1; i <= 10000; i++) {
    console.log(to10k(i))
}


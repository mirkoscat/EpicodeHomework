const cambia = document.getElementById('cambia');
const colors = ['rosso', 'verde', 'blu'];
let currentColorIndex = 0;
/* tramite il resto dell'operazione modulo ci muoviamo interno all'array 0%3=0, 1%3=1, 2%3=2 */
if (cambia) {
    setInterval(() => {
        cambia.classList.remove(colors[currentColorIndex % colors.length]);
        
        currentColorIndex++;
        
        cambia.classList.add(colors[currentColorIndex % colors.length]);
        
    }, 1000);
}
//bootrstap modal
const myModal1 = document.getElementById('myModal1')
const myModal2 = document.getElementById('myModal2')
const myModal3 = document.getElementById('myModal3')
const myModal4 = document.getElementById('myModal4')
const myInput = document.getElementById('myInput')

myModal.addEventListener('shown.bs.modal', () => {
  myInput.focus()
})
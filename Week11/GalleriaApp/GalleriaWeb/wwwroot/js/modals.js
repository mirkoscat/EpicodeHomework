//modal open
{
    var buttons = document.querySelectorAll('[data-target^="#exampleModalCenter_"]');
    buttons.forEach(function (button) {
        button.addEventListener('click', function () {
            var target = this.getAttribute('data-target');
            var modal = document.getElementById(target.substring(1));
            modal.classList.add('show');
            modal.style.display = 'block';
        });
    });
}
//modal close on screen
{

    var modals = document.querySelectorAll('[id^="exampleModalCenter_"]');
    modals.forEach(function (modal) {
        modal.addEventListener('click', function (event) {
            if (event.target === modal) {
                modal.classList.remove('show');
                modal.style.display = 'none';
            }
        });
    });
}
//modal close on button
{
    var closeButtons = document.querySelectorAll('[data-dismiss="modal"]');
    closeButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            var modal = button.closest('.modal');
            modal.classList.remove('show');
            modal.style.display = 'none';
        });
    });
}

var TicTacToe = /** @class */ (function () {
    function TicTacToe() {
        this.currentPlayer = "X";
        this.board = [
            ["", "", ""],
            ["", "", ""],
            ["", "", ""],
        ];
    }
    TicTacToe.prototype.checkRows = function () {
        for (var i = 0; i < this.board.length; i++) {
            if (this.board[i][0] &&
                this.board[i][0] === this.board[i][1] &&
                this.board[i][1] === this.board[i][2]) {
                return this.board[i][0];
            }
        }
        return undefined;
    };
    TicTacToe.prototype.play = function (coordinate) {
        var row = coordinate.row, col = coordinate.col;
        if (this.board[row][col] !== "") {
            return null; // Return null if the cell is already taken
        }
        this.board[row][col] = this.currentPlayer;
        var winner = this.checkWinner();
        if (winner) {
            return winner; // Return the winner if there is one
        }
        this.currentPlayer = this.currentPlayer === "X" ? "O" : "X";
        return null;
    };
    TicTacToe.prototype.checkWinner = function () {
        // Check rows
        for (var i = 0; i < 3; i++) {
            if (this.board[i][0] !== "" &&
                this.board[i][0] === this.board[i][1] &&
                this.board[i][0] === this.board[i][2]) {
                return this.board[i][0];
            }
        }
        // Check columns
        for (var i = 0; i < 3; i++) {
            if (this.board[0][i] !== "" &&
                this.board[0][i] === this.board[1][i] &&
                this.board[0][i] === this.board[2][i]) {
                return this.board[0][i];
            }
        }
        // Check diagonals
        if (this.board[0][0] !== "" &&
            this.board[0][0] === this.board[1][1] &&
            this.board[0][0] === this.board[2][2]) {
            return this.board[0][0];
        }
        if (this.board[0][2] !== "" &&
            this.board[0][2] === this.board[1][1] &&
            this.board[0][2] === this.board[2][0]) {
            return this.board[0][2];
        }
        // Return null if there is no winner
        return null;
    };
    TicTacToe.prototype.getCurrentPlayer = function () {
        return this.currentPlayer;
    };
    TicTacToe.prototype.getPlayerAt = function (row, col) {
        return this.board[row][col];
    };
    return TicTacToe;
}());
// Instantiate a new TicTacToe game
var game = new TicTacToe();
// Get references to the elements in the DOM
var boardEl = document.querySelector(".board") || null;
var winnerEl = document.querySelector(".winner") || null;
var playerEl = document.querySelector(".player") || null;
playerEl.textContent = "Current player: ".concat(game.getCurrentPlayer());
// Create the board
for (var i = 0; i < 3; i++) {
    for (var j = 0; j < 3; j++) {
        var cellEl = document.createElement("div");
        cellEl.classList.add("cell");
        cellEl.dataset.row = i.toString();
        cellEl.dataset.col = j.toString();
        cellEl.addEventListener("click", handleClick);
        boardEl.appendChild(cellEl) || null;
    }
}
// Handle a click on a cell
function handleClick(event) {
    var row = parseInt(event.target.dataset.row);
    var col = parseInt(event.target.dataset.col);
    var winner = game.play({ row: row, col: col });
    if (winner) {
        // Display the winner
        winnerEl.textContent = "Winner: ".concat(winner);
        playerEl.textContent = "";
    }
    else {
        // Display the current player
        playerEl.textContent = "Current player: ".concat(game.getCurrentPlayer());
    }
    // Update the board
    updateBoard();
}
// Update the board
function updateBoard() {
    var cells = boardEl.querySelectorAll(".cell");
    cells.forEach(function (cell) {
        var row = parseInt(cell.dataset.row);
        var col = parseInt(cell.dataset.col);
        var player = game.getPlayerAt(row, col);
        if (player) {
            cell.textContent = player;
        }
        else {
            cell.textContent = "";
        }
    });
}

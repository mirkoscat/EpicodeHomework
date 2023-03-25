"use strict";
class TicTacToe {
    constructor() {
        this.currentPlayer = "X";
        this.board = [
            ["", "", ""],
            ["", "", ""],
            ["", "", ""],
        ];
    }
    checkRows() {
        for (let i = 0; i < this.board.length; i++) {
            if (this.board[i][0] &&
                this.board[i][0] === this.board[i][1] &&
                this.board[i][1] === this.board[i][2]) {
                return this.board[i][0];
            }
        }
        return undefined;
    }
    play(coordinate) {
        const { row, col } = coordinate;
        if (this.board[row][col] !== "") {
            return null; // Return null if the cell is already taken
        }
        this.board[row][col] = this.currentPlayer;
<<<<<<< HEAD
        const winner = this.checkWinner();
=======
        var winner = this.checkWinner();
        if (winner === "tie") {
            return winner; // Return the winner if there is one
        }
>>>>>>> 4d4b4e47cf41cb8d0d53616a6a2451831ffee762
        if (winner) {
            return winner; // Return the winner if there is one
        }
        this.currentPlayer = this.currentPlayer === "X" ? "O" : "X";
        return null;
    }
    checkWinner() {
        // Check rows
        for (let i = 0; i < 3; i++) {
            if (this.board[i][0] !== "" &&
                this.board[i][0] === this.board[i][1] &&
                this.board[i][0] === this.board[i][2]) {
                return this.board[i][0];
            }
        }
        // Check columns
        for (let i = 0; i < 3; i++) {
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
        // Check for tie
        var isTie = true;
        for (var i = 0; i < 3; i++) {
            for (var j = 0; j < 3; j++) {
                if (this.board[i][j] === "") {
                    isTie = false;
                    break;
                }
            }
            if (!isTie) {
                return null;
                break;
            }
        }
        if (isTie) {
            return "tie";
        }
        // Return null if there is no winner
<<<<<<< HEAD
        return null;
=======
    };
    TicTacToe.prototype.getCurrentPlayer = function () {
        return this.currentPlayer;
    };
    TicTacToe.prototype.getPlayerAt = function (row, col) {
        return this.board[row][col];
    };
    TicTacToe.prototype.reset = function () {
        this.currentPlayer = "X";
        this.board = [
            ["", "", ""],
            ["", "", ""],
            ["", "", ""],
        ];
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
>>>>>>> 4d4b4e47cf41cb8d0d53616a6a2451831ffee762
    }
    getCurrentPlayer() {
        return this.currentPlayer;
    }
    getPlayerAt(row, col) {
        return this.board[row][col];
    }
}
// Get references to the elements in the DOM
const boardEl = document.querySelector(".board");
const winnerEl = document.querySelector(".winner");
const playerEl = document.querySelector(".player");
const refreshButton = document.querySelector("#refresh-button");
let game;
// Create a new game and render the board
function newGame() {
    game = new TicTacToe();
    playerEl.textContent = `Current player: ${game.getCurrentPlayer()}`;
    boardEl.innerHTML = "";
    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
            const cellEl = document.createElement("div");
            cellEl.classList.add("cell");
            cellEl.dataset.row = i.toString();
            cellEl.dataset.col = j.toString();
            cellEl.addEventListener("click", handleClick);
            boardEl.appendChild(cellEl);
        }
    }
    updateBoard();
}
// Handle a click on a cell
function handleClick(event) {
<<<<<<< HEAD
    const row = parseInt(event.target.dataset.row);
    const col = parseInt(event.target.dataset.col);
    const winner = game.play({ row, col });
    if (winner) {
=======
    var row = parseInt(event.target.dataset.row);
    var col = parseInt(event.target.dataset.col);
    var winner = game.play({ row: row, col: col });
    var test = document.querySelector(".reset") || null;
    console.log(winner);
    if (winner && winner !== "tie") {
>>>>>>> 4d4b4e47cf41cb8d0d53616a6a2451831ffee762
        // Display the winner
        winnerEl.textContent = `Winner: ${winner}`;
        playerEl.textContent = "";
        test.classList.toggle("hidden");
        console.log(test.classList.contains("hidden"));
    }
    else if (winner === "tie") {
        // Display the winner
        winnerEl.textContent = "It's a tie!";
        playerEl.textContent = "";
        test.classList.toggle("hidden");
    }
    else {
        // Display the current player
<<<<<<< HEAD
        playerEl.textContent = `Current player: ${game.getCurrentPlayer()}`;
=======
        console.log(winner);
>>>>>>> 4d4b4e47cf41cb8d0d53616a6a2451831ffee762
    }
    // Update the board
    updateBoard();
}
// Update the board
function updateBoard() {
    const cells = boardEl.querySelectorAll(".cell");
    cells.forEach((cell) => {
        var _a, _b;
        const row = parseInt((_a = cell.dataset.row) !== null && _a !== void 0 ? _a : "");
        const col = parseInt((_b = cell.dataset.col) !== null && _b !== void 0 ? _b : "");
        const player = game.getPlayerAt(row, col);
        if (player) {
            cell.textContent = player;
        }
        else {
            cell.textContent = "";
        }
    });
}
<<<<<<< HEAD
// Start a new game when the page loads
newGame();
// Add a click event listener to the Refresh button
refreshButton.addEventListener("click", handleRefresh);
function handleRefresh() {
    game = new TicTacToe();
    playerEl.textContent = `Current player: ${game.getCurrentPlayer()}`;
    winnerEl.textContent = "";
    updateBoard();
=======
function reset() {
    game.reset();
    updateBoard();
    var test = document.querySelector(".reset") || null;
    test.classList.toggle("hidden");
    winnerEl.textContent = "";
    playerEl.textContent = "Current player: ".concat(game.getCurrentPlayer());
>>>>>>> 4d4b4e47cf41cb8d0d53616a6a2451831ffee762
}

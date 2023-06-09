"use strict";
var Player;
(function (Player) {
    Player["X"] = "X";
    Player["O"] = "O";
    Player["Empty"] = "";
})(Player || (Player = {}));
class TicTacToe {
    constructor() {
        this.currentPlayer = Player.X;
        this.board = [
            [Player.Empty, Player.Empty, Player.Empty],
            [Player.Empty, Player.Empty, Player.Empty],
            [Player.Empty, Player.Empty, Player.Empty],
        ];
    }
    //ogni singola giocata
    play(coordinate) {
        const { row, col } = coordinate;
        if (this.board[row][col] !== Player.Empty) {
            return null; // torna null se la cella è già occupata
        }
        this.board[row][col] = this.currentPlayer;
        const winner = this.checkWinner();
        if (winner === "tie") {
            return winner; //placeholder per il pareggio
        }
        if (winner) {
            return winner; // Return the winner if there is one
        }
        this.currentPlayer = this.currentPlayer === Player.X ? Player.O : Player.X;
        return null;
    }
    checkWinner() {
        // Check rows
        for (let i = 0; i < 3; i++) {
            if (this.board[i][0] !== Player.Empty && this.board[i][0] === this.board[i][1] && this.board[i][0] === this.board[i][2]) {
                return this.board[i][0];
            }
        }
        // Check columns
        for (let i = 0; i < 3; i++) {
            if (this.board[0][i] !== Player.Empty && this.board[0][i] === this.board[1][i] && this.board[0][i] === this.board[2][i]) {
                return this.board[0][i];
            }
        }
        // Check diagonals
        if (this.board[0][0] !== Player.Empty && this.board[0][0] === this.board[1][1] && this.board[0][0] === this.board[2][2]) {
            return this.board[0][0];
        }
        if (this.board[0][2] !== Player.Empty && this.board[0][2] === this.board[1][1] && this.board[0][2] === this.board[2][0]) {
            return this.board[0][2];
        }
        // Check pareggio
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
    const row = parseInt(event.target.dataset.row);
    const col = parseInt(event.target.dataset.col);
    const winner = game.play({ row, col });
    var test = document.querySelector(".reset") || null;
    console.log(winner);
    if (winner && winner !== "tie") {
        // Display the winner
        winnerEl.textContent = "Winner: ".concat(winner);
        playerEl.textContent = "";
        test === null || test === void 0 ? void 0 : test.classList.toggle("hidden");
        console.log(test === null || test === void 0 ? void 0 : test.classList.contains("hidden"));
    }
    else if (winner === "tie") {
        // Display the winner
        winnerEl.textContent = "It's a tie!";
        playerEl.textContent = "";
        test === null || test === void 0 ? void 0 : test.classList.toggle("hidden");
    }
    else {
        // Display the current player
        playerEl.textContent = "Current player: ".concat(game.getCurrentPlayer());
        console.log(winner);
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
// Start a new game when the page loads
newGame();
// Add a click event listener to the Refresh button
refreshButton.addEventListener("click", handleRefresh);
function handleRefresh() {
    game = new TicTacToe();
    playerEl.textContent = `Current player: ${game.getCurrentPlayer()}`;
    winnerEl.textContent = "";
    updateBoard();
}


class TicTacToe {
    public currentPlayer: any;
    public board: any;
    public row: any;
    public col: any;

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
        const winner = this.checkWinner();
        if (winner === "tie") {
            return winner; // Return the winner if there is one
        }
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
        let isTie = true;
        for (let i = 0; i < 3; i++) {
            for (let j = 0; j < 3; j++) {
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
    }
    getCurrentPlayer() {
        return this.currentPlayer;
    }
    getPlayerAt(row, col) {
        return this.board[row][col];
    }
    reset() {
        this.currentPlayer = "X";
        this.board = [
            ["", "", ""],
            ["", "", ""],
            ["", "", ""],
        ];
    }
    }
// Instantiate a new TicTacToe game
const game = new TicTacToe();
// Get references to the elements in the DOM
const boardEl = document.querySelector(".board") || null;
const winnerEl = document.querySelector(".winner") || null;
const playerEl = document.querySelector(".player") || null;
playerEl.textContent = `Current player: ${game.getCurrentPlayer()}`
// Create the board
for (let i = 0; i < 3; i++) {
    for (let j = 0; j < 3; j++) {
        const cellEl = document.createElement("div");
        cellEl.classList.add("cell");
        cellEl.dataset.row = i.toString();
        cellEl.dataset.col = j.toString();
        cellEl.addEventListener("click", handleClick);
        boardEl.appendChild(cellEl) || null;
    }
}
// Handle a click on a cell
function handleClick(event) {
    const row = parseInt(event.target.dataset.row);
    const col = parseInt(event.target.dataset.col);
    const winner = game.play({ row, col });
    const test = document.querySelector(".reset") || null;
    console.log(winner)
    if (winner && winner !== "tie") {
        // Display the winner
        winnerEl.textContent = `Winner: ${winner}`;
        playerEl.textContent = "";
        test.classList.toggle("hidden");
        console.log(test.classList.contains("hidden"))

    } else if (winner === "tie") {
        // Display the winner
        winnerEl.textContent = `It's a tie!`;
        playerEl.textContent = "";
        test.classList.toggle("hidden");
    }
    else {
        // Display the current player
        console.log(winner)
    }
    // Update the board
    updateBoard();
}
// Update the board
function updateBoard() {
    const cells = boardEl.querySelectorAll(".cell") as NodeListOf<HTMLDivElement>;
    cells.forEach((cell) => {
        const row = parseInt(cell.dataset.row);
        const col = parseInt(cell.dataset.col);
        const player = game.getPlayerAt(row, col);
        if (player) {
            cell.textContent = player;
        }
        else {
            cell.textContent = "";
        }
    }
    );
}

function reset() {
    game.reset();
    updateBoard();
    const test = document.querySelector(".reset") || null;
    test.classList.toggle("hidden");
    winnerEl.textContent = "";
    playerEl.textContent = `Current player: ${game.getCurrentPlayer()}`;
}
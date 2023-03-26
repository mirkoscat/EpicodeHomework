//ringrazio @andreaguli14 per i fix dei simboli su tabella e check pareggio

// Definizione dell'enumerazione Player
enum Player { X = "X", O = "O", Empty = "" }

class TicTacToe {

  public currentPlayer: any;
  public board: any;
  public row: any;
  public col: any;

  constructor() {
    this.currentPlayer = Player.X;
    this.board = [
      [Player.Empty,Player.Empty,Player.Empty],
      [Player.Empty, Player.Empty,Player.Empty],
      [Player.Empty,Player.Empty, Player.Empty],
    ];
  }

  //ogni singola giocata
  play(coordinate: any) {
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
    //switch giocatore corrente
    this.currentPlayer = this.currentPlayer === Player.X ? Player.O : Player.X;
    
    return null;
  }
  
//a ogni click cerco un vincitore
  checkWinner():string | null | undefined {
    // Check righe
    for (let i = 0; i < 3; i++) {
      if (this.board[i][0] !== Player.Empty && this.board[i][0] === this.board[i][1] && this.board[i][0] === this.board[i][2]) {
        return this.board[i][0];
      }
    }
    // Check colonne
    for (let i = 0; i < 3; i++) {
      if (this.board[0][i] !== Player.Empty &&this.board[0][i] === this.board[1][i] &&this.board[0][i] === this.board[2][i]) {
        return this.board[0][i];
      }
    }
    // Check diagonali
    if (this.board[0][0] !== Player.Empty &&this.board[0][0] === this.board[1][1] &&this.board[0][0] === this.board[2][2]) {
      return this.board[0][0];
    }
    if (this.board[0][2] !== Player.Empty && this.board[0][2] === this.board[1][1] &&this.board[0][2] === this.board[2][0]) {
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
  
  //torna il giocatore corrente
  getCurrentPlayer():string {
    return this.currentPlayer;
  }
  
  //torna il giocatore in una certa posizione
  getPlayerAt(row: any, col: any):Player {
    return this.board[row][col];
  }
}


// Referenze elementi DOM
const boardEl = document.querySelector(".board") as HTMLDivElement;
const winnerEl = document.querySelector(".winner") as HTMLDivElement;
const playerEl = document.querySelector(".player") as HTMLDivElement;
const refreshButton = document.querySelector("#refresh-button") as HTMLButtonElement;

// Dichiaro un gioco di tipo tris
let game: TicTacToe;

// Creo una funzione che fa partire un nuovo gioco
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

// Click su una cella
function handleClick(event: any) {
  const row = parseInt(event.target.dataset.row);
  const col = parseInt(event.target.dataset.col);
  const winner = game.play({ row, col });
  var test = document.querySelector(".reset");
  console.log(winner);
  if (winner && winner !== "tie") {
    // Visualizza vincitore
    winnerEl.textContent = "Winner: ".concat(winner);
    playerEl.textContent = "";
    test?.classList.toggle("hidden");
    console.log(test?.classList.contains("hidden"));
  }
  else if (winner === "tie") {
    // Visualizza vincitore
    winnerEl.textContent = "It's a tie!";
    playerEl.textContent = Player.Empty;
    test?.classList.toggle("hidden");
  } else {
    // Visualizza current player
    playerEl.textContent = "Current player: ".concat(game.getCurrentPlayer());
    console.log(winner);
  }
  // Aggiorna la tabella
  updateBoard();
}

// Aggiorna la tabella
function updateBoard() {
  const cells = boardEl.querySelectorAll(".cell") as NodeListOf<HTMLDivElement>;
  cells.forEach((cell) => {
    const row = parseInt(cell.dataset.row ?? Player.Empty);
    const col = parseInt(cell.dataset.col ?? Player.Empty);
    //creo il giocatore in una certa posizione
    const player = game.getPlayerAt(row, col);
    if (player) {
      cell.textContent = player;
    } else {
      cell.textContent = Player.Empty;
    }
  });
}

// Parte il gioco quando la pagina carica
newGame();

// Listener bottone refresh aggiunto in un secondo momento
refreshButton.addEventListener("click", handleRefresh);

function handleRefresh() {
  game = new TicTacToe();
  playerEl.textContent = `Current player: ${game.getCurrentPlayer()}`;
  winnerEl.textContent = Player.Empty;
  updateBoard();
}

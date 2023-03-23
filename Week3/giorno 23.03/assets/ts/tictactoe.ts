// ancora da cambiare. si riesce a vincere, almeno.
enum Player {
  X = "X",
  O = "O",
  C = "C",
}

class TicTacToe {
  
  private board: Player[][] = [
    [Player.C, Player.C, Player.C],
    [Player.C, Player.C, Player.C],
    [Player.C, Player.C, Player.C],
  ];
  private currentPlayer: Player = Player.X;
  private isGameOver = false;
  private numMoves = 0;
  private winner: Player | null = null;
  private isBoardFull: boolean = false;

  private checkWinner(): Player | null {
    // Check righe
    for (let i = 0; i < 3; i++) {
      if (
        this.board[i][0] !== null &&
        this.board[i][0] === this.board[i][1] &&
        this.board[i][0] === this.board[i][2]
      ) {
        return this.board[i][0];
      }
    }

    // Check colonne
    for (let j = 0; j < 3; j++) {
      if (
        this.board[0][j] !== null &&
        this.board[0][j] === this.board[1][j] &&
        this.board[0][j] === this.board[2][j]
      ) {
        return this.board[0][j];
      }
    }

    // Check diagonale  top-left to bottom-right
    if (
      this.board[0][0] !== null &&
      this.board[0][0] === this.board[1][1] &&
      this.board[0][0] === this.board[2][2]
    ) {
      return this.board[0][0];
    }

    // Check diagonale  top-right to bottom-left
    if (
      this.board[0][2] !== null &&
      this.board[0][2] === this.board[1][1] &&
      this.board[0][2] === this.board[2][0]
    ) {
      return this.board[0][2];
    }

    
    return null;
  }


  public playMove(row: number, col: number): void {
   
    if (this.isGameOver) throw new Error("Game is over!");

    function isBoardFull(b: any[][]): boolean {
      for (let row = 0; row < b.length; row++) {
        for (let col = 0; col < b[row].length; col++) {
          if (b[row][col] === null) {
            return false;
          }
        }
      }
      return true;
    }


    // Update the board with the current player's mark
    this.board[row][col] = this.currentPlayer;

    // Check if the current player has won
    this.winner = this.checkWinner();

    // Switch to the other player
    this.currentPlayer = this.currentPlayer === Player.X ? Player.O : Player.X;

    // Check if the game is over (board is full or there is a winner)
    if (this.winner !== null || this.isBoardFull) {
      this.isGameOver = true;
    }
  }


  public getBoard(): Player[][] {
    return this.board;
  }
  public getWinner(): Player | null {
    return this.winner;
  }

  public isGameover(): boolean {
    return this.winner !== Player.X || this.numMoves < 9;
  }
}


function renderBoard(board: Player[][], container: HTMLElement): void {
  // Clear the container
  container.innerHTML = "";

  // Render each cell in the board
  for (let i = 0; i < 3; i++) {
    for (let j = 0; j < 3; j++) {
      const cell = document.createElement("div");
      cell.classList.add("cell");
      cell.textContent = board[i][j] || "";
      cell.addEventListener("click", () => {
        if (!game.isGameover()) {
          try {
            game.playMove(i, j);
            renderBoard(game.getBoard(), container);
            if (game.getWinner()) {
              alert(`${game.getWinner()} wins!`);
            } else if (game.isGameover()) {
              alert("Game over!");
            }
          } catch (error: any) {
            alert(error.message);
          }
        }
      });
      container.appendChild(cell);
    }
  }
}

// Get the container element
const container = document.getElementById("board") as HTMLElement;

// Create a new TicTacToe game
const game = new TicTacToe();

// Render the board
renderBoard(game.getBoard(), container);

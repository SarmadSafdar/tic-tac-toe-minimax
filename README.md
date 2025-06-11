# Tic Tac Toe Minimax – C# Console Application

## Author
Sarmad Safdar

## 🧠 Description
This is a C# console application that allows a human player to play Tic Tac Toe against a computer opponent. The AI uses the **minimax algorithm**, ensuring optimal gameplay. The board is rendered in the console, and the game proceeds until there's a winner or a draw.

---

## 🛠 How to Run the Program

### Prerequisites
- A C# development environment such as:
  - Visual Studio
  - Visual Studio Code (with the C# extension)
  - Any IDE that supports C#

### Steps
1. **Create a new C# project** in your IDE.
2. **Paste the source code** into your project's main `.cs` file.
3. **Build and run** the project:
   - In Visual Studio: Press `Ctrl + F5`
   - In VS Code: Use the **Run** panel or terminal

The program will execute in the console window.

---

## 🧩 Game Design Overview

- The game board is a 1D array representing 9 positions (1–9).
- Player is `X`, computer is `O`.
- The human can choose whether to go first.
- The computer uses the **minimax** algorithm to determine the best move.
- The game continues until:
  - One player wins
  - It's a draw (no spots left)

---

## 🔍 Functions & Methods

| Method           | Description |
|------------------|-------------|
| `Main`           | Entry point, manages game loop and flow |
| `InitializeBoard`| Fills the board with numbers 1–9 |
| `PrintBoard`     | Displays current board status |
| `HumanMove`      | Handles user input and validates moves |
| `ComputerMove`   | Uses minimax to choose the best move |
| `Minimax`        | Recursive AI algorithm to evaluate best possible moves |
| `CheckWin`       | Checks all winning conditions (rows, columns, diagonals) |
| `IsDraw`         | Checks for draw if no spaces remain |

---

## ▶️ Sample Game Flow

1. Program asks: _"Do you want to go first? (yes/no)"_
2. Player inputs a number between 1–9 to mark a spot.
3. Board updates after each move.
4. The game ends with either:
   - "You win!"
   - "Computer wins!"
   - "It's a draw!"

---

## 📄 License
This project was developed as part of an academic course and is shared for educational purposes.

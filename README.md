# Turkish Draughts Game

A C# Windows Forms application for playing Turkish Draughts locally or online against another player or the computer.


## Features

- Local Play: Play against another person on the same computer.
- Online Play: Connect and play with another player over the internet.
- AI Opponent: Challenge the computer and try to win agains it.
- User-Friendly Interface: Intuitive and easy-to-use graphical interface.


## Technologies Used

- Programming Language: C#
- Framework: .NET Framework
- UI: Windows Forms
- Networking: TCP/IP Sockets
- AI: Best Move algorithm using Binary Tree



<div style="display: flex; justify-content: space-between;">
<img src="https://raw.githubusercontent.com/RaduCruceat/TurkishDraughts/master/TurkishDraughts/Resources/KingMoveAnimation.gif" alt="King Move" width="400">
<img src="https://raw.githubusercontent.com/RaduCruceat/TurkishDraughts/master/TurkishDraughts/Resources/GameWinAnimation.gif" alt="Game Win" width="400">


<br>
## Game Rules

- The game is played on an 8x8 board.
- Each player starts with 8 pieces.
- Pieces move horizontally or vertically, not diagonally.
- Captures are made by jumping over an opponent's piece.
- When a man reaches the back row, it promotes to a king.
- Kings can move any number of empty squares orthogonally forwards, backwards or sideways.
- If a jump is available it must be taken. 
- If there is more than one way to jump, the one capturing the most number of pieces must be taken. 
- A king is not allowed to turn 180 degrees between two captures.


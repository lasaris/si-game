# SI-game

Project for social engineering game creation application.

## High-level components

Project will consists of three major applications for different types of actors.

### Desktop game application

- WPF application probably
- Players opens application, then writes down link for game, game is loaded and user can play.
- After the game, the user can upload the event log from the game.

### Desktop game-creation application

- WPF application probably.
- Game creator can create scenarios through form in desktop application, decision points, game branches etc. will be allowed.

### Web-api application for administration files with game scenarios

- Simple ASP.NET Core application on server with game scenarios files (json format).
- It also contains log files from played games.
- A few simple controller, database should not be needed.

## Use case diagram

![UseCase](https://github.com/sbojnak/si-game/blob/master/SI_usecase.png)

## Notes

Authentication and authorization should not be needed, creator will create a game locally (they can be also saved locally) and then he uploads it on server and server will return him a link with game for players.

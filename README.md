# SI-game

Project for social engineering game creation application.

## High-level components

Project will consists of three major applications for different types of actors.

### Desktop game application

- WPF application probably
- Players opens application, then writes down link for game, game is loaded and user can play.
- After the game, the user can upload the event log from the game.

### Web game management application

- Web-api for retrieving game scenario by game id from game application
- Game creator can create scenarios, decision points, game branches etc. will be allowed.
- Initially, scenarios will be saved as files (probably in json format)
- Filenames will have format userid-gameid.json, in the beginning no password authorization, user will authorize himself only with userid.

## Use case diagram

![UseCase](https://github.com/sbojnak/si-game/blob/master/SI_usecase.png)

## Notes

Authentication and authorization should not be needed, creator will create a game locally (they can be also saved locally) and then he uploads it on server and server will return him a link with game for players.

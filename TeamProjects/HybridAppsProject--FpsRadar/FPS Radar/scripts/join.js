(function (APP) {

    APP.models.join.connect = function connect() {
        
        window.everlive.data('Games').getById(APP.models.join.info.get("gameId"))
            .then(
                function (response) {
                    var game = response.result;
                    var playerData = {
                        role: -1,
                        team: -1,
                        color: "",
                        name: APP.models.options.game.get("userName"),
                        userId: APP.models.login.userId,
                        longitude: 0,
                        latitude: 0,
                        status: 0,
                        notMovingSince: new Date(),
                    }
                    console.log(game);

                    for (var i = 0; i < game.gameRoles.length; i++) {
                        if (game.gameRoles[i].password == APP.models.join.info.get("rolePassword")) {

                            for (var p = 0; p < game.gamePlayers.length; p++) {
                                if(game.gamePlayers[p].userId == playerData.userId){

                                    APP.models.game.refreshInterval = game.refreshInterval;
                                    APP.kendoApp.navigate("views/radar.html");
                                    APP.models.game.ingame = true;
                                    return;
                                }
                            }
                            
                            var role = game.gameRoles[i];
                            playerData.role = i;
                            playerData.team = role.team;
                            playerData.color = role.color;

                            game.gamePlayers.push(playerData);

                            debugger;
                            window.everlive.data('Games').updateSingle(game,
                                function (data) {
                                    console.log(data);
                                    APP.kendoApp.navigate("views/radar.html");
                                    APP.models.game.ingame = true;
                                },
                                function (error) {
                                    alert(error.message);
                                }
                            );
                            return;
                        }
                    }
                    alert("incorrect role password");
                },
                function (error) {
                    alert(error.message);
                });
    }
}(APP || {}));
APP.models.game.connect = function () {
    console.log("connecting");
    window.everlive.data('Games').getById(APP.models.join.info.gameId)
        .then(
            function (response) {
                function get2DDistance(p1, p2, q1, q2) {
                    return Math.sqrt((p1 - p2) * (p1 - p2) + (q1 - q2) * (q1 - q2));
                }

                var game = response.result;
                var playerIndex = -1;
                var roleIndex = -1;
                var visible = [];
                var role = {};
                var player = {};

                APP.models.game.positions = [];
                APP.models.game.positions = game.gamePlayers;
                
                for (var p = 0; p < game.gamePlayers.length; p++) {
                    game.gamePlayers[p].colour = game.gamePlayers[p].color;
                    if (game.gamePlayers[p].status == 3) {
                        continue;
                    }
                    if (game.gamePlayers[p].userId == APP.models.login.userId) {
                        playerIndex = p;
                        player = game.gamePlayers[p];
                        roleIndex = game.gamePlayers[p].role;
                        role = game.gameRoles[roleIndex];
                        game.gamePlayers[p].name = APP.models.options.game.userName;
                        game.gamePlayers[p].longitude = APP.models.game.ownPosition.longitude;
                        game.gamePlayers[p].latitude = APP.models.game.ownPosition.latitude;
                        game.gamePlayers[p].status = APP.models.game.ownPosition.status;
                        
                        window.everlive.data('Games').updateSingle(game, function (data) {}, function (error) {});

                        if (!APP.models.options.game.get("displayNames")) {
                            player.name = "";
                        }

                    } else {
                        var u = game.gamePlayers[p];

                        if (true 
                            ||
                            // team moving
                            (u.team == player.team &&
                                get2DDistance(u.longitude, u.latitude, player.longitude, player.latitude) < role.friendlyRange &&
                                role.seeTeamMoving &&
                                (new Date() - u.notMovingSince) / 1000 < 60) ||
                            // team still
                            (u.team == player.team &&
                                get2DDistance(u.longitude, u.latitude, player.longitude, player.latitude) < role.friendlyRange &&
                                role.seeTeamStill) ||
                            // enemy moving
                            (u.team != player.team &&
                                get2DDistance(u.longitude, u.latitude, player.longitude, player.latitude) < role.enemyRange &&
                                role.seeEnemyMoving &&
                                (new Date() - u.notMovingSince) / 1000 < 60) ||
                            // enemy still
                            (u.team != player.team &&
                                get2DDistance(u.longitude, u.latitude, player.longitude, player.latitude) < role.enemyRange &&
                                role.seeEnemyStill)) {

                            // if any condition is met, the player is visible
                            if (!APP.models.options.game.get("gamedisplayNames")) {
                                //u.name = "";
                            }
                            if (APP.models.options.game.get("displayEnemiesAsRed")) {
                                if (u.team == player.team) {
                                    u.color = APP.models.create.colors.green;
                                } else {
                                    u.color = APP.models.create.colors.red;
                                }
                            }
                            if (get2DDistance(u.longitude, u.latitude, player.longitude, player.latitude) < 10 &&
                                u.team != player.team) {
                                u.status = 2;
                            }

                            u.longitude = (u.longitude - player.longitude) / 500 * 150;
                            u.latitude = (u.latitude - player.latitude) / 500 * 150;

                            visible.push(u);
                        }
                    }
                }

                if (APP.models.options.get("displaySelfOnRadar")) {
                    player.color = "rgba(0,255,255,0.5)";
                    player.longitude = 0;
                    player.latitude = 0;
                    visible.push(player);
                }
                
                APP.models.game.positions = visible;
                window.everlive.data('Games').updateSingle(game, function (data) {}, function (error) {});

            },
            function (error) {
                console.log("Connect error:");
                console.log(error);
            });
}
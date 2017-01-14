(function (APP) {
    var createGameModel = APP.models.create;

    createGameModel.save = function save() {
        alert("You are attempting to save this game configuration");
    };

    createGameModel.load = function load() {
        alert("You are attempting to load a game configuration");
    };

    createGameModel.connect = function connect() {
        var game = {
            gameRoles: APP.models.create.game.gameRoles,
            gameName: APP.models.create.game.gameOptions.gameName,
            refreshInterval: APP.models.create.game.gameOptions.refreshInterval,
            showIdentity: APP.models.create.game.gameOptions.showIdentity,
            notifyOnDanger: APP.models.create.game.gameOptions.notifyOnDanger,
            allowSignals: APP.models.create.game.gameOptions.allowSignals,
            teamOnlySignals: APP.models.create.game.gameOptions.teamOnlySignals,
            timeLimit: APP.models.create.game.gameOptions.timeLimit,
            end: APP.models.create.game.gameOptions.end
        };

        if (0 > game.timeLimit || game.timeLimit >= 24) {
            alert("The time limit must b in range 1-24");
            return;
        }

        game.end = new Date();
        game.end.setHours(game.end.getHours() + game.timeLimit);
        
        window.APP.ajax.send("/api/games", "POST", APP.ajax.getHeaders(), game,
            function (response) {
                window.APP.kendoApp.navigate("views/create-passwords.html");
            },
            function (error) {
                alert("Error creating game : " + JSON.stringify(error));
            }
        );
    };

    createGameModel.visions = {
        teamMoving: 0,
        teamStill: 1,
        enemyMoving: 2,
        enemyStill: 3,

        all: 4,

        getString: function (num) {
            if (num == undefined) {
                return "None";
            }
            switch (num) {
            case 0:
                return "MT";
            case 1:
                return "ST";
            case 2:
                return "ME";
            case 3:
                return "SE";
            default:
            }
        }
    }

    createGameModel.colors = {
        red: "rgb(255,0,0)",
        green: "rgb(0,255,0)",
        blue: "rgb(0,0,255)",
        aqua: "rgb(0,255,255)",
        magenda: "rgb(255,0,255)",
        yellow: "rgb(255,0,255)",

        getString: function (color) {
            var self = this;
            for (var i in self) {
                if (self[i] == color) {
                    return i;
                }
            }
            return "unknown";
        }
    }

    createGameModel.makeGameRole = function makeGameRole(name, team, color, friendlyRange, enemyRange,
        seeTeamMoving, seeTeamStill, seeEnemyMoving, seeEnemyStill,
        password) {
        if (typeof name != "string" || name.length == 0) {
            throw {
                message: "the role name is not valid"
            }
        }
        if (typeof color != "string" || color.length == 0) {
            throw {
                message: "the role color is not valid"
            }
        }
        if (typeof password != "string" || password.length == 0) {
            throw {
                message: "the role password is not valid"
            }
        }
        if (typeof team != "number" || team < 0 || team > 6) {
            throw {
                message: "the role team is not valid"
            }
        }
        if (typeof friendlyRange != "number" || friendlyRange < 0 || friendlyRange > 500) {
            throw {
                message: "the role friendlyRange is not valid"
            }
        }
        if (typeof enemyRange != "number" || enemyRange < 0 || enemyRange > 500) {
            throw {
                message: "the role enemyRange is not valid"
            }
        }
        if (typeof seeTeamMoving != "boolean") {
            throw {
                message: "the role seeTeamMoving is not valid"
            }
        }
        if (typeof seeTeamStill != "boolean") {
            throw new {
                message: "the role seeTeamStill is not valid"
            }
        }
        if (typeof seeEnemyMoving != "boolean") {
            throw {
                message: "the role seeEnemyMoving is not valid"
            }
        }
        if (typeof seeEnemyStill != "boolean") {
            throw {
                message: "the role seeEnemyStill is not valid"
            }
        }

        var role = {
            name: name,
            password: password,
            team: team,
            color: color,
            friendlyRange: friendlyRange,
            enemyRange: enemyRange,
            vision: [],
            info: function () {
                var result = [];

                result.push("Team [" + this.team + "], Color [" + APP.models.create.colors.getString(this.color) + "]");
                result.push("Team [" + this.friendlyRange + "m] Enemy [" + this.enemyRange + "m]");
                if (this.vision.length == APP.models.create.visions.all) {
                    result.push("Sees : [All]");
                } else {
                    var vision = "Sees : ";
                    for (var i = 0; i < this.vision.length; i++) {
                        vision += "[" + APP.models.create.visions.getString(this.vision[i]) + "] ";
                    }
                    result.push(vision);
                }
                return result.join(";<br/>")
            }
        }
        if (seeTeamMoving) {
            role.vision.push(APP.models.create.visions.teamMoving);
        }
        if (seeTeamStill) {
            role.vision.push(APP.models.create.visions.teamStill);
        }
        if (seeEnemyMoving) {
            role.vision.push(APP.models.create.visions.enemyMoving);
        }
        if (seeEnemyStill) {
            role.vision.push(APP.models.create.visions.enemyStill);
        }

        return role;
    }

    createGameModel.game.set("gameRoles", [
        createGameModel.makeGameRole("Team 1", 1, createGameModel.colors.blue, 500, 300, true, true, true, false, "team1isthebest"),
        createGameModel.makeGameRole("Team 2", 2, createGameModel.colors.red, 500, 300, true, true, true, false, "team2isthebest")
    ]);

    createGameModel.selectRole = function selectRole(index) {
        var role = APP.models.create.game.gameRoles[index];
        if (role === undefined) {
            throw {
                message: "role index is out of range"
            };
        }

        APP.models.create.currentRole.set("index", index);
        APP.models.create.currentRole.set("name", role.name);
        APP.models.create.currentRole.set("team", role.team);
        APP.models.create.currentRole.set("color", role.color);
        APP.models.create.currentRole.set("friendlyRange", role.friendlyRange);
        APP.models.create.currentRole.set("enemyRange", role.enemyRange);
        APP.models.create.currentRole.set("seeTeamMoving", role.vision.indexOf(APP.models.create.visions.teamMoving) !== -1);
        APP.models.create.currentRole.set("seeTeamStill", role.vision.indexOf(APP.models.create.visions.teamStill) !== -1);
        APP.models.create.currentRole.set("seeEnemyMoving", role.vision.indexOf(APP.models.create.visions.enemyMoving) !== -1);
        APP.models.create.currentRole.set("seeEnemyStill", role.vision.indexOf(APP.models.create.visions.enemyStill) !== -1);
        APP.models.create.currentRole.set("password", role.password);
    };

    createGameModel.addRole = function addRole() {
        var roleModel = APP.models.create.currentRole;
        APP.models.create.game.gameRoles.push(
            APP.models.create.makeGameRole(
                roleModel.name,
                roleModel.team,
                roleModel.color,
                roleModel.friendlyRange,
                roleModel.enemyRange,
                roleModel.seeTeamMoving,
                roleModel.seeTeamStill,
                roleModel.seeEnemyMoving,
                roleModel.seeEnemyStill,
                roleModel.password
            )
        );
        window.APP.kendoApp.navigate("views/create.html");
    };

    createGameModel.updateRole = function updateRole() {
        var roleModel = APP.models.create.currentRole;
        APP.models.create.game.set(
            "gameRoles[" + APP.models.create.currentRole.index + "]",
            APP.models.create.makeGameRole(
                roleModel.name,
                roleModel.team,
                roleModel.color,
                roleModel.friendlyRange,
                roleModel.enemyRange,
                roleModel.seeTeamMoving,
                roleModel.seeTeamStill,
                roleModel.seeEnemyMoving,
                roleModel.seeEnemyStill,
                roleModel.password
            )
        );

        window.APP.kendoApp.navigate("views/create.html");
    };

    createGameModel.deleteRole = function deleteRole() {
        APP.models.create.game.get("gameRoles").splice(APP.models.create.currentRole.get("index"), 1);
        window.APP.kendoApp.navigate("views/create.html");
    };

}(APP || {}));
(function (APP) {
    var createGameModel = APP.models.create;

    createGameModel.save = function save() {
        alert("You are attempting to save this game configuration");
    };

    createGameModel.load = function load() {
        alert("You are attempting to load a game configuration");
    };

    createGameModel.connect = function connect() {
        var game = APP.models.create.game.gameOptions;
        if (0 > game.timeLimit || game.timeLimit > 24) {
            alert("The time limit must b in range 1-24");
            return;
        }
        if (APP.models.create.game.gameName.length == 0) {
            alert("Your game doesn't have a name.");
            return;
        }
        if (APP.models.create.game.gameRoles.length == 0) {
            alert("Your game doesn't have any roles.");
            return;
        }
        /*
        var roles = APP.models.create.game.gameRoles;
        for(var i = 0;i< roles.length;i++){
            if(roles[i].name.length){
                alert("Role number " +(i+1)+ " doesn't a name.");
                return;
            }
            if(roles[i].password.length){
                alert("Role number " +(i+1)+ " doesn't a password.");
                return;
            }
        }*/

        game.end = new Date();
        game.end.setHours(game.end.getHours() + game.timeLimit);
        game.gameRoles = APP.models.create.game.gameRoles;
        
        game.gamePlayers = [];

        var data = window.everlive.data('Games');
        data.create(game,
            function (data) {
                var id = data.result.Id;
                APP.models.create.gameId = id;
                APP.kendoApp.navigate("views/create-passwords.html");
            },
            function (error) {
                alert("An error occured during the creation of the game: " + error.message);
                return;
            });
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

                result.push("Team [" + this.team + "], Color [" + createGameModel.colors.getString(this.color) + "]");
                result.push("Team [" + this.friendlyRange + "m] Enemy [" + this.enemyRange + "m]");
                if (this.vision.length == createGameModel.visions.all) {
                    result.push("Sees : [All]");
                } else {
                    var vision = "Sees : ";
                    for (var i = 0; i < this.vision.length; i++) {
                        vision += "[" + createGameModel.visions.getString(this.vision[i]) + "] ";
                    }
                    result.push(vision);
                }
                return result.join(";<br/>")
            }
        }
        if (seeTeamMoving) {
            role.vision.push(createGameModel.visions.teamMoving);
        }
        if (seeTeamStill) {
            role.vision.push(createGameModel.visions.teamStill);
        }
        if (seeEnemyMoving) {
            role.vision.push(createGameModel.visions.enemyMoving);
        }
        if (seeEnemyStill) {
            role.vision.push(createGameModel.visions.enemyStill);
        }

        return role;
    }

    createGameModel.game.set("gameRoles", [
createGameModel.makeGameRole("Team 1", 1, createGameModel.colors.blue, 500, 300, true, true, true, false, "team1isthebest"),
createGameModel.makeGameRole("Team 2", 2, createGameModel.colors.red, 500, 300, true, true, true, false, "team2isthebest")
]);

    createGameModel.selectRole = function selectRole(index) {
        var role = createGameModel.game.gameRoles[index];
        if (role === undefined) {
            throw {
                message: "role index is out of range"
            };
        }

        createGameModel.currentRole.set("index", index);
        createGameModel.currentRole.set("name", role.name);
        createGameModel.currentRole.set("team", role.team);
        createGameModel.currentRole.set("color", role.color);
        createGameModel.currentRole.set("friendlyRange", role.friendlyRange);
        createGameModel.currentRole.set("enemyRange", role.enemyRange);
        createGameModel.currentRole.set("seeTeamMoving", role.vision.indexOf(createGameModel.visions.teamMoving) !== -1);
        createGameModel.currentRole.set("seeTeamStill", role.vision.indexOf(createGameModel.visions.teamStill) !== -1);
        createGameModel.currentRole.set("seeEnemyMoving", role.vision.indexOf(createGameModel.visions.enemyMoving) !== -1);
        createGameModel.currentRole.set("seeEnemyStill", role.vision.indexOf(createGameModel.visions.enemyStill) !== -1);
        createGameModel.currentRole.set("password", role.password);
    };

    createGameModel.addRole = function addRole() {
        var roleModel = createGameModel.currentRole;
        createGameModel.game.gameRoles.push(
            createGameModel.makeGameRole(
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
        var roleModel = createGameModel.currentRole;
        createGameModel.game.set(
            "gameRoles[" + createGameModel.currentRole.index + "]",
            createGameModel.makeGameRole(
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
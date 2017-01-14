(function (APP) {
    var optionsModel = APP.models.options;

    optionsModel.setAvatar = function setAvatar() {
        alert("You are attempting to change your avatar");
    };

    optionsModel.save = function save() {
        debugger;
        window.everlive.Users.updateSingle({
                Id: window.APP.models.login.userId,

                userName: window.APP.models.options.game.userName,
                userAvatar: window.APP.models.options.game.userAvatar,
                displayNames: window.APP.models.options.game.displayNames,
                displayEnemiesAsRed: window.APP.models.options.game.displayEnemiesAsRed,
                vibrateOnDanger: window.APP.models.options.game.vibrateOnDanger,
                vibrateOnSignal: window.APP.models.options.game.vibrateOnSignal,
                playSoundOnDanger: window.APP.models.options.game.playSoundOnDanger,
                playSoundOnSignal: window.APP.models.options.game.playSoundOnSignal,
                displaySelfOnRadar: window.APP.models.options.game.displaySelfOnRadar,
                showTimeLeft: window.APP.models.options.game.showTimeLeft
            },
            function (data) {
                window.APP.kendoApp.navigate("views/blank.html");
            },
            function (error) {
                alert(error.message);
            });
    };

    optionsModel.load = function load() {
        debugger;
        window.everlive.Users.getById(window.APP.models.login.userId)
            .then(function (data) {
                    window.APP.models.options.game.set("userName", data.result.userName);
                    window.APP.models.options.game.set("userAvatar", data.result.userAvatar);
                    window.APP.models.options.game.set("displayNames", data.result.displayNames);
                    window.APP.models.options.game.set("displayEnemiesAsRed", data.result.displayEnemiesAsRed);
                    window.APP.models.options.game.set("vibrateOnDanger", data.result.vibrateOnDanger);
                    window.APP.models.options.game.set("vibrateOnSignal", data.result.vibrateOnSignal);
                    window.APP.models.options.game.set("playSoundOnDanger", data.result.playSoundOnDanger);
                    window.APP.models.options.game.set("playSoundOnSignal", data.result.playSoundOnSignal);
                    window.APP.models.options.game.set("displaySelfOnRadar", data.result.displaySelfOnRadar);
                    window.APP.models.options.game.set("showTimeLeft", data.result.showTimeLeft);
                },
                function (error) {
                    alert("An error occured while the program was loading your settings. Please restart the program.")
                    console.log(error);
                });
    };

}(APP || {}));
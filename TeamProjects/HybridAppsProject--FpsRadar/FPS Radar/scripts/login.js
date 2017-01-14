(function (APP) {
    var loginModel = APP.models.login;

    loginModel.connect = function () {
        window.everlive.Users.login(
            loginModel.info.email,
            loginModel.info.password
        )
            .then(function (data) { // success callback
                    console.dir(data);
                    window.APP.kendoApp.navigate("views/blank.html");
                    APP.models.login.userId = data.result.principal_id;
                    APP.models.login.token = data.result.access_token;
                    APP.models.options.load();
                    APP.models.login.save();
                },
                function (error) { // error callback
                    alert(error.message)
                    console.dir(error);
                });
    }
    loginModel.register = function () {
        window.everlive.Users.register(
            loginModel.info.email,
            loginModel.info.password, {
                Email: loginModel.info.email,
                userName: "NewPlayer",
                userAvatar: "http://static-resource.np.community.playstation.net/avatar/3RD/UP10241302063_94646ECAB3510E2CE66E_L.png",
                displayNames: true,
                displayEnemiesAsRed: true,
                vibrateOnDanger: true,
                vibrateOnSignal: true,
                playSoundOnDanger: false,
                playSoundOnSignal: false,
                displaySelfOnRadar: true,
                showTimeLeft: true
            },
            function (data) {
                console.dir(data);
                APP.models.login.save();
                window.APP.kendoApp.navigate("views/blank.html");
                APP.models.login.userId = data.result.principal_id;
                APP.models.login.token = data.result.access_token;
                APP.models.options.load();
                APP.models.login.save();
            },
            function (error) {
                alert(error.message)
                console.dir(error);
            });
    }

    loginModel.save = function save() {

    };

    loginModel.load = function load() {

    };

}(APP || {}));
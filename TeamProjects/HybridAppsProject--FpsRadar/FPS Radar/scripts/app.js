window.APP = window.APP || {};

(function () {
    // create an object to store the models for each view
    window.APP = {
        models: {
            login: {
                userName: "",
                token: "",
                info: new kendo.data.ObservableObject({
                    email: "lokikko@mail.bg",
                    password: "123456"
                }),
                save: function save() {
                    //alert("You are attempting to save your login data");
                },
                load: function load() {
                    //alert("You are attempting to load your login data");
                },
                connect: function connect() {
                    alert("You are attempting to login to your user profile");
                    window.APP.kendoApp.navigate("views/blank.html");
                },
                register: function register() {
                    alert("You are attempting to register a new user profile");
                }
            },
            create: {
                title: 'Create Game',
                currentRole: new kendo.data.ObservableObject({
                    name: "New Role Name",
                    team: 1,
                    color: "rgb(255,0,255)",
                    friendlyRange: 500,
                    enemyRange: 300,
                    seeTeamMoving: true,
                    seeTeamStill: true,
                    seeEnemyMoving: true,
                    seeEnemyStill: false,
                    password: "secret"
                }),
                game: new kendo.data.ObservableObject({
                    gameName: "New Game",
                    gameRoles: [],
                    gameOptions: {
                        refreshInterval: 5,
                        showIdentity: true,
                        notifyOnDanger: true,
                        allowSignals: true,
                        teamOnlySignals: false,
                        timeLimit: 4,
                        end: new Date()
                    }
                }),
                save: function save() {
                    alert("You are attempting to save your this game configuration");
                },
                load: function load() {
                    alert("You are attempting to load a game configuration");
                },
                connect: function connect() {
                    alert("You are attempting to create a game with this game configuration");
                },
                addRole: function addRole() {
                    alert("You are attempting to add a role to this game");
                },
                goToAddRole: function goToAddRole() {
                    window.APP.kendoApp.navigate("views/create-role.html");
                },
                goToOptions: function goToOptions() {
                    if (window.APP.models.create.game.gameRoles.length != 0) {
                        window.APP.kendoApp.navigate("views/create-options.html");
                    } else {
                        alert("You must add at least one role");
                    }
                },
            },
            options: {
                title: 'Options',
                game: new kendo.data.ObservableObject({
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
                }),
                setAvatar: function setAvatar() {
                    alert("You are attempting to change your avatar");
                },
                save: function save() {
                    alert("You are attempting to save your settings");
                },
                load: function load() {
                    alert("You are attempting to load your settings");
                }
            },
            join: {
                title: 'Join Game',
                info: new kendo.data.ObservableObject({
                    gameId: "7b4feb00-480c-11e4-9b81-99b6eff624e9",
                    rolePassword: "team1isthebest"
                }),
                connect: function connect() {
                    alert(
                        "You are attempting to join the game [" +
                        APP.models.join.info.get("gameName") +
                        "] with password [" + APP.models.join.info.get("rolePassword") +
                        "]");

                    APP.kendoApp.navigate("views/radar.html");
                    APP.models.game.ingame = true;
                    //APP.models.game.start();
                    console.log(APP.models.game.ingame);
                }
            },

            camera: {
                avatar: {},
                capture: function capture() {
                    console.log("you'reattempting to show a player");
                }
            },
            radar: {
                title: 'Radar',
                radar: {},
                d: 1,
                t: 0,
                s: {},
                cntrX: 150,
                cntrY: 150,
                circle: {},
                midCircle: {},
                inCircle: {},
                hLine: {},
                globalDiv: {},
                vLine: {},
                showPlayer: function showPlayer() {
                    console.log("you'reattempting to show a player");
                },
                rotate: function rotate() {
                    console.log("you'reattempting to show a player");
                },
                clear: function clear() {
                    console.log("you're attempting to pause the radar")
                },
                pauseRadar: function pauseRadar() {
                    console.log("you're attempting to pause the radar")
                },
                refreshRadar: function refreshRadar() {
                    console.log("you're attempting to refresh the radar")
                },
                stop: function stop() {
                    console.log("you're attempting to stop")
                },
                run: function run() {
                    console.log('run radar');
                }
            },
            game: {
                title: 'FPS Radar',
                refreshInterval: 5,
                ownPosition: {},
                positions: [],
                compas: {},
                heading: {},
                timeout: 0,
                ingame: false,
                start: function start() {
                    console.log("you're trying to start a game");
                },
                onDeviceReady: function onDeviceReady() {
                    console.log("you're trying to start a game");
                },
                connect: function () {
                    console.log("connecting to server");
                },
                refresh: function () {
                    console.log("refreshing the radar");
                },
                exit: function exit() {
                    console.log("you're trying to leave the game");
                },
                getCompas: function getCompas() {
                    console.log("getting the compas");
                },
                getPositions: function getPositions() {
                    console.log("getting the positions");
                },
                getOwnPositions: function getOwnPositions() {
                    console.log("getting own position");
                },
                pause: function pause() {
                    console.log("paused");
                },
                warnForDanger: function warnForDanger() {
                    console.log("warnForDanger");
                },
                warnForSignal: function warnForSignal() {
                    console.log("warnForSignal");
                },
                signal: function signal() {
                    // console.log("signal");
                }
            },
        }
    }

    // this function is called by Cordova when the application is loaded by the device
    document.addEventListener('deviceready', function () {
        // hide the splash screen as soon as the app is ready. otherwise
        // Cordova will wait 5 very long seconds to do it for you.
        navigator.splashscreen.hide();
    }, false);


    window.APP.kendoApp = new kendo.mobile.Application(document.body, {

        // you can change the default transition (slide, zoom or fade)
        transition: 'slide',

        // comment out the following line to get a UI which matches the look
        // and feel of the operating system
        skin: 'flat',

        // the application needs to know which view to load first
        initial: 'views/login.html'
    });

    window.everlive = new Everlive({
        apiKey: "YIkUYpepYhVpvtzE",
        scheme: "http"
    });


    APP.ajax = {
        getHeaders: function getHeaders() {
            var result = {
                "Content-Type": "application/json",
                Accept: "application/json",
                //Authorization: "Bearer  " + APP.models.login.token
            }
            return result;
        },
        send: function (url, type, headers, item, success, error) {
            var baseUri = "http://radardb.apphb.com";

            jQuery.support.cors = true;
            return $.ajax({
                type: type,
                url: baseUri + url,
                data: item || "",
                headers: headers || {},
                success: success,
                error: error
            });
        }
    }
    APP.models.login.load();

    document.addEventListener("pause", function () {
        if (APP.models.game.inGame && !APP.models.game.paused) {
            APP.models.game.pause();
        }
    }, false);

    document.addEventListener("resume", function () {
        if (APP.models.game.inGame && APP.models.game.paused) {
            APP.models.game.pause();
        }
    }, false);
    
    document.addEventListener("offline", function(){ alert("You are not connected to the internet."); }, false);

}());
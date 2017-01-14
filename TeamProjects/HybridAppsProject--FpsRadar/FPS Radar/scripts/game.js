(function (APP) {
    var gameModel = APP.models.game;

    gameModel.ownPosition = {
        longitude: 0,
        latitude: 0,
        playerId: 0,
        playerTeam: 0,
        status: 0
    };

    gameModel.positions = [
        {
            longitude: 2,
            latitude: 2,
            name: "gosho",
            team: 1,
            colour: "#3f9ddc",
            status: 0
         },
        {
            longitude: 0,
            latitude: 0,
            name: "pesho",
            team: 2,
            colour: "#ff00e1",
            status: 1
         }, {
            longitude: 9,
            latitude: 150,
            name: "shosho",
            team: 1,
            colour: "#3f9ddc",
            status: 0
         }, {
            longitude: 3,
            latitude: 11,
            name: "gosho",
            team: 2,
            colour: "#ff00e1",
            status: 0
         }
     ];

    gameModel.exit = function exit() {

        APP.models.radar.clear();
        APP.kendoApp.navigate("views/blank.html");
        gameModel.ingame = false;
        console.log("you're trying to leave the game");
    };

    gameModel.start = function start() {
        document.addEventListener("deviceready",  gameModel.onDeviceReady, false);    
        gameModel.ingame = true;
        gameModel.paused = false;
        APP.models.radar.run();
        APP.models.game.refresh();
        console.log("you're trying to start a game");
    };

    gameModel.onDeviceReady = function () {
        
        gameModel.getCompas();
        /*app.watchID = navigator.compass.watchHeading(
            app.compassUpdate,
            app.compassError, {
                frequency: 3000
            });*/
    };
    
    
    gameModel.refresh = function (){
        if(!APP.models.game.paused){
            APP.models.game.getOwnPositions();
            APP.models.game.connect();
            APP.models.radar.clear();
            APP.models.radar.showPlayer();
        }
        if(APP.models.game.ingame){
            console.log("refreshing")
            setTimeout(APP.models.game.refresh, APP.models.game.refreshInterval * 1000)
        }
    };
    
    gameModel.pause = function pause() {
        
        if (!gameModel.paused) {
            APP.models.game.ownPosition.status = 3;
            APP.models.game.connect();
            APP.models.radar.clear();
            // APP.models.radar.pauseRadar();
            gameModel.paused = true;
        } else {
            APP.models.radar.showPlayer();
            // APP.models.radar.startRadar();
            gameModel.paused = false;
        }

        console.log("paused");
    };

    gameModel.pause = function pause() {
        if (!APP.models.game.paused) {
            APP.models.radar.clear();
            APP.models.game.ingame = false;
            // APP.models.radar.pauseRadar();
            APP.models.game.paused = true;
        } else {
            APP.models.radar.showPlayer();
            APP.models.game.ingame = true;
            document.addEventListener("deviceready",  APP.models.game.onDeviceReady, false); 
            // APP.models.radar.startRadar();
            APP.models.game.paused = false;
        }

        console.log("paused");
    },

    gameModel.getOwnPositions = function getOwnPositions() {
        if (navigator.geolocation && APP.models.game.ingame) {
            navigator.geolocation.getCurrentPosition(
                //SUCCESS
                function (position) {
                    //gameModel.heading=position.coords.heading;
                    APP.models.game.ownPosition.latitude = position.coords.latitude * 110540;
                    APP.models.game.ownPosition.longitude = position.coords.longitude * 111320;
                    //gameModel.ownPosition.longitude = position.coords.longitude * (111320 * Math.cos(position.coords.latitude));
                    //alert(gameModel.heading);
                    console.log('Success Sent Coordinates: ' + APP.models.game.ownPosition.latitude + " " + APP.models.game.ownPosition.longitude);
                },
                //FAIL
                function (err) {
                    alert('Compass error: ' + err.code);
                }
            );
        }

    };

    gameModel.warnForDanger = function warnForDanger() {
        navigator.notification.vibrate(3000);
        console.log('danger');
    };

    gameModel.warnForSignal = function warnForSignal() {
        navigator.notification.vibrate(1000);
        console.log('signal');
    };

    function generateDiv(radius, x, y) {
        var resultDiv = document.getElementById('holder');
        var div = document.createElement("div");
        div.style.width = radius * 2 + "px";
        div.style.height = radius * 2 + "px";
        div.style.borderRadius = "200px";
        div.style.border = "none";
        div.style.position = "absolute";
        div.style.top = y + "px";
        div.style.left = y + "px";
        div.style.background = "#ff0000";
        APP.models.radar.globalDiv.appendChild(div);
    }

    gameModel.getCompas = function getCompas() {
      
 navigator.compass.getCurrentHeading(
                function (heading) {
                    APP.models.game.heading = heading.magneticHeading;
                    APP.models.radar.rotate();
                },
                function (err) {

                }
            );
       
        gameModel.timeout = setTimeout(function () {
            if (gameModel.ingame) {
                APP.models.game.getCompas()
            }
        }, 3000);

    };

    gameModel.signal = function signal() {

        gameModel.ownPosition.status = 1;
        gameModel.getOwnPositions();
        //gameModel.getCompas();
        gameModel.ownPosition.status = 0;
        console.log("signal");
    };

    gameModel.exit = function exit() {
        APP.models.radar.stop();
        console.log("you're trying to leave the game");
    };

}(APP || {}));
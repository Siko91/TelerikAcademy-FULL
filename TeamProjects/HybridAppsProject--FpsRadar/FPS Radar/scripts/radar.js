(function (APP) {
    var radarModel = APP.models.radar;

    radarModel.pauseRadar = function pauseRadar() {
        //clearTimeout(radarModel.t);
    },

    radarModel.stop = function stop() {
        /* clearTimeout(radarModel.t);*/
        
        APP.kendoApp.navigate("views/blank.html");
    };

    radarModel.show = function show() {
        radarModel.startRadar();
    };
    
    radarModel.clear =function clear() {
      radarModel.globalDiv.style.transform="rotate(0deg)";
        while (radarModel.globalDiv.firstChild) {
            
    radarModel.globalDiv.removeChild(radarModel.globalDiv.firstChild);
}
    };
    
    radarModel.rotate= function rotate() {
                    APP.models.game.heading;
                    radarModel.globalDiv.style.transform="rotate(" + APP.models.game.heading+ "deg)";
                    console.log("you'reattempting to show a player");
                };
                    
    radarModel.showPlayer= function showPlayer() {
 
        for (var position in APP.models.game.positions) {
            var colour=APP.models.game.positions[position].colour;
           
           if(APP.models.game.positions[position].status===1&&APP.models.options.game.get("vibrateOnSignal"))
            {
                APP.models.game.warnForSignal()
                colour='#ffffff';
            }
            else if(APP.models.game.positions[position].status===2&&APP.models.options.game.get("vibrateOnDanger"))
            {
                APP.models.game.warnForDanger()
            }
            generateDiv(5,
                        (radarModel.globalDiv.clientHeight/2+APP.models.game.positions[position].longitude),
                        (radarModel.globalDiv.clientWidth/2+APP.models.game.positions[position].latitude),
                       colour);  
            generateText((radarModel.globalDiv.clientHeight/2+APP.models.game.positions[position].longitude),
                        (radarModel.globalDiv.clientWidth/2+APP.models.game.positions[position].latitude),
                        colour,
                        APP.models.game.positions[position].name
                        );
        }
                    
       }

    function generateDiv(radius, x, y,color) {
        var div = document.createElement("div");
        div.style.width = radius * 2 + "px";
        div.style.height = radius * 2 + "px";
        div.style.borderRadius = "200px";
        div.style.border = "none";
        div.style.position = "absolute";
        div.style.bottom = (x-radius) + "px";
        div.style.left = (y-radius) + "px";
        div.style.background =color;
        radarModel.globalDiv.appendChild(div);
    }
    
      function generateText( x, y,color,name) {
       var div = document.createElement("div");
          
        div.style.position = "absolute";
        div.style.bottom = x +"px";
        div.style.left = y + "px";
        div.style.color =color;
          div.innerHTML = name;
        radarModel.globalDiv.appendChild(div);
    }



    radarModel.run = function run() {
        debugger;
       radarModel.globalDiv = document.getElementById('holder');
        radarModel.showPlayer();
        
       
        console.log('radar attempting to start');
    };
}(APP || {}));
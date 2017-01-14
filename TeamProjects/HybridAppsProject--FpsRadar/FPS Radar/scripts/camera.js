(function (APP) {
    var cameraModel = APP.models.camera;
    cameraModel.capture = function capture() {

        navigator.camera.getPicture(function onSuccess(imageURI) {
            //var image = document.getElementById('myImage');
            APP.models.options.game.set("userAvatar",imageURI )
            
        }, function (err) {

        }, {
            quality: 50,
            destinationType: Camera.DestinationType.FILE_URI
        });

        console.log("you'reattempting to show a player");
    }
    
     APP.models.options.setAvatar= function setAvatar() {
         APP.models.camera.capture();
        
                }

}(APP || {}));
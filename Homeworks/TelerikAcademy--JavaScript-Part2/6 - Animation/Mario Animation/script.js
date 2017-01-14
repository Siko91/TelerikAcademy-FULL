
      var stage = new Kinetic.Stage({
        container: 'container',
        width: 578,
        height: 200
      });
      var layer = new Kinetic.Layer();

      var imageObj = new Image();
      imageObj.onload = function() {
        var mario = new Kinetic.Sprite({
          x: 250,
          y: 40,
          image: imageObj,
          animation: 'idle',
          animations: {
            idle: [
              // x, y, width, height (4 frames)
              2,2,70,119,
              75,2,74,119,
              150,2,81,119,
              230,2,76,119,
              324,2,76,119
            ],
            punch: [
              // x, y, width, height (5 frames)
              70,155,110,130,
              165,155,110,130,
              310,155,110,130,
              420,155,110,130,
              560,155,110,130
            ]
          },
          frameRate: 7,
          frameIndex: 0
        });

        // add the shape to the layer
        layer.add(mario);

        // add the layer to the stage
        stage.add(layer);

        // start sprite animation
        mario.start();

        var frameCount = 0;
        
        mario.on('frameIndexChange', function(evt) {
          if (mario.animation() === 'punch' && ++frameCount > 5) {
            mario.animation('idle');
            frameCount = 0;
          }
        });
          
        document.getElementById('punch').addEventListener('click', function() {
          mario.animation('punch');
        }, false);
      };
      imageObj.src = 'mario-sprite.png';
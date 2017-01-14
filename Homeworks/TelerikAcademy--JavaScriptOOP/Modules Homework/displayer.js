var Displayer = function(containerSelector) {

	//variables 
	var _this = this;

	_this._container = $(containerSelector)
		.css("width", "500px")
		.css("height", "500px")
		.css('position', 'absolute')
		.css('top', '0')
		.css('left', '0')
		.css('overflow', 'hidden')
		.css("border", "2px solid rgba(40, 0, 0, 0.3)");

	_this._basicElement = 
		$("<div/>")
			.css('width', '15px')
			.css('height', '15px')
			.css('border-radius', '15px')
			.css('position', 'absolute')[0];

	//functions 

	_this.drawGame = function drawGame(solidObjects) {
		for (var i = solidObjects.length - 1; i >= 0; i--) {
			$(solidObjects[i].element)
				.css('top', solidObjects[i].y + "px")
				.css('left', solidObjects[i].x + "px");
		};
	}

	_this.makeNewObstacle = function makeNewObstacle() {
		return $(_this._basicElement.cloneNode(true))
			.css('background', 'gray')
			.addClass('obstacle')
			.appendTo(_this._container)
			[0];
	}

	_this.makeNewFood = function makeNewFood() {
		return $(_this._basicElement.cloneNode(true))
			.css('background', 'red')
			.css('border', '2px solid black')
			.css('border-radius', '2px')
			.addClass('food')
			.appendTo(_this._container)
			[0];
	}

	_this.makeNewSnakePart = function makeNewSnakePart() {
		return $(_this._basicElement.cloneNode(true))
			.css('background', 'green')
			.addClass('snake')
			.appendTo(_this._container)
			[0];
	}

	_this.makeSnakeHead = function makeSnakeHead() {
		return $("<div/>")
			.css('width', '9px')
			.css('height', '9px')
			.css('border-radius', '50px')
			.css('border', '3px solid green')
			.css('background', 'aqua')
			.css('position', 'absolute')
			.addClass('snake')
			.appendTo(_this._container)
			[0];
	}

	return {
		container: _this._container,
		drawGame: _this.drawGame,
		makeNewFood: _this.makeNewFood,
		makeNewObstacle: _this.makeNewObstacle,
		makeNewSnakePart: _this.makeNewSnakePart,
		makeSnakeHead: _this.makeSnakeHead
	};
};
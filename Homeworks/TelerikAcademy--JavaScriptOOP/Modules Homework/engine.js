var Engine = function(displayer, objects) {
	//variables
	var _this = this;
	_this._displayer = displayer;
	_this._objects = objects;
	_this._obstacles = [];
	_this._snake = [];
	_this._food = [];

	_this._snakeElementsToAdd = 0;

	_this._direction = {
		up: {x: 0, y: -20},
		down: {x: 0, y: 20},
		left: {x: -20, y: 0},
		right: {x: 20, y: 0}
	}
	_this._currentDir = _this._direction.up;
	
	//functions
	_this.run = function run() {

		for (var i = 0; i < 25; i++) {
			var obstacleElement = _this._displayer.makeNewObstacle();
			var coords = _this._getNewFreeCoords();
			var obstacle = new _this._objects.obstacle(coords.x, coords.y, obstacleElement);
			_this._obstacles.push(obstacle);
		}

		var snakeElement = 
			_this._displayer.makeSnakeHead();
		var snakeHead = new _this._objects.snakePart(140, 300, snakeElement);
		_this._snake.push(snakeHead);
		
		for (var i = 1; i < 3; i++) {
			var snakeElement = _this._displayer.makeNewSnakePart();
			var snakePart = new _this._objects.snakePart(140, 300 + i*20, snakeElement);
			_this._snake.push(snakePart);
		}

		var foodElement = _this._displayer.makeNewFood();
		var coords = _this._getNewFreeCoords();
		var food = new _this._objects.food(coords.x, coords.y, foodElement);
		_this._food.push(food);
		_this._moveSnake();

		document.addEventListener("keydown", _this._changeDirection, true);
	}

	_this._changeDirection = function _changeDirection (ev) {

		switch (ev.keyCode){
			case 37: // left
				if (_this._currentDir !== _this._direction.right){
					_this._currentDir = _this._direction.left;
					_this._canChangeDirection = false;
				}
				break;
			case 38: // up
				if (_this._currentDir !== _this._direction.down){
					_this._currentDir = _this._direction.up;
					_this._canChangeDirection = false;
				}
				break;
			case 39: // right

				if (_this._currentDir !== _this._direction.left){
					_this._currentDir = _this._direction.right;
					_this._canChangeDirection = false;
				}
				break;
			case 40: // down
				if (_this._currentDir !== _this._direction.up){
					_this._currentDir = _this._direction.down;
					_this._canChangeDirection = false;
				}
				break;
			default:
				break;
		}
	}

	_this._moveSnake = function _moveSnake(){
		var gameOver = false;
		var colidingElement = _this._getElementAtPosition(
			_this._snake[0].x,
			_this._snake[0].y,
			10,
			true);
		if (colidingElement) {
			if (colidingElement instanceof _this._objects.food) {
				_this._snakeElementsToAdd += 1;
			}
			if (colidingElement instanceof _this._objects.obstacle) {
				gameOver = true;
			}
			if (colidingElement instanceof _this._objects.snakePart) {
				gameOver = true;
			}
		}
		
		if (0 > _this._snake[0].x || _this._snake[0].x > 500 ||
			0 > _this._snake[0].y || _this._snake[0].y > 500) {
			gameOver = true;
		}
		if (!gameOver) {
			setTimeout(_this._moveSnake, 400);
			var snakePartToInsert;
			if (_this._snakeElementsToAdd <= 0) {
				snakePartToInsert = _this._snake.pop();
				snakePartToInsert.x = _this._snake[0].x;
				snakePartToInsert.y = _this._snake[0].y;
			}
			else {
				var snakeElement = _this._displayer.makeNewSnakePart();
				snakePartToInsert = new _this._objects.snakePart(
					_this._snake[0].x, 
					_this._snake[0].y, 
					snakeElement);
				_this._snakeElementsToAdd--;
				_this._replaceFood();
			}
			_this._snake.splice(1, 0, snakePartToInsert);
			_this._snake[0].x += _this._currentDir.x;
			_this._snake[0].y += _this._currentDir.y;
			_this._callDisplayer();
		}
		else {
			alert('game over');
		}
	}

	_this._replaceFood = function _replaceFood(){
		var coords = _this._getNewFreeCoords();
		_this._food[0].x = coords.x;
		_this._food[0].y = coords.y;
	}

	_this._getElementAtPosition = function _getElementAtPosition(x, y, radius, includeSnake){
		radius = radius || 10;

		for (var i = 0; i < _this._obstacles.length; i++) {
			if (Math.abs(x - (_this._obstacles[i].x + 7.5)) < radius
				&& Math.abs(y - (_this._obstacles[i].y + 7.5)) < radius) {
				return _this._obstacles[i];
			}
		}
		for (var i = 0; i < _this._food.length; i++) {
			if (Math.abs(x - (_this._food[i].x + 7.5)) < radius
				&& Math.abs(y - (_this._food[i].y + 7.5)) < radius) {
				return _this._food[i];
			}
		}
		if (includeSnake) {
			for (var i = 2; i < _this._snake.length; i++) {
				if (Math.abs(x - (_this._snake[i].x + 7.5)) < radius
					&& Math.abs(y - (_this._snake[i].y + 7.5)) < radius) {
					return _this._snake[i];
				}
			}
		}
		return null;
	}

	_this._getNewFreeCoords = function _getNewFreeCoords(){
		function rndNum() {
			return (Math.floor(Math.random() * 500 / 20) * 20)
		}
		var x = rndNum();
		var y = rndNum();

		while(true){
			var elementAtPos = _this._getElementAtPosition(x, y, 40, true);
			if (elementAtPos !== null) {
				x = rndNum();
				y = rndNum();
			}
			else {
				break;
			}
		}
		return {x: x, y: y};
	}

	_this._callDisplayer = function callDrawer(){
		_this._displayer.drawGame(_this._obstacles);
		_this._displayer.drawGame(_this._food);
		_this._displayer.drawGame(_this._snake);
	}

	return {
		run: _this.run
	};
}

window.onload = function() {
	var displayer = new Displayer("#snake-game")
	var objects = new Objects();
	var engine = new Engine(displayer, objects);
	engine.run();
}
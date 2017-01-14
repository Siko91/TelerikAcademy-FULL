var Objects = function() {
	//variables 
	var _this = this;

	//functions 
	_this._solidObject = function solidObject(x, y, element) {
		this.x = x;
		this.y = y;
		this.element = element;
	}
	_this._solidObject.prototype.setPosition = function setPosition(x, y){
		this.x = x;
		thix.y = y;
	}

	_this.obstacle = function obstacle(x, y, element) {
		_this._solidObject.call(this, x, y, element);
		this.objectType = 'obstacle';
	}
	this.obstacle.prototype = new _this._solidObject();

	_this.snakePart = function snakePart(x, y, element) {
		_this._solidObject.call(this, x, y, element);
		this.objectType = 'snakePart';
	}
	this.snakePart.prototype = new _this._solidObject();

	_this.food = function food(x, y, element) {
		_this._solidObject.call(this, x, y, element);
		this.objectType = 'food';
	}
	this.food.prototype = new _this._solidObject();

	return {
		obstacle: _this.obstacle,
		food: _this.food,
		snakePart: _this.snakePart
	};
};
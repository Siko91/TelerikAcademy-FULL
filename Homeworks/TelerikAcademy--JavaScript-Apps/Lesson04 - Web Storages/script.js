window.onload = function() {
	var game = new Game();
	game.Run("#wrapper");


	function Game(){
		"use strict";
		var _this = this;
		_this._secretNumber = "";
		_this._$container = {};
		_this._turnsCount = 0;
		_this._inputIsSet = false;

		function clearSaves() {
			localStorage.removeItem("highScores");
			_this._$container.next(".scores").find("li").remove();
		}

		function saveHighScore(name, turns) {
			var scores = [];
			var $scoreList = _this._$container.next(".scores");
			var $newScore = $("<li>")
				.attr("data-main", turns)
				.append("<strong>" + name + "</strong> --> " + turns);

			var $oldScores = $scoreList.find("li");
			for (var i = $oldScores.length - 1; i >= 0; i--) {
				scores.push($($oldScores[i]));
			}
			scores.push($newScore);
			scores = scores.sort(function($sc1, $sc2){
				return (parseInt($sc1.attr("data-main")) > parseInt($sc2.attr("data-main"))? 1 :
					parseInt($sc1.attr("data-main")) < parseInt($sc2.attr("data-main"))? -1 : 0)
			})
			for (var i = 0; i < scores.length; i++) {
				$scoreList.append(scores[i]);
				scores[i] = {
					name : scores[i].find("strong").html(),
					score : scores[i].attr("data-main")
				}
			}
			localStorage.removeItem("highScores");
			localStorage.setItem("highScores", JSON.stringify(scores));
		}

		function onGameOver(turns) {
			var saveScore = confirm("Congratulations, you beat the game in " + turns + "turns!\nDo you want to save your score?")
			if (saveScore) {
				var name = prompt("Input your name: ", "unnamed");
				saveHighScore(name, turns);
			}
			var $inputContainer = _this._$container.find(".input").empty();
		}

		function onSendClick(){
			var text = _this._$container.find(".the-number-input").val();
			_this._$container.find(".the-number-input").val("");
			var $ol = _this._$container.find(".turns-list");

			var sheep = 0;
			var rams = 0;

			function registerError(){
				$("<li>")
					.css("color", "red")
					.append("invalid input attempt : '" + text + "'")
					.appendTo($ol);
			}

			if (text.length !== 4) {
				registerError();
				return;
			}
			if (text[0] === "0") {
				registerError();
				return;
			}
			for (var i = 0; i < 4; i++) {
				if ("0" > text[i] || text[i] > "9") {
					registerError();
					return;
				}
				var index = _this._secretNumber.indexOf(text[i]);
				while(index !== -1) {
					if (index === i) {
						rams++;
					}
					else {
						sheep++;
					}
					index = _this._secretNumber.indexOf(text[i], index+1);
				}
			}
			$("<li>")
				.append("(" + text + ") - Found " + sheep + " sheep and " + rams + " rams.")
				.appendTo($ol);
			_this._turnsCount++;
			if (text === _this._secretNumber) {
				onGameOver(_this._turnsCount);
			}
		}

		function setInput(){
			var $inputContainer = _this._$container.find(".input").empty();

			$("<br>")
				.appendTo($inputContainer);
			$("<label>")
				.append("input your guess hire:")
				.appendTo(_this._$container.find(".input"));
			$("<br>")
				.appendTo($inputContainer);
			$("<input>")
				.addClass("the-number-input")
				.css("height", "60px")
				.css("width", "120px")
				.css("margin", "auto")
				.css("font-size", "50px")
				.css("background", "none")
				.css("border", "1 px solid black")
				.appendTo($inputContainer);
			$("<br>")
				.appendTo($inputContainer);
			$("<button>")
				.append("Send...")
				.click(onSendClick)
				.appendTo($inputContainer);
			$("<br>")
				.appendTo($inputContainer);
			$("<ol>")
				.addClass("turns-list")
				.css("width", "300px")
				.css("height", "180px")
				.css("margin", "auto")
				.css("border", "1px solid black")
				.css("overflow", "auto")
				.on("click", "li", function(){
						var $li = $(this);
						$li.parent().find("li").css("background", "none");
						$li.css("background", "aqua");
					})
				.appendTo($inputContainer);
		}

		function startTheGame(){
			_this._secretNumber = (Math.floor(Math.random()*8999)+1000).toString();
			_this._turnsCount === 0;
			_this._$container.find(".turns-list").empty();
			setInput();
			alert("Cheating Tip!\nThe secret number is: " + _this._secretNumber);
		}

		function createDOMElements(selector){
			_this._$container = $(selector)
				.empty()
				.css("width", "600px")
				.css("height", "400px")
				.css("text-align", "center")
				.css("float", "left")
				.css("border", "1px solid black");

			$("<header>")
				.addClass("header")
				.css("background", "lightgray")
				.css("height", "40px")
				.css("color", "black")
				.append($("<h1>")
					.append("> Guess the Number <")
					.css("margin", 0)
					.css("padding", 0))
				.appendTo(_this._$container);
			$("<button>")
				.append("START / RESTART")
				.addClass("start-button")
				.click(startTheGame)
				.appendTo(_this._$container);
			$("<div>")
				.addClass("input")
				.appendTo(_this._$container);

			$("<ol>")
				.addClass("scores")
				.css("width", "300px")
				.css("height", "400px")
				.css("text-align", "center")
				.css("float", "left")
				.css("overflow", "auto")
				.append($("<button>")
					.append("Clear High Scores")
					.click(clearSaves))
				.append($("<div>")
					.css("background", "lightgray")
					.css("height", "40px")
					.css("color", "black")
					.append($("<h1>")
						.append("> High Scores <")
						.css("margin", 0)
						.css("padding", 0)))
				.insertAfter(_this._$container);
		}

		function loatHighScores() {
			_this._$container.next(".scores").find("li").remove();
			var scores = JSON.parse(localStorage.getItem("highScores"));
			if (scores) {
				for (var i = scores.length - 1; i >= 0; i--) {
					saveHighScore(scores[i].name, scores[i].score);
				}
			}
		}

		function Run(selector){
			createDOMElements(selector);
			loatHighScores();

			// some preset saves - used for fast testing
			if (!localStorage.getItem("highScores")) {
				saveHighScore("pesho", 5);
				saveHighScore("gogo", 4);
				saveHighScore("sasho", 22);
				saveHighScore("mimi", 15);
			}
		}

		return { Run : Run };
	}
}
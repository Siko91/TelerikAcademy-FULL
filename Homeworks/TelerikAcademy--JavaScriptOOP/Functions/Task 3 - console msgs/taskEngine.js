window.onload = function() {

	document.getElementById("console-write-line")
		.addEventListener('click', ConsoleWriteLine, 'false');
	document.getElementById("console-write-complex-line")
		.addEventListener('click', ConsoleWriteComplexLine, 'false');
	document.getElementById("console-write-error")
		.addEventListener('click', ConsoleWriteError, 'false');
	document.getElementById("console-write-warning")
		.addEventListener('click', ConsoleWriteWarning, 'false');

	consoleLogger = new consoleLogger();
}

function ConsoleWriteLine() {
    var input = document.getElementById('message').value;
    consoleLogger.writeLine(input);
}

function ConsoleWriteComplexLine() {
    var input = document.getElementById('complex-message').value;
    var inputArr = parseToArray(input);
    consoleLogger.writeLine(inputArr);
}

function ConsoleWriteError() {
    var input = document.getElementById('error-message').value;
    var inputArr = parseToArray(input);
    consoleLogger.writeError(inputArr);
}

function ConsoleWriteWarning() {
    var input = document.getElementById('warn-message').value;
    var inputArr = parseToArray(input);
    consoleLogger.writeWarning(inputArr);
}

function parseToArray(string) {
	if (string.indexOf("{0}") === -1) {
		return string;
	}

	var betweenQuotes = false;
	var array = [];

	var position1, position2;

	var extractWord = function extractWord(p1, p2){
		array.push(string.substring(p1, p2));
	}

	for (var i = 0; i < string.length; i++) {
		if (string[i] === "'") {
			if (!betweenQuotes) {
				position1 = i+1;
			}
			else {
				position2 = i;
				extractWord(position1, position2);
			}
			betweenQuotes = !betweenQuotes;
		}
	}

	return array;
}
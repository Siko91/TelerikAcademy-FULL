function Solve (params) {

	var ERROR_MESSAGE = "Division by zero! At Line:"

	var variables = {};

	var operations = {
		plus: function(arr) {
			var result = arr[0];
			for (var i = 1; i < arr.length; i++) {
				result += arr[i];
			}
			return result;
		},
		minus: function(arr) {
			var result = arr[0];
			for (var i = 1; i < arr.length; i++) {
				result -= arr[i];
			}
			return result;
		},
		umnoji: function(arr) {
			var result = arr[0];
			for (var i = 1; i < arr.length; i++) {
				result *= arr[i];
			}
			return result;
		},
		razdeli: function(arr) {
			if (arr[0] == 0) {
				return ERROR_MESSAGE;
			}

			var result = arr[0];
			for (var i = 1; i < arr.length; i++) {
				if (arr[i] == 0) {
					throw ERROR_MESSAGE;
				}
				result /= arr[i];
			}
			return result;
		}
	}

	var removeBraclets = function(str) {
		var result = str.substring(1, str.length-1);
		return result;
	}

	var convertStrToStrArr = function(str) {
		var array = [];
		var startIndex = 0;
		var insideNested = false;
		for (var i = 0; i < str.length; i++) {
			if (str[i] == " " && !insideNested) {
				array.push(str.substring(startIndex, i));
				startIndex = i+1;
			}
			else if (i == str.length - 1) {
				array.push(str.substring(startIndex));
			}
			else if (str[i] == "(") {
				insideNested = true;
			}
			else if (str[i] == ")") {
				insideNested = false;
			}
		}
		array = array.filter(function(element) { return element.length > 0 });
		return array
	}

	var parseArray = function(arr) {
		for (var i = 0; i < arr.length; i++) {
			if (isNaN(parseInt(arr[i]))) {
				arr[i] = getItemValue(arr[i]);
			}
			else {
				arr[i] = parseInt(arr[i]);
			}
		}
		return arr;
	}

	var getItemValue = function(str) {
		if (!isNaN(parseInt(str))) {
			return parseInt(str);
		}
		else if (str[0] == "(") {
			return handleOperation(str);
		}
		else {
			return variables[str];
		}
	}

	var handleOperation = function(operation) {
		operation = removeBraclets(operation);
		operation = convertStrToStrArr(operation);

		if (operation[0] == "def") {
			variables[operation[1]] = getItemValue(operation[2]);
		}
		else if (operation[0] == "+") {
			operation = parseArray(operation.slice(1))
			return operations.plus(operation);
		}
		else if (operation[0] == "-") {
			operation = parseArray(operation.slice(1))
			return operations.minus(operation);
		}
		else if (operation[0] == "*") {
			operation = parseArray(operation.slice(1))
			return operations.umnoji(operation);
		}
		else if (operation[0] == "/") {
			operation = parseArray(operation.slice(1))
			var result = operations.razdeli(operation);
		}
		else {
			return parseInt(operation[0]);
		}
	}

	// Program starts hire
	for (var i = 0; i < params.length - 1; i++) {
		try	{
			handleOperation(params[i]);
		}
		catch (err) {
			return err + (i+1);
		}
	}
	var result = handleOperation(params[params.length - 1]);

	return result;
}
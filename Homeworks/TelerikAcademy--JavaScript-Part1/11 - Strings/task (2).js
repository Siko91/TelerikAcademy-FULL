function DoTask2()
{
	var input = document.getElementById("input2").value.split("");

	var result = true;
	var counter = 0;
	for (var i = 0; i < input.length; i++) {

		if (input[i] === "(") {
			counter++;
		}

		if (input[i] === ")") {
			counter--;
		}

		if (counter < 0) {
			result = false;
			break;
		}
	}

	if (counter != 0) {
		result = false;
	}

	ShowResult("The braclets are " + (result? "currect":"incorrect"), "done", 2);
}
function DoTask10()
{
	var text = document.getElementById("input10").value;
	text = text.replace(/[^\w\s]/gi, '');

	var words = text.split(" ");
	words = words.filter(function(n){ return n.length > 0 });

	for (var i = 0; i < words.length; i++) {

		var reversedWord = words[i].split("").reverse().join("");

		if (!(words[i] === reversedWord)) {
			words.splice(i, 1);
			i--;
		}
	}

	ShowResult(words.join("<br />"), "done", 10);
}
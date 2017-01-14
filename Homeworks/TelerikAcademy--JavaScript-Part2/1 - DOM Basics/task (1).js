function DoTask1()
{
	var divsInOtherDivs = getDivsInOtherDivs();
	var divsInOtherDivsAlternativeMethod = getDivsInOtherDivsAlternativeMethod()

	var result = "There are " 
		+ divsInOtherDivs.length 
		+ " divs that are in other divs"
		+ "<br />"
		+ "I made both methods.";

	ShowResult(result, "done", 1);
}

function getDivsInOtherDivs() {
	var divsInOtherDivs = document.querySelectorAll("div div");
	return divsInOtherDivs;
}

function getDivsInOtherDivsAlternativeMethod() {
	var divs = document.getElementsByTagName("div");
	var divsInOtherDivs = [];

	for (var i = divs.length - 1; i >= 0; i--) {
		var divsInThisDiv = divs[i].getElementsByTagName("div");
		for (var y = divsInThisDiv.length - 1; y >= 0; y--) {
			divsInOtherDivs.push(divsInThisDiv[y]);
		};
	};

	return divsInOtherDivs;
}
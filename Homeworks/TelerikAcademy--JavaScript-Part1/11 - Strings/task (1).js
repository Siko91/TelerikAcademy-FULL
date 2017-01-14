function DoTask1()
{
	var input = document.getElementById("input1").value.split("");
	input = input.reverse().join("");
	ShowResult(input, "done", 1);
}
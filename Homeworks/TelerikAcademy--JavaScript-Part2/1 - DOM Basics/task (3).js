function DoTask3()
{
    var inputColor = document.getElementById("input3").value;
    var wrapper = document.getElementById("wrapper");
    wrapper.style.backgroundColor = inputColor;

    ShowResult("It should be done now", "done", 3);
    var resultDiv = document.getElementById("result3");
    resultDiv.style.backgroundColor = inputColor;
    resultDiv.style.color = "Aqua";
}
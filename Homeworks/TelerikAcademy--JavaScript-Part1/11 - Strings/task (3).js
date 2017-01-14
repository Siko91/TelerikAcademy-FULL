function DoTask3()
{
    var input = document.getElementById("input3-1").value;
    var substr = document.getElementById("input3-2").value;
    var caseSensitivity = document.getElementById("input3-3").checked;

    var typeOfSearch = "g";
    if (caseSensitivity === false) {
    	typeOfSearch = "gi";
    }

    var regex = new RegExp(substr,typeOfSearch);
    var appearences = input.split(regex);

    ShowResult("The result is: " + appearences.length, "done", 3);
}
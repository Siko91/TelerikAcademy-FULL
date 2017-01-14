function DoTask3()
{
	var result = "";

	var oldObj = [
		[1, 2, 3, 4, 5, 6, 7, 8, 9],
		["1", "2", "1", "2", "1", "2", null],
		[true, false, "alien", true, false, "alien", undefined]
	];

	var cln = clone(oldObj);

	result += "--- Old Object ---<br />";
	result += oldObj.join("<br />");
	result += "<br /><br />--------------<br /><br />";
	result += "--- Cloned Object ---<br />";
	result += cln.join("<br />");

	ShowResult(result, "done", 3);
}

function clone(oldObj) {
    if (oldObj == null || "Object" != typeof oldObj) {
        return oldObj;
    }

    if (oldObj instanceof Array) {
        var copy = [];
        for (var i = 0 ; i < oldObj.length ; i++) {
            copy.push(clone(oldObj[i]));
        }
        return copy;
    }

    if (oldObj instanceof Object) {
        var copy = {};
        for (var attr in oldObj) {
            if (oldObj.hasOwnProperty(attr)) {
                copy[attr] = clone(oldObj[attr]);
            }
        }
        return copy;
    }
}
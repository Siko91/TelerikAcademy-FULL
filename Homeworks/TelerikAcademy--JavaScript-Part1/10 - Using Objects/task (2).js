function DoTask2()
{
	Array.prototype.remove = function (num) {
		var result = this.filter(function(n){ return n !== num });
		return result;
  	}
    
	var numToRemove = document.getElementById("input2").value;
	numToRemove = parseFloat(numToRemove);
	if (isNaN(numToRemove)) {
		ThrowError(2);
		return;
	}
	if (numToRemove < 1 || numToRemove > 10) {
		ThrowError(2);
		return;
	}

	var arrOfNums = new Array();
	for (var i = 1; i <= 10; i++) {
		for (var y = 1; y <= 3; y++) {
			arrOfNums.push(i);
		}
	}

	var newArr = arrOfNums.remove(numToRemove)
	ShowResult( newArr.join(", ") , "done" , 2 );
}
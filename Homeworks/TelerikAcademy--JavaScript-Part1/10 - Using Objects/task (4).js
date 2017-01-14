function DoTask4()
{
	Object.prototype.hasProperty = function(propertyName) {
		if (typeof propertyName != "string") {
			return false;
		}
		if (!this[propertyName]) {
			return false;
		}
		return true;
	}

	var myObj = new MyObject();

	var result = "";

	for (var i = 1; i <= 4; i++) {
		result += "myObj.hasProperty(prop" + i + ") == " 
		+ (myObj.hasProperty("prop" + i)? "true" : "false") 
		+ "<br />";
	}
	ShowResult(result, "done", 4);
}

function MyObject() {
	this.prop1 = function() { 
		return true; 
	}
	this.prop2 = function() { 
		return 7; 
	}
	this.prop3 = "aaa";
}
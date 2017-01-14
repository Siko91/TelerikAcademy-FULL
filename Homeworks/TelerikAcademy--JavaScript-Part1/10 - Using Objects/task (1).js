function DoTask1()
{
	var p1X = document.getElementById("input1-1-1").value;
	var p1Y = document.getElementById("input1-1-2").value;
	var p2X = document.getElementById("input1-1-3").value;
	var p2Y = document.getElementById("input1-1-4").value;

	var L1Length = document.getElementById("input1-2-1").value;
	var L2Length = document.getElementById("input1-2-2").value;
	var L3Length = document.getElementById("input1-2-3").value;

	var P1 = new Point2D(parseFloat(p1X), parseFloat(p1Y));
	var P2 = new Point2D(parseFloat(p2X), parseFloat(p2Y));

	var L1 = new Line2D( new Point2D(0, 0) , new Point2D(0, parseFloat(L1Length)) );
	var L2 = new Line2D( new Point2D(0, 0) , new Point2D(0, parseFloat(L2Length)) );
	var L3 = new Line2D( new Point2D(0, 0) , new Point2D(0, parseFloat(L3Length)) );

	var result = "";
	result += CalculateDistance(P1, P2);
	result += "<br /><br /> ---------------------------- <br /><br />"
	result += CheckTriangle(L1, L2, L3);

	ShowResult(result, "done", 1);
}

function Point2D(numberX, numberY)
{
	this.X = numberX;
	this.Y = numberY;

	this.getDistanceFromPoint = function(Point)
	{
		return Math.sqrt(
			Math.pow((Point.X - this.X), 2) +
			Math.pow((Point.Y - this.Y), 2)
			);
	}
	this.validatePoint = function() { 
		if (isNaN(this.X) || isNaN(this.Y)) {
			return false;
		}
		return true;
	}

	this.toString = function() {
		return "["+this.X+", "+this.Y+"]";
	}
}

function Line2D(P1, P2)
{
	this.P1 = P1;
	this.P2 = P2;
	this.length = this.P1.getDistanceFromPoint(P2);

	this.toString = function() {
		return this.P1.toString() + "-" + this.P2.toString();
	}
	this.validateLine = function() { 
		if (!this.P1.validatePoint || !this.P2.validatePoint) {
			return false;
		}
		return true;
	}
}

function CalculateDistance(P1, P2) {
	return ( "---Distance Calculation---<br />"
		+ "P1: " + P1.toString() + "<br />" 
		+ "P2: " + P2.toString() + "<br />"
		+ "Distance: " + P1.getDistanceFromPoint(P2)
		);
}

function CheckTriangle(L1, L2, L3){
	var CanMakeTriangle = true;

	if (L1.length*L1.length > L2.length*L2.length + L3.length*L3.length ||
		L2.length*L2.length > L1.length*L1.length + L3.length*L3.length ||
		L3.length*L3.length > L2.length*L2.length + L1.length*L1.length) {
		CanMakeTriangle = false;
	}
	else if (L1.length == 0 || L2.length == 0 || L3.length == 0) {
		CanMakeTriangle = false;
	}
	else if (L1.validateLine || L2.validateLine || L3.validateLine) {
		CanMakeTriangle = false;
	}

	return ( "---Triangle Posibility Check---<br />"
		+ "L1: " + L1.toString() + "<br />"
		+ "L2: " + L2.toString() + "<br />"
		+ "L3: " + L3.toString() + "<br />"
		+ "Posibility: " + CanMakeTriangle
		);
}
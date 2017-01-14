function Solve(params) {
	var ROW = 0;
	var COL = 1;

	var inRange = function(pos, range) {
		return (0 <= pos && pos < range);
	}

	var size = params[0].split(" ").map(Number);
	var position = params[1].split(" ").map(Number);

	var jumps = params.slice(2, (2 + size[2]));

	params = null;

	var visitedPositions = new Array(size[ROW]*size[COL]);

	var pointCounter = size[COL] * position[ROW] + position[COL] + 1;
	var jumpCounter = 0;
	var rabitIsOut = true;
	var jumpIndex = 0;

	while (true) {

		var currentJump = jumps[jumpIndex].split(" ").map(Number);
		position[ROW]+=currentJump[ROW];
		position[COL]+=currentJump[COL];
		jumpCounter++;

		var indexOfCurrentPosition = size[COL] * position[ROW] + position[COL]

		if (!inRange(position[ROW],size[ROW]) || !inRange(position[COL],size[COL])) {
			rabitIsOut = true;
			break;
		}
		else if (visitedPositions[indexOfCurrentPosition] == true) {
			rabitIsOut = false;
			break;
		}
		else {
			visitedPositions[indexOfCurrentPosition] = true
			pointCounter += (indexOfCurrentPosition + 1);
		}

		if (jumpIndex >= (jumps.length - 1)) {
			jumpIndex = 0;
		}
		else {
			jumpIndex++;
		}
	}

	var result = "";
	if (rabitIsOut) {
		result = "escaped " + pointCounter;
	}
	else {
		result = "caught " + jumpCounter;
	}

	return result;
}
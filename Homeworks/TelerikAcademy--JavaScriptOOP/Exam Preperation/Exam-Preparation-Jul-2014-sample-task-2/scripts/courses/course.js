define(function() {
	'use strict'
	var Course = (function() {
		function Course(name, calcScoreFunction) {
			var _this = this;
			_this.name = name;
			_this.calcScoreFunction = calcScoreFunction;
			_this.students = [];
		}
		Course.prototype.addStudent = function(student) {
			var _this = this;
			_this.students.push(student);
		}
		Course.prototype.calculateResults = function(){
			var _this = this;
			for (var i = 0, len = _this.students.length; i < len; i++) {
				_this.students[i].totalScore = _this.calcScoreFunction(_this.students[i]);
			}
		}
		Course.prototype.getTopStudentsByExam = function(count) {
			var _this = this;
			SortStudentsBy(_this.students, "exam");
			return _this.students.slice(0,count);
		}
		Course.prototype.getTopStudentsByTotalScore = function(count) {
			var _this = this;
			SortStudentsBy(_this.students, "totalScore");
			return _this.students.slice(0,count);
		}

		function SortStudentsBy(students, sorter, reversed) {
			if (reversed) {
				students = students.sort(function(st1, st2) {
					return st1[sorter] - st2[sorter];
				});
			}
			else{
				students = students.sort(function(st1, st2) {
					return st2[sorter] - st1[sorter];
				});
			}
		}
		return Course;
	}());
	return Course;
});
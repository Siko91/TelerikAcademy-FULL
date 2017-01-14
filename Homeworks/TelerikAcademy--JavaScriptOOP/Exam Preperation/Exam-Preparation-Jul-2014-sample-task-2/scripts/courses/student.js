define(function() {
	'use strict'
	var Student = (function() {
		function Student(studentInfo) {
			this.name = studentInfo.name;
			this.exam = studentInfo.exam;
			this.homework = studentInfo.homework;
			this.attendance = studentInfo.attendance;
			this.teamwork = studentInfo.teamwork;
			this.bonus = studentInfo.bonus;
			this.totalScore = 0;
		}
		return Student;
	}());
	return Student;
});
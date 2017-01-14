define(function() {
        var Utils = function(){
        	var strings = ["foo", "bar", "baz"];
        	var MARK_MIN = 2;
        	var MARK_MAX = 6;
        	var MARKS_COUNT_MIN = 1;
        	var MARKS_COUNT_MAX = 5;
        	var AGE_MIN = 15;
        	var AGE_MAX = 55;
        	var numbersOfLeggs = [2, 4, 6, 8, 100];

            function sum(nums){
                var sum = 0;
                for (var i = nums.length - 1; i >= 0; i--) {
                    sum += nums[i];
                }
                return sum;
            }

        	function getString() {
        		return strings[Math.floor(Math.random() * strings.length)];
        	}

        	function getLeggsNumber() {
        		return numbersOfLeggs[Math.floor(Math.random() * numbersOfLeggs.length)];
        	}

        	function getAge() {
        		return Math.floor(Math.random() * (AGE_MAX - AGE_MIN)) + AGE_MIN;
        	}

        	function getMarks(count) {
        		var arr = [];
        		var len = count || (Math.floor(Math.random() * (MARKS_COUNT_MAX - MARKS_COUNT_MIN)) + MARKS_COUNT_MIN);
        		for (var i = 0; i < len; i++) {
        			var mark = Math.floor(Math.random() * (MARK_MAX - MARK_MIN + 1)) + MARK_MIN;
        			arr.push(mark);
        		}
        		return arr;
        	}

        	function Student(firstName, lastName, age, marks) {
        		"use strict";
        		this.firstName = firstName;
        		this.lastName = lastName;
        		this.age = age;
        		this.marks = marks;
        	}
            Student.prototype.toString = function toString(){
                return JSON.stringify(this);
            }
            Student.prototype.fullName = function fullName(){
                return this.firstName + " " + this.lastName;
            }
            Student.prototype.avgMark = function avgMark(){
                return sum(this.marks) / this.marks.length;
            }

        	function Human(firstName, lastName, age) {
        		"use strict";
        		this.firstName = firstName;
        		this.lastName = lastName;
        		this.age = age;
        	}
            Human.prototype.toString = function toString(){
                return JSON.stringify(this);
            }
            Human.prototype.fullName = function fullName(){
                return this.firstName + " " + this.lastName;
            }

        	function Animal(specie, numberOfLeggs) {
        		"use strict";
        		this.specie = specie;
                this.numbersOfLeggs = numberOfLeggs;
        	}
            Animal.prototype.toString = function toString(){
                return JSON.stringify(this);
            }

        	function Book(name, author){
        		"use strict";
        		this.name = name;
        		this.author = author;
        	}
            Book.prototype.toString = function toString(){
                return JSON.stringify(this);
            }

        	function getSomeStudents(count, marksCount){
        		var arr = [];
        		for (var i = 0; i < count; i++) {
        			var stud = new Student(
                        getString(),
                        getString(),
                        getAge(),
                        marksCount? getMarks(marksCount) : getMarks());
        			arr.push(stud);
        		}
        		return arr;
        	}

        	function getSomeHumans(count){
        		var arr = [];
        		for (var i = 0; i < count; i++) {
        			var human = new Human(
                        getString(),
                        getString(),
                        getAge());
        			arr.push(human);
        		}
        		return arr;
        	}

        	function getSomeAnimals(count){
        		var arr = [];
        		for (var i = 0; i < count; i++) {
        			var animal = new Animal(
                        getString(),
                        getLeggsNumber());
        			arr.push(animal);
        		}
        		return arr;
        	}

        	function getSomeBooks(count){
        		var arr = [];
        		for (var i = 0; i < count; i++) {
        			var book = new Book(
                        getString(),
                        getString());
        			arr.push(book);
        		}
        		return arr;
        	}

        	return {
        		getSomeStudents : getSomeStudents,
        		getSomeAnimals : getSomeAnimals,
        		getSomeBooks : getSomeBooks,
        		getSomeHumans : getSomeHumans
        	}
        }();
        return Utils;
    }
);
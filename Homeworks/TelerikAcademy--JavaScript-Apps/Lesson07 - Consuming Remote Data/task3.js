
(function () {

	function getData() {
		RemoteControler.get("http://localhost:3000/students")
			.then(function (obj) {
				if (obj) {
					console.log(obj);
					alert("" + JSON.stringify(obj));
				}
			})
			.done();
	}

	function postData() {
		var student = {
			name: prompt("Input student name: ", "Khrischan Rollvery"),
			grade: 2
		}
		RemoteControler.post("http://localhost:3000/students", student)
			.then(function (obj) {
				if (obj) {
					console.log(obj);
					alert("" + JSON.stringify(obj));
				}
			})
			.done();
	}

	function deleteData() {
		var id = prompt("Input the id ot the student to delete: ", "1");
		RemoteControler.delete("http://localhost:3000/students/" + id)
			.then(function (obj) {
				if (obj) {
					console.log(obj);
					alert("" + JSON.stringify(obj));
				}
			})
			.done();
	}

	var btns = $("#task3btn")
		.on("click", displayTask1Controls);

	function displayTask1Controls(){
		var p = $("<p>")
				.append("This task requires a running server. Please start it now if you haven't done so, already.")

		var btn1 = $("<button>")
				.append("GET")
				.click(getData);

		var btn2 = $("<button>")
				.append("POST")
				.click(postData);

		var btn3 = $("<button>")
				.append("DELETE")
				.click(deleteData);

		$("#wrapper").find("#content").empty()
			.append(p)
			.append(btn1)
			.append(btn2)
			.append(btn3);
	}

}());


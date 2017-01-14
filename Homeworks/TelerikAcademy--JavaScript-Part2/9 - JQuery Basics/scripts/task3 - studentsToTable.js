function generateStudentsTable() {
    // clean up
    var $resultChildren = $('#the-result-box *');
    $resultChildren.remove();

    var studentData = [];
    for (var i = 0; i < 15; i++) {
        studentData.push({
            fname: "FirstName"+i,
            lname: "LastName"+i,
            grade: i+1
        });
    }

    var $table = $("<table id='the-table' />")
        .css('margin', 'auto')
        .css('margin-top', '40px')
        .css('border', '1px solid black')
        .css('border-collapse', 'collapse');

    $table.append($("<thead><tr><th>First name</th><th>Last name</th><th>Grade</th></tr></thead>"))

    for (var i = 0; i < studentData.length; i++) {
        var $row = $("<tr/>")
            .appendTo($table);

        $("<td>" + studentData[i].fname + "</td>")
            .css('border', '1px solid black')
            .css('padding', '3px')
            .appendTo($row);
        $("<td>" + studentData[i].lname + "</td>")
            .css('border', '1px solid black')
            .css('padding', '3px')
            .appendTo($row);
        $("<td>" + studentData[i].score + "</td>")
            .css('border', '1px solid black')
            .css('padding', '3px')
            .appendTo($row);
    }

    $("#the-result-box").append($table);
}
function DoTask9()
{
    var text = document.getElementById("input9").value;

    var mailRegex1 = /([\w_]+)\@(\w+)\.([\w\.]+\w)/g;

    var mails = text.match(mailRegex1);
    var result = "";

    for (var i in mails) {
    	result += mails[i].toString()+"<br />";
    }

    ShowResult(result, "done", 9);
}
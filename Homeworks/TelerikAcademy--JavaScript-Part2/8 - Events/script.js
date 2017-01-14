uniqueId = 0;
var submitBtn = document.getElementById("task-form-submit");
submitBtn.addEventListener('click', addNewArticle, false);

function addNewArticle() {
    var name = document.getElementById("task-form-topic").value;
    if (name === "") {
        return;
    }
    var description = document.getElementById("task-form-description").value;
    alert(description);
    var important = document.getElementById("task-form-important").checked;

    var newArticle = makeTODOArticle(name, description, important);
    var taskList = document.getElementById("task-list");
    taskList.appendChild(newArticle);
}

function makeTODOArticle(name, description, important) {
    var article = document.createElement('article');
    article.id = "todo-" + uniqueId++;

    var header = document.createElement('header');
    var h1 = document.createElement('h1');
    h1.innerHTML = name;

    var date = document.createElement('span');
    var d = new Date();
    date.innerHTML = "Added in " + d.getFullYear() + "/" + d.getMonth() + "/" + d.getDate();

    header.appendChild(h1);
    header.appendChild(document.createElement("br"));
    header.appendChild(date);

    var text = document.createElement('div');
    text.innerHTML = description.replace('\n', '<br/>'); ;

    var btnMakeImp = document.createElement("button");
    btnMakeImp.id = article.id + "-btn"
    btnMakeImp.addEventListener('click', function () { todgeImportant(article.id, btnMakeImp.id); }, false);

    
    if (important) {
        article.className = " important"
        btnMakeImp.innerHTML = "Remove important";
    }
    else {
        btnMakeImp.innerHTML = "Make important";
    }

    article.appendChild(header);
    article.appendChild(text);
    article.appendChild(btnMakeImp);

    return article;
}

function todgeImportant(aticleId, btnId) {
    var article = document.getElementById(aticleId);
    var btn = document.getElementById(btnId);
    if (article.className.indexOf('important') === -1) {
        article.className = "important";
        btn.innerHTML = "Remove important";
    }
    else {
        article.className.replace("important", "");
        article.className = "";
        btn.innerHTML = "Make Important";
    }
}
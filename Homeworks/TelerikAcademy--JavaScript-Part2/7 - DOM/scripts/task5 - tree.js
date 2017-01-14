var idCounter = 0;

function getNextId() {
    return "id" + idCounter++;
}

function generateTreeView() {
    var resultDiv = document.getElementById('the-result-box');
    while (resultDiv.firstChild) {
        resultDiv.removeChild(resultDiv.firstChild);
    }
    var listFragment = document.createDocumentFragment();
    for (var i = 0; i < 5; i++) {
        var node = new treeNode("Element " + i);
        for (var y = 0; y < 5; y++) {
            var innerNode = new treeNode(node.name + "." + y);
            for (var z = 0; z < 5; z++) {
                var evenInnerNode = new treeNode(innerNode.name + "." + z);
                for (var ohComeON = 0; ohComeON < 5; ohComeON++) {
                    var theInnerestNode = new treeNode(evenInnerNode.name + "." + ohComeON);
                    evenInnerNode.addChild(theInnerestNode.element);
                }
                innerNode.addChild(evenInnerNode.element);
            }
            node.addChild(innerNode.element);
        }
        listFragment.appendChild(node.element);
    }
    resultDiv.appendChild(listFragment);
}

function treeNode(name) {
    this.name = name;
    this.children = [];
    this.element = makeTreeNodeElement(name);
    this.addChild = function(childNonde) {
        var content = this.element.getElementsByTagName("div")[0];
        content.appendChild(childNonde);

        var btn = this.element.getElementsByTagName("button")[0];
        btn.style.background = "#efefef";
    }
}

function makeTreeNodeElement(name) {
    var wrapper = document.createElement("div");

    wrapper.style.padding = 0;
    wrapper.style.margin = 0;
    wrapper.style.background = "none";
    wrapper.style.border = "none";

    var btn = document.createElement("button");
    btn.innerHTML = "+";
    btn.id = getNextId();
    btn.style.background = "#55ef55";

    var nameLabel = document.createElement("label");
    nameLabel.innerHTML = name;
    nameLabel.setAttribute('for', btn.id);

    var content = document.createElement("div");
    content.id = btn.id + "-content";
    content.style.margin = "0";
    content.style.marginLeft = "40px";
    content.style.display = "none";

    wrapper.appendChild(btn);
    wrapper.appendChild(nameLabel);
    wrapper.appendChild(content);

    btn.addEventListener('click', function () { todgeHideOfContent(content.id); }, false);

    return wrapper;
}

function todgeHideOfContent(id) {
    var content = document.getElementById(id);
    var btn = document.getElementById(id.substr(0, id.indexOf("-")));
    if (content.style.display === "none") {
        content.style.display = "block";
        btn.style.background = "#55ef55";
    }
    else {
        content.style.display = "none";
        btn.style.background = "#efefef";
    }
}
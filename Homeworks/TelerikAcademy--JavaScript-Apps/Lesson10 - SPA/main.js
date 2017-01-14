(function () {
    var messagesToShow = 50;
    var milisecondsBetweenRefresh = 5000;

    $("#username-input").val(prompt("Ïnput User Name"));
    reloadMessages();
    setInterval(reloadMessages, milisecondsBetweenRefresh);
    $("#send-btn").on("click", sendMessage);


    function reloadMessages() {
        RemoteControler.get("http://crowd-chat.herokuapp.com/posts")
            .then(function (messages) {
                var $list = $("#messages-list").empty();
                var len = Math.min(messages.length, messagesToShow);
                var init = Math.max(0, messages.length - messagesToShow - 1);
                console.log(messages.length + " messages\n" + len + " will be shown\n" + init + " will be the first index");
                var messageFragment = document.createDocumentFragment();
                for (var i = init + len; i > init; i--) {
                    var $message = $("<li>")
                        .attr("id", messages[i].id)
                        .append($("<header>").append(messages[i].by))
                        .append(messages[i].text)
                        .appendTo(messageFragment);
                    if (messages[i].by === $("#username-input").val()) {
                        $message.addClass("myMessage");
                    }
                }
                $list.append(messageFragment);
            }).done();
    }

    function sendMessage() {
        var text = $("#chat-input").val();
        var user = $("#username-input").val();
        RemoteControler.post("http://crowd-chat.herokuapp.com/posts", { user: user, text: text });
        reloadMessages();
    }
}())
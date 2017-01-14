function generateSlider() {
    // clean up
    var $resultChildren = $('#the-result-box *');
    $resultChildren.remove();

    // create content
    generateContentForSlider();

    // setTimeOut
    setTimeout(AnimateSlide, 5000);
}

function generateContentForSlider() {
    var $wrapper = $("<div id='wrapper' />")
        .css("margin-top", "50px");
    var $list = $("<ul id='slide-list' />");
    $list[0].style.border = "1px solid black";
    $list[0].style.width = "60%";
    $list[0].style.height = "300px";
    $list[0].style.margin = "auto";
    $list[0].style.padding = "40px";

    $wrapper.append($list);

    var distanceBetweenControls = 50;

    $("<button id='prev-btn'>Prevous</button>")
        .css("margin-left", distanceBetweenControls + "px")
        .css("margin-right", distanceBetweenControls + "px")
        .appendTo($wrapper);
    $("<input type='range' id='the-slider' min='1', max='0' step='1' value='1' />")
        .css("margin-left", distanceBetweenControls + "px")
        .css("margin-right", distanceBetweenControls + "px")
        .appendTo($wrapper);
    $("<button id='next-btn'>Next</button>")
        .css("margin-left", distanceBetweenControls + "px")
        .css("margin-right", distanceBetweenControls + "px")
        .appendTo($wrapper);

    $wrapper.appendTo('#the-result-box');

    $("#the-slider").change(ChangeCurrentSlideItem);
    $("#prev-btn").click(SubstractFromSlideValue);
    $("#next-btn").click(AddToSlideValue);

    generateListItemForSlider("<li class='slide-content current'><div>1<div>2<div>3<div>4<div>Div 5 = Content in many divs</div></div></div></div></div></li>");
    generateListItemForSlider("<li class='slide-content'><img src='https://www.google.bg/logos/doodles/2014/world-cup-2014-6-4876025385189376.2-hp.gif' alt='Google worldCup logo' /><li>");
    generateListItemForSlider("<li class='slide-content'><input value='f-name' /><input value='l-name' /><button>Send</button><li>");
    generateListItemForSlider("<li class='slide-content'><div>1<div>2<div>3<div>4<div>Div 5 = Content in many divs</div></div></div></div></div></li>");
    generateListItemForSlider("<li class='slide-content'><img src='https://www.google.bg/logos/doodles/2014/world-cup-2014-6-4876025385189376.2-hp.gif' alt='Google worldCup logo' /><li>");
    generateListItemForSlider("<li class='slide-content'><input value='f-name' /><input value='l-name' /><button>Send</button><li>");
    generateListItemForSlider("<li class='slide-content'><div>1<div>2<div>3<div>4<div>Div 5 = Content in many divs</div></div></div></div></div></li>");
    generateListItemForSlider("<li class='slide-content'><img src='https://www.google.bg/logos/doodles/2014/world-cup-2014-6-4876025385189376.2-hp.gif' alt='Google worldCup logo' /><li>");
    generateListItemForSlider("<li class='slide-content'><input value='f-name' /><input value='l-name' /><button>Send</button><li>");
    generateListItemForSlider("<li class='slide-content'><div>1<div>2<div>3<div>4<div>Div 5 = Content in many divs</div></div></div></div></div></li>");
    generateListItemForSlider("<li class='slide-content'><img src='https://www.google.bg/logos/doodles/2014/world-cup-2014-6-4876025385189376.2-hp.gif' alt='Google worldCup logo' /><li>");
    generateListItemForSlider("<li class='slide-content'><input value='f-name' /><input value='l-name' /><button>Send</button><li>");
    generateListItemForSlider("<li class='slide-content'><div>1<div>2<div>3<div>4<div>Div 5 = Content in many divs</div></div></div></div></div></li>");
    generateListItemForSlider("<li class='slide-content'><img src='https://www.google.bg/logos/doodles/2014/world-cup-2014-6-4876025385189376.2-hp.gif' alt='Google worldCup logo' /><li>");
    generateListItemForSlider("<li class='slide-content'><input value='f-name' /><input value='l-name' /><button>Send</button><li>");
    generateListItemForSlider("<li class='slide-content'><div>1<div>2<div>3<div>4<div>Div 5 = Content in many divs</div></div></div></div></div></li>");
    generateListItemForSlider("<li class='slide-content'><img src='https://www.google.bg/logos/doodles/2014/world-cup-2014-6-4876025385189376.2-hp.gif' alt='Google worldCup logo' /><li>");
    generateListItemForSlider("<li class='slide-content'><input value='f-name' /><input value='l-name' /><button>Send</button><li>");
}

function generateListItemForSlider(content) {
    $("#slide-list").append(content);
    $("#the-slider")[0].max = parseInt($("#the-slider")[0].max) + 1;
}

function ChangeCurrentSlideItem() {
    var value = $("#the-slider")[0].value;
    $(".slide-content.current").removeClass('current');
    var current = $(".slide-content")[value - 1];
    $(current).addClass('current');
}

function SubstractFromSlideValue() {
    var value = parseInt($("#the-slider").val()) - 1;
    $("#the-slider").attr('value', value);
    if (value < 1) {
        value = parseInt($("#the-slider").attr('max'));
    }
    $("#the-slider").attr('value', value);
    ChangeCurrentSlideItem();
}

function AddToSlideValue() {
    var value = parseInt($("#the-slider").val()) + 1;
    if (value > parseInt($("#the-slider").attr('max'))) {
        value = 1;
    }
    $("#the-slider").attr('value', value);
    ChangeCurrentSlideItem();
}

function AnimateSlide() {
    AddToSlideValue();
    setTimeout(AnimateSlide, 5000);
}


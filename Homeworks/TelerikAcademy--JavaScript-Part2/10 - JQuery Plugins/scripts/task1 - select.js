(function () {
    $.fn.makeSelectFancy = function () {
        var $select = $(this)
            .addClass('hidden-by-fancy-selector')
            .change(onOriginalSelectChange)
            .hide();

        var $options = $('select#' + $select.attr('id') + ' option');

        var $wrapper = $("<div class='dropdown-list-container' />")
            .css('display', 'inline-block')
            .insertAfter($select);

        var $current = $("<div class='dropdown-list-selected-item'></div>")
            .css('border', '1px solid black')
            .css('display', 'inline-block')
            .click(todgeHideAndShowOfOptions)
            .append('<span class="selected-text">' + $options[$select[0].selectedIndex].innerHTML + '</span>')
            .append('<img src="http://iconizer.net/files/Oxygen/orig/arrow-down.png" style="display:inline-block; width:15px; height:15px; margin-left:5px;" >')
            .appendTo($wrapper);

        $('<br/>').insertAfter($current);

        var $list = $('<ul class="dropdown-list-options" />')
            .css('list-style-type', 'none')
            .css('margin', '0')
            .css('padding', '0')
            .css('border', '1px solid black')
            .css('display', 'none')
            .appendTo($wrapper);

        for (var i = 0; i < $options.length; i++) {
            $('<li class="dropdown-list-option" data-value="'
            + $($options[i]).attr('value')
            + '">'
            + $options[i].innerHTML
            + '</li>')
                .click(onItemSelect)
                .mouseover(onItemOver)
                .mouseleave(onItemLeave)
                .appendTo($list);
        }

        function todgeHideAndShowOfOptions() {
            var $list = $(this).parent().find('ul.dropdown-list-options');

            if ($list.css('display') === 'none') {
                $list.css('display', 'inline-block');
            }
            else {
                $list.css('display', 'none');
            }
        }

        function onItemSelect() {
            var $selected = $(this);
            var $listItems = $selected.parent().find('li')
            var selectedIndex = $listItems.index($selected);

            $selected
                .parent()
                    .parent()
                        .find(".dropdown-list-selected-item .selected-text")
                            .html($selected.html());
            $listItems
                .parent()
                    .css("display", "none");

            var $originalSelect = $selected.parent().parent().prev();
            $originalSelect[0].selectedIndex = selectedIndex;
        }

        function onItemOver() {
            $(this).css("background", "lightGray");
        }

        function onItemLeave() {
            $(this).css("background", "none");
        }

        function onOriginalSelectChange() {
            var $select = $(this);
            var $options = $select.find('option');

            $select
                .next()
                .find(".selected-text")
                .html($($options[$select[0].selectedIndex]).html())
        }

        return $select
    }
} ());

function generateSelect() {
    // clean up
    var $resultChildren = $('#the-result-box *');
    $resultChildren.remove();

    var $select = $("<select id='dropdown'/>")
        .append("<option value='1'>Opt 1</option>")
        .append("<option value='2'>Opt 2</option>")
        .append("<option value='3'>Opt 3</option>")
        .append("<option value='4'>Opt 4</option>")
        .append("<option value='5'>Opt 5</option>")
        .appendTo("#the-result-box")
        .makeSelectFancy();

    $select
        .css("display", "block")
        .css("margin", "auto")
        .css("margin-bottom", "50px")
        .css("opacity", "0.1");

    $("<span>this should have been hidden, but I've cheated for demonstration purpoces</span>")
        .css("display", "block")
        .css("margin", "auto")
        .css("margin-top", "150px")
        .css("opacity", "0.1")
        .insertBefore($select);
}
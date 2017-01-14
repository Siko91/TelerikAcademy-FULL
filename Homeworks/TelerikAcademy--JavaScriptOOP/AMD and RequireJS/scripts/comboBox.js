define(["JQuery"], function () {
    return $.fn.comboBox = function comboBox() {
        var $this = $(this)
        $people = $this.find(".person-item"),
        $current = {},
        expanded = false;

        $people.hide();
        $current = $people.first().addClass("current").show();

        $this.on("click", ".person-item", function () {
            if (expanded) {
                expanded = false;
                $people.hide();
                $current.removeClass("current").hide();
                $current = $(this).addClass("current").show().css("background", "");
                $this.off("mouseover", ".person-item");
                $this.off("mouseleave", ".person-item");
            }
            else {
                expanded = true;
                $people.show();
                $this.on("mouseover", ".person-item", function () {
                    $(this).css("background", "lightgray");
                });
                $this.on("mouseleave", ".person-item", function () {
                    $(this).css("background", "");
                });
            }
        });

        return $this;
    }
});
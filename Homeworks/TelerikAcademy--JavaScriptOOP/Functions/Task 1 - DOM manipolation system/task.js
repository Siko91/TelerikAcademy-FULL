var domModule = {

    buffer: {},

    appendChild: function (elementSelector, parentSelector) {
        var $parent = $(parentSelector);
        $(elementSelector).appendTo($parent);
    },

    removeChild: function (parentSelector, removeSelector) {
        $(parentSelector).find(removeSelector).remove();
    },

    addHandler: function (elementSelector, eventType, func) {
        $(elementSelector)[eventType](func);
    },

    appendToBuffer: function (parentSelector, elementSelector) {
        if (this.buffer[parentSelector]) {
            this.buffer[parentSelector].push(elementSelector);

            if (this.buffer[parentSelector].length >= 100) {
                var length = this.buffer[parentSelector].length;
                for (var i = 0; i < length; i++) {
                    this.appendChild(this.buffer[parentSelector][i], parentSelector);
                }
            }
        }
        else {
            this.buffer[parentSelector] = [elementSelector];
        }
    }
}
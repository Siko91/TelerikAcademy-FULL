define(function() {
  'use strict';
  var Item;
  Item = (function() {
    function Item(content) {
      this.data = content.toString();
    }
    Item.prototype.getData = function getData() {
      return {
        content: this.data
      };
    };
    return Item;
  })();
  return Item;
});
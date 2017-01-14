define(function() {
    'use strict';
    var Section;
    Section = (function() {
      function Section(title) {
        this.title = title.toString();
        this.items = [];
      }

      Section.prototype.add = function add(item){
        this.items.push(item);
      }

      Section.prototype.getData = function getData(item) {
        return {
          title: this.title,
          items: this.items.map(function(item) {
            return item.getData();
          })
        }
      }

      return Section;
    }());
    return Section;
  });
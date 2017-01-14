define(function() {
	'use strict';
	var Container;
	Container = (function() {
		function Container() {
			this.sections = [];
		}
		Container.prototype.add = function add(section) {
			this.sections.push(section);
		}
		Container.prototype.getData = function getData() {
			return this.sections.map(function(sect) {
				return sect.getData();
			})
		}
		return Container;
	}());
	return Container;
});
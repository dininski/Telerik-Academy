(function() {
	'use strict';

	var Domify = function() {
		this.appendChild = function(child, parent) {
			var parentToAppendTo = document.querySelector(parent);
			console.log(parentToAppendTo);
			parentToAppendTo.appendChild(child);
		}
	}
	
})();
(function($) {
	$.fn.treeview = function() {

		$(this).children().find('ul').hide();

		$(this).find('li').on('click', function(ev) {
			ev.stopPropagation();
			$(this).children().toggle();
		})

		return $(this);
	}	
}(jQuery));


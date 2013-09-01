(function () {
    "use strict";

    WinJS.UI.Pages.define("/pages/searchedItem/searchedItem.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            Data.getMovieById(options.movieId).done();
        }
    });
})();

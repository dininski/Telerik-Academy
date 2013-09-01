/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
(function () {
    "use strict";
    var apiKey = "t95y7y8admstbtrezh9xbzyr";

    var resultsPerPage = 10;
    var currentPage = 1;
    var country = "us";

    var list = new WinJS.Binding.List();
    var groupedItems = list.createGrouped(
        function groupKeySelector(item) { return item.group.key; },
        function groupDataSelector(item) { return item.group; }
    );

    var infoType = {
        box_office: {
            key: "box_office",
            title: "Box office movies",
            subtitle: "Best box office movies",
            description: "The highest grossing movies in the box office",
            itemSubtitle: "Critics rating: ",
            itemSubtitleField: "ratings.critics_rating",
            itemSubtitleFooter: ""
        },
        upcoming: {
            key: "upcoming",
            title: "Upcoming movies",
            subtitle: "Highly anticipated movies.",
            description: "Some of the upcoming movies from Hollywood",
            itemSubtitle: "Release date: ",
            itemSubtitleField: "release_dates.theater",
            itemSubtitleFooter: ""
        },
        in_theaters: {
            key: "in_theaters",
            title: "Now playing",
            subtitle: "Movies currently playing in theaters.",
            description: "You can see any of these movies now playing in a theater near you",
            itemSubtitle: "Runtime: ",
            itemSubtitleField: "runtime",
            itemSubtitleFooter: " minutes"
        }
    };

    getInfo(resultsPerPage, currentPage, country, infoType.box_office)
        .then(getInfo(resultsPerPage, currentPage, country, infoType.upcoming)
            .then(getInfo(resultsPerPage, currentPage, country, infoType.in_theaters)))
        .done();

    function getInfo(pageLimit, page, country, infoType) {
        return new WinJS.Promise(function () {
            makeGetRequest(
                "http://api.rottentomatoes.com/api/public/v1.0/lists/movies/" +
                infoType.key + ".json?" +
                "page_limit=" + pageLimit +
                "&page=" + page +
                "&country=" + country +
                "&apikey=" + apiKey)
                 .then(function (xhr) {
                     var movieGroup = {
                         key: infoType.key,
                         title: infoType.title,
                         subtitle: infoType.subtitle,
                         description: infoType.description
                     };

                     var responseJson = JSON.parse(xhr.response);
                     var moviesData = responseJson.movies;
                     movieGroup.backgroundImage = moviesData[0].posters.original;

                     if (!moviesData.total || moviesData.total >= page * pageLimit) {
                         for (var i = 0; i < moviesData.length; i++) {
                             var movieItem = moviesData[i];
                             var itemFieldData = eval("movieItem." + infoType.itemSubtitleField) + infoType.itemSubtitleFooter;
                             addMovieToList(
                                 movieGroup,
                                 movieItem,
                                 infoType.itemSubtitle + itemFieldData);
                         }
                     }
                 })
        });
    }

    function addMovieToList(movieGroup, movieItem, subtitle) {
        list.push({
            group: movieGroup,
            title: movieItem.title,
            subtitle: subtitle,
            description: movieItem.synopsis,
            backgroundImage: movieItem.posters.detailed,
            content: movieItem.synopsis
        });
    }

    WinJS.Namespace.define("Data", {
        items: groupedItems,
        groups: groupedItems.groups,
        getItemReference: getItemReference,
        getItemsFromGroup: getItemsFromGroup,
        resolveGroupReference: resolveGroupReference,
        resolveItemReference: resolveItemReference,
        getInfo: getInfo,
        infoTypes: infoType
    });

    // Get a reference for an item, using the group key and item title as a
    // unique reference to the item that can be easily serialized.
    function getItemReference(item) {
        return [item.group.key, item.title];
    }

    // This function returns a WinJS.Binding.List containing only the items
    // that belong to the provided group.
    function getItemsFromGroup(group) {
        return list.createFiltered(function (item) { return item.group.key === group.key; });
    }

    // Get the unique group corresponding to the provided group key.
    function resolveGroupReference(key) {
        for (var i = 0; i < groupedItems.groups.length; i++) {
            if (groupedItems.groups.getAt(i).key === key) {
                return groupedItems.groups.getAt(i);
            }
        }
    }

    // Get a unique item from the provided string array, which should contain a
    // group key and an item title.
    function resolveItemReference(reference) {
        for (var i = 0; i < groupedItems.length; i++) {
            var item = groupedItems.getAt(i);
            if (item.group.key === reference[0] && item.title === reference[1]) {
                return item;
            }
        }
    }

    function makeGetRequest(requestUrl) {
        return WinJS.xhr({
            url: requestUrl
        });
    }
})();

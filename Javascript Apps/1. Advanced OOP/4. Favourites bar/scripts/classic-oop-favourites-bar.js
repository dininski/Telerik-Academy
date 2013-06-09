var Url = Class.create({
    init: function (title, url) {
        this.title = title;
        this.url = url;
    }
});

var Folder = Class.create({
    init: function (title, urls) {
        this.title = title;
        this.urls = urls;
    }
});

var FavouritesBar = Class.create({
    init: function (urls, folders, barContainer) {
        this.urls = urls;
        this.folders = folders;
        this.barContainer = document.querySelector(barContainer);
        this.containerFragment = document.createDocumentFragment();
        this.container = document.createElement('ul');
        this.container.id = "favouritesBar";
        this.containerFragment.appendChild(this.container);
    },
    render: function () {
        for (var i = 0; i < this.urls.length; i++) {
            var currentUrl = this.urls[i];
            var urlContainer = document.createElement('li');
            var link = document.createElement('a');
            link.setAttribute('href', currentUrl.url);
            link.innerHTML = currentUrl.title;
            urlContainer.appendChild(link);
            this.container.appendChild(urlContainer);
        }

        for (var i = 0; i < this.folders.length; i++) {
            var folderListItem = document.createElement('li');
            folderListItem.className = "urlFolderContainer";
            folderListItem.innerHTML = this.folders[i].title;
            var folderContainer = document.createElement('ul');
            folderListItem.appendChild(folderContainer);
            folderContainer.className += " urlFolder";
            for (var j = 0; j < this.folders[i].urls.length; j++) {
                var currentUrl = this.folders[i].urls[j];
                var urlContainer = document.createElement('li');
                var link = document.createElement('a');
                link.setAttribute('href', currentUrl.url);
                link.innerHTML = currentUrl.title;
                urlContainer.appendChild(link);
                folderContainer.appendChild(urlContainer);
                this.container.appendChild(folderListItem);
            }
        }

        this.barContainer.appendChild(this.containerFragment);
    }
})
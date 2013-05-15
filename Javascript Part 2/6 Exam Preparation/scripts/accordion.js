controls = function () {
    var getAccordion = function(identifier) {
        return new Accordion(identifier);
    }

    var buildAccordion = function (container, data) {
        var accordionContainer = getAccordion(container);

        if (data) {
            for (var i = 0; i < data.length; i++) {
                addItem(accordionContainer, data[i]);
            }
        }
        return accordionContainer;
    }

    function addItem(item, dataItem) {
        var accItem = item.add(dataItem.title);
        if (dataItem.items) {
            for (var i = 0; i < dataItem.items.length; i++) {
                addItem (accItem, dataItem.items[i]);
            }
        }
    }

    function Accordion(identifier) {
        var items = [];
        var containerObject = document.querySelector(identifier);
        var itemsList = document.createElement('ul');
        containerObject.appendChild(itemsList);

        this.add = function (title) {
            var webItem = new Item(title);
            items.push(webItem);
            return webItem;
        };

        this.getItemsList = function () {
            return itemsList;
        }

        this.render = function () {

            while (itemsList.firstChild) {
                itemsList.removeChild(itemsList.firstChild);
            }

            var accordionFragment = document.createDocumentFragment();
            for (var i = 0; i < items.length; i++) {
                var subItem = items[i].render();
                accordionFragment.appendChild(subItem);
            }

            itemsList.appendChild(accordionFragment);
            containerObject.appendChild(itemsList);
        };

        itemsList.addEventListener('click', function (ev) {
            var targetElement = ev.target;

            if (targetElement.firstElementChild) {
                if (!ev) {
                    ev = window.event;
                }

                if (targetElement instanceof HTMLLIElement) {
                    ev.stopPropagation();
                    ev.preventDefault();
                    var sameDepthElements = targetElement.parentElement.childNodes;
                    for (var i = 0; i < sameDepthElements.length; i++) {
                        if (sameDepthElements[i].firstElementChild && sameDepthElements[i] != targetElement) {
                            sameDepthElements[i].firstElementChild.style.display = 'none';
                        }
                    }
                    
                    toggleVisibility(targetElement.firstElementChild);
                }
            }
        }, false);

        var toggleVisibility = function (element) {
            if (element.style.display === 'none') {
                element.style.display = 'block';
            } else {
                element.style.display = 'none';
            }
        }

        this.serialize = function () {
            var serializedItems = [];
            for (var i = 0; i < items.length; i++) {
                serializedItems.push(items[i].serialize());
            }
            return serializedItems;
        }
    }

    function Item(title) {

        this.title = title;

        var subItems = [];
        this.add = function (title) {
            var nestedItem = new Item(title);
            subItems.push(nestedItem);
            return nestedItem;
        }

        this.render = function () {
            var currentItem = document.createElement('li');
            currentItem.innerHTML = this.title;
            var subItemsCount = subItems.length;

            if (subItemsCount > 0) {
                var sublist = currentItem.appendChild(document.createElement('ul'));
                sublist.style.display = 'none';

                for (var i = 0; i < subItemsCount; i++) {
                    var child = subItems[i].render();
                    sublist.appendChild(child);
                }
            }
            return currentItem;
        }

        this.serialize = function () {
            var thisItem = {
                title: title
            };

            if (subItems.length > 0) {
                var serializedItems = [];
                for (var i = 0; i < subItems.length; i += 1) {
                    var serItem = subItems[i].serialize();
                    serializedItems.push(serItem);
                }
                thisItem.items = serializedItems;
            }
            return thisItem;
        }
    }

    return {
        getAccordion: getAccordion,
        buildAccordion: buildAccordion,
    }
}();
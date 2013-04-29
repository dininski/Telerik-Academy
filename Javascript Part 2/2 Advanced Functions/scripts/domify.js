var domify = (function () {
    var appendChild = function (elementToAppend, parentElement) {
        var parent = document.querySelector(parentElement);
        parent.appendChild(elementToAppend);
    }

    var removeChild = function (parentElements, elementToRemove) {
        var parents = document.querySelectorAll(parentElements);

        // check if the element to remove is a pseudo element
        if (elementToRemove.indexOf(':') > 0) {
            var pseudoElement = elementToRemove.substr(elementToRemove.indexOf(':') + 1);
            switch (pseudoElement) {
                case 'first':
                    break;
                case 'second':
                    break;
            }
        }
    }

    var addHandler = function (eventElement, eventType, callback) {
        var elementToAddHandlerTo = document.querySelector(eventElement);
        elementToAddHandlerTo.addEventListener(eventType, callback);
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler
    };
})();
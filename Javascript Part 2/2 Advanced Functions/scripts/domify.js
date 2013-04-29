var domify = (function () {
    var appendChild = function (elementToAppend, parentElement) {
        var parent = document.querySelector(parentElement);
        parent.appendChild(elementToAppend);
    }

    var removeChild = function (parents, elementToRemove) {
        var parentElements = document.querySelectorAll(parents);

        // check if the element to remove is a pseudo element
        if (elementToRemove.indexOf(':') > 0) {
            var pseudoElement = elementToRemove.substr(elementToRemove.indexOf(':') + 1);
            var element = elementToRemove.substr(0, elementToRemove.indexOf(':'));
            switch (pseudoElement) {
                case 'first':
                    removeFirstChild(parentElements, element);
                    break;
                case 'last':
                    removeLastChild(parentElements, element);
                    break;
            }
        } else {
            // TODO!!!
        }
    }

    // this method is not exposed to the public
    var removeFirstChild = function (parentElements, elementToRemove) {
        for (var i = 0; i < parentElements.length; i++) {
            var firstElement = parentElements[i].querySelector(elementToRemove);
            parentElements[i].removeChild(firstElement);
        }
    }

    // this method is not exposed to the public
    var removeLastChild = function (parentElements, elementToRemove) {
        for (var i = 0; i < parentElements.length; i++) {
            var allChildren = parentElements[i].querySelectorAll(elementToRemove);
            var pseudoElementToRemove= allChildren[allChildren.length - 1];
            parentElements[i].removeChild(pseudoElementToRemove);
        }
    }

    var addHandler = function (eventElement, event, callback) {
        var elementToAddHandlerTo = document.querySelector(eventElement);
        elementToAddHandlerTo.addEventListener(event, callback);
    }

    // TODO: to finish buffer
    var addToBuffer = function() {
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        addToBuffer: addToBuffer
    };
})();
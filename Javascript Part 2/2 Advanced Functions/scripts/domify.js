var domify = (function () {
    var elementsBuffer = new Array();
    var MAX_BUFFER_SIZE = 100;

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
            for (var i = 0; i < parentElements.length; i++) {
                var allElementsToRemove = parentElements[i].querySelectorAll(elementToRemove);

                for (var j = 0; j < allElementsToRemove.length; j++) {
                    parentElements[i].removeChild(allElementsToRemove[j]);
                }
            }
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
            var pseudoElementToRemove = allChildren[allChildren.length - 1];
            parentElements[i].removeChild(pseudoElementToRemove);
        }
    }

    //a method to add handlers to different elements
    var addHandler = function (eventElement, event, callback) {
        var elementToAddHandlerTo = document.querySelector(eventElement);
        elementToAddHandlerTo.addEventListener(event, callback);
    }

    var addToBuffer = function (containerElement, elementToAppend) {
        if (elementsBuffer[containerElement] == null) {
            elementsBuffer[containerElement] = document.createDocumentFragment();
        }

        elementsBuffer[containerElement].appendChild(elementToAppend);
        
        if (elementsBuffer[containerElement].childNodes.length == MAX_BUFFER_SIZE) {
            var parent = document.querySelector(containerElement);
            parent.appendChild(elementsBuffer[containerElement]);
            elementsBuffer[containerElement] = null;
        }
    }

    var appendElementsFromBuffer = function () {
        for (var container in elementsBuffer) {
            var currentContainer = elementsBuffer[container];
            var domContainer = document.querySelector(container);
            for (var i = 0; i < currentContainer.length; i++) {
                domContainer.appendChild(currentContainer[i]);
            }
        }

        bufferSize = 0;
        elementsBuffer = [];
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        addToBuffer: addToBuffer
    };
})();
var todolify = (function () {
    'use strict';

    var todoList = document.querySelector('#todo-list');

    var addItem = function (date, todoContent) {
        if (!date) {
            throw new Error('A date must be set!');
        }

        if (!todoContent) {
            throw new Error('The content of the todo item cannot be empty!');
        }

        var newItem = document.createElement('option');
        newItem.innerText = date + ': ' + todoContent;
        todoList.appendChild(newItem);
    }

    var removeItem = function () {
        if (todoList.selectedIndex == -1) {
            throw new Error('No item is selected for removal!');
        }

        todoList.removeChild(todoList[todoList.selectedIndex]);
    }

    return {
    	addItem: addItem,
        removeItem: removeItem
    }
})();
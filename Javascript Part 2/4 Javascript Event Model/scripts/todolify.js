var todolify = (function () {
    'use strict';

    var todoList = document.querySelector('#todo-list');
    var hiddenItems = new Array();
    var currentElementId = 0;

    var addItem = function (date, todoContent) {
        if (!date) {
            throw new Error('A date must be set!');
        }

        if (!todoContent) {
            throw new Error('The content of the todo item cannot be empty!');
        }

        var newTodoListItem = document.createElement('div');

        var radioButton = document.createElement('input');
        radioButton.setAttribute('type', 'radio');
        radioButton.setAttribute('id', currentElementId);
        radioButton.setAttribute('name', 'todo list item');
        newTodoListItem.appendChild(radioButton);

        var labelForRadioButton = document.createElement('label');
        labelForRadioButton.setAttribute('for', currentElementId);
        labelForRadioButton.innerHTML = date + ': ' + todoContent;
        newTodoListItem.appendChild(labelForRadioButton);

        currentElementId++;
        todoList.appendChild(newTodoListItem);
    }

    var removeItem = function () {
        if (todoList.selectedIndex == -1) {
            throw new Error('No item is selected for removal!');
        }

        var itemToRemove = getCheckedItem();

        todoList.removeChild(itemToRemove);
    }

    var hideItem = function () {

        var itemToHide = getCheckedItem();

        itemToHide.style.visibility = 'hidden';
        itemToHide.style.position = 'absolute';

        hiddenItems.push(itemToHide);
    }

    var showItems = function () {
        for (var i = 0; i < hiddenItems.length; i++) {
            hiddenItems[i].style.visibility = 'visible';
            hiddenItems[i].style.position = 'static';
        }

        hiddenItems = new Array();
    }

    var getCheckedItem = function () {
        var allItems = todoList.children;
        for (var i = 0; i < allItems.length; i++) {
            if (allItems[i].firstChild.checked) {
                return allItems[i];
            }
        }
    }

    return {
        addItem: addItem,
        removeItem: removeItem,
        hideItem: hideItem,
        showItems: showItems
    }
})();
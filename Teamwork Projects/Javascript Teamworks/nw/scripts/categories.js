var categories = (function () {
    var categoryStorage;
    var categorySaveName = "categories";
    var expenses;
    var expensesSaveName = "expenses";

    var init = function() {
        categoryStorage = storage.load(categorySaveName);
        expenses = storage.load(expensesSaveName);
        
        if (expenses === undefined || expenses === {}) {
            createDefaultCategoryStorage();
        };
    }

    var addCategory = function (categoryName) {

        if (categoryStorage[categoryName] === null) {

            categoryStorage[categoryName] = [];
            categoryStorage[categoryName].push("none");
            storage.save(categorySaveName, categoryStorage);

            expenses[categoryName] = {};
            expenses[categoryName]["none"] = [];
            storage.save(expensesSaveName, expenses);
        };
    }

    var createDefaultCategoryStorage = function () {
        createStorage();
        createCategoryStorage();
    }

    function createCategoryStorage() {
        var categoryStorageTemplate = {
            foodAndGroceries: ["fastFood", "restaurantFood", "groceries", "none"],
            entertainment: ["cinema", "bars", "discos", "vacations", "none"],
            medical: ["medicines", "dentist", "doctor", "none"],
        }

        storage.save(categorySaveName, categoryStorage);
    }

    function createStorage() {

        var expensesTemplate = {

            foodAndGroceries: {
                fastFood: [],
                restaurantFood: [],
                groceries: [],
                none: [],
            },

            entertainment: {
                cinema: [],
                bars: [],
                discos: [],
                vacations: [],
                none: [],
            },

            medical: {
                medicines: [],
                dentist: [],
                doctor: [],
                none: [],
            }
        }

        storage.save(expensesSaveName, expensesTemplate);
    }


    var addSubCategory = function (category, subCategory) {

        if (categoryStorage[category][subCategory] == null) {

            categoryStorage[category].push(subCategory);
            storage.save(expensesSaveName, categoryStorage);

            expenses[category][subCategory] = [];
            storage.save(expensesSaveName, expenses);
        };
    }

    var deleteCategory = function (category) {

        if (categoryStorage[category] != null) {
            delete categoryStorage[category];
            delete expenses[category];
            storage.save(expensesSaveName, categoryStorage);
            storage.save(expensesSaveName, expenses);
        };
    }

    var deleteSubCategory = function (category, subCategory) {

        var element = categoryStorage[category].indexOf(subCategory);
        categoryStorage[category].splice(element, 1);

        delete expenses[category][subCategory];
        storage.save(categorySaveName, categoryStorage);
        storage.save(expensesSaveName, expenses);
    }

    var getAllCategories = function () {
        var result = [];

        for (var category in categoryStorage) {
            result.push(category);
        }

        return result;
    }

    var getAllSubCategories = function (category) {
        return categoryStorage[category];
    }

    return {
        init: init,
        addCategory: addCategory,
        createDefaultCategoryStorage: createDefaultCategoryStorage,
        addSubCategory: addSubCategory,
        deleteCategory: deleteCategory,
        deleteSubCategory: deleteSubCategory,
        getAllCategories: getAllCategories,
        getAllSubCategories: getAllSubCategories
    }
}())
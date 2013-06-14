var categories = (function () {

    var addCategory = function (categoryName) {
        // if (storage.load("categories") == null) {
        // 	createCategoryStorage();
        // };

        var categoryStorage = storage.load("categories");

        if (categoryStorage[categoryName] == null) {

            categoryStorage[categoryName] = [];
            categoryStorage[categoryName].push("none");
            storage.save("categories", categoryStorage);

            var expenses = storage.load("expenses");
            expenses[categoryName] = {};
            expenses[categoryName]["none"] = [];
            storage.save("expenses", expenses);
        };
    }

    var createDefaultCategoryStorage = function () {
        if (storage.load("expenses") == null) {
            createStorage();
            createCategoryStorage();
        };
    }

    function createCategoryStorage() {
        var categoryStorage = {
            foodAndGroceries: ["fastFood", "restaurantFood", "groceries", "none"],
            entertainment: ["cinema", "bars", "discos", "vacations", "none"],
            medical: ["medicines", "dentist", "doctor", "none"],
        }

        storage.save("categories", categoryStorage);
    }

    function createStorage() {

        var expenses = {

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

        storage.save("expenses", expenses);
    }


    var addSubCategory = function (category, subCategory) {

        var categoryStorage = storage.load("categories");

        if (categoryStorage[category][subCategory] == null) {

            categoryStorage[category].push(subCategory);
            storage.save("categories", categoryStorage);

            var expenses = storage.load("expenses");
            expenses[category][subCategory] = [];
            storage.save("expenses", expenses);
        };
    }

    var deleteCategory = function (category) {
        var categories = storage.load("categories");
        var expenses = storage.load("expenses");

        if (categories[category] != null) {
            delete categories[category];
            delete expenses[category];
            storage.save("categories", categories);
            storage.save("expenses", expenses);
        };
    }

    var deleteSubCategory = function (category, subCategory) {
        var categories = storage.load("categories");
        var expenses = storage.load("expenses");

        var element = categories[category].indexOf(subCategory);
        categories[category].splice(element, 1);

        delete expenses[category][subCategory];
        storage.save("categories", categories);
        storage.save("expenses", expenses);
    }

    var getAllCategories = function () {
        var result = [];
        var categories = storage.load("categories");
        for (var category in categories) {
            result.push(category);
        }

        return result;
    }

    var getAllSubCategories = function (category) {
        var result = [];
        var categories = storage.load("categories");

        return categories[category];
    }

    return {
        addCategory: addCategory,
        createDefaultCategoryStorage: createDefaultCategoryStorage,
        addSubCategory: addSubCategory,
        deleteCategory: deleteCategory,
        deleteSubCategory: deleteSubCategory,
        getAllCategories: getAllCategories,
        getAllSubCategories: getAllSubCategories

    }

}())
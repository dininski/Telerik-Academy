var categories = (function () {
    var categoryStorage;
    var categoryStorageName = 'categories';
    var expenses;
    var expensesStorageName = 'expenses';

    var init = function() {
        categoryStorage = storage.load(categoryStorageName);
        expenses = storage.load(expensesStorageName);
        if (expenses === null || expenses === undefined) {
            createDefaultCategoryStorage();
        }

        expenses = storage.load(expensesStorageName);
    }

    var addCategory = function (categoryName) {

        if (categoryStorage[categoryName] == null) {

            categoryStorage[categoryName] = [];
            categoryStorage[categoryName].push("none");
            storage.save(categoryStorageName, categoryStorage);

            expenses[categoryName] = {};
            expenses[categoryName]["none"] = [];
            storage.save(expensesStorageName, expenses);
        };
    }

    var createDefaultCategoryStorage = function () { 
            createStorage();
            createCategoryStorage();
    }

    function createCategoryStorage() {
        var categoryStorage = {
            home: ["rent", "appliances", "renovation"],
            utilities: ["electricity", "heating", "water", "phone", "cellPhone", "internet"],
            foodAndGroceries: ["fastFood", "restaurantFood", "groceries"],
            entertainment: ["cinema", "bars", "discos", "vacations"],
            medical: ["medicines", "dentist", "doctor"],
        }

        storage.save(categoryStorageName, categoryStorage);
    }

    function createStorage() {

        var expenses = {

            home: {
                rent: [],
                furnishing: [],
                appliances: [],
                renovation: [],
            },

            utilities: {
                electricity: [],
                heating: [],
                water: [],
                phone: [],
                cellPhone: [],
                internet: [],
            },

            foodAndGroceries: {
                fastFood: [],
                restaurantFood: [],
                groceries: [],
            },

            entertainment: {
                cinema: [],
                bars: [],
                discos: [],
                vacations: [],
            },

            medical: {
                medicines: [],
                dentist: [],
                doctor: [],
            }
        }

        var allTimeExpenses = expenses;
        storage.save("expenses", expenses);
        storage.save("allTimeExpenses", allTimeExpenses);
    }

    // done up to here
    var addSubCategory = function (category, subCategory) {

        if (categoryStorage[category][subCategory] == null) {

            categoryStorage[category].push(subCategory);
            storage.save(categoryStorageName, categoryStorage);

            var expenses = storage.load("expenses");
            expenses[category][subCategory] = [];
            storage.save(expensesStorageName, expenses);
        };
    }

    var deleteCategory = function (category) {
        if (categoryStorage[category] != null) {
            delete categoryStorage[category];
            delete expenses[category];
            storage.save(categoryStorageName, categoryStorage);
            storage.save(expensesStorageName, expenses);
        };
    }

    var deleteSubCategory = function (category, subCategory) {

        var element = categoryStorage[category].indexOf(subCategory);
        categoryStorage[category].splice(element, 1);

        delete expenses[category][subCategory];
        storage.save(categoryStorageName, categoryStorage);
        storage.save(expensesStorageName, expenses);
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
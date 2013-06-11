var homeBudget = (function () {
    var addIncomes = function (month, year) {
        var key = "income" + "-" + month + "-" + year;
        var value = accounts.getAllIncomesSum(year, month);
        storage.save(key, value);
    };

    var getIncomes = function (month, year) {
        var key = "income" + "-" + month + "-" + year;
        return storage.load(key);
    };

    function removeBudgetItem(type, month, year) {
        var key = type + "-" + month + "-" + year;
        storage.remove(key);        
    }    

    var addExpenses = function (month, year) {
        var key = "expenses" + "-" + month + "-" + year;
        var value = expenses.getAllExpensesSum(year, month);
        storage.save(key, value);
    };

    var getExpenses = function (month, year) {
        var key = "expenses" + "-" + month + "-" + year;
        return storage.load(key);
    };

    var addBudget = function (month, year) {
        var key = "budget" + "-" + month + "-" + year;
        var value = getIncomes(month, year) - getExpenses(month, year);
        storage.save(key, value);
    };

    var getBudget = function (month, year) {
        var key = "budget" + "-" + month + "-" + year;
        return storage.load(key);
    };

    return {
        addIncomes: addIncomes,
        getIncomes: getIncomes,
        removeBudgetItem: removeBudgetItem,
        addExpenses: addExpenses,
        getExpenses: getExpenses,
        addBudget: addBudget,
        getBudget: getBudget,
    }
}());
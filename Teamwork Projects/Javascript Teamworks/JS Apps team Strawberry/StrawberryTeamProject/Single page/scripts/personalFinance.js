var personalFinance = angular.module("personalFinance", []);

personalFinance.config(function($routeProvider, $locationProvider){
    
    $locationProvider.html5Mode(true);

    $routeProvider.when('/', {
      title: "Home",
      header: "Personal Finance Single Page App",
      footer: "Made by team Strawberry",
      templateUrl: 'templates/home.html',
      controller: 'HomeController'
  });
  
    $routeProvider.when('/addAccount', {
      header: 'Add new account',
      templateUrl: 'templates/addAccount.html',
      controller: 'AccountsController'
  });

    $routeProvider.when('/expenses', {
      header: 'Expenses ordered by account',
      templateUrl: 'templates/expenses.html',
      controller: 'ExpensesController'
  });

    $routeProvider.when('/categories', {
      header: 'Categories',
      templateUrl: 'templates/categories.html'
    });

  $routeProvider.otherwise({redirectTo: '/'});

});

personalFinance.controller('HomeController', function($scope, $location) {

	$scope.goToAccounts = function() {
		$location.path('/addAccount');
	}

  $scope.goToCategories = function() {
    $location.path('/categories');
  }

  $scope.goToExpenses = function() {
    $location.path('/expenses');
  }
});

personalFinance.controller('AccountsController', function($scope, $location) {

})

personalFinance.controller('ExpensesController', function($scope, $location) {
  $scope.addAccount = function() {
    $location.path('/addAccount');
  }
})

personalFinance.run(['$location', '$rootScope', function($location, $rootScope) {
    $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {
        if (current.$$route) {
          $rootScope.title = current.$$route.title || "Personal Finance Single Page App";
          $rootScope.header = current.$$route.header || "Personal Finance Single Page App";
          $rootScope.footer = current.$$route.footer || "Made by team Strawberry";
        };
    });
}]);

personalFinance.directive('renderMobile', function($timeout) {
  return {
    restrict: 'A',
    link: function(scope, element, attrs) {
      $timeout(function() {
        $('body').trigger('create');
      }, 5);
    }
  }
});

// personalFinance.directive('backButton', function($window) {
//   return {
//     restrict: 'A',
//     link: function(scope, element, attrs) {
//         $(element).on('click', function() {
//           $window.history.back();
//         })
//     }
//   }
// });

personalFinance.directive('datePicker', function($timeout, $location) {
  return {
    restrict: 'A',
    link: function(scope, element, attrs) {
      $timeout(function() {
        $(element).datepicker();
        drawAddCards();
        $('body').trigger('create');
        addCardHandlers(scope, $location);
      }, 5);
    }
  }
});

personalFinance.directive('categoriesRenderer', function($timeout) {
  return {
    restrict: 'A',
    link: function(scope, element, attrs) {
      $timeout(function() {
        drawCategories();
        $('body').trigger('create');
      }, 5);
    }
  }
});

personalFinance.directive('expensesRenderer', function($timeout) {
  return {
    restrict: 'A',
    link: function(scope, element, attrs) {
      $timeout(function() {
        drawExpenses();
        $('body').trigger('create');
      }, 5);
    }
  }
});

personalFinance.directive('addCardRenderer', function($timeout) {
  return {
    restrict: 'A',
    link: function(scope, element, attrs) {
      $timeout(function() {
        drawAddCards();
        $('body').trigger('create');
      }, 5);
    }
  }
});

var drawCategories = function() {
  var allCategories = categories.getAllCategories();

    for (var i = 0; i < allCategories.length; i++) {
        var category = allCategories[i];

        $collapse = $('<div></div>')
    .attr({ 'data-role': "collapsible", 'data-collapsed': false })
      .append($('<h3></h3>')
          .text(category)//acc type
      )

        $ul = $('<ul></ul>')
               .attr({ 'data-role': "listview", 'data-divider-theme': "b", 'data-inset': "true" });

        var allSubCat = categories.getAllSubCategories(category);

        for (var j = 0; j < allSubCat.length; j++) {
            var subCat = allSubCat[j];

            $ul.append($('<li></li>')
          .attr({ 'data-theme': "c" })
          .append($('<a></a>')
            .attr({ 'data-transition': "slide" })
            .text(subCat)
          )
        )
            $collapse.append($ul);
        }

        $li = $('<li></li>')
              .attr({ 'data-theme': "c" })
              .addClass('not-added-item')
              .on('click', { category: category }, function (event) {
                  $(this).find('.ui-link-inherit').toggle();
                  $(this).find('#newCategoryField').toggle().focus();
              })
              .append($('<a></a>')
                  .attr({ 'data-transition': "slide" })
                  .css("color", "green")
                  .text("add new subcategory")
              ).append("<input id='newCategoryField' type='text' placeholder='New Subcategory here' style='display: none'/>")
                    .on('keydown', { category: this.parent.parent.data }, function (event) {
                        if (event.keyCode == 13) {
                            console.log(category);
                            var catField = $(this).find('#newCategoryField');
                            if (catField.val().length > 1) {                                    // TODO check input !
                                // categories.addSubCategory(category, catField.val());
                                var prevClone = $(this).prev().clone();
                                $(this).before(prevClone);
                                prevClone.find('.ui-link-inherit').text(catField.val());
                                $(this).find('a').show();
                                catField.val('');
                                catField.hide();
                            };
                        };
                    })

        $ul.append($li);
        $collapse.append($ul);

        $("#acc-container").append($collapse);
    }

    $ul = $('<ul></ul>')
               .attr({ 'data-role': "listview", 'data-divider-theme': "b", 'data-inset': "true" })
               .css("margin-top", "0px");
    $ul.append($('<li></li>')
               .attr({ 'data-theme': "c" })
               .addClass('not-added-item')
               .on('click', function () {
                   console.log("wtf");
               })
               .append($('<a></a>')
                   .attr({ 'data-transition': "slide" })
                   .css("color", "green")
                   .text("add new subcategory")
               )
           )

    $("#acc-container").append($ul);
};

var drawAddCards = function() {
  var allAccounts = storage.load("accounts");
      var totalBalance = accounts.totalBalance();
      
      $("#totalBalance").text(totalBalance).css({ 'font-size': "14px", 'color': "#61B329", 'text-shadow': "text-shadow: 1px 1px 0px green" });

      $("#add-new-account-button").on('click', function(){
        location.href="addAccount.html";
      })

      for (var type in allAccounts) {

          var accType = accounts.accTypeParser(type);
          var totalBalance = accounts.totalBalance(type);

          $collapse = $('<div></div>')
      .attr({ 'data-role': "collapsible", 'data-collapsed': false })
        .append($('<h3></h3>')
            .text(accType)//acc type
            .append($('<span></span>')
              .text("$" + totalBalance)//acc type total sum
                .addClass("totalAccountsSum")
            )
        )

          $ul = $('<ul></ul>')
                   .attr({ 'data-role': "listview", 'data-divider-theme': "b", 'data-inset': "true" });
          for (var i = 0; i < allAccounts[type].length; i++) {
              var accName = allAccounts[type][i].name;
              var accBalance = allAccounts[type][i].balance;

              $ul.append($('<li></li>')
            .attr({ 'data-theme': "c" })
            .append($('<a></a>')
              .attr({ 'data-transition': "slide" })
              .text(accName)
              .append($('<span></span>')
                .text("$" + Number(accBalance).toFixed(2))
              )
            ).on('click', { type: type, accName: accName }, function (event) {
                var go = "expensesByAccount.html?type=" + event.data.type + "&accName=" + event.data.accName;
                location.href = go;
            })
          )
              $collapse.append($ul);
          }
          $("#acc-container").append($collapse);
      }
}

var drawExpenses = function() {

    var allAccounts = storage.load("accounts");
    var totalBalance = accounts.totalBalance();
    
    //$("#totalBalance").text(totalBalance).css({ 'font-size': "14px", 'color': "#61B329", 'text-shadow': "text-shadow: 1px 1px 0px green" });

    $("#add-new-account-button").on('click', function(){
      location.href="AddAccount.html";
    })

    for (var type in allAccounts) {

        var accType = accounts.accTypeParser(type);
        var totalBalance = accounts.totalBalance(type);

        $collapse = $('<div></div>')
    .attr({ 'data-role': "collapsible", 'data-collapsed': false })
      .append($('<h3></h3>')
          .text(accType)//acc type
          .append($('<span></span>')
            .text("$" + totalBalance)//acc type total sum
              .addClass("totalAccountsSum")
              .css('float', 'right')
          )
      )

        $ul = $('<ul></ul>')
                 .attr({ 'data-role': "listview", 'data-divider-theme': "b", 'data-inset': "true" });
        for (var i = 0; i < allAccounts[type].length; i++) {
            var accName = allAccounts[type][i].name;
            var accBalance = allAccounts[type][i].balance;

            $ul.append($('<li></li>')
          .attr({ 'data-theme': "c" })
          .append($('<a></a>')
            .attr({ 'data-transition': "slide" })
            .text(accName)
            .append($('<span></span>')
              .text("$" + Number(accBalance).toFixed(2))
              .css('float', 'right')
            )
            .attr({'ng-click':'getAccountData()'})  
          )
        )
            $collapse.append($ul);
        }
        $("#acc-container").append($collapse);
    }
}

var addCardHandlers = function(scope, $location) {
  $("#addCardButton").on('click', function(){
        var type = $('#type').val();
        var accName = $('#name').val();
        var balance = $('#balance').val();
        var date = $('#datepicker').val();
        accounts.addAccount(type, accName, Number(balance), date);
        scope.$apply(function() {
          $location.path('/expenses');
        })
    })
}
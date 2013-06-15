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
      header: 'Manage accounts',
      templateUrl: 'templates/expenses.html',
      controller: 'ExpensesController'
  });

    $routeProvider.when('/categories', {
      header: 'Categories',
      templateUrl: 'templates/categories.html'
    });

    $routeProvider.when('/charts', {
      header: 'Budget charts',
      templateUrl: 'templates/chart.html'
    });

  $routeProvider.otherwise({redirectTo: '/'});

});

personalFinance.controller('HomeController', function($scope, $location) {

  $scope.expenses = "Manage accounts";
  $scope.categories = "Manage categories";
  $scope.charts = "Generate financial stats";

  $scope.goToCategories = function() {
    $location.path('/categories');
  }

  $scope.goToExpenses = function() {
    $location.path('/expenses');
  }

  $scope.goToCharts = function() {
    $location.path('/charts');
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
      var total = accounts.totalBalance();
      
      $("#totalBalance").text(total).css({ 'font-size': "14px", 'color': "#61B329", 'text-shadow': "text-shadow: 1px 1px 0px green" });

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
      var total = accounts.totalBalance();

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

        var totals = $('<div id="totalBalance"></div>');
        var totalsElement = $(totals);
      totalsElement.text('Total: ' + total).css({
        'text-shadow': "text-shadow: 1px 1px 0px green",
        'margin' : '0',
        'padding' : '10px',
        'text-align' : 'center'
      }).addClass('ui-bar-a');

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
                .append($('<span class="ui-btn-up-a ui-btn-corner-all" style="margin: 0 5px; padding: 7px;">delete</span>'))
                .on('click', { type: type, accName: accName }, function (event) {
                  var accountName = event.data.accName;
                  var accountType = event.data.type;
                  accounts.deleteAccount(accountType, accountName);
                  var cardBlock = $(this).parent().parent().parent().parent();
                  cardBlock.parent().parent().parent()
                    .find('.totalAccountsSum').first().text(accounts.totalBalance(accountType));
                  cardBlock.remove();
                  totalsElement.text('Total: '+accounts.totalBalance());
                })
              )
            )
          )
              $collapse.append($ul);
          }
          $("#acc-container").append($collapse);
      }



     $transferDiv = $('<div></div>')
          .attr({'data-role': "content"})
          .css('text-align', "center")
          .css('margin-top', "10px")
          .append($('<button id="transfer-funds-button"></button>')
            .attr({'data-role': 'content', "data-inline": 'true', 'data-theme': 'a'})
            .text("Transfer Funds")
            .css('color', 'black')
            .css('border-radius', '10px')
            .css('cursor', 'pointer')
            ).on('click', function(){
              $("#transfer-funds-div").fadeIn(1500)
              $("#transfer-funds-button").parent().css('display', 'none');
            })


          $transferDivInside = $("<div id='transfer-funds-div' style='margin-top: 20px; display: none'></div>")
            .append($('<div data-role="fieldcontain"></div>'))

      $labelTransferFrom = $('<label for="select-menu-from-acc"></label>').text("From:");
      $labelTransferTo = $('<label for="select-menu-to-acc"></label>').text("To:");

      $selectTransferFrom = $('<select id="select-menu-from-acc"></select>')
      $selectTransferTo = $('<select id="select-menu-to-acc"></select>')

      for(var type in allAccounts){
         for (var i = 0; i < allAccounts[type].length; i++) {
          var accName = allAccounts[type][i].name;
           $option = $('<option></option>');
           $option.text(accName);
           $option.val(type + '/' + accName);
           $selectTransferFrom.append($option);
           $selectTransferTo.append($option.clone());
         };
      }

      $amountLabel = $('<label for="transferAmount"></label>').text("Amount:");
      $amountInput = $('<input id="transferAmount" placeholder="Amount here" type="text" />')
      $transferButton = $('<a data-role="button">Transfer</a>').on('click',{accounts: accounts}, function(event){
        $valueFrom = $("#select-menu-from-acc").val();
        $typeFrom = $valueFrom.split('/')[0];
        $nameFrom = $valueFrom.split('/')[1];

        $valueTo = $("#select-menu-to-acc").val();
        $typeTo = $valueTo.split('/')[0];
        $nameTo = $valueTo.split('/')[1];

        $amount = $("#transferAmount").val(); 
          event.data.accounts.makeTransfer($typeFrom, $nameFrom, Number($amount), $typeTo, $nameTo);
      })

      $transferDivInside.append($labelTransferFrom);
      $transferDivInside.append($selectTransferFrom);
      $transferDivInside.append($labelTransferTo);
      $transferDivInside.append($selectTransferTo);
      $transferDivInside.append($amountLabel);
      $transferDivInside.append($amountInput);
      $transferDivInside.append($transferButton);
      $transferDiv.append($transferDivInside);
      $("#acc-container").after($transferDiv);
      $($transferDiv).before(totals);
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
var app = angular.module("personalFinance", []);

app.config(function($routeProvider){

    $routeProvider.when('/', {
    templateUrl: 'templates/home.html',
    controller: 'HomeController'
  });

    $routeProvider.when('/addAccount', {
    	templateUrl: 'templates/addAccount.html',
    	controller: 'AccountsController'
  });
});

app.controller('HomeController', function($scope, $location) {
	$scope.goToAccounts = function() {
		$location.path('/addAccount');
	}
});

app.controller('AccountsController', function($scope, $location) {
	$scope.goBack = function() {
		  window.history.back();
	}
})
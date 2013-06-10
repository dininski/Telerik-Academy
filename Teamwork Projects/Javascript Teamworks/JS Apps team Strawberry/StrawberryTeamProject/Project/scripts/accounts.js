var accounts = (function() {


	var addAccount = function(type, accName, balance, expireDate){
		if (storage.load("accounts") == null) {
			createStorage();
		};

		var accounts = storage.load("accounts");

		if (!accNameExists(accounts[type], accName)) {
			if (isNumber(balance)) {
				var account = {
					name: accName, balance: balance, expireDate: expireDate
				}

				accounts[type].push(account);
				storage.save("accounts", accounts);
			} else {
				alert("Balance should be a number");
			}
		} else {
			alert("Card name already exists. Please choose another name !");
		}
	}

	function accNameExists(arr, accName){
		var exists = false;

		for (var i = 0; i < arr.length; i++) {
			if (arr[i].name == accName) {
				exists = true;
				break;
			};
		};

		return exists;
	}

	function createStorage(){
		var accounts = {
			debit:[],
			credit:[],
			bank:[],
		}

		storage.save("accounts", accounts);
	}

	var makePayment = function(accType, accName, amount){  
		var accounts = storage.load("accounts");
		for (var i = 0; i < accounts[accType].length; i++) {
			if (accounts[accType][i].name == accName) {
				accounts[accType][i].balance -= amount;
				console.log(accounts[accType][i].name +  " payment - " + amount);
				break;
			};
		}; 
		storage.save("accounts", accounts);
	}

	var totalBalance = function(accType){
		if (arguments.length == 0) {
			return getAllAccBalance();
		};

		if (arguments.length == 1) {
			return getAccTypeBalance(accType);
		};
	}

	function getAllAccBalance(){
		var accounts = storage.load("accounts");
		var balance = 0;

		for(var k in accounts){
			for (var i = 0; i < accounts[k].length; i++) {
				balance += accounts[k][i].balance;
			};
		}

		return balance;
	}

	function getAccTypeBalance(accType){
		var accounts = storage.load("accounts");
		var balance = 0;

		for (var i = 0; i < accounts[accType].length; i++) {
			balance += accounts[accType][i].balance;
		};

		return balance;
	}

	var addFunds = function(accType, accName, amount){
		var accounts = storage.load("accounts");
		var accNameFound = false;
		for (var i = 0; i < accounts[accType].length; i++) {
			if (accounts[accType][i].name == accName) {
				accNameFound = true;
				if (isNumber(amount) && isPositiveNumber(amount)) {
					accounts[accType][i].balance += amount;
					console.log(accounts[accType][i].name + " - $" + amount + " added");
					storage.save("accounts", accounts);
				} else {
					alert("Amount should be a positive number !");
				}
				break;
			};
		};
		if (!accNameFound) {
			alert("Account name does not exist !");
		};
	}

	function isNumber(n) {
	  return !isNaN(parseFloat(n)) && isFinite(n);
	}

	function isPositiveNumber(n) {
		return n > 0;
	}

	return{
		addAccount: addAccount,
		makePayment: makePayment,
		totalBalance: totalBalance,
		addFunds: addFunds,


	}

}())
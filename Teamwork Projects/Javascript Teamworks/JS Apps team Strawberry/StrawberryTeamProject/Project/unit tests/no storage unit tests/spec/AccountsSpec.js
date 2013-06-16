describe("Accounts", function() {
  accounts.init();
  var accountInformation;

        // addAccount +
        // makePayment +
        // totalBalance
        // addFunds
        // getAllIncomesSum
        // makeTransfer
        // deleteAccount
        // accTypeParser
        
    beforeEach(function() {
    	storage.clear();
    	accounts.init();
    	accountInformation = {
			type: 'debit',
			accName: 'test debit',
			balance: 2000,
			expireDate: "10/10/2010",
		};
    });

  	describe("adds and account", function() {
  		it("when account has valid amount and type", function() {
  			

  			accounts.addAccount(accountInformation.type, accountInformation.accName,
  							accountInformation.balance, accountInformation.expireDate);

  			var entireAccountsStorage = storage.load('accounts');

  			var actualtResult = entireAccountsStorage[accountInformation.type][0];

  			expect(actualtResult.name).toEqual(accountInformation.accName);
  			expect(actualtResult.balance).toEqual(accountInformation.balance);
  			expect(actualtResult.expireDate).toEqual(accountInformation.expireDate);
  		});

  		it("when entering negative amount for debit card", function() {
  			accountInformation.balance = -100;

  			var testInvalidBalance = function() {
  				accounts.addAccount(accountInformation.type, accountInformation.accName,
  									accountInformation.balance, accountInformation.expireDate);
  			}

  			expect(testInvalidBalance)
  				.toThrow(new Error("Balance should be a positive number!"));
  		})
  	})

	describe("makes a payment", function() {
		//accType, accName, amount
		describe("when balance > withdrawal amount", function() {
				it("deducts the amount from the accont", function() {

				var withdrawalAmount = 300;

				accounts.addAccount(accountInformation.type, accountInformation.accName,
								accountInformation.balance, accountInformation.expireDate);

				expect(accounts.makePayment(accountInformation.type, accountInformation.accName, withdrawalAmount))
					.toBeTruthy();

				var allAccounts = storage.load('accounts');
				var actualBalance = allAccounts[accountInformation.type][0].balance;
				expect(actualBalance).toEqual(accountInformation.balance - withdrawalAmount);
			});
		})

		describe("when withdrawal amount > balance", function() {
				it("does not deduct any amount from the accont", function() {

				var withdrawalAmount = accountInformation.balance + 300;

				accounts.addAccount(accountInformation.type, accountInformation.accName,
								accountInformation.balance, accountInformation.expireDate);

				var invalidOperation = function() {
					accounts.makePayment(accountInformation.type, accountInformation.accName, withdrawalAmount)
				};

				expect(invalidOperation).toThrow(new Error("Insufficient funds in the account!"));

				var allAccounts = storage.load('accounts');
				var actualBalance = allAccounts[accountInformation.type][0].balance;
				expect(actualBalance).toEqual(accountInformation.balance);
			});
		})
	})
});
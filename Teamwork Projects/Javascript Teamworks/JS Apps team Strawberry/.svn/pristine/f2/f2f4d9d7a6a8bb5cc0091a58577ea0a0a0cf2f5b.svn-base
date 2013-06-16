describe("Accounts", function() {
  accounts.init();
  var initialBalance = 2000;
  var defaultDebitCardName = 'dummy debit card';
  var debitCardType = 'debit';
  var accountInformation;
        
    beforeEach(function() {
    	storage.clear();
    	accounts.init();
    	accountInformation = {
			type: debitCardType,
			accName: defaultDebitCardName,
			balance: initialBalance,
			expireDate: "10/10/2010",
		};
    });

  	describe("adds an account to the storage", function() {
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

  describe("calculates the total balance", function() {
    it("balance is valid", function() {
      accounts.addAccount(accountInformation.type, accountInformation.accName,
                accountInformation.balance, accountInformation.expireDate);

      accountInformation.accName = 'second account';
      accountInformation.balance = 100;
      accountInformation.type = 'credit';

      accounts.addAccount(accountInformation.type, accountInformation.accName,
                accountInformation.balance, accountInformation.expireDate);

      var fullBalance = accounts.totalBalance();

      expect(fullBalance).toEqual(initialBalance + accountInformation.balance);
    })
  }) 

  describe("adds funds to an account", function() {
    it("amount of 100", function() {
      accounts.addAccount(accountInformation.type, accountInformation.accName,
                accountInformation.balance, accountInformation.expireDate);

      accounts.addFunds(accountInformation.type, accountInformation.accName,
        100, '2/2/2012');

      allAccounts = storage.load('accounts');
      var actualCardBalance = allAccounts[accountInformation.type][0].balance;
      expect(actualCardBalance).toEqual(2100);
    });
  })

  describe('transfers from one account to another', function() {
    it("moves the funds", function() {

      accounts.addAccount(accountInformation.type, accountInformation.accName,
                accountInformation.balance, accountInformation.expireDate);

      accounts.addAccount('credit', 'dummy credit card account',
                800, accountInformation.expireDate);

      accounts.makeTransfer(accountInformation.type, accountInformation.accName,
                500, 'credit', 'dummy credit card account');

      allAccounts = storage.load('accounts');
      var actualDebitCardBalance = allAccounts[accountInformation.type][0].balance;
      var actualCreditCardBalance = allAccounts['credit'][0].balance;

      expect(actualDebitCardBalance).toEqual(1500);
      expect(actualCreditCardBalance).toEqual(1300);
    })
  })

  describe('deletes an account', function() {
    it('deletes an account',function() {

      accounts.addAccount(accountInformation.type, accountInformation.accName,
                accountInformation.balance, accountInformation.expireDate);

      accounts.deleteAccount(accountInformation.type, accountInformation.accName);

      allAccounts = storage.load('accounts');
      var actualCard = allAccounts[accountInformation.type][0];

      expect(actualCard).toEqual(null);
    })
  })
});
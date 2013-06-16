describe("Categories", function() {
	storage.save('categories', []);
	categories.init();
    
    beforeEach(function() {
		storage.clear();
		storage.save('categories', []);
    })

	it('adds a category', function() {
		categories.addCategory('dummy name');
		var dummyCategory = storage.getStorage().categories;
		expect(dummyCategory['dummy name']).toBeDefined();
	})

	it('creates a default set ot categories', function() {
		categories.createDefaultCategoryStorage();
		var allCategories = storage.getStorage().categories;
		expect(allCategories['home']).toBeDefined();
		expect(allCategories['utilities']).toBeDefined();
		expect(allCategories['foodAndGroceries']).toBeDefined();
		expect(allCategories['entertainment']).toBeDefined();
		expect(allCategories['medical']).toBeDefined();

		expect(allCategories['home'].length).toEqual(3);
		expect(allCategories['utilities'].length).toEqual(6);
		expect(allCategories['foodAndGroceries'].length).toEqual(3);
		expect(allCategories['entertainment'].length).toEqual(4);
		expect(allCategories['medical'].length).toEqual(3);
	})

	it('adds subcategories', function() {
		categories.addCategory('main');
		categories.addSubCategory('main', 'sub');

		var allCategories = storage.getStorage().categories;

		expect(allCategories['main'].length).toEqual(2);
		expect(allCategories['main'][1]).toEqual('sub');
	})

	it('returns all categories', function() {
		storage.clear();
		categories.createDefaultCategoryStorage();
		categories.init();
		var allCats = categories.getAllCategories();
		
		expect(allCats.length).toEqual(5);
		expect(allCats[0]).toEqual('home');
		expect(allCats[1]).toEqual('utilities');
		expect(allCats[2]).toEqual('foodAndGroceries');
		expect(allCats[3]).toEqual('entertainment');
		expect(allCats[4]).toEqual('medical');
	})

	it('returns all subcategories', function() {
		storage.clear();
		categories.createDefaultCategoryStorage();
		categories.init();

		var allSubcats = categories.getAllSubCategories('home');

		expect(allSubcats.length).toEqual(3);
		expect(allSubcats[0]).toEqual('rent');
		expect(allSubcats[1]).toEqual('appliances');
		expect(allSubcats[2]).toEqual('renovation');
	})

	it('deletes a category', function() {
		storage.clear();
		categories.createDefaultCategoryStorage();
		categories.init();

		var allCatsBeforeRemoval = storage.load('categories');
		expect(allCatsBeforeRemoval['home']).toBeDefined();

		categories.deleteCategory('home');

		var allCatsAfterRemoval = storage.load('categories');
		expect(allCatsAfterRemoval['home']).toBeUndefined();
	})

	it('deletes a subcategory', function() {
		storage.clear();
		categories.createDefaultCategoryStorage();
		categories.init();

		var subcatsBeforeRemoval = categories.getAllSubCategories('utilities');
		expect(subcatsBeforeRemoval.length).toEqual(6);
		expect(subcatsBeforeRemoval[2]).toEqual('water');

		categories.deleteSubCategory('utilities', 'water');
		expect(subcatsBeforeRemoval.length).toEqual(5);
		expect(subcatsBeforeRemoval[2]).toNotEqual('water');
	})
});
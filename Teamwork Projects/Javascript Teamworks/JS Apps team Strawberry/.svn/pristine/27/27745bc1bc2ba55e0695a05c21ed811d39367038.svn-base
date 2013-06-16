describe("Storage", function() {
  var input;

  beforeEach(function() {
  	storage.clear();
  });

  it("should successfully save and load from localstorage", function() {
    var test = "test value";
    storage.save('container', test);
    expect(storage.load('container')).toEqual(test);
  });

  it("should successfully remove items from localstorage", function() {
  	var valueToRemove = "to remove";
  	storage.save('container', valueToRemove);
  	storage.remove('container');

  	expect(storage.load('container')).toEqual(null);
  })

  it("shoud successfully clear the localstorage", function() {
  	var firstVal = "value 1";
  	var secondVal = "value 2";
  	storage.save('firstVal', firstVal);
  	storage.save('secondVal', secondVal);
  	storage.clear();

  	expect(storage.load('firstVal')).toEqual(null);
  	expect(storage.load('secondVal')).toEqual(null);
  })
});
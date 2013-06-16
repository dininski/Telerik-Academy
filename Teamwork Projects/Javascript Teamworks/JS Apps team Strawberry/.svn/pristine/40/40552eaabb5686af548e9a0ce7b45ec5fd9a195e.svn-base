describe("Mock storage", function() {

   beforeEach(function() {
    storage.clear();
  });

  it("saves and loads from mock storage", function() {
    var test = "test value";
    storage.save('container', test);
    expect(storage.load('container')).toEqual(test);
  });

  it("removes items from mock storage", function() {
    var valueToRemove = "to remove";
    storage.save('container', valueToRemove);
    storage.remove('container');

    expect(storage.load('container')).toEqual(null);
  })

  it("clears the mock storage", function() {
    var firstVal = "value 1";
    var secondVal = "value 2";
    storage.save('firstVal', firstVal);
    storage.save('secondVal', secondVal);
    storage.clear();

    expect(storage.load('firstVal')).toEqual(null);
    expect(storage.load('secondVal')).toEqual(null);
  })
});
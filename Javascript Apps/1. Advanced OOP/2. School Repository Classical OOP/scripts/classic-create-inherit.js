var Class = (function () {
    function createClass(properties) {
        var createFunction = function () {
            this.init.apply(this, arguments);
        }

        for (var prop in properties) {
            createFunction.prototype[prop] = properties[prop];
        }
        if (!createFunction.prototype.init) {
            createFunction.prototype.init = function () { }
        }
        return createFunction;
    }

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;   // Set prototype of derived class
        var parentPrototype = new parent();  // Get copy of parent class
        this.prototype = Object.create(parentPrototype);  // Set to derived class all parent prototypes
        this.prototype._super = parent;  // Set to _super property parent class prototypes
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];  // Add all derived class prototypes to the derived class
        }
    }

    return {
        create: createClass,
    };
}());
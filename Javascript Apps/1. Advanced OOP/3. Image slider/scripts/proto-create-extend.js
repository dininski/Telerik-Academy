(function () {
    "use strict";

    if (!Object.create) {
        Object.create = function (obj) {
            function newObj() { };
            newObj.prototype = obj;
            return new newObj();
        }
    }
    if (!Object.prototype.extend) {
        Object.prototype.extend = function (properties) {
            function f() { };
            f.prototype = Object.create(this);
            for (var prop in properties) {
                f.prototype[prop] = properties[prop];
            }
            f.prototype._super = this;
            return new f();
        }
    }
})();
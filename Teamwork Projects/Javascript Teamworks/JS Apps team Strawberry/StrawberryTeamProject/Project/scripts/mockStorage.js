var storage = (function() {
    var storageObj = {};

    var save = function(key, value) {
        storageObj[key] = value;
    }

    var load = function(key) {
        return storageObj[key];
    }

    var remove = function(key) {
        storageObj[key] = null;
    }

    var clear = function() {
        storageObj = {};
    }

    var getStorage = function() {
        return storageObj;
    }

    return {
        save: save,
        load: load, 
        remove: remove,
        clear: clear,
        getStorage: getStorage
    }
})();
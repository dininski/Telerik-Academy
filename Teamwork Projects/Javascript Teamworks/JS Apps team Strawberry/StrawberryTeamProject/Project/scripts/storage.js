var storage = (function () {

    var save = function (name, data) {
        return localStorage.setObject(name, data);
    }

    var load = function (name) {
        return localStorage.getObject(name);
    }

    return {
        save: save,
        load: load
    }

}())
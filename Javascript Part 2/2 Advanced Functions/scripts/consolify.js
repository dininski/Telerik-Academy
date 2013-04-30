var consolify = (function () {

    var writeLine = function () {
        var message = arguments[0].toString();
        for (var i = 1; i < arguments.length; i++) {
            message = message.replace(('{' + (i - 1) + '}'), arguments[i]);
        }

        console.log(message);
    }

    var writeError = function () {
        var error = arguments[0].toString();
        for (var i = 1; i < arguments.length; i++) {
            error = error.replace(('{' + (i - 1) + '}'), arguments[i]);
        }

        console.error(error);
    }

    var writeWarning = function () {
        var warning = arguments[0].toString();
        for (var i = 1; i < arguments.length; i++) {
            warning = warning.replace(('{' + (i - 1) + '}'), arguments[i]);
        }

        console.warn(warning);
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };
})();
function AditiLogService(userAgent) {
    var prepareMessage = function (logId, message, type) {
        var formattedMessage = logId + " : " +
            new Date().toString() + " : " + type + " : " + message;

        return formattedMessage;
    };

    var logMsg = function (message, type) {
        var minLogId = 1;
        var maxLogId = 100000;
        var logId = Math.floor(
            Math.random() * (maxLogId - minLogId) + minLogId);
        var formattedMessage = prepareMessage(message, type);

        userAgent.localStorage['LOG:' + logId.toString()] = formattedMessage;
    };

    var serviceDefinition = {
        log: function (message) {
            logMsg(message, "LOG");
        },
        info: function (message) {
            logMsg(message, "INFO");
        },
        warn: function (message) {
            logMsg(message, "WARNING");
        },
        error: function (message) {
            logMsg(message, "ERROR");
        }
    };

    return serviceDefinition;
}

function AditiExceptionHandlerService(logService) {
    var service = function (exception, cause) {
        logService.error("Exception Occurred ... " +
            exception.message + ", Cause : " + cause);
    };

    return service;
}
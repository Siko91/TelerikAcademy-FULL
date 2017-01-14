var consoleLogger = function ConsoleLogger() {
    this.parse = function parse(line){
        if (typeof line !== 'object') {
            return line;
        }
        for (var i = 0; i < line.length-1; i++) {
            line[i] = line[i].toString();
            if (line[0].indexOf("{" + (i) + "}") !== -1) {
                line[0] = line[0].replace("{" + (i) + "}", line[i+1]);
            }
            else {
                this.writeError("Couldn't parse the input string. {" + (i) + "} is missing.");
                return;
            }
        }
        return line[0];
    },

    this.writeLine = function writeLine(line){
        line = this.parse(line);
        console.log(line);
    },

    this.writeError = function writeError(errorMsg){
        errorMsg = this.parse(errorMsg);
        this.writeLine(["Error: {0}", errorMsg]);
    },

    this.writeWarning = function writeWarning(warnMsg){
        warnMsg = this.parse(warnMsg);
        this.writeLine(["Warning: {0}", warnMsg]);
    }
}
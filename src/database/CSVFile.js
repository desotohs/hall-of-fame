import FileSystem from "./FileSystem";

class CSVRow {
    constructor(header, row) {
        this.header = header;
        this.row = row;
    }

    get(field) {
        return this.row[this.header.findIndex(f => f === field)];
    }
}

class CSVFile {
    constructor(text) {
        this.rows = text.split(/[\n\r]+/).map(r => r.split(/, ?/));
        this.header = this.rows.splice(0, 1)[0];
        this.length = this.rows.length;
    }

    getRow(n) {
        return new CSVRow(this.header, this.rows[n]);
    }

    toArray() {
        return this.rows.map(r => new CSVRow(this.header, r));
    }
}

function loadCSV(path, callback) {
    FileSystem.resolvePath(path, file => {
        if (file) {
            file.cat("text/csv", data => {
                callback(new CSVFile(data.contents));
            });
        } else {
            callback(null);
        }
    });
}

loadCSV.CSVFile = CSVFile;
export default loadCSV;

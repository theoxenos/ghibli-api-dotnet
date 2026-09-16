const fs = require("fs");
const path = require("path");

const json = require("../data.json");

Object.keys(json).forEach(key => {
    fs.createWriteStream(path.join(__dirname, `${key}.json`)).write(JSON.stringify(json[key], null, 2));
});
const fs = require("node:fs");
const data = {
    films: require("./films.json"),
    locations: require("./locations.json"),
    species: require("./species.json"),
    people: require("./people.json"),
    vehicles: require("./vehicles.json"),
};

const keys = Object.keys(data);

// Create a lookup table for every resource type.
const dataById = Object.fromEntries(
    keys.map((key) => [
        key,
        new Map(data[key].map((item) => [item.id, item])),
    ])
);

let errors = 0;

// Check that every referenced ID exists in the corresponding resource.
for (const sourceKey of keys) {
    for (const item of data[sourceKey]) {
        for (const targetKey of keys) {
            const references = item[targetKey];

            // Only validate fields that contain arrays of IDs.
            if (!Array.isArray(references)) {
                continue;
            }

            for (const referencedId of references) {
                if (!dataById[targetKey].has(referencedId)) {
                    console.error(
                        `${sourceKey} "${item.id}" references missing ` +
                        `${targetKey} with id "${referencedId}"`
                    );

                    errors++;
                }
            }
        }
    }
}

if (errors === 0) {
    console.log("All references are valid.");
} else {
    console.error(`Found ${errors} invalid reference(s).`);
    process.exitCode = 1;
}

console.log("Writing data.json...");
fs.writeFileSync("data.json", JSON.stringify(data, null, 2));
console.log("Done.");

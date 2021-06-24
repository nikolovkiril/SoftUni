function sumByTowns(input) {

    let objects = {};

    for (let i = 0; i < input.length; i += 2) {
        if (!objects.hasOwnProperty(input[i])) {
            objects[input[i]] = 0;
        }

        objects[input[i]] += Number(input[i + 1]);
    }
    //console.log(oblects);
    console.log(JSON.stringify(objects));
}

sumByTowns(['Sofia', '20', 'Varna', '3', 'Sofia', '5', 'Varna', '4']);
sumByTowns(['Sofia', '20', 'Varna', '3', 'sofia', '5', 'varna', '4']);
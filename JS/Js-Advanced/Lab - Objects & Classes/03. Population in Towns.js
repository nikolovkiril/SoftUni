function populationInTown(input) {

    let objects = new Map();

    for (let index = 0; index < input.length; index++) {
        let element = input[index].split(' <-> ');

        let city = element[0];
        let population = Number(element[1]);

        if (!objects.has(city)) {
            objects.set(city, population);
        }
        else {
            objects.set(city, objects.get(city) + population);
        }
    }
    for (let currentObject of objects) {
        console.log(`${currentObject[0]} : ${currentObject[1]}`);
    }
}

populationInTown([
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000'
]);
populationInTown([
    'Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000'
]);
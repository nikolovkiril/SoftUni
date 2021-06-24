function autoEngineeringCompany(input) {

    let result = {};

    input.forEach(row => {
        let [make, model, quantity] = row.split(' | ');

        if (!result[make]) {
            result[make] = {};
        }
        if (!result[make][model]) {
            result[make][model] = Number(quantity);
        } else {
            result[make][model] += Number(quantity);
        }
    });
    for (const key in result) {
        console.log(key);
        let sub = result[key];
        
        for (const res in sub) {
            console.log(`###${res} -> ${sub[res]}`);
        }
    }
}


autoEngineeringCompany([
    'Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10'
]);


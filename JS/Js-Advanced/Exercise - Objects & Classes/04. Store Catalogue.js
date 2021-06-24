function storeCatalogue(input) {

    let result = {};

    input.forEach(row => {
        let [name, price] = row.split(' : ');
        price = Number(price);
        let letter = name[0];
        if (!result[letter]) {
            result[letter] = [];
        }
        let product = { name, price };
        result[letter].push(product);

    });
    
    result = Object.entries(result).sort();
   for (let i = 0; i < result.length; i++) {
       console.log(result[i][0]);
       let sorted = result[i][1].sort((current,next) => current.name.localeCompare(next.name));
       sorted.forEach(el => console.log(`  ${el.name}: ${el.price}`));
   }
}

storeCatalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]);
storeCatalogue([
    'Banana : 2',
    'Rubic`s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10'
]);

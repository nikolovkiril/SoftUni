function cappyJuice(input) {

    let result = {};
    let bottles = {};

    input.forEach(row => {
        let [fruit, quantity] = row.split(' => ');
        if (!result[fruit]) {
            result[fruit] = Number(quantity);
        } else {
            result[fruit] += Number(quantity);
        }

        if (result[fruit] >= 1000) {
            bottles[fruit] = parseInt(result[fruit] / 1000);
        }
    });
    Object.keys(bottles).forEach(b => console.log(`${b} => ${bottles[b]}`));
}

cappyJuice([
    'Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549'
]);
cappyJuice([
    'Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
]);

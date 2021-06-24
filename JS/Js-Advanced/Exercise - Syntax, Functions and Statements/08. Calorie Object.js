function solve(input) {

    const calories = {};

    for (let i = 0; i < input.length; i += 2) {

        calories[input[i]] = +input[i+1];
    }

    console.log(calories);

}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);



function solve(input) {
    let result = ' ';

    let symbol = '*';
    for (let i = 0; i < input; i++) {


        console.log((symbol + result).repeat(input));
    }
}

solve(5);
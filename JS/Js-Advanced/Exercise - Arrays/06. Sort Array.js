function solve(input) {

    let result = input
        .sort((a, b) => {
            a = a.toLowerCase();
            b = b.toLowerCase();
            if (a == b) return 0;
            if (a > b) return 1;
            return -1;
        })
        .sort((a, b) => a.length - b.length);


    result.forEach(x => console.log(x));
}

solve(['alpha',
    'beta',
    'gamma']);
solve(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']);
solve(['test',
    'Deny',
    'omen',
    'Default']);
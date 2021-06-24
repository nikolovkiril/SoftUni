function solve(input) {

    let step = Number(input.pop(input[input.length - 1]));

    for (let i = 0; i < input.length; i += step) {
        console.log(input[i]);
    }

}


solve(['5',
    '20',
    '31',
    '4',
    '20',
    '2']);
solve(['dsa',
    'asd',
    'test',
    'tset',
    '2']);
solve(['1',
    '2',
    '3',
    '4',
    '5',
    '6']);
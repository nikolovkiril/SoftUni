function solve(input) {
    let rotations = Number(input.pop(input[input.length - 1]));
    if (rotations > 1000) {
        rotations %= 1000;
    }
    for(let i = 0; i < rotations; i++) {
        
        input.unshift(input.pop());
    }
    console.log(input.join(' '));
}

solve(['1',
    '2',
    '3',
    '4',
    '2']);
solve(['Banana',
    'Orange',
    'Coconut',
    'Apple',
    '15']);
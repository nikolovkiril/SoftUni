function solve(input) {

    let delimiter =input.pop(input[input.length - 1]);
    let res = input.slice(input[0], input[input.length - 1]);
    let result = input
        .join(delimiter);

    console.log(result);
}


solve(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']);
solve(['How about no?',
    'I',
    'will',
    'not',
    'do',
    'it!',
    '_']);
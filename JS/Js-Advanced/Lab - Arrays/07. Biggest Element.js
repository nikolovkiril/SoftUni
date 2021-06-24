function solve(input) {

    let maxNum = input
        .map(row => Math.max(...row))
        .reduce((x, a) => Math.max(x, a), Number.MIN_SAFE_INTEGER);
    console.log(maxNum);
}

solve([
    [20, 50, 10],
    [8, 33, 145]
]);
solve([
    [3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]
]);
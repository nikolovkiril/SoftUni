function solve(first, second) {

    let result = 0;

    for (let i = second; i >= 0; i--) {
        if (first % i == 0 && second % i == 0) {
            result = i;
            break;
        }
    }

    console.log(result);
}

solve(15, 5);
solve(2154, 458);
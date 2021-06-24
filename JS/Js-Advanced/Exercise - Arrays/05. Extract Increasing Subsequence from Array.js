function solve(input) {

    let arr = input.map(Number);
    let result = [arr[0]];
    let biggestNumber = arr[0];
 
    for (let i = 1; i < input.length; i++) {
 
        let currentNumber =arr[i];
 
        if (currentNumber >= biggestNumber) {
            result.push(currentNumber);
            biggestNumber = currentNumber;
        }
    }
 
    result.forEach(x=> console.log(x));

}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]);
solve([1,
    2,
    3,
    4]);
solve([20,
    3,
    2,
    15,
    6,
    1]);
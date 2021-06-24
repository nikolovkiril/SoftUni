function solve(number) {

    let sum = 0;
    let num = number % 10;
    let isEqual = true;

    while (number / 10 > 0) {
        
        let toCheck = number % 10;
        if (num != toCheck) {
            isEqual = false;
        }
        sum += toCheck;
        number = Math.floor(number / 10);
    }
console.log(isEqual);
console.log(sum);
}

solve(222);
solve(1234);
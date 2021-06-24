function solve(input) {

    const sum = function (input) {
        let result = 0;

        for (let number of input) {
            result += number;
        }
        return result;
    };

    const sumInverted = input => {

        let result = 0;

        for (const number of input) {
            result += 1 / number;
        }

        return result;
    };

    const concat = input => {
        return input.join('');
    };

    console.log(sum(input))
    console.log(sumInverted(input));
    console.log(concat(input));
}
solve([1, 2, 3])
solve([2, 4, 8, 16])
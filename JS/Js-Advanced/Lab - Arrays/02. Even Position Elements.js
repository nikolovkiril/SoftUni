function solve(input) {

    let string = '';
    for (let i = 0; i < input.length; i += 2) {

        string += input[i] + ' ';
    }

    console.log(string);

}

solve(['20', '30', '40']);
solve(['5', '10']);
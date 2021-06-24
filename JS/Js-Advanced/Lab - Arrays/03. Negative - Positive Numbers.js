function solve(input) {

    let resul = [];

    for (let i = 0; i < input.length; i++) {

        if (input[i] > 0) {
            resul.push(input[i]);
        } else if (input[i] < 0) {
            resul.unshift(input[i]);
        } else {
            resul.push(input[i]);
        }
    }

    for (const key in resul) {
        console.log(resul[key]);

    }
}


//solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);
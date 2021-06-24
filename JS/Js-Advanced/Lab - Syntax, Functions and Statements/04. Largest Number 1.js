function solve(one, two, three) {

    let result = 0;
    if (one > two && one > three) {
        result = one;
    }
    else if (two > one && two > three) {
        result = two;
    }
    else{
        result = three;
    }
    console.log(`The largest number is ${result}.`);
}

solve(5, -13, 16);
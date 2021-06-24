function solve(input) {
    let result = input
        .split(/[` .,!?-]/g)
        .filter(x => x != '')
        .map(x => x.toUpperCase())
        .join(', '); 

    // let result = input
    //     .toUpperCase()
    //     .split(/[` .,!?-]/g)
    //     .filter(x => x != '')
    //     .join(', ');

    console.log(result)
}

solve('Hi, how are you?');
solve('Hello');
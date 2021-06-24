function solve(input) {

    let arr = [];

    for (let i = 0; i < input.length; i++) {
        let command = input[i];
        let add = i + 1;
        switch (command) {
            case 'add':
                arr.push(add);
                break;
            case 'remove':
                arr.pop();
                break;
        }
    }
    if (arr.length > 0) {
        arr.forEach(x => console.log(x));
    } else {
        console.log('Empty');
    }
}


solve(['add',
    'add',
    'add',
    'add']);
solve(['add',
    'add',
    'remove',
    'add',
    'add']);
solve(['remove',
    'remove',
    'remove']);
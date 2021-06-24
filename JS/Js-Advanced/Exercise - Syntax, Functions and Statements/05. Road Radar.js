function solve(input) {
    let speedToCheck = Number(input[0]);
    let area = input[1];

    let motorway = 130;
    let interstate = 90;
    let city = 50;
    let residential = 20;

    switch (area) {
        case 'city':
            if (speedToCheck > city) {
                let dif = speedToCheck - city;
                if (dif <= 20) {
                    console.log('speeding');
                } else if (dif > 20 && dif <= 40) {
                    console.log('excessive speeding');
                } else if (dif > 40) {
                    console.log('reckless driving');

                } else{
                    console.log();
                }
            }
            break;
        case 'residential':
            if (speedToCheck > residential) {
                let dif = speedToCheck - residential;
                if (dif <= 20) {
                    console.log('speeding');
                } else if (dif > 20 && dif <= 40) {
                    console.log('excessive speeding');
                } else if (dif > 40) {
                    console.log('reckless driving');

                } else{
                    console.log();
                }
            }
            break;
        case 'interstate':
            if (speedToCheck > interstate) {
                let dif = speedToCheck - interstate;
                if (dif <= 20) {
                    console.log('speeding');
                } else if (dif > 20 && dif <= 40) {
                    console.log('excessive speeding');
                } else if (dif > 40) {
                    console.log('reckless driving');

                } else {
                    console.log();
                }
            }
            break;
        case 'motorway':
            if (speedToCheck > motorway) {
                let dif = speedToCheck - motorway;
                if (dif <= 20) {
                    console.log('speeding');
                } else if (dif > 20 && dif <= 40) {
                    console.log('excessive speeding');
                } else if (dif > 40) {
                    console.log('reckless driving');

                } else{
                    console.log();
                }
            }
            break;
    }

}

solve([40, 'city']);
solve([21, 'residential']);
solve([120, 'interstate']);
solve([200, 'motorway']);
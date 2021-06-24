function solve(steps, footprint, speed) {

    let distanceCalculator = steps * footprint;
    let speedInSec = speed / 3.6;
    let rest = Math.floor(distanceCalculator / 500);
    let time = distanceCalculator / speedInSec + rest * 60;

    let hours = Math.floor(time / 3600);
    let min = Math.floor(time / 60);
    let sec = Math.round(time % 60);


    console.log(`${hours < 10 ? 0 : ""}${hours}:${min < 10 ? 0 : ""}${min}:${sec < 10 ? 0 : ""}${sec}`);


}

solve(4000, 0.60, 5);
solve(2564, 0.70, 5.5);
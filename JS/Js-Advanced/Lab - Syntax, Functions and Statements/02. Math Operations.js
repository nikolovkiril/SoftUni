function solve(fir, sec, third) {
    let result;
    switch (third) {
        case '+': result = fir + sec; break;
        case '-': result = fir - sec; break;
        case '/': result = fir / sec; break;
        case '*': result = fir * sec; break;
        case '%': result = fir % sec; break;
        case '**': result = fir ** sec; break;
    }
    console.log(result);
}
solve(2 , 3 ,' +');
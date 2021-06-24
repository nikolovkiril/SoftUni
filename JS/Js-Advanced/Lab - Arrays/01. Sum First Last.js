function solve(input) {
    let firstNum = Number(input[0]);
    let lastNum =Number(input[input.length - 1]);
    
    console.log(sum(firstNum,lastNum));
    
    
    function sum (first,last  ){
        return first + last;
    }
}
solve(['20', '30', '40']);
solve(['5', '10']);
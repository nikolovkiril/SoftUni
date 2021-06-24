function subtract() {
    
    let first = document.getElementById('firstNumber');
    let sec = document.getElementById('secondNumber');
    let div = document.getElementById('result');
    
    let firstParsed = Number(first.value);
    let secParsed = Number(sec.value);
    
    let result = firstParsed - secParsed;

    div.innerHTML = result;
}
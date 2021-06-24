function solve() {


    let outPutWindow = document.getElementById('expressionOutput');
    let result = document.getElementById('resultOutput');

    document.querySelector('.keys').addEventListener('click', numbers);
    document.querySelector('.clear').addEventListener('click', clear);

    function clear() {
        outPutWindow.textContent = '';
        result.textContent = '';
    }

    function numbers(event) {
        let currSymbol = event.target.value;

        switch (currSymbol) {
            case '+':
            case '-':
            case '*':
            case '/':
                outPutWindow.textContent += ` ${currSymbol} `;
                break;
            case '=':
                let [letf, operant, right] = outPutWindow.textContent.split(' ');
                if (!operant || !right) {
                    result.textContent = 'NaN';
                } else {
                    result.textContent = sum(+letf, operant, +right);
                }
                break;
            default:
                outPutWindow.textContent += currSymbol;
        }

    }
    function sum(letf, operant, right) {
        switch (operant) {
            case '+':
                return Number(letf + right);
            case '-':
                return Number(letf - right);
            case '*':
                return Number(letf * right);
            case '/':
                return Number(letf / right);
        }
    }
}

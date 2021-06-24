function solve() {

    let button = document.getElementsByTagName('button')[0];
    button.addEventListener('click', add);

    function add() {
        let input = document.getElementsByTagName('input')[0];
        let inputValue = document.getElementsByTagName('input')[0].value;

        let firstLetter = inputValue[0].toUpperCase();
        let name = firstLetter + inputValue.substring(1).toLowerCase();

        let char = firstLetter.charCodeAt();
        let row = document.getElementsByTagName('li')[char - 65];

        row.textContent.length === 0
            ? row.textContent = name
            : row.textContent += `, ${name}`;

        input.value = '';
    }
}
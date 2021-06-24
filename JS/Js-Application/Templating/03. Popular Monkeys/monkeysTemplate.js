import monkeys from './monkeys.js';

const elements = {
    allMonkeys: () => document.querySelector('div.monkeys')
}

fetch('./monkeys.hbs')
    .then(r => r.text())
    .then(monkeysTemplateSrc => {
        const monkeysTemp = Handlebars.compile(monkeysTemplateSrc);
        const result = monkeysTemp({ monkeys });

        elements.allMonkeys().innerHTML = result;
        attachEventListener();
    })

function attachEventListener() {

    elements.allMonkeys().addEventListener('click', (e) => {
        const { target } = e;

        const p = target.parentNode.querySelector('p');

        if (target.nodeName !== 'BUTTON' || target.textContent !== 'Info') {
            return;
        }
        
        if (p.style.display === 'none') {
            p.style.display = 'block';
        } else {
            p.style.display = 'none';
        }

    });
}
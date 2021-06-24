function solve() {
    let buttonEl = document.querySelector('#container button');
    let inputEls = Array.from(document.querySelectorAll('#container input'));
    let [nameEl, ageEl, kindEl, ownerEl] = inputEls;
    let adopEl = document.querySelector('#adoption ul');
    let adoptedEl = document.querySelector('#adopted ul');


    buttonEl.addEventListener('click', e => {
        e.preventDefault();
        //ako ne e validen input ili e null
        if (!inputEls.every(x => x.value)) {
            return;
        }

        if (!Number(ageEl.value)) {
            return;
        }

        let liEl = document.createElement('li');
        let pEl = document.createElement('p');
        let spanEl = document.createElement('span');
        let buttonEl = document.createElement('button');


        pEl.innerHTML = `<strong>${nameEl.value}</strong> is a <strong>${ageEl.value}</strong> year old <strong>${kindEl.value}</strong>`
        spanEl.textContent = `Owner: ${ownerEl.value}`
        buttonEl.textContent = `Contact with owner`



        liEl.appendChild(pEl);
        liEl.appendChild(spanEl);
        liEl.appendChild(buttonEl);

        adopEl.appendChild(liEl);

        nameEl.value = '';
        ageEl.value = '';
        kindEl.value = '';
        ownerEl.value = '';

        buttonEl.addEventListener('click', firstButton);

    });

    function firstButton(e) {
        let parentEl = e.currentTarget.parentElement;

        e.currentTarget.remove();

        let divEl = document.createElement('div');
        let inputEl = document.createElement('input');
        let changeEl = document.createElement('button');

        inputEl.setAttribute('placeholder', 'Enter your names');
        changeEl.textContent = 'Yes! I take it!';


        divEl.appendChild(inputEl);
        divEl.appendChild(changeEl);

        parentEl.appendChild(divEl);

        changeEl.addEventListener('click', secButton);
    }
    function secButton(e) {
        let oldButtonEl = e.currentTarget.parentElement;
        let parentAdoptionEl = oldButtonEl.parentElement;

        let inputName = parentAdoptionEl.querySelector('input');

        let newName = inputName.value;
        if (!newName) {
            return;
        }
        adoptedEl.appendChild(parentAdoptionEl);

            let oldSpan = document.querySelector('span');
            let oldButton = oldButtonEl.querySelector('button');
            let oldInput = oldButtonEl.querySelector('input');
            oldSpan.textContent = `New Owner: ${newName}`;
            oldButton.textContent = `Checked`;
            oldInput.remove();
            oldButton.addEventListener('click', e => {
                parentAdoptionEl.remove();
            });
        
    }

}


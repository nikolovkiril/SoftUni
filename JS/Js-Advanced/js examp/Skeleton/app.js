function solve() {

    let openSection = document.getElementsByTagName('section')[1];
    let inProgressSection = document.getElementsByTagName('section')[2];
    let completeSection = document.getElementsByTagName('section')[3];

    let addButton = document.getElementById('add');

    let input1 = document.getElementById('task');
    let input2 = document.getElementById('description');
    let input3 = document.getElementById('date');

    addButton.addEventListener('click', (e) => {
        e.preventDefault();

        if (!input1.value || !input2.value || !input3.value) {
            return;
        }

        let article = document.createElement('article');
        let h3 = document.createElement('h3');
        let descriptionP = document.createElement('p');
        let dateP = document.createElement('p');
        let div = document.createElement('div');
        let startButton = document.createElement('button');
        let deleteButton = document.createElement('button');

        div.className = 'flex';
        startButton.className = 'green';
        deleteButton.className = 'red';

        startButton.textContent = 'Start';
        deleteButton.textContent = 'Delete';

        h3.textContent = input1.value;
        descriptionP.textContent = `Description: ${input2.value}`;
        dateP.textContent = `Due Date: ${input3.value}`;
        startButton.addEventListener('click', () => {
            startButton.remove();
            inProgressSection.lastElementChild.appendChild(article);

            let finishBtn = document.createElement('button');
            finishBtn.className = 'orange';
            finishBtn.textContent = 'Finish';
            div.appendChild(finishBtn);
            finishBtn.addEventListener('click',() =>{
                completeSection.lastElementChild.appendChild(article);
                article.lastElementChild.remove();
            });

        });

        deleteButton.addEventListener('click', () => {
            article.remove();
        });

        div.appendChild(startButton);
        div.appendChild(deleteButton);

        article.appendChild(h3);
        article.appendChild(descriptionP);
        article.appendChild(dateP);
        article.appendChild(div);

        openSection.lastElementChild.appendChild(article);
        input1.value = '';
        input3.value = '';
        input2.value = '';

    });

}
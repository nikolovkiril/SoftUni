function attachEvents() {
    const url = 'https://phonebook-nakov.firebaseio.com/phonebook.json';
    let loadBtn = document.getElementById('btnLoad');
    let createBtn = document.getElementById('btnCreate');
    let ul = document.getElementById('phonebook');

    createBtn.addEventListener('click', create);

    loadBtn.addEventListener('click', load);

    function load() {
        fetch(url)
            .then(response => response.json())
            .then((data) => {

                [...ul.children].forEach(x => x.remove());
                
                Object.keys(data).forEach((key) => {

                    let li = document.createElement('li');
                    li.textContent = `${data[key].person}: ${data[key].phone}`;
                    let deleteBtn = document.createElement('button');
                    deleteBtn.textContent = 'Delete';

                    deleteBtn.addEventListener('click', (e) => delContact(e, key));
                    li.appendChild(deleteBtn);
                    ul.appendChild(li);
                });
            });
    }
    function create() {
        let personEl = document.getElementById('person');
        let phoneEl = document.getElementById('phone');

        let newContact = JSON.stringify({ person: personEl.value, phone: phoneEl.value });
        fetch(url, { method: "POST", body: newContact });
        personEl.value = '';
        phoneEl.value = '';
    }

    function delContact(e, key) {
        let url = `https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`;
        fetch(url, { method: 'DELETE' })
        e.currentTarget.parentElement.remove();
    };

}

attachEvents();
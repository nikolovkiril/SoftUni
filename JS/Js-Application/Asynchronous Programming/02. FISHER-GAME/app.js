function attachEvents() {

    const baseUrl = 'https://fisher-game.firebaseio.com/catches.json';

    const addBtn = document.querySelector('button.add');
    const loadBtn = document.querySelector('button.load');

    let divEl = document.getElementById('catches');

    let anglerInp = document.querySelector('fieldset > input.angler');
    let weightInp = document.querySelector('fieldset > input.weight');
    let speciesInp = document.querySelector('fieldset > input.species');
    let locationInp = document.querySelector('fieldset > input.location');
    let baitInp = document.querySelector('fieldset > input.bait');
    let captureTimeInp = document.querySelector('fieldset > input.captureTime');

    addBtn.addEventListener('click', add);

    loadBtn.addEventListener('click', load);

    function clearInputs() {
        anglerInp.value = "";
        weightInp.value = "";
        speciesInp.value = "";
        locationInp.value = "";
        baitInp.value = "";
        captureTimeInp.value = "";
    };
    function add() {

        let obj = JSON.stringify({
            angler: anglerInp.value,
            weight: weightInp.value,
            species: speciesInp.value,
            location: locationInp.value,
            bait: baitInp.value,
            captureTime: captureTimeInp.value,
        });

        fetch(baseUrl, {
            method: "POST",
            body: obj
        })
            .then(resp => resp.json());

        clearInputs();
    };
    function load() {

        fetch(baseUrl)
            .then(resp => resp.json())
            .then(data => {

                Object.keys(data).forEach(key => {
                    let { angler, weight, species, location, bait, captureTime } = data[key];

                    let newCatchDiv = createElement("div", "catch", "");
                    newCatchDiv.setAttribute('data-id', key);

                    let anglerLabel = document.createElement('label');
                    anglerLabel.textContent = 'Angler';
                    let anglerInput = createElement("input", "angler", angler, "text");


                    let weightLabel = document.createElement('label');
                    weightLabel.textContent = 'Weight';
                    let weightInput = createElement("input", "weight", weight, "number");

                    let speciesLabel = document.createElement('label');
                    speciesLabel.textContent = 'Species';
                    let speciesInput = createElement("input", "species", species, "text");

                    let locationLabel = document.createElement('label');
                    locationLabel.textContent = 'Location';
                    let locationInput = createElement("input", "location", location, "text");

                    let baitLabel = document.createElement('label');
                    baitLabel.textContent = 'Bait        ';
                    let baitInput = createElement("input", "bait", bait, "text");

                    let captureTimeLabel = document.createElement('label');
                    captureTimeLabel.textContent = 'Capture Time';
                    let captureTimeInput = createElement("input", "captureTime", captureTime, "number");

                    let updateBtn = document.createElement('button');
                    let deleteBtn = document.createElement('button');
                    updateBtn.className = 'update';
                    deleteBtn.className = 'delete';
                    updateBtn.textContent = 'Update';
                    deleteBtn.textContent = 'Delete';

                    updateBtn.addEventListener('click', () => {

                    });
                    let delUrl = `https://fisher-game.firebaseio.com/catches/${key}.json`;
                    let updateUrl = `https://fisher-game.firebaseio.com/catches/${key}.json`

                    updateBtn.addEventListener('click', () => {
                        let updatedObj = JSON.stringify({
                            angler: anglerInput.value,
                            weight: weightInput.value,
                            species: speciesInput.value,
                            location: locationInput.value,
                            bait: baitInput.value,
                            captureTime: captureTimeInput.value,
                        });
                        console.log(updatedObj);
                        fetch(updateUrl, { method: 'PUT', body: updatedObj});
                    });
                    deleteBtn.addEventListener('click', () => {
                        fetch(delUrl, { method: 'DELETE' })
                            .then(res => res.json());
                    });

                    newCatchDiv.appendChild(anglerLabel);
                    newCatchDiv.appendChild(anglerInput);
                    newCatchDiv.appendChild(document.createElement('hr'));
                    newCatchDiv.appendChild(weightLabel);
                    newCatchDiv.appendChild(weightInput);
                    newCatchDiv.appendChild(document.createElement('hr'));
                    newCatchDiv.appendChild(speciesLabel);
                    newCatchDiv.appendChild(speciesInput);
                    newCatchDiv.appendChild(document.createElement('hr'));
                    newCatchDiv.appendChild(locationLabel);
                    newCatchDiv.appendChild(locationInput);
                    newCatchDiv.appendChild(document.createElement('hr'));
                    newCatchDiv.appendChild(baitLabel);
                    newCatchDiv.appendChild(baitInput);
                    newCatchDiv.appendChild(document.createElement('hr'));
                    newCatchDiv.appendChild(captureTimeLabel);
                    newCatchDiv.appendChild(captureTimeInput);
                    newCatchDiv.appendChild(document.createElement('hr'));

                    newCatchDiv.appendChild(updateBtn);
                    newCatchDiv.appendChild(deleteBtn);
                    divEl.appendChild(newCatchDiv);
                });
            });
    };

    function createElement(element, classes, content, type) {

        let el = document.createElement(element);

        if (element === 'input') {
            el.type = type;
            el.value = content;
        } else {
            el.innerHTML = content;
        }
        el.className = classes;
        return el;
    };
};


attachEvents();


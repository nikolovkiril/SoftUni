const htmlSelectors = {
    'loadStudents': () => document.getElementById('loadStudents'),

    'createBtn': () => document.querySelector('#form-create > button'),

    'createId': () => document.getElementById('create-id'),
    'createFirstName': () => document.getElementById('create-first-name'),
    'createLastName': () => document.getElementById('create-last-name'),
    'createFacultyNumber': () => document.getElementById('create-faculty-number'),
    'createGrade': () => document.getElementById('create-grade'),

    'studentsContainer': () => document.querySelector('table > tbody'),
}

htmlSelectors['loadStudents']()
    .addEventListener('click', getStudents);

htmlSelectors['createBtn']()
    .addEventListener('click', createStudent);

function createStudent(e,studentsData) {

    e.preventDefault();

    let postUrl = 'https://student-exercises.firebaseio.com/students/.json';
    const idInput = htmlSelectors['createId']();
    const firstNameInput = htmlSelectors['createFirstName']();
    const lastNameInput = htmlSelectors['createLastName']();
    const facultyNumberInput = htmlSelectors['createFacultyNumber']();
    const gradeInput = htmlSelectors['createGrade']();

    if ((idInput.value !== '') && firstNameInput.value !== '' && lastNameInput.value !== ''
        && facultyNumberInput.value !== '' && gradeInput.value !== 0) {

        fetch(postUrl, {
            method: "POST",
            body: JSON.stringify({
                id: idInput.value,
                firstName: firstNameInput.value,
                lastName: lastNameInput.value,
                facultyNumber: facultyNumberInput.value,
                grade: gradeInput.value
            })
        })
            .then(getStudents)
        // .catch(x => alert(x.message));

        idInput.value = '';
        firstNameInput.value = '';
        lastNameInput.value = '';
        facultyNumberInput.value = '';
        gradeInput.value = '';
    } else {
        throw new Error(alert('Input can not be empty'));
    }
}

function getStudents(e) {

    e.preventDefault();
    
    let getUrl = 'https://student-exercises.firebaseio.com/students/.json';

    fetch(getUrl)
        .then(res => res.json())
        .then(renderStudents)
        .catch(e => alert("Объркал си адреса"))
}

function renderStudents(studentsData) {
    const studentsContainer = htmlSelectors['studentsContainer']();

    if (studentsContainer.innerHTML != '') {
        studentsContainer.innerHTML = '';
    }

    Object.keys(studentsData)
        .forEach(studentId => {
            const { id, firstName, lastName, facultyNumber, grade } = studentsData[studentId];

            const tableRow = createDOMElement('tr', '', {}, {},
                createDOMElement('td', id, {}, {}),
                createDOMElement('td', firstName, {}, {}),
                createDOMElement('td', lastName, {}, {}),
                createDOMElement('td', facultyNumber, {}, {}),
                createDOMElement('td', grade, {}, {}));

            studentsContainer.appendChild(tableRow);
        })
}

function createDOMElement(type, content, attributes, events, ...children) {
    const domElement = document.createElement(type);

    if (content !== '') {
        domElement.textContent = content;
    }

    Object.entries(attributes)
        .forEach(([attrKey, attrValue]) => {
            domElement.setAttribute(attrKey, attrValue);
        });

    Object.entries(events)
        .forEach(([eventName, eventHandler]) => {
            domElement.addEventListener(eventName, eventHandler);
        });

    children
        .forEach((child) => {
            domElement.appendChild(child);
        });

    return domElement;
}
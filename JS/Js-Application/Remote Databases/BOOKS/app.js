const htmlSelector = {
    'loadBooks': () => document.getElementById('loadBooks'),

    'submitBtn': () => document.querySelector('form > button'),
    'edittBtn': () => document.querySelector('#form-edit > button'),
    'deleteBtn': () => document.querySelector('#form-delete > button'),

    'titleInput': () => document.getElementById('title'),
    'authorInput': () => document.getElementById('author'),
    'isbnInput': () => document.getElementById('isbn'),

    'bookContainer': () => document.querySelector('table > tbody'),

    'editForm': () => document.getElementById('form-edit'),
    'editTitle': () => document.getElementById('edit-title'),
    'editAuthor': () => document.getElementById('edit-author'),
    'editIsbn': () => document.getElementById('edit-isbn'),

    'deleteForm': () => document.getElementById('form-delete'),
    'deleteTitle': () => document.getElementById('delete-title'),
    'deleteAuthor': () => document.getElementById('delete-author'),
    'deleteIsbn': () => document.getElementById('delete-isbn'),

}
htmlSelector['loadBooks']()
    .addEventListener('click', allBooks);

htmlSelector['submitBtn']()
    .addEventListener('click', createBook);

htmlSelector['edittBtn']()
    .addEventListener('click', editBook);

htmlSelector['deleteBtn']()
    .addEventListener('click', deleteBookById);

function allBooks(e) {
    let getUrl = 'https://books-exercises-ea44b.firebaseio.com/books/.json';

    fetch(getUrl)
        .then(response => response.json())
        .then(renderBooks)
        .catch(e => alert("Объркал си адреса"))
}
function renderBooks(booksData) {
    const bookContainer = htmlSelector['bookContainer']();

    if (bookContainer.innerHTML != '') {
        bookContainer.innerHTML = '';
    }
    Object.keys(booksData)
        .forEach(bookId => {
            const { title, author, isbn } = booksData[bookId];

            const tableRow = createDOMElement('tr', '', {}, {},
                createDOMElement('td', title, {}, {}),
                createDOMElement('td', author, {}, {}),
                createDOMElement('td', isbn, {}, {}),
                createDOMElement('td', '', {}, {},
                    createDOMElement('button', "Edit", { 'data-key': bookId }, { click: getBookById }),
                    createDOMElement('button', 'Delete', { 'data-key': bookId }, { click: deleteBookById })));

            bookContainer.append(tableRow);
        });
}
function deleteBookById(e) {
    e.preventDefault();
    let id = this.getAttribute('data-key')

    let deleteUrl = `https://books-exercises-ea44b.firebaseio.com/books/${id}/.json`;

    htmlSelector['deleteForm']().style.display = 'none';

    fetch(deleteUrl, {
        method: "DELETE",
        // body: JSON.stringify()
    })
        .then(allBooks)
        .catch(e => alert(e.message));

}
function getBookById(e) {
    let id = this.getAttribute('data-key')
    console.log(id);
    let editUrl = `https://books-exercises-ea44b.firebaseio.com/books/${id}/.json`;
    fetch(editUrl)
        .then(response => response.json())
        .then(({ title, author, isbn }) => {
            htmlSelector['editTitle']().value = title;
            htmlSelector['editAuthor']().value = author;
            htmlSelector['editIsbn']().value = isbn;
            htmlSelector['editForm']().style.display = 'block';
            htmlSelector['edittBtn']().setAttribute('data-key', id);
        })
        .catch(e => alert(e.message));
}

function editBook(e) {
    e.preventDefault();

    const id = this.getAttribute('data-key');

    const editTitle = htmlSelector['editTitle']();
    const editAuthor = htmlSelector['editAuthor']();
    const editIsbn = htmlSelector['editIsbn']();

    let edit1Url = `https://books-exercises-ea44b.firebaseio.com/books/${id}/.json`;

    if (editTitle.value !== '' && editAuthor.value !== '' && editIsbn.value !== '') {
        htmlSelector['editForm']().style.display = 'none';

        fetch(edit1Url, {
            method: "PATCH",
            body: JSON.stringify({ title: editTitle.value, author: editAuthor.value, isbn: editIsbn.value })
        })
            .then(allBooks)
            .catch(e => alert(e.message));
    } else {
        throw new Error(alert('Input can not be empty'));
    }
}

function createBook(e) {
    e.preventDefault();

    let postUrl = 'https://books-exercises-ea44b.firebaseio.com/books/.json';

    const titleInput = htmlSelector['titleInput']();
    const authorInput = htmlSelector['authorInput']();
    const isbnInput = htmlSelector['isbnInput']();

    if (titleInput.value !== '' && authorInput.value !== '' && isbnInput.value !== '') {

        fetch(postUrl, {
            method: "POST",
            body: JSON.stringify({ title: titleInput.value, author: authorInput.value, isbn: isbnInput.value })
        })
            .then(allBooks)
        // .catch(e => alert(e.message));

        titleInput.value = '';
        authorInput.value = '';
        isbnInput.value = '';

    } else {
        throw new Error(alert('Input can not be empty'));
    }
}

function createDOMElement(type, text, attributes, events, ...children) {
    const DOMElement = document.createElement(type);

    if (text !== '') {
        DOMElement.textContent = text;
    }

    Object.entries(attributes)
        .forEach(([key, value]) => {
            DOMElement.setAttribute(key, value);
        });
    Object.entries(events)
        .forEach(([name, handler]) => {
            DOMElement.addEventListener(name, handler);
        });

    children.forEach((child) => {
        DOMElement.appendChild(child)
    });
    return DOMElement;
};



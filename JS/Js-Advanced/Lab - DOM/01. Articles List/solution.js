function createArticle() {


	let titleInputElement = document.getElementById('createTitle');
	let contentInputElement = document.getElementById('createContent');

	if (titleInputElement.value != '' && contentInputElement.value != '') {

		let articleElement = document.createElement('article');
		let articleSectionElement = document.getElementById('articles');
		articleSectionElement.appendChild(articleElement);


		let headingElement = document.createElement('h3');
		let contentsElement = document.createElement('p');
		articleElement.appendChild(headingElement);
		articleElement.appendChild(contentsElement);


		headingElement.innerHTML = titleInputElement.value
		contentsElement.innerHTML = contentInputElement.value


		titleInputElement.value = '';
		contentInputElement.value = '';
	}
}

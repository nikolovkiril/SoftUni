const elements = {
    allCats: () => document.getElementById('allCats')
}

Promise.all([
    getTemplate('./template.hbs'),
    getTemplate('./cats.hbs')
])
    .then(([templateSource, catsSource]) => {

        Handlebars.registerPartial('cat', catsSource);
        let template = Handlebars.compile(templateSource);
        let resHTML = template({ cats });
        elements.allCats().innerHTML = resHTML;
        attachEventListener();
    })
    .catch(e => console.error(e));

function attachEventListener() {
    elements.allCats().addEventListener('click', (e) => {
        const { target } = e;

        if (target.nodeName === 'BUTTON' && target.className === 'showBtn') {
            let status = target.parentNode.querySelector('div.status');
            if (status.style.display === 'none') {
                status.style.display = 'block';
            } else {
                status.style.display = 'none';
            }
        }
    })
}

function getTemplate(templateLocation) {
    return fetch(templateLocation).then((r) => r.text());
}
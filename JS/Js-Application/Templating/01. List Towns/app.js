const elements = {
    input: () => document.getElementById('towns'),
    root: () => document.getElementById('root'),
    btnLoadTowns: () => document.getElementById('btnLoadTowns')
};

elements.btnLoadTowns().addEventListener('click', getInput);


function getInput(e) {
    e.preventDefault();

    const { value } = elements.input();
    const towns = value.split(/[, ]+/g).map(t => { return { name: t } })
    appendTowns(towns);
}

function appendTowns(towns) {

    getTemplate()
        .then(templateSource => {
            const temp = Handlebars.compile(templateSource);
            const htmlRes = temp({ towns });
            elements.root().innerHTML = htmlRes;
        })
        .catch(e => console.error(e));
}


function getTemplate() {
    return fetch('./template.hbs').then((r) => r.text());
}
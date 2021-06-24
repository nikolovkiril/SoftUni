function solve() {
    let elements = {
        //form: document.getElementsByTagName('form')[0],
        name: document.querySelector('input[name="lecture-name"]'),
        date: document.querySelector('input[name="lecture-date"]'),
        module: document.querySelector('select[name="lecture-module"]'),
        Basics: document.querySelector('option[value="Basics"]'),
        addBtn: document.querySelector('form button'),
        modulesDiv: document.querySelector('.modules'),
        moduleList: () => Array.from(document.querySelectorAll('.module')),
        listItems: () => Array.from(document.querySelectorAll('.flex')),
    }
    //.log(elements.form);
    console.log(elements.name);
    console.log(elements.date);
    console.log(elements.module);
    console.log(elements.addBtn);
    console.log(elements.module[0]);
    // console.log(elements.modulesDiv);
    // console.log(elements.moduleList);
    // console.log(elements.listItems);

};
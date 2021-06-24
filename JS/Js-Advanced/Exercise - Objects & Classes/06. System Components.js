function systemComponents(input) {

    let result = {};

    input.forEach(row => {
        let [system, component, subComponent] = row.split(' | ');

        if (!result[system]) {
            result[system] = {};
        }
        if (!result[system][component]) {
            result[system][component] = [];
        }
        result[system][component].push(subComponent);

    });
    Object.entries(result).sort((current,next) => {
        return Object.entries(next[1]).length - Object.entries(current[1]).length || current[0].localeCompare(next[0]);
    }).forEach(([system,component]) => {
        console.log(system);
        Object.entries(component).sort((current,next) =>{
            return next[1].length - current[1].length;
        }).forEach(([component,subComponent]) =>{
            console.log(`|||${component}`);
            subComponent.forEach(sub => console.log(`||||||${sub}`));
        });
    });
    console.log();
};


systemComponents([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'
]);


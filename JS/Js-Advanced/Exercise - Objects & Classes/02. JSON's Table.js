function jSONTable(input) {

    let html = '<table>'
    for (const row of input) {
        let result = JSON.parse(row);
        html += '\n\t<tr>\n\t\t'
        html += '<td>' + result.name + '</td>\n\t\t'
        html += '<td>' + result.position +'</td>\n\t\t'
        html += '<td>' + result.salary +'</td>\n\t'
        html += '</tr>'
    }
    html += '\n</table>'
    console.log(html);

}
jSONTable([
    '{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}'
]);

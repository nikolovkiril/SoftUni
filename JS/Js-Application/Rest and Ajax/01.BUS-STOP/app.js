function getInfo() {

    let bussStopName = ['1287', '1308', '1327', '2334'];
    let stopId = document.getElementById('stopId');
    let res = document.getElementById('stopName');
    let ul = document.getElementById('buses');

    const url = `https://judgetests.firebaseio.com/businfo/${stopId.value}.json`;

    if (!bussStopName.includes(stopId.value)) {
        res.textContent = 'Error';
        return;
    }

    fetch(url)
        .then(response => response.json())
        .then(data => {
            res.textContent = data.name;
            Object.keys(data.buses).forEach(key => {

                let li = document.createElement('li');
                li.textContent = `Bus ${key} arrives in ${data.buses[key]}`;
                ul.appendChild(li);
            })

        });

    stopId.value = '';
}
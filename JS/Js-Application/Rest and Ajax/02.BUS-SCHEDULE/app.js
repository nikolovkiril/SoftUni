function solve() {

    let stopName = 'depot';
    let nextStop;
    const firstUrl = `https://judgetests.firebaseio.com/schedule/`;
    const info = document.getElementById('info');

    function changeButton() {
        const depart = document.getElementById('depart');
        const arrive = document.getElementById('arrive');
        if (depart.disabled) {
            depart.disabled = false;
            arrive.disabled = true;
        } else {
            depart.disabled = true;
            arrive.disabled = false;
        }
    }

    function depart() {
        const url = `${firstUrl}${stopName}.json`;
        fetch(url)
            .then(response => response.json())
            .then(data => {
                info.textContent = `Next stop ${data.name}`;
                stopName = data.next;
                nextStop = data.name;
            })
        changeButton();

    }

    function arrive() {
        info.textContent = `Arriving at ${nextStop}`;
        changeButton();
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
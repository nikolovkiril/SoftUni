function tickets(data = [], criterion = "") {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }
    let result = [];
    data.forEach((row) => {
        let [destination, price, status] = row.split('|');
        let splitData = new Ticket(destination, price, status);
        result.push(splitData);
    });
    if (criterion === "destination") {
        result.sort((a, b) =>
            a.destination.localeCompare(b.destination)
        );
    } else if (criterion === "price") {
        result.sort((a, b) =>
            a.price - b.price
        );
    } else if (criterion === "status") {
        result.sort((a, b) =>
            a.status.localeCompare(b.status)
        );
    }
    return result;
}

tickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
],
    'destination'
);
tickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
],
    'status'
);
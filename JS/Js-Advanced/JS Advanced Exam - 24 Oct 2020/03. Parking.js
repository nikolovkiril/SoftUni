class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }
    addCar(carModel, carNumber) {
        if (this.capacity == this.vehicles.length) {
            throw new Error('Not enough parking space.');
        }
        this.vehicles.push({ carModel, carNumber, payed: false });
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let currCar = this.vehicles.find(x => x.carNumber === carNumber);
        let payedCar = this.vehicles.find(x => x.carNumber === carNumber);


        if (!this.vehicles.includes(currCar)) {
            throw new Error('The car, you`re looking for, is not found.');
        }
        if (payedCar.payed == false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }
        this.vehicles.pop(currCar);
        return `${carNumber} left the parking lot.`
    }


    pay(carNumber) {
        let currCar = this.vehicles.find(x => x.carNumber === carNumber);
        let payedCar = this.vehicles.find(x => x.carNumber === carNumber);
        payedCar.payed = true;

        if (!this.vehicles.includes(currCar)) {
            throw new Error(`${carNumber} is not in the parking lot.`);

        }
        if (payedCar.payed == false) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }
        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        let result = `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.\n`;
        let currCar = this.vehicles.find(x => x.carNumber === carNumber);

        if (currCar.carNumber == carNumber) {
            let carModels = currCar.carModel;
            let carNumbers = currCar.carNumber;
            let payeds = currCar.payed;
            if (payeds === false) {
                result += `${carModels} == ${carNumbers} -  Not payed`;
            } else {
                result += `${carModels} == ${carNumbers} - Has payed`;
            }
        } else if(currCar.carNumber == null){
            for (let i = 0; i < this.vehicles.length; i++) {
                let curr = this.vehicles[i];
                let carModels = curr.carModel;
                let carNumbers = curr.carNumber;
                let payeds = curr.payed;

                if (payeds === false) {
                    result += `${carModels} == ${carNumbers} -  Not payed`;

                } else {
                    result += `${carModels} == ${carNumbers} - Has payed`;
                }

            }

        }

        return result;
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.addCar("Volvo t600", "TX36CA"));
console.log(parking.addCar("Volvo t600", "TX3691C"));
console.log(parking.addCar("Volvo t600", "TX691CA"));
console.log(parking.addCar("Volvo t600", "TX3691A"));
console.log(parking.getStatistics());

// console.log(parking.pay("TX3691CA"));
// console.log(parking.pay("TX3691CA"));
// console.log(parking.removeCar("TX3691CA"));
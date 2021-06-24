class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }
    newCustomer({ firstName, lastName, personalId }) {
        let hasCustomer = this.allCustomers.find(x => x.personalId === personalId);
        if (hasCustomer) {
            throw new Error(`${firstName} ${lastName} is already our customer!`);
        }
        let customer = { firstName, lastName, personalId };
        this.allCustomers.push(customer);

        return customer;
    }
    depositMoney(personalId, amount) {
        let curCustom = this.allCustomers.find(x => x.personalId === personalId);
        if (!curCustom) {
            throw new Error('We have no customer with this ID!');
        }
        if (curCustom.totalMoney) {
            curCustom.totalMoney += amount;
        } else {
            curCustom.totalMoney = amount;
            curCustom.transactions = [];
        }
        curCustom.transactions.push(`${curCustom.firstName} ${curCustom.lastName} made deposit of ${amount}$!`);
        return `${curCustom.totalMoney}$`;
    }
    doTask(){
        
    }
    withdrawMoney(personalId, amount) {
        let curCustom = this.allCustomers.find(x => x.personalId === personalId);
        if (!curCustom) {
            throw new Error('We have no customer with this ID!');
        }
        if (curCustom.totalMoney < amount) {
            throw new Error(`${curCustom.firstName} ${curCustom.lastName} does not have enough money to withdraw that amount!`);
        } else {
            curCustom.totalMoney -= amount;
            curCustom.transactions.push(`${curCustom.firstName} ${curCustom.lastName} withdrew ${amount}$!`);
        }
        return `${curCustom.totalMoney}$`;
    }
    customerInfo(personalId) {
        let curCustom = this.allCustomers.find(x => x.personalId === personalId);
        if (!curCustom) {
            throw new Error('We have no customer with this ID!');
        }
        let result = `Bank name: ${this._bankName}\n`;
        result += `Customer name: ${curCustom.firstName} ${curCustom.lastName}\n`;
        result += `Customer ID: ${personalId}\n`;
        result += `Total Money: ${curCustom.totalMoney}$\n`
        if (curCustom.transactions.length > 0) {
            result += 'Transactions:\n';
            for (let i = curCustom.transactions.length; i > 0; i--) {
                result += `${i}. ${curCustom.transactions[i - 1]}\n`;
            }
        }
        return result;
    }
}

let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({ firstName: "Svetlin", lastName: "Nakov", personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: "Mihaela", lastName: "Mileva", personalId: 4151596 }));
bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);
console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
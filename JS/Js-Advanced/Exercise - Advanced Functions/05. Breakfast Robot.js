function solve() {

    let recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2,
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20,
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3,
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1,
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10,
        },
    };

    let currentStock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    };

    let action = {
        restock: (arg1, quantity) => {
            currentStock[arg1] += Number(quantity);
            return `Success`;
        },
        prepare: (arg1, quantity) => {

            let aray = Object.keys(recipes[arg1]);
            for (const microelement of aray) {
                if (currentStock[microelement] < recipes[arg1][microelement] * +quantity) {
                    return `Error: not enough ${microelement} in stock`;
                }
            }
            Object.keys(recipes[arg1]).forEach(microelement => {
                currentStock[microelement] -= recipes[arg1][microelement] * quantity;
            });
            return `Success`;
        },
        report: () => {
            let result = '';
            Object.keys(currentStock).forEach(microelement => {
                let curr = `${microelement}=${currentStock[microelement]} `;
                result += curr;
            });
            return result.trim();
        }
    };
    return (commands) => {
        let [command, arg1, quantity] = commands.split(' ');
        return action[command](arg1, quantity);
    }
}
function solve() {

    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            let task = this.tasks.shift();
            console.log(task);
            this.tasks.push(task);
        }

        collectSalary() {
            let salary = this.salary;
            if(this.constructor.name === 'Manager'){
                salary += this.dividend;
            }
            console.log(`${this.name} received ${salary} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(`${this.name} is working on a simple task.`);
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(`${this.name} is working on a complicated task.`);
            this.tasks.push(`${this.name} is taking time off work.`);
            this.tasks.push(`${this.name} is supervising junior workers.`);
        }

    }

    class Manager extends Employee{
        constructor(name, age) {
            super(name, age);
            this.tasks.push(`${this.name} scheduled a meeting.`);
            this.tasks.push(`${this.name} is preparing a quarterly report.`);
            this.dividend = 0;
        }
    }


    return { Junior, Senior, Manager };

}

solve();
let create = solve();

let junior = new create.Junior('Pesho', 31);
let manager = new create.Manager('Lili', 24);
manager.dividend = 400;
manager.work();
manager.work();
manager.work();
manager.collectSalary();
junior.work();
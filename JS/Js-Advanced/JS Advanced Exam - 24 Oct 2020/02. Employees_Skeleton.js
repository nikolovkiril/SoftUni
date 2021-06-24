function solveClasses() {
    class Developer {

        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.baseSalary = 1000;
            this.tasks = [];
            this.experience = 0;
        }


        addTask(id, taskName, priority) {

            let task = { id, taskName, priority };

            if (priority === 'high') {
                this.tasks.unshift(task);
            } else {
                this.tasks.push(task);
            }

            return `Task id ${id}, with ${priority} priority, has been added.`
        }
        doTask() {
            let hasTask = this.tasks.find(x => x.priority === 'high');

            if (hasTask) {
                return `${priority}`;
            }
            return `${this.firstName}, you have finished all your tasks. You can rest now.`;
        }

        getSalary() {
            return `${this.firstName} ${this.lastName} has a salary of: ${this.baseSalary}`
        }

        reviewTasks() {
            let res = 'Tasks, that need to be completed:\n';

            if (this.tasks.length > 0) {
                for (let i = 0; i < this.tasks.length; i++) {
                    let one = this.tasks[i];
                    if (this.tasks.length === i + 1) {

                        res += `${one.id}: ${one.taskName} - ${one.priority}`;
                    } else {
                        res += `${one.id}: ${one.taskName} - ${one.priority}\n`;
                    }
                }
            }
            return res;
        }
    }
    class Junior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.bonus = bonus;
            this.tasks = [];
            this.baseSalary = 1000 + bonus;
            this.experience = experience;
        }
        learn(years) {
            this.experience++;
        }
    }
    class Senior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.baseSalary = 1000 + bonus;
            this.tasks = [];
            this.experience = experience + 5;

        }
        changeTaskPriority(taskId) {
            let tasksId = this.tasks.find(x => x.taskId === taskId);
            let priorr = this.tasks.find(x => x.priority);
            if (priorr == 'high') {
                priorr == 'low';
            }else{
                priorr == 'high';
            }
            return priorr;
        }
    }

    return {
        Developer,
        Junior,
        Senior
    }
}
let classes = solveClasses();
const developer = new classes.Developer("George", "Joestar");
console.log(developer.addTask(1, "Inspect bug", "low"));
console.log(developer.addTask(2, "Update repository", "high"));
console.log(developer.reviewTasks());
console.log(developer.getSalary());

const junior = new classes.Junior("Jonathan", "Joestar", 200, 2);
junior.addTask(1, "Create functionality", "low");
console.log(junior.getSalary());


const senior = new classes.Senior("Joseph", "Joestar", 200, 2);
senior.addTask(1, "Create functionality", "low");
senior.addTask(2, "Update functionality", "high");
console.log(senior.changeTaskPriority(2)["priority"]);
function Stringer(string, initialLength) {

    this.innerString = string;
    this.innerLength = initialLength;

    this.increase = (initialLength) => {this.innerLength += initialLength};

    this.decrease = (initialLength) => {this.innerLength = this.innerLength - initialLength < 0 ? 0 : this.innerLength - initialLength};

    this.toString = () => {return `${this.innerString.substr(0, this.innerLength)}${this.innerString.length > this.innerLength ? "...": ""}`};
}

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...

test.increase(4);
console.log(test.toString()); //Test
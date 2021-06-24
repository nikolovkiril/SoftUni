function Stringer(string, initialLength) {

    this.innerString = string;
    this.innerLength = initialLength;

    this.increase = (initialLength) => {this.innerLength += initialLength};

    this.decrease = (initialLength) => {this.innerLength = this.innerLength - initialLength < 0 ? 0 : this.innerLength - initialLength};

    this.toString = () => {return `${this.innerString.substr(0, this.innerLength)}${this.innerString.length > this.innerLength ? "...": ""}`};
}
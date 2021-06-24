class List {

    constructor() {
        this.list = [];
        this.list.sort((a, b) => a - b);
        this.size = this.list.length; //or 0;
    }

   add(elemet){

   }
   
    remove(index) {
        if (index < 0 || index >= this.list.length) {
            throw new Error();
        } else {
            this.size--;
            this.list.splice(index, 1);
            return this.list.sort((a, b) => a - b);
        }
    }

    get(index) {
        if (index < 0 || index >= this.list.length) {
            throw new Error();
        } else {
            return this.list[index];
        }
    }
}
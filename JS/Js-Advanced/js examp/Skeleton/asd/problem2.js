function solve() {
    class Article {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }
        toString() {
            let result = `Title: ${this.title}`;
            result += '\n'
            result += `Content: ${this.content}`;
            return result;
        }

    }
    class ShortReports extends Article {
        constructor(title, content, originalResearch) {
            if (content.length >= 150) {
                throw new Error('Short reports content should be less then 150 symbols.');
            }
            super(title, content);
            this.comments = [];
        }

    }
    class BookReview {

    }
}



let classes = solve();
let lorem = new classes.Article("Lorem", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce non tortor finibus, facilisis mauris vel…");
console.log(lorem.toString()); 
let short = new classes.ShortReports("SpaceX and Javascript", "Yes, its damn true.SpaceX in its recent launch Dragon 2 Flight has used a technology based on Chromium and Javascript. What are your views on this ?", { title: "Dragon 2", author: "wikipedia.org" });
class Article {

    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = []; //like count  
        this._id = 1;

    }
    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`
        }

        if (this._likes.length === 1) {
            return `${this._likes[0]} likes this article!`
        }

        return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`
    }
    like(username) {
        if (this.creator === username) {
            throw new Error("You can't like your own articles!");
        }

        if (this._likes.includes(username)) {
            throw new Error("You can't like the same article twice!");

        }

        this._likes.push(username);

        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error("You can't dislike this article!");
        }

        let index = this._likes.indexOf(username);

        this._likes.splice(index, 1);

        return `${username} disliked ${this.title}`;
    }
    comment(username, content, id) {
        let com = null;

        this._comments.forEach(e => {
            if (e.id === id) {
                com = e;
            }
        });

        if (!com) {
            let comment = {
                id: this._id,
                username,
                content,
                replies: []
            }

            this._id += 1;
            this._comments.push(comment);
            return `${username} commented on ${this.title}`;
        }

        let index = com.replies.length;

        let rep = {
            Id: `${com.id}.${index + 1}`,
            username,
            content
        }

        com.replies.push(rep);

        return 'You replied successfully';
    }

    toString(sortingType) {

        let sortedComets = this.sortFunctions[sortingType](this._comments);

        return `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\nComments:\n` + sortedComets.reduce((acc, c) => {
            acc.push(`-- ${c.id}. ${c.username}: ${c.content}`);

            if (c.replies.length > 0) {
                let sortedRep = this.sortFunctions[sortingType](c.replies);
                let sR = sortedRep.reduce((acc2, r) => {
                    acc2.push(`--- ${r.Id}. ${r.username}: ${r.content}`);
                    return acc2;
                }, []).join('\n');

                acc.push(sR);
            }
            return acc;
        }, []).join('\n');
    }

    sortFunctions = {
        'asc': (a) => a.sort((a, b) => a.id - b.id),
        'desc': (a,) => a.sort((a, b) => b.id - a.id),
        'username': (a) => a.sort((a, b) => a.username.localeCompare(b.username))
    }
}

let art = new Article("My Article", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
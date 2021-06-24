const UserModel = firebase.auth();
const DB = firebase.firestore();

const app = Sammy('#root', function () {

    this.use('Handlebars', 'hbs');

    this.get('/home', function (context) {

        DB.collection('posts')
            .get()
            .then((res) => {
                context.posts = res.docs.map((post) => { return { id: post.id, ...post.data() } });
                extendContext(context)
                    .then(function () {
                        this.partial('./templates/home.hbs');
                    })
            })
    });

    this.get('/register', function (context) {
        extendContext(context)
            .then(function () {
                this.partial('./templates/register.hbs');
            })
    });

    this.post('/register', function (context) {
        const { email, password, rePassword } = context.params;
        console.log(context.params);
        if (password !== rePassword) {
            throw new Error(alert('pass'))
        }
        UserModel.createUserWithEmailAndPassword(email, password)
            .then((user) => {

                this.redirect('/login');
            })
            .catch((error) => {
                if (email === '') {
                    alert('empty')
                } else if (password.length < 6) {
                    alert('short')
                    return;
                } else {
                    alert('same user')
                    return;
                }
            });
    });

    this.get('/login', function (context) {
        extendContext(context)
            .then(function () {
                this.partial('./templates/login.hbs');
            })
    });

    this.post('/login', function (context) {
        const { email, password } = context.params;

        UserModel.signInWithEmailAndPassword(email, password)
            .then((user) => {
                saveUserData(user);
                this.redirect('/home');
            })
            .catch((error) => {
                if (email === '') {
                    alert('empty')
                } else if (password.length < 6) {
                    alert('short')
                    return;
                }
            });
    });

    this.post('/create-post', function (context) {
        const { title, category, content } = context.params;
        console.log(context.params);
        DB.collection('posts').add({
            title,
            category,
            content,
            creator: getUserData().uid,
        }).then(() => {
            this.redirect('/home');
        })
    });

    this.get('/edit/:postid', function (context) {

        const { postid } = context.params;
        DB.collection('posts')
            .doc(postid)
            .get()
            .then((res) => {

                context.posts = { id: postid, ...res.data() };
                console.log(res.data());
                extendContext(context)
                    .then(function () {
                        this.partial('/templates/editPost.hbs');
                    });
            });
    });

    this.post('/edit/:postid', function (context) {

        const { title, category, content } = context.params;
        DB.collection('posts')
            .doc(postid)
            .get()
            .then((res) => {

                console.log(res);
                return DB.collection('posts')
                    .doc(postid)
                    .set({
                        ...res.data(),
                        title,
                        category,
                        content
                    })
                    .then((res) => {
                        this.redirect('/home');
                    });
            });
    });

    this.get('/delete/:postid', function (context) {
        const { postid } = context.params;

        DB.collection('posts')
            .doc(postid)
            .delete()
            .then(() => {
                this.redirect('/home')
            })
    });

    this.get('/details/:postid', function (context) {
        const { postid } = context.params;
        DB.collection('posts')
            .doc(postid)
            .get()
            .then((res) => {
                const { uid } = getUserData();
                const actualPost = res.data();
                const curUser = actualPost.creator === uid;

                context.posts = { ...actualPost, uid, id: postid };
                console.log(actualPost.creator);
                console.log(curUser);
                extendContext(context)
                    .then(function () {
                        this.partial('/templates/details.hbs');
                    });
            });

    });

    this.get('/logout', function (context) {
        UserModel.signOut()
            .then((res) => {
                clearUserData();
                this.redirect('/home');
            }).catch(function (error) {
                // An error happened.
            });
    });
});

app.run('/home');

function extendContext(context) {

    const user = getUserData();
    context.isLoggedIn = Boolean(getUserData());
    context.email = user ? user.email : '';

    return context.loadPartials({
        'header': './templates/common/header.hbs',
        'post': './templates/post.hbs',
    })
};

function saveUserData(data) {
    const { user: { email, uid } } = data;
    localStorage.setItem('user', JSON.stringify({ email, uid }));
};

function getUserData() {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user) : null;
};

function clearUserData() {
    this.localStorage.removeItem('user');
};


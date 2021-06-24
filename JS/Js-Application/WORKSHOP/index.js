const UserModel = firebase.auth();

const db = firebase.firestore();


const app = Sammy('body', function () {

    this.use('Handlebars', 'hbs');

    this.get('/home', function (context) {
        db.collection("movies")
            .get()
            .then(res => {
                context.movies = res.docs.map((movie) => { return { id: movie.id, ...movie.data() } });
                extendContext(context)
                    .then(function () {
                        this.partial('./templates/display.hbs');
                    });
            });

    });

    this.get('/login', function (context) {
        extendContext(context)
            .then(function () {
                this.partial('./templates/login.hbs');
            });
    });

    this.post('/login', function (context) {
        const { email, password } = context.params;
        if (email !== '' && password.length >= 6) {
            UserModel.signInWithEmailAndPassword(email, password)
                .then((userData) => {
                    saveUserData(userData);
                    this.redirect('/home');
                    throw new Error(alert('Login successful.'));
                }).catch(function (error) {
                    // Handle Errors here.
                    var errorCode = error.code;
                    if (errorCode == 'auth/user-not-found') {
                        alert('There is no user record corresponding to this identifier. The user may have been deleted.');
                    }
                });
        } else {
            if (email === '') {
                throw new Error(alert('The email address is badly formatted.'))
            } if (password.length < 6) {
                throw new Error(alert('Password should be at least 6 characters'))
            }
        }

    });

    this.get('/logout', function (context) {
        UserModel.signOut()
            .then(() => {
                clearUserData();
                this.redirect('/login');
            })
            .catch(alert('Successful logout'));
    });

    this.get('/register', function (context) {
        extendContext(context)
            .then(function () {
                this.partial('./templates/register.hbs');
            });
    });

    this.post('/register', function (context) {
        const { email, password, repeatPassword } = context.params;

        if (email !== '' && password.length >= 6 && password === repeatPassword) {
            UserModel.createUserWithEmailAndPassword(email, password)
                .then((userData) => {
                    this.redirect('#/login');
                })
                .catch(alert('Successful registration!'));
        } else {
            if (email === '') {
                throw new Error(alert('The email address is badly formatted.'))
            }
            if (password.length < 6) {
                throw new Error(alert('Password should be at least 6 characters'))
            }
        }
    });

    this.get('/addMovie', function (context) {
        extendContext(context)
            .then(function () {
                this.partial('./templates/addMovie.hbs');
            });
    });

    this.post('/addMovie', function (context) {

        const { title, description, imageUrl } = context.params;
        db.collection('movies').add({
            title,
            description,
            imageUrl,
            Creator: getUserData().uid,
            PeopleLiked: []
        }).then(() => {
            this.redirect('/home');
        })
            .catch(alert('Created successfully!'));
    })

});


(() => {
    app.run('/home');
})();

function extendContext(context) {

    const user = getUserData();
    context.isLoggedIn = Boolean(user);
    context.userEmail = user ? user.email : '';

    return context.loadPartials({
        'header': './templates/header.hbs',
        'footer': './templates/footer.hbs',
        'moveisSearchAdd': './templates/moveisSearchAdd.hbs',
        'description': './templates/description.hbs',
    })
};
function saveUserData(userData) {
    const { user: { email, uid } } = userData;
    localStorage.setItem('user', JSON.stringify({ email, uid }));
};

function getUserData() {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user) : null;
};

function clearUserData() {
    this.localStorage.removeItem('user');
};


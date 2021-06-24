const UserModel = firebase.auth();
const DB = firebase.firestore();

const app = Sammy('#root', function () {

    this.use('Handlebars', 'hbs');

    this.get('/home', function (context) {

        DB.collection('destinations')
            .get()
            .then((res) => {
                context.destinations = res.docs.map((des) => { return { id: des.id, ...des.data() } });
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
        if (password !== rePassword) {
            return;
        }
        UserModel.createUserWithEmailAndPassword(email, password)
            .then((user) => {
                alert('User registration successful.')
                this.redirect('/login');
            })
            .catch((error) => {
                if (email === '') {
                    throw new error(alert('Incorect email'))
                } else if (password.length < 6) {
                    throw new error(alert('Password lenght must be at least 6 characters'));
                } else {
                    throw new error(alert('Something went wrong'));
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
                alert('Login successful.')
                this.redirect('/home');
            })
            .catch((error) => {
                if (email === '') {
                } else if (password.length < 6) {
                    throw new error(alert('Password lenght must be at least 6 characters'));
                }
            });
    });

    this.get('/add', function (context) {
        extendContext(context)
            .then(function () {
                this.partial('./templates/createDes.hbs');
            })
    });

    this.post('/add', function (context) {
        const { destination, city, duration, departureDate, imgUrl } = context.params;
        DB.collection('destinations').add({
            destination,
            city,
            duration,
            departureDate,
            imgUrl,
            creator: getUserData().uid,
            clients: []
        }).then(() => {
            this.redirect('/home');
        })
    });

    this.get('/edit/:desId', function (context) {

        const { desId } = context.params;
        DB.collection('destinations')
            .doc(desId)
            .get()
            .then((res) => {

                context.des = { id: desId, ...res.data() };
                extendContext(context)
                    .then(function () {
                        this.partial('/templates/editDes.hbs');
                    });
            });
    });

    this.post('/edit/:desId', function (context) {

        const { desId, destination, city, duration, departureDate, imgUrl } = context.params;
        DB.collection('destinations')
            .doc(desId)
            .get()
            .then((res) => {
                return DB.collection('destinations')
                    .doc(desId)
                    .set({
                        ...res.data(),
                        destination,
                        city,
                        duration,
                        departureDate,
                        imgUrl,
                    })
                    .then((res) => {
                        this.redirect(`/details/${desId}`);
                    });
            });
    });

    this.get('/delete/:desId', function (context) {
        const { desId } = context.params;

        DB.collection('destinations')
            .doc(desId)
            .delete()
            .then(() => {
                this.redirect('/destinations')
            })
    });   

    this.get('/details/:desId', function (context) {
        const { desId } = context.params;

        DB.collection('destinations')
            .doc(desId)
            .get()
            .then((res) => {
                const { uid } = getUserData();
                const actualDes = res.data();

                const salesman = actualDes.creator === uid;
                const client = !!actualDes.clients.find(id => id === uid);

                context.des = { ...actualDes, salesman, id: desId };
                extendContext(context)
                    .then(function () {
                        this.partial('/templates/details.hbs');
                    });
            });

    });

    this.get('/destinations', function (context) {

        DB.collection('destinations')
            .get()
            .then((res) => {
                const { uid } = getUserData();

                context.destinations = res.docs.map((des) => { return { id: des.id, ...des.data()} });
                extendContext(context)
                    .then(function () {
                        this.partial('./templates/dashboard.hbs');
                    })
            })
            

    });

    this.get('/logout', function (context) {
        UserModel.signOut()
            .then((res) => {
                clearUserData();
                alert('Logout successful.')
                this.redirect('/login');
            }).catch(function (error) {
                throw new error(alert('Something went wrong'));
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
        'footer': './templates/common/footer.hbs',
        'notifications': './templates/common/notifications.hbs'
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



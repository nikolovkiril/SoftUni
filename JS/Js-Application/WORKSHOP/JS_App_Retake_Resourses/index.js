const UserModel = firebase.auth();
const DB = firebase.firestore();

const app = Sammy('#root', function () {

    this.use('Handlebars', 'hbs');

    this.get('/home', function (context) {

        DB.collection('offers')
            .get()
            .then((res) => {
                context.offers = res.docs.map((offer) => { return { id: offer.id, ...offer.data() } });
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
            notify('Password dost match!!!','error')
            return;
        }
        UserModel.createUserWithEmailAndPassword(email, password)
            .then((user) => {

                this.redirect('/login');
            })
            .catch((error) => {
                if (email === '') {
                    notify('empty','error')
                } else if (password.length < 6) {
                    notify('short' , 'error')
                    return;
                } else {
                    notify('same user')
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
                    notify('empty')
                } else if (password.length < 6) {
                    notify('short')
                    return;
                }
            });
    });

    this.get('/create-offer', function (context) {
        extendContext(context)
            .then(function () {
                this.partial('./templates/newOffer.hbs');
            })
    });

    this.post('/newOffer', function (context) {
        const { name, price, imgURL, description, brand } = context.params;
        DB.collection('offers').add({
            name,
            price,
            imgURL,
            description,
            brand,
            salesMan: getUserData().uid,
            clients: []
        }).then(() => {
            this.redirect('/home');
        })
    });

    this.get('/edit-offer/:id', function (context) {
        extendContext(context)
            .then(function () {
                this.partial('./templates/editOffer.hbs');
            })
    });

    this.get('/edit/:offerId', function (context) {

        const { offerId } = context.params;
        DB.collection('offers')
            .doc(offerId)
            .get()
            .then((res) => {

                context.offer = { id: offerId, ...res.data() };

                extendContext(context)
                    .then(function () {
                        this.partial('/templates/editOffer.hbs');
                    });
            });
    });

    this.post('/edit/:offerId', function (context) {

        const { offerId, name, price, imgURL, description, brand } = context.params;
        DB.collection('offers')
            .doc(offerId)
            .get()
            .then((res) => {
                return DB.collection('offers')
                    .doc(offerId)
                    .set({
                        ...res.data(),
                        name,
                        price,
                        imgURL,
                        description,
                        brand,
                    })
                    .then((res) => {
                        this.redirect(`/details/${offerId}`);
                    });
            });
    });

    this.get('/delete/:offerId', function (context) {
        const { offerId } = context.params;

        DB.collection('offers')
            .doc(offerId)
            .delete()
            .then(() => {
                this.redirect('/home')
            })
    });

    this.get('/buy/:offerId', function (context) {
        const { offerId } = context.params;
        const { uid } = getUserData().uid;

        DB.collection('offers')
            .doc(offerId)
            .get()
            .then((res) => {
                const offerData = { ...res.data() };
                offerData.clients.push(getUserData().uid)
                return DB.collection('offers')
                    .doc(offerId)
                    .set(offerData)
            })
            .then(() => {
                this.redirect(`/details/${offerId}`)
            })
    });

    this.get('/details/:offerId', function (context) {
        const { offerId } = context.params;

        DB.collection('offers')
            .doc(offerId)
            .get()
            .then((res) => {
                const { uid } = getUserData();
                const actualOfferData = res.data();

                const salesman = actualOfferData.salesMan === uid;
                const client = !!actualOfferData.clients.find(id => id === uid);

                context.offer = { ...actualOfferData, salesman, id: offerId };
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
function notify(message, type = 'success') {
    let notifycationEl;

    switch (type) {
        case 'success':
            notifycationEl = document.getElementById('successBox');
            break;
        case 'error':
            notifycationEl = document.getElementById('errorBox');
            break;
    }
    notifycationEl.innerHTML = message;
    notifycationEl.parentElement.style.display = 'block';
}


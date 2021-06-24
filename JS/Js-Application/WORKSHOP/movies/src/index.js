import { homePage } from './controllers/home.js';
import { registerPage, loginPage, postRegister, addMoviePage, detailsPage, postLogin, postMovie , logout} from './controllers/user.js';
import * as api from './data.js';
import { getUserData } from './util.js'
window.api = api;

const app = Sammy('#root', function (context) {

    this.use('Handlebars', 'hbs');

    const user = getUserData();
    this.userData = user;

    this.get('/', homePage);
    this.get('/home', homePage);
    this.get('/register', registerPage);
    this.get('/login', loginPage);
    this.get('/addMovie', addMoviePage);
    this.get('/details/:id', detailsPage);

    this.get('/logout', logout);

    this.post('/register', (context) => { postRegister(context); });
    this.post('/login', (context) => { postLogin(context); });
    this.post('/addMovie', (context) => { postMovie(context); });
});

app.run();



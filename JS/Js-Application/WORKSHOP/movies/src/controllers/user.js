import { login, register, createMovie, getById, getAll , clearUserData } from '../data.js';
import { addPartials, getUserData, getUserId } from '../util.js';

export async function loginPage() {
    await addPartials(this);
    this.partial('/templates/user/loginPage.hbs');
};

export async function registerPage() {
    await addPartials(this);
    this.partial('/templates/user/registerPage.hbs');
};

export async function postRegister(context) {
    const { email, password, rePassword } = context.params;
    if (email.lenght == 0 || password.lenght == 0) {
        throw new Error('field are empty');
    } else if (password != rePassword) {
        throw new Error('pas dont match');
    } else {
        const result = await register(email, password);
        context.app.userData = result;
        context.redirect('/login');
    }
};

export async function postLogin(context) {
    const { email, password } = context.params;
    if (email.lenght == 0 || password.lenght == 0) {
        throw new Error('field are empty');
    } else {
        const result = await login(email, password);
        context.app.userData = result;
        context.redirect('/home');
    }
};

export async function logout(context) {
    const result = await clearUserData();
    context.redirect('/login');
};

export async function addMoviePage() {
    await addPartials(this);
    const context = {
        user: this.app.userData,
    }
    this.partial('/templates/catalog/addMovie.hbs', context);
};

export async function postMovie(context) {
    const { title, description, imageUrl } = context.params;
    if (title == '' || description == '' || imageUrl == '') {
        notify('Invalid inputs!', 'error');
        return;
    } else {
        const result = await createMovie({
            title,
            description,
            imageUrl,
            canEdit: movie._ownerId != user.localId
        });
        notify('Created successfully!')
        context.redirect('/home');
    }
};

export async function detailsPage() {
    await addPartials(this);
    const movie = await getById(this.params.id);
    const context = {
        user: this.app.userData,
        movie
    }
    console.log(movie._ownerId);
    console.log(context.user.localId);
    this.partial('/templates/description/details.hbs', context);
};
import { login, register, getById, clearUserData } from '../data.js';
import { addPartials, getUserData, getUserId } from '../util.js';

export async function loginPage() {
    await addPartials(this);
    this.partial('/templates/login.hbs');
};

export async function registerPage() {
    await addPartials(this);
    this.partial('/templates/register.hbs');
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
    try {
        if (email.lenght == 0 || password.lenght == 0) {
            throw new Error('field are empty');
        } else {
            const result = await login(email, password);
            context.app.userData = result;
            context.redirect('/home');
        }
    } catch {
        context.redirect('/login');
    }
};

export async function logout(context) {
    const result = await clearUserData();
    context.redirect('/login');
};

// export async function addPost() {
//     await addPartials(this);
//     const context = {
//         user: this.app.userData,
//     }
//     this.partial('/templates/post.hbs', context);
// };

export async function postCreatePost(context) {
    const { title, category, content } = context.params;
    if (title == '' || description == '' || imageUrl == '') {
        return;
    } else {
        const result = await createMovie({
            title,
            category,
            content,
            canEdit: movie._ownerId != user.localId
        });
        context.redirect('/home');
    }
};

export async function detailsPage() {
    await addPartials(this);
    const post = await getById(this.params.id);
    const context = {
        user: this.app.userData,
        post
    }
    console.log(movie._ownerId);
    console.log(context.user.localId);
    this.partial('/templates/details.hbs', context);
};
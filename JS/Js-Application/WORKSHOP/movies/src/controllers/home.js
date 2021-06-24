import { getAll } from '../data.js';
import { addPartials } from '../util.js';

export async function homePage() {
    await addPartials(this);

    const context = {
        movies : await getAll()
    };

    context.user = this.app.userData;


    this.partial('/templates/catalog/homePage.hbs',context);
};
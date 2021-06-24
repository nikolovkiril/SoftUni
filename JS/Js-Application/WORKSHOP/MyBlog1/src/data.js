import { getUserData, setUserData, objectToArray } from "./util.js";

const apiKey = 'AIzaSyBuj2asCgO4KoSg1Kw2XydVDsui8JFdhDA';
const databaseUrl = 'https://myblog-f8a9d-default-rtdb.firebaseio.com/';

const endPoints = {
    LOGIN: 'https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=',
    REGISTER: 'https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=',
    POSTS: 'posts',
    POSTS_BY_ID: 'posts/'
};
function host(url) {
    let res = databaseUrl + url + '.json';
    const auth = getUserData();
    if (auth !== null) {
        res += `?auth=${auth.idToken}`;
    }
    return res;
}

async function request(url, method, body) {
    let option = {
        method,
    };
    if (body) {
        Object.assign(option, {
            headers: {
                'content-type': 'application/json',
            },
            body: JSON.stringify(body)
        });
    }

    let response = await fetch(url, option);
    let data = await response.json();
    return data;
};

async function get(url) {
    return request(url, 'GET');
};
async function post(url, body) {
    return request(url, 'POST', body);
};
async function del(url) {
    return request(url, 'DELETE');
};
async function patch(url, body) {
    return request(url, 'PATCH', body);
};

export async function login(email, password) {
    let response = await post(endPoints.LOGIN + apiKey, {
        email,
        password,
        returnSecureToken: true
    });

    setUserData(response);

    return response;

};
export async function register(email, password) {
    let response = await post(endPoints.REGISTER + apiKey, {
        email,
        password,
        returnSecureToken: true
    });

    setUserData(response);

    return response;
};

export async function clearUserData(context) {
    sessionStorage.clear();
};

// export async function createPost(post) {
//     const data = Object.assign({ _ownerId: getUserId()}, post);
//     return post(host(endPoints.POSTS), data);
// }

export async function getAll() {
    const records = await get(host(endPoints.POSTS));
    return objectToArray(records);
};

export async function getById(id) {
    const record = await get(host(endPoints.POSTS_BY_ID + id));
    record._id = id;
    return record;
};

export async function editMovie(id, post) {
    return patch(host(endPoints.POSTS_BY_ID + id), post);
};

export async function deleteById(id) {
    return del(host(endPoints.POSTS_BY_ID + id));
};

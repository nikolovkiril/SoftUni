function solve(request) {

    let method = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let regex = /^([A-Za-z0-9.]+)$|\*/g;
    let version = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let messageRgx = /^([^<>\\&'"]*)$/g;

    if (!method.includes(request.method) || !request.hasOwnProperty('method')) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (!request.uri.match(regex)|| !request.hasOwnProperty('method')) {
        throw new Error('Invalid request header: Invalid URI');
    }

    if (!version.includes(request.version)|| !request.hasOwnProperty('method')) {
        throw new Error('Invalid request header: Invalid Version');
    }

    if (!request.message.match(messageRgx)|| !request.hasOwnProperty('method')) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return request;
}
solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
});
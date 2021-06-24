function attachEvents() {
    let sendBtn = document.getElementById('submit');
    let refreshBtn = document.getElementById('refresh');

    let author = document.getElementById('author');
    let content = document.getElementById('content');


    let getUrl = 'https://rest-messanger.firebaseio.com/messanger.json'; //GET request


    sendBtn.addEventListener('click', sendMsg);
    refreshBtn.addEventListener('click', refresh);

    function sendMsg() {
        let obj = {
            author: author.value,
            content: content.value
        }
        fetch(getUrl, { method: "POST", body: JSON.stringify(obj) });

        author.value = '';
        content.value = '';
    };

    function refresh() {
        fetch(getUrl)
            .then(response => response.json())
            .then((data) => {
                messages.textContent = '';
                let res = Object.values(data)
                    .reduce((messages, message) =>
                        (messages += `${message.author}: ${message.content}\n`));

                document.getElementById('messages').textContent = res;

            });
    };
}

attachEvents();
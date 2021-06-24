function toggle() {

    let changeText = document.getElementsByClassName('button')[0];

    let displayStyle = document.getElementById('extra');

    if (changeText.textContent == 'More') {
        displayStyle.style.display = 'block';
        changeText.textContent = 'Less';
    }else{
        changeText.textContent = 'More';
        displayStyle.style.display = 'none';
    }
}
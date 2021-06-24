function attachEvents() {

    const url = 'https://judgetests.firebaseio.com/locations.json';

    const cityes = ["London", "New York", "Barcelona"];

    let location = document.getElementById('location');
    let getWeather = document.getElementById('submit');

    let currentConditionsDiv = document.getElementById('current');
    let parentDiv = document.getElementById('forecast');

    let upcoming = document.getElementById('upcoming');

    const weatherSymbols = {
        'Sunny': '&#x2600',              // ☀
        'Partly sunny': '&#x26C5',       // ⛅
        'Overcast': '&#x2601',           // ☁
        'Rain': '&#x2614',               // ☂
        'Degrees': '&#176',              // °
    }

    getWeather.addEventListener('click', () => {
        fetch(url)
            .then(res => res.json())
            .then(data => {
                let code;
                for (let locObj of data) {
                    if (location.value === locObj.name) {
                        code = locObj.code;
                    }
                }
                let currentConditions = fetch(`https://judgetests.firebaseio.com/forecast/today/${code}.json`)
                    .then(res => res.json());


                let treeDayForecast = fetch(`https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`)
                    .then(res => res.json());


                Promise.all([currentConditions, treeDayForecast])
                    .then(forecast)
                    .catch(error => {
                        parentDiv.textContent = 'Error';
                    });
                location.value = '';
            });
    });

    function forecast([currentConditionsData, treeDayForecastData]) {

        parentDiv.style.display = 'block';
        todayForecast(currentConditionsData);
        nextTreeDaysForecast(treeDayForecastData);
    };

    function nextTreeDaysForecast(treeDayForecastData) {

        let upcomingDiv = createElement('div', 'forecast-info', '');
        upcoming.appendChild(upcomingDiv);

        treeDayForecastData.forecast.forEach(obj => {
            let spanUpcoming = createElement('span', 'upcoming', '');
            upcomingDiv.appendChild(spanUpcoming);

            let upcomingSymbol = weatherSymbols[obj.condition];
            let spanSymbol = createElement('span', 'symbol', upcomingSymbol);

            let temp = `${obj.low}${weatherSymbols.Degrees}/${obj.high}${weatherSymbols.Degrees}`;

            let spanTemp = createElement('span', 'forecast-data', temp);
            let spanCond = createElement('span', 'forecast-data', obj.condition);
            spanUpcoming.appendChild(spanSymbol);
            spanUpcoming.appendChild(spanTemp);
            spanUpcoming.appendChild(spanCond);

        });


    };

    function todayForecast(currentConditionsData) {

        //parentDiv.removeChild(error1);
        let divEl = createElement("div", "forecasts", "");
        let symbol = weatherSymbols[currentConditionsData.forecast.condition];
        let spanConditionSymbol = createElement('span', 'condition symbol', symbol);

        divEl.appendChild(spanConditionSymbol);
        currentConditionsDiv.appendChild(divEl);
        parentDiv.style.display = 'block';

        let spanCondition = createElement('span', 'condition', '');

        let temperature = `${currentConditionsData.forecast.low}${weatherSymbols.Degrees}/${currentConditionsData.forecast.high}${weatherSymbols.Degrees}`;

        let spanName = createElement('span', 'forecast-data', currentConditionsData.name);
        let spanTemperature = createElement('span', 'forecast-data', temperature);
        let spanConditionIn = createElement('span', 'forecast-data', currentConditionsData.forecast.condition);

        divEl.appendChild(spanCondition);

        spanCondition.appendChild(spanName);
        spanCondition.appendChild(spanTemperature);
        spanCondition.appendChild(spanConditionIn);
    };

    function createElement(element, newClassName, content) {
        let elementToCreate = document.createElement(element);
        elementToCreate.className = newClassName;
        elementToCreate.innerHTML = content;

        return elementToCreate;
    };
}

attachEvents();
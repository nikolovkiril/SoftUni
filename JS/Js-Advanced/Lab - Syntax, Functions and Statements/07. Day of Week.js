function DayOfWeek(input) {
    let resut;

    switch (input) {
        case 'Monday': resut = 1;
            break;
        case 'Tuesday': resut = 2;
            break;
        case 'Wednesday': resut = 3;
            break;
        case 'Thursday': resut = 4;
            break;
        case 'Friday': resut = 5;
            break;
        case 'Saturday': resut = 6;
            break;
        case 'Sunday': resut = 7;
            break;

        default:
            resut = 'error';
            break;
    }
    console.log(resut);

}
DayOfWeek('Sunday');
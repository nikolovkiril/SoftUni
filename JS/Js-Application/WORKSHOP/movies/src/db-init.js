/* globals firebase */

export default function init(){
    var firebaseConfig = {
        apiKey: "AIzaSyCmc-llp-R3oOCpK229BJXPrEK-CSlXfpo",
        authDomain: "movies-workshop-22970.firebaseapp.com",
        databaseURL: "https://movies-workshop-22970.firebaseio.com",
        projectId: "movies-workshop-22970",
        storageBucket: "movies-workshop-22970.appspot.com",
        messagingSenderId: "511979894437",
        appId: "1:511979894437:web:551d3d844b5e7655d5bf4c"
      };
      firebase.initializeApp(firebaseConfig);
}


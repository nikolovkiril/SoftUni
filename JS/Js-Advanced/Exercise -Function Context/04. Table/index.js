function solve() {
   let tbodyElement = document.getElementsByTagName('tbody')[0];
   let lastClicked;

   Array.from(tbodyElement.children).forEach(x => {
      x.addEventListener('click', handler);
   });
   function handler(e) {
      let elementToChange = e.target.parentElement;
      if (elementToChange.style.backgroundColor === '') {
         elementToChange.style.backgroundColor = "#413f5e";
         if (lastClicked === undefined) {
            lastClicked = elementToChange;
         } else {
            if (lastClicked !== elementToChange) { 
               lastClicked.style.backgroundColor = '';
               lastClicked = elementToChange;
            }
         }
      } else {
         elementToChange.style.backgroundColor = '';
      }

   }
}

function solve() {

   let btn = document.querySelector('.btn.create');
   btn.addEventListener('click', createArticle);

   function createArticle(e) {
      e.preventDefault();

      let author = document.getElementById('creator');
      let title = document.getElementById('title');
      let category = document.getElementById('category');
      let content = document.getElementById('content');

      if (!author.value || !title.value || !category.value || !content.value) {
         return;
      }
      generateArticleStructure(author, title, category, content);

   }
   function deleteArticle(e) {
      let asd = e.target.parentElement.parentElement.remove();q 
   }

   function archive(e) {
      let titleArticle = e.target.parentElement.parentElement.querySelector('h1').textContent;
      let archiveSectio = document.querySelector('.archive-section ul');

      let li = document.createElement('li');
      li.textContent = titleArticle;
      archiveSectio.appendChild(li);

      let sortedLi = Array.from(archiveSectio.getElementsByTagName('li'))
         .sort((a, b) => (a.textContent).localeCompare(b.textContent));

      while (archiveSectio.firstChild) {
         archiveSectio.removeChild(archiveSectio.firstChild);
      }

      for (const element of sortedLi) {
         archiveSectio.appendChild(element);
      }
      deleteArticle(e);
   }

   function generateArticleStructure(author, title, category, content) {

      let article = document.createElement('article');
      let h1 = document.createElement('h1');
      h1.textContent = title.value;
      article.appendChild(h1);


      let categoryP = document.createElement('p');
      categoryP.innerHTML = 'Category:';
      let categoryStrong = document.createElement('strong');
      categoryStrong.textContent = category.value;
      categoryP.appendChild(categoryStrong);
      article.appendChild(categoryP);

      let authorP = document.createElement('p');
      authorP.innerHTML = `Creator:`;
      let authorStrong = document.createElement('strong');
      authorStrong.textContent = author.value;
      authorP.appendChild(authorStrong);
      article.appendChild(authorP);

      let contentP = document.createElement('p');
      contentP.textContent = content.value;
      article.appendChild(contentP);

      let div = document.createElement('div');
      div.classList.add('buttons');

      let deletBtn = document.createElement('button');
      deletBtn.classList.add('btn', 'delete');
      deletBtn.textContent = 'Delete';
      deletBtn.addEventListener('click', deleteArticle);


      let archiveBtn = document.createElement('button');
      archiveBtn.classList.add('btn', 'archive');
      archiveBtn.textContent = 'Archive';
      archiveBtn.addEventListener('click', archive);

      div.appendChild(deletBtn);
      div.appendChild(archiveBtn);

      article.appendChild(div);
      document.querySelector('main section').appendChild(article);

   }


}

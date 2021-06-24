using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] articleTokens = Console.ReadLine().Split(", ");
            Article myArticle = new Article(articleTokens[0], articleTokens[1], articleTokens[2]);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] cmdTokens = Console.ReadLine().Split(": ");
                string cmd = cmdTokens[0];

                if (cmd == "Edit")
                {
                    myArticle.Edit(cmdTokens[1]);
                }
                else if (cmd == "ChangeAuthor")
                {
                    myArticle.ChangeAuthor(cmdTokens[1]);
                }
                else
                {
                    myArticle.Rename(cmdTokens[1]);
                }
            }
            Console.WriteLine(myArticle);
        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public void Edit(string content)
        {
            this.Content = content;
        }
        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }
        public void Rename(string title)
        {
            this.Title = title;
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}

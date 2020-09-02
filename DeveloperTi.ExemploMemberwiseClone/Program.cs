using System;

namespace DeveloperTi.ExemploMemberwiseClone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var livro1 = new Book
            {
                Author = "José de Deus",
                Title = "Vai com Jeová",
                Category = new Category("Terror")
            };

            var livro2 = livro1.ShallowCopy();

            Console.WriteLine("Livro 1 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro1.Author, livro1.Title, livro1.Category.Name);
            Console.WriteLine("Livro 2 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro2.Author, livro2.Title, livro2.Category.Name);
            Console.WriteLine("");

            livro1.Author = "Junior";
            livro1.Title = "Será que deu certo??";
            livro1.Category.Name = "AutoAjuda";
            Console.WriteLine("Livro 1 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro1.Author, livro1.Title, livro1.Category.Name);
            Console.WriteLine("Livro 2 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro2.Author, livro2.Title, livro2.Category.Name);
            Console.WriteLine("");

            var livro3 = livro1.DeepCopy();

            livro1.Author = "Otávio";
            livro1.Title = "Será que deu certo 2??";
            livro1.Category.Name = "SelfHeal";
            Console.WriteLine("Livro 1 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro1.Author, livro1.Title, livro1.Category.Name);
            Console.WriteLine("Livro 3 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro3.Author, livro3.Title, livro3.Category.Name);
            Console.ReadKey();
        }
    }
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public Category Category { get; set; }

        public Book ShallowCopy()
        {
            return (Book)this.MemberwiseClone();
        }
        public Book DeepCopy()
        {
            var book = (Book)this.MemberwiseClone();
            book.Category = new Category(Category.Name);
            book.Author = string.Copy(Author);
            book.Title = string.Copy(Title);
            return book;
        }
    }
    public class Category
    {
        public string Name { get; set; }
        public Category(string name)
        {
            this.Name = name;
        }
    }
}

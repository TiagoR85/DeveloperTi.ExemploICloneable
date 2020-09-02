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
            Console.WriteLine("ShallowCopy em Livro 1, gerando um clone, Livro 2.");
            Console.WriteLine("ShallowCopy, copia os typesValues, mas copiando também, o endereço de memória dos referenceValue.");
            Console.WriteLine("");
            Console.WriteLine("Livro 1 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro1.Author, livro1.Title, livro1.Category.Name);
            Console.WriteLine("Livro 2 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro2.Author, livro2.Title, livro2.Category.Name);

            Console.WriteLine("");
            Console.WriteLine("Alterando Livro 2...");
            Console.WriteLine("");

            livro2.Author = "Junior";
            livro2.Title = "Coloca nas mãos de Deus";
            livro2.Category.Name = "AutoAjuda";
            Console.WriteLine("Livro 1 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro1.Author, livro1.Title, livro1.Category.Name);
            Console.WriteLine("Livro 2 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro2.Author, livro2.Title, livro2.Category.Name);
            Console.WriteLine("");
            Console.WriteLine("Perceba que após alterar as propriedades de Livro 2, " +
                "{0}ele tbm alterou o conteúdo da referenceValue Categoria, {0}tanto em Livro 1, como em Livro 2", Environment.NewLine);
            Console.WriteLine("");

            var livro3 = livro1.DeepCopy();
            Console.WriteLine("DeepCopy em Livro 3");
            Console.WriteLine("Alterando Livro 3...");
            Console.WriteLine("");
            livro3.Author = "Otávio";
            livro3.Title = "Cada um tem sua cruz";
            livro3.Category.Name = "SelfHeal";
            Console.WriteLine("Livro 1 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro1.Author, livro1.Title, livro1.Category.Name);
            Console.WriteLine("Livro 3 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro3.Author, livro3.Title, livro3.Category.Name);
            Console.WriteLine("DeepCopy, copia os typesValues, e cria novos espaços na memória para armazenar os referenceTypes");
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

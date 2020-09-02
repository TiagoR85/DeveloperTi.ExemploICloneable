using System;

namespace DeveloperTi.ExemploICloneable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var livro1 = new Livro
            {
                Autor = "José de Deus",
                Titulo = "Vai com Jeová",
                Categoria = new Categoria("Terror")
            };

            var livro2 = (Livro)livro1.Clone();

            Console.WriteLine("Livro 1 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro1.Autor, livro1.Titulo, livro1.Categoria.Name);
            Console.WriteLine("Livro 2 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro2.Autor, livro2.Titulo, livro2.Categoria.Name);
            Console.WriteLine("");
            Console.WriteLine("agora vamos alterar o Livro 1");
            Console.Write("Nome do Autor:");
            livro1.Autor = Console.ReadLine();
            Console.Write("Titulo da obra:");
            livro1.Titulo = Console.ReadLine();
            Console.Write("Categoria:");
            livro1.Categoria.Name = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Livro 1 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro1.Autor, livro1.Titulo, livro1.Categoria.Name);
            Console.WriteLine("Livro 2 - Autor:{0}, Titulo:{1}, Categoria:{2}", livro2.Autor, livro2.Titulo, livro2.Categoria.Name);
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
    public class Livro : ICloneable
    {
        public string Autor { get; set; }
        public string Titulo { get; set; }
        public Categoria Categoria { get; internal set; }
        public Livro() { }
        public Livro(Livro livro)
        {
            this.Autor = livro.Autor;
            this.Titulo = livro.Titulo;
        }
        public object Clone()
        {
            var obj = new Livro(this);
            obj.Categoria = (Categoria)this.Categoria.Clone();
            return obj;
        }
    }
    public class Categoria : ICloneable
    {
        public string Name { get; set; }
        public Categoria(string name)
        {
            this.Name = name;
        }

        public object Clone()
        {
            return new Categoria(string.Copy(Name));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Лабораторная_работа__1
{
    enum Frequency { Weekly, Monthly, Yearly };
    class Program
    {
        static void Main(string[] args)
        {
            Edition ed = new Edition("Эхо Сочи", DateTime.Now, 100);
            Magazine magaz = new Magazine(ed.Publication, Frequency.Weekly, ed.datewrite, ed.Circulation);
            Console.WriteLine(magaz.ToShortString());
            magaz.AddArticles(new Article(new Person("Suetin", "Artyom", new DateTime(1994, 8, 26)),"Дальневосточный потоп",5));
            magaz.AddArticles(new Article(new Person("Potapov", "Igor", new DateTime(1966, 6, 6)),"Исследование русла реки Амур",3));
            magaz.AddEditors(new Person("Ronaldo", "Cristiano", new DateTime(1985, 2, 5)));
            Console.WriteLine(magaz.ToString());
            Edition edition1 = new Edition("Сочи Олимпийский",new DateTime(1994,8,26),5);
            Edition edition2 = new Edition("Сочи Олимпийский", new DateTime(1994, 8, 26), 5);
            if ((!object.ReferenceEquals(edition1, edition2)) && (edition1 == edition2))
                Console.WriteLine(edition1.GetHashCode() + "\t" + edition2.GetHashCode());
            try 
            { 
                ed.Circulation = -10; 
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                Console.WriteLine(aoore.Message);
            }
            Magazine magaz1 = (Magazine)magaz.DeepCopy();
            magaz.Publication = "Эхо Москвы";
            Console.WriteLine(magaz.ToString());
            Console.WriteLine(magaz1.ToString());
            Console.Write("Введите параметр рейтинга: ");
            int raiting=int.Parse(Console.ReadLine());
            foreach (var i in magaz.article)
            {
                if (i.rat>raiting)
                    Console.WriteLine(i.ToString());
            }
            Console.WriteLine(magaz.edition);
            Console.Write("Введите подстроку: ");
            string find=Console.ReadLine();
            foreach (var i in magaz.article)
            {
                if (i.ArticleName.Contains(find))
                    Console.WriteLine(i.ToString());
            }

        }
    }
}

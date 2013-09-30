using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Лабораторная_работа__1
{
    class Article : IRateAndCopy
    {
        public Person person;
        public string ArticleName;
        public double rat;
        public Article()
        {
            person = new Person();
            ArticleName = "";
            rat = 0;
        }
        public Article(Person author, string name, double rating)
        {
            person = author;
            ArticleName = name;
            rat = rating;
        }
        public override string ToString()
        {
            return "Название статьи:" + ArticleName + " Рейтинг:" + rat + " " + person.ToString();
        }
        public int Rating { get; set; }
        public virtual object DeepCopy()
        {
            Article art = new Article();
            art.person = person;
            art.rat = rat;
            art.ArticleName = ArticleName;
            return (object)art;
        }

    }
}


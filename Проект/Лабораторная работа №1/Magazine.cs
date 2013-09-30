using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Лабораторная_работа__1
{
    class Magazine:Edition, IRateAndCopy
    {
        private ArrayList editor = new ArrayList();
        public ArrayList Editor
        {
            get
            {
                ArrayList al = new ArrayList();
                foreach (object i in editor)
                    al.Add(((Person)i).DeepCopy());
                return al;
            }
            set
            {
                ArrayList al = new ArrayList();
                foreach (object i in value)
                    al.Add(((Person)i).DeepCopy());
                editor = al;
            }
        }
        Article[] articles = new Article[0];
        public Article[] article
        {
            get
            {
                Article[] art = new Article[articles.Length];
                for (int i = 0; i < art.Length; i++)
                    art[i] = (Article)articles[i].DeepCopy();
                return art;
            }
            set
            {
                Article[] art = new Article[value.Length];
                for (int i = 0; i < art.Length; i++)
                    art[i] = (Article)value[i].DeepCopy();
                articles = art;
            }
        }
        public double SredRating
        {
            get
            {
                double result = 0;
                for (int i = 0; i < articles.Length; i++)
                    result = result + articles[i].rat;
                result = result / articles.Length;
                return result;
            }
        }
        public Magazine(string publicat, Frequency Freq, DateTime dw, int circul)
        {
            publication = publicat;
            freq = Freq;
            DateWrite = dw;
            circulation = circul;
        }
        public Magazine():base()
        {
            freq = 0;
        }
        public void AddArticles(params Article[] art)
        {
            int q = articles.Length;
            Array.Resize<Article>(ref articles, q + art.Length);
            for (int i = q, j = 0; i < articles.Length; i++, j++)
                articles[i] = art[j];

        }
        public void AddEditors(params Person[] per)
        {
            for (int i = 0; i < per.Length; i++)
                editor.Add(per[i]);
        }
        public override string ToString()
        {
            string str = base.ToString() + " " + freq + " " + "Cписок статей:\n";
            foreach (var i in articles)
                str += ((Article)i).ToString() + "\n";
            str += "Редакторы\n";
            foreach (var i in editor)
                str+=((Person)i).ToString()+"\n";
            str += "Средний рейтинг: " + SredRating;
            return str;
        }
        public virtual string ToShortString()
        {
            return base.ToString() + " " + freq + " " + "Средний рейтинг:" + SredRating; 
        }
        public override object DeepCopy()
        {
            Magazine mag = new Magazine(publication, freq, DateWrite, circulation);
            mag.editor = Editor;
            mag.articles = article;
            return (object)mag;
        }
        public int Rating { get; set; }
        public Edition edition
        {
            get { return new Edition(publication, freq, DateWrite, circulation); }
            set
            {
                publication = value.Publication;
                freq = value.FR;
                DateWrite = value.datewrite;
                circulation = Circulation;
            }
        }

    }
}

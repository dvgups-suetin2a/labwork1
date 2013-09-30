using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Лабораторная_работа__1
{
    class Edition
    {
        protected string publication;
        public string Publication
        {
            get { return publication; }
            set { publication = value; }
        }
        protected DateTime DateWrite;
        public DateTime datewrite
        {
            get { return DateWrite; }
            set { DateWrite = value; }
        }
        protected int circulation;
        public int Circulation
        {
            get { return circulation; }
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Введено ошибочное значение тиража. Тираж не может быть отрицательным числом");
                else
                    circulation = value;
            }
        }
        protected Frequency freq;
        public Frequency FR
        {
            get { return freq; }
            set { freq = value; }
        }
        public Edition()
        {
            publication = "";
            DateWrite = DateTime.Now;
            circulation = 0;
        }
        public Edition(string publicat, DateTime write, int circulat)
        {
            publication = publicat;
            DateWrite = write;
            circulation = circulat;
        }
        public Edition(string publicat, Frequency Freq, DateTime write, int circulat)
        {
            publication = publicat;
            freq = Freq;
            DateWrite = write;
            circulation = circulat;
        }
        public virtual object DeepCopy()
        {
            Edition edition = new Edition();
            edition.circulation = circulation;
            edition.DateWrite = DateWrite;
            edition.publication = publication;
            return (object) edition;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || (GetType() != obj.GetType()))
                return false;
            else
            {
                Edition edition = (Edition)obj;
                return (edition.publication==publication)&&(edition.DateWrite==DateWrite)&&(edition.circulation==circulation);
            }
        }
        public static bool operator == (Edition edition1,Edition edition2)
        {
            return (edition1.circulation==edition2.circulation) && (edition1.DateWrite==edition2.DateWrite) && (edition1.publication==edition2.publication);
        }
        public static bool operator !=(Edition edition1, Edition edition2)
        {
            return !edition1.Equals(edition2);
        }
        public override int GetHashCode()
        {
            return this.publication.GetHashCode() ^ this.DateWrite.GetHashCode() ^ this.circulation.GetHashCode();
        }
        public override string ToString()
        {
            return "Название:" + publication + " Дата публикации:" + DateWrite.ToShortDateString() + " Тираж:" + circulation;
        }

    }
}
    

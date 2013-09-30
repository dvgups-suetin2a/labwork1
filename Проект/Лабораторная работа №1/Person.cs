using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Лабораторная_работа__1
{
    class Person : IRateAndCopy
    {
        private string Family;
        public string family
        {
            get { return Family; }
            set { Family = value; }
        }
        private string Name;
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        private DateTime Data;
        public DateTime data
        {
            get { return Data; }
            set { Data = value; }
        }
        public int ChangeYear
        {
            get { return Data.Year; }
            set { Data = new DateTime(value, Data.Month, Data.Day); }
        }
        public Person(string Family, string Name, DateTime Data)
        {
            this.Family = Family;
            this.Name = Name;
            this.Data = Data;
        }
        public Person()
        {
            Family = "";
            Name = "";
            Data = DateTime.Now;
        }
        public override string ToString()
        {
            return "Фамилия:" + Family + " Имя:" + Name + " День рождения:" + Data.ToShortDateString();
        }
        public virtual string ToShortString()
        {
            return "Фамилия:" + Family + " Имя:" + Name;
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || (GetType() != obj.GetType()))
                return false;
            else
            {
                Person person = (Person)obj;
                return (person.Family == Family) && (person.Name == Name) && (person.Data == Data);
            }
        }
        public static bool operator ==(Person person1, Person person2)
        {
            return (person1.Family == person2.Family) && (person1.Name == person2.Name) && (person1.Data == person2.Data);
        }
        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Equals(person2); 
        }
        public override int GetHashCode()
        {
            return this.Family.GetHashCode() ^ this.Name.GetHashCode() ^ this.Data.GetHashCode();
        }
        public virtual object DeepCopy()
        {
            Person PersonCopy = new Person();
            PersonCopy.Family = Family;
            PersonCopy.Name = Name;
            PersonCopy.Data = Data;
            return (object)PersonCopy;
        }
        public int Rating { get; set; }

    }
}


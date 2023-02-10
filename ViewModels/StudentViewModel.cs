using App12.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App12.ViewModels
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        StudentsListViewModel lvm;

        public Student Student { get; private set; }

        public StudentViewModel()
        {
            Student = new Student();
        }

        public StudentsListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        public string FIO
        {
            get { return Student.FIO; }
            set
            {
                if (Student.FIO != value)
                {
                    Student.FIO = value;
                    OnPropertyChanged("FIO");
                }
            }
        }
        public string Street
        {
            get { return Student.Street; }
            set
            {
                if (Student.Street != value)
                {
                    Student.Street = value;
                    OnPropertyChanged("Street");
                }
            }
        }
        public string Apartament
        {
            get { return Student.Apartament; }
            set
            {
                if (Student.Apartament != value)
                {
                    Student.Apartament = value;
                    OnPropertyChanged("Apartament");
                }
            }
        }

        public string House
        {
            get { return Student.House; }
            set
            {
                if (Student.House != value)
                {
                    Student.House = value;
                    OnPropertyChanged("House");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(FIO.Trim())) ||
                    (!string.IsNullOrEmpty(Apartament.Trim())) ||
                    (!string.IsNullOrEmpty(Street.Trim())));
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

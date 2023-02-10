using App12.Models;
using App12.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App12.ViewModels
{
    public class StudentsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<StudentViewModel> Students { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateStudentCommand { protected set; get; }
        public ICommand DeleteFriendCommand { protected set; get; }
        public ICommand SaveFriendCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        StudentViewModel selectedFriend;

        public INavigation Navigation { get; set; }

        public StudentsListViewModel()
        {
            Students = new ObservableCollection<StudentViewModel>();
            CreateStudentCommand = new Command(CreateFriend);
            DeleteFriendCommand = new Command(DeleteFriend);
            SaveFriendCommand = new Command(SaveFriend);
            BackCommand = new Command(Back);
        }

        public StudentViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                if (selectedFriend != value)
                {
                    StudentViewModel tempFriend = value;
                    selectedFriend = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new StudentPage(tempFriend));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateFriend()
        {
            Navigation.PushAsync(new StudentPage(new StudentViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }
        private void SaveFriend(object friendObject)
        {
            StudentViewModel friend = friendObject as StudentViewModel;
            if (friend != null && friend.IsValid && !Students.Contains(friend))
            {
                Students.Add(friend);
            }
            Back();
        }
        private void DeleteFriend(object friendObject)
        {
            StudentViewModel friend = friendObject as StudentViewModel;
            if (friend != null)
            {
                Students.Remove(friend);
            }
            Back();
        }
    }
}
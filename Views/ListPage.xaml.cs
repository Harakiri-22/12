using App12.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App12.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsListPage : ContentPage
    {
        public StudentsListPage()
        {
            InitializeComponent();
            BindingContext = new StudentsListViewModel() { Navigation = this.Navigation };
        }
    }
}
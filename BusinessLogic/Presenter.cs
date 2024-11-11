using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Presenter : INotifyPropertyChanged
    {
        int k = 0;
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set { students = value; OnPropertyChanged(nameof(Students)); }
        }
        private Student currentStudent = new Student();
        public Student CurrentStudent
        {
            get { return currentStudent; }
            set { currentStudent = value; OnPropertyChanged(nameof(CurrentStudent)); }
        }
        public RelayCommand AddStudentCommand { get; set; }
        public RelayCommand RemoveStudentCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        public Presenter()
        {
            Students = new ObservableCollection<Student>() { };
            CurrentStudent = new Student();
            AddStudentCommand = new RelayCommand(addStudent);
            RemoveStudentCommand = new RelayCommand(removeStudent);
        }

        private void addStudent()
        {
            k++;
            CurrentStudent.Id = k;
            Students.Add(CurrentStudent);
            CurrentStudent = new Student();
        }

        private void removeStudent()
        {
            Students.Remove(CurrentStudent);
            CurrentStudent = new Student();
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

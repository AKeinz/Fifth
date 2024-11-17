using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace BusinessLogic
{
    public class Logic : INotifyPropertyChanged
    {
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set { _students = value; OnPropertyChanged(nameof(Students)); }
        }
        private ObservableCollection<Student> _students = new ObservableCollection<Student>();

        public Student StudentBeingAdded
        {
            get { return _studentBeingAdded; }
            set { _studentBeingAdded = value; OnPropertyChanged(nameof(StudentBeingAdded)); }
        }
        private Student _studentBeingAdded = new Student();

        public Student HighlightedStudent
        {
            get { return _highlightedStudent; }
            set { _highlightedStudent = value; OnPropertyChanged(nameof(HighlightedStudent)); }
        }
        private Student _highlightedStudent = new Student();

        public RelayCommand AddStudentCommand { get; set; }
        public RelayCommand RemoveStudentCommand { get; set; }

        public Logic()
        {
            Students = new ObservableCollection<Student>() { };
            StudentBeingAdded = new Student();
            AddStudentCommand = new RelayCommand(AddStudent);
            RemoveStudentCommand = new RelayCommand(RemoveStudent);
        }

        private void AddStudent()
        {
            globalIdCount++;
            StudentBeingAdded.Id = globalIdCount;
            Students.Add(StudentBeingAdded);
            StudentBeingAdded = new Student();
        }
        private int globalIdCount = 0;

        private void RemoveStudent()
        {
            Students.Remove(HighlightedStudent);
            HighlightedStudent = new Student();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

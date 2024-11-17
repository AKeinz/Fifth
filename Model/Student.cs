using System.ComponentModel;

namespace Model
{
    public class Student : INotifyPropertyChanged
    {
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        private int _id;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private string _name;

        public string Specialty
        {
            get { return _specialty; }
            set { _specialty = value; OnPropertyChanged(nameof(Specialty)); }
        }
        private string _specialty;

        public string Group
        {
            get { return _group; }
            set { _group = value; OnPropertyChanged(nameof(Group)); }
        }
        private string _group;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

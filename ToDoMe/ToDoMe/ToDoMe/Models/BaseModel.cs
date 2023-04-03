using System.ComponentModel;

namespace ToDoMe.Models
{
    public class BaseModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

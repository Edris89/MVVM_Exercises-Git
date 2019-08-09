using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_exercise
{
    class MyViewModel : INotifyPropertyChanged
    {
        class User

        {
            private string firstname;
            private string lastname;

            public string FirstName
            {
                get { return firstname; }

                set { firstname = value; }
            }

            public string LastName
            {
                get { return lastname; }

                set { lastname = value; }
            }

        }

        private User user;

        public string FirstName
        {
            get { return user.FirstName; }
            set
            {
                if (user.FirstName != value)
                {
                    user.FirstName = value;
                    OnPropertyChange("FirstName");
                    OnPropertyChange("FullName");
                }
            }
        }

        public string LastName
        {
            get { return user.LastName; }
            set
            {
                if (user.LastName != value)
                {
                    user.LastName = value;
                    OnPropertyChange("LastName");
                    OnPropertyChange("FullName");
                }
            }
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public MyViewModel()
        {
            user = new User
            {
                FirstName = "Edris",
                LastName = "C# Beginner xD",
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

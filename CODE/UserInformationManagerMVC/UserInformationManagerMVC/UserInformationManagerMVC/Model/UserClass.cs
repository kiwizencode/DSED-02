using System;

namespace UserInformationManagerMVC.Model
{
	public class User
	{
        public enum SexOfPerson { Male, Female }

        private string _FirstName;
        public string FirstName
        {
            get => _FirstName; 
            set
            {
                if (value.Length > 50)
                    throw new Exception("Error! FirstName must be less than 51 characters!");
                else
                    _FirstName = value;
            }
        }

        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set
            {
                if (value.Length > 50)
                    throw new Exception("Error! LastName must be less than 51 characters!");
                else
                    _LastName = value;
            }
        }
        private string _ID;
        public string ID
        {
            get => _ID; 
            set
            {
                if (value.Length > 9)
                    throw new Exception("Error! ID must be less than 10 characters!");
                else
                    _ID = value;
            }
        }

        public string Department { get; set; }
        public SexOfPerson Sex { get; set; }

        public User(string firstname, string lastname, string id, string department, SexOfPerson sex)
        {
            FirstName = firstname;
            LastName = lastname;
            ID = id;
            Department = department;
            Sex = sex;
        }
    }
}


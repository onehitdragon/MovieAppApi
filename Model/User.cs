using System;

namespace MovieAppApi.Model{
    public class User : Account{
        private string lastName;
        private string firstName;
        private DateTime birthDay;
        private bool gender;
        public string LastName{
            get{
                return lastName;
            }
            set{
                lastName = value;
            }
        }
        public string FirstName{
            get{
                return firstName;
            }
            set{
                firstName = value;
            }
        }
        public DateTime BirthDay{
            get{
                return birthDay;
            }
            set{
                birthDay = value;
            }
        }
        public bool Gender{
            get{
                return gender;
            }
            set{
                gender = value;
            }
        }
        public User(){}
        public User(string email, string password, string lastName, string firstName, DateTime birthDay, bool gender) : base(email, password){
            this.lastName = lastName;
            this.firstName = firstName;
            this.birthDay = birthDay;
            this.gender = gender;
        }
    }
}
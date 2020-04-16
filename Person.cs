namespace DZ_13_04SQL
{
    public class Person
    {
        public string LastName {get; set;}
        public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string BirthDate {get; set;}
        public Person(){}
        public Person(string lastname, string firstname, string middlename, string birthdate)
        {
                this.LastName = lastname;
                this.FirstName = firstname;
                this.MiddleName = middlename;
                this.BirthDate = birthdate;
        }
    }
}
namespace PWATutorial.Shared
{
    public class Contact
    {
        public int ContactID {  get; set; }
        public string FirstName {  get; set; }
        public string LastName {  get; set; }

        // public Contact() 
        // {

        // }
        public Contact(int ContactID, string FirstName, string LastName)
        {
            this.ContactID = ContactID;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public string FullName()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}

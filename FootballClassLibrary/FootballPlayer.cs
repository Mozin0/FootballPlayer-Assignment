namespace FootballClassLibrary
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int ShirtNumber { get; set; }
        public FootballPlayer()
        {

        }
        public FootballPlayer(int id, string? name, int age, int shirtNumber)
        {
            Id = id;
            Name = name;
            Age = age;
            ShirtNumber = shirtNumber;
        }

        public void ValidateId()
        {
            if (Id <= 0)
            {
                throw new IndexOutOfRangeException("Id cannot be less than 0");
            }
            
        }

        public void ValidateName()
        {
            if (Name != null && Name.Length < 2)
            {
                throw new IndexOutOfRangeException("Name cannot be less than 2 characters");
            }
        }

        public void ValidateAge()
        {
            if (Age < 1)
            {
                throw new IndexOutOfRangeException("Age cannot be less than 1");
            }
        }

        public void ValidateShirtNumber()
        {
            if (ShirtNumber < 1 || ShirtNumber > 99)
            {
                throw new IndexOutOfRangeException("The Shirt Number is out of range");
            }
        }


    }
}
using FootballClassLibrary;
using FootballPlayerAPI.Managers;

namespace FootballPlayerUnitTests
{
    public class UnitTest1
    {
        private FootballPlayer footballPlayer;
        private FootballPlayersManager footballPlayersManager;
        public UnitTest1()
        {
            footballPlayer = new();
            footballPlayersManager = new FootballPlayersManager();
        }

        [Theory]
        [InlineData("M")]
        [InlineData("")]
        public void NameLessThanTwo(string name)
        {
            footballPlayer.Name = name;
            Assert.Throws<IndexOutOfRangeException>(footballPlayer.ValidateName);
        }

        [Theory]
        [InlineData("Mo")]
        [InlineData("Bob")]
        [InlineData("Steven")]
        [InlineData("Bob The Builder")]
        public void NameMoreThanTwo(string name)
        {
            footballPlayer.Name = name;
            footballPlayer.ValidateName();
        }

        [Theory]
        [InlineData(999)]
        [InlineData(1)]
        public void IdPositive(int id)
        {
            footballPlayer.Id = id;
            footballPlayer.ValidateId();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public void IdNegative(int id)
        {
            footballPlayer.Id = id;
            Assert.Throws<IndexOutOfRangeException>(footballPlayer.ValidateId);
        }

        [Theory]
        [InlineData(999)]
        [InlineData(1)]
        [InlineData(50)]
        public void AgeOverOne(int age)
        {
            footballPlayer.Age = age;
            footballPlayer.ValidateAge();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void AgeLessThanOne(int age)
        {
            footballPlayer.Age = age;
            Assert.Throws<IndexOutOfRangeException>(footballPlayer.ValidateAge);
        }

        [Theory]
        [InlineData(99)]
        [InlineData(1)]
        [InlineData(50)]
        public void ShirtNumberInRange(int shirtNumber)
        {
            footballPlayer.ShirtNumber = shirtNumber;
            footballPlayer.ValidateShirtNumber();
        }

        [Theory]
        [InlineData(100)]
        [InlineData(0)]
        [InlineData(-10)]
        public void ShirtNumberOutOfRange(int shirtNumber)
        {
            footballPlayer.ShirtNumber = shirtNumber;
            Assert.Throws<IndexOutOfRangeException>(footballPlayer.ValidateShirtNumber);
        }

        [Fact]
        public void CheckIfListIsEmpty()
        {
            var list = footballPlayersManager.GetAll();
            Assert.NotEmpty(list);
            Assert.Equal(5, list.Count);            
        }

        [Fact]
        public void AddNewPlayerToList()
        {
            FootballPlayer Ben = new(6, "Ben", 20, 7);
            footballPlayersManager.Add(Ben);
            Assert.Contains(Ben, footballPlayersManager.GetAll());

        }

        [Fact]
        public void DeletePlayerInList()
        {
            footballPlayersManager.Delete(1);
            Assert.Throws<InvalidDataException>(() => footballPlayersManager.GetById(1));
        }
        
        [Fact]
        public void DeletePlayerNotInList()
        {
            Assert.Throws<InvalidDataException>(() => footballPlayersManager.Delete(8));
        }

    }
}
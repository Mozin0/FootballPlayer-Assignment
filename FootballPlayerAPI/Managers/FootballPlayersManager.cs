using FootballClassLibrary;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace FootballPlayerAPI.Managers
{
    public class FootballPlayersManager
    {
      private FootballPlayer _footballPlayer = new();
      private static List<FootballPlayer> footballPlayersList = new List<FootballPlayer>
      {
          new FootballPlayer(1,"Mike", 24, 6),
          new FootballPlayer(2,"Bob", 20, 3),
          new FootballPlayer(3,"John", 18, 33),
          new FootballPlayer(4,"Steve", 26, 12)
      };

      public List<FootballPlayer> GetAll()
      {
            return footballPlayersList;
          //return new List<FootballPlayer>(footballPlayersList);
      }
      
      public FootballPlayer GetById(int id)
      {
          var result = footballPlayersList.FirstOrDefault(x => x.Id == id);
            if (result == null || result.Id != id)
            {
                throw new InvalidDataException("This Id does not exist");
            }
            return result;

        }

        public FootballPlayer Add(FootballPlayer footballPlayer)
      {
          var idExists = footballPlayersList.Any(x => x.Id == footballPlayer.Id);
            if (idExists)
            {
                throw new IndexOutOfRangeException("Id exists");
            }
          footballPlayer.ValidateId();
          footballPlayer.ValidateName();
          footballPlayer.ValidateAge();         
          footballPlayer.ValidateShirtNumber();

          footballPlayersList.Add(footballPlayer);
          return footballPlayer;
      }
      
      public FootballPlayer Delete(int id)
      {
          var footballPlayer = footballPlayersList.FirstOrDefault(x => x.Id == id);
          if (footballPlayer == null)
          {
                throw new InvalidDataException("This player does not exist");
          }
          footballPlayersList.Remove(footballPlayer);
          return footballPlayer;
      }
      
      public FootballPlayer Update(int id, FootballPlayer updatedFootballPlayer)
      {
            //var footballPlayer = footballPlayersList.FirstOrDefault(x => x.Id == id);
            var footballPlayer = GetById(id);
            if (footballPlayer == null)
            {
            throw new InvalidDataException("This player does not exist");
            }

          footballPlayer.Id = updatedFootballPlayer.Id;
          footballPlayer.Name = updatedFootballPlayer.Name;
          footballPlayer.Age = updatedFootballPlayer.Age;
          footballPlayer.ShirtNumber = updatedFootballPlayer.ShirtNumber;
          footballPlayer.ValidateId();
          footballPlayer.ValidateName();
          footballPlayer.ValidateAge();
          footballPlayer.ValidateShirtNumber();

          return footballPlayer;
      }
    }
}

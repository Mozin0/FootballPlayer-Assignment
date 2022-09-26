using FootballClassLibrary;
using FootballPlayerAPI.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FootballPlayerAPI.Controllers
{
    [Route("footballPlayer")]
    [ApiController]
    public class FootballPlayerController : ControllerBase
    {
        private FootballPlayersManager _manager;

        public FootballPlayerController(FootballPlayersManager manager)
        {
            _manager = manager;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FootballPlayer>> GetAll()
        {
            var getAll = _manager.GetAll();
           // getAll.Clear();
            if (getAll.Count <= 0)
            {
                NotFound();
               // throw new InvalidDataException("There is no Data in the List");
            }
            return Ok(getAll);
        }

        // GET api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> GetById(int id)
        {
            try
            {
                var getId = _manager.GetById(id);
                return Ok(getId);
            }
            catch (InvalidDataException e)
            {
               return NotFound(e.Message);
            }
            
        }

        // POST api/<ValuesController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult Post(FootballPlayer footballPlayer)
        {
            try
            {
               _manager.Add(footballPlayer);
               return Created("api/FootballPlayer", footballPlayer);                
            }
            catch (IndexOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, FootballPlayer footballPlayer)
        {
            try
            {
                _manager.Update(id, footballPlayer);
                return Ok();
            }
            catch (InvalidDataException e)
            {
                return NotFound(e.Message);
            }
            catch(IndexOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _manager.Delete(id);
                return Ok();
            }
            catch (InvalidCastException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

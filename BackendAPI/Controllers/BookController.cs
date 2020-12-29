using BackendAPI.Model;
using Interfaces.Model;
using Interfaces.Model.Book;
using Library.Model;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        [HttpGet("light")]
        public ITrackedResult<ISpellBook> Light()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfLight()
            };
        }

        [HttpGet("darkness")]
        public ITrackedResult<ISpellBook> Darkness()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfDarkness()
            };
        }

        [HttpGet("creation")]
        public ITrackedResult<ISpellBook> Creation()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfCreation()
            };
        }

        [HttpGet("destruction")]
        public ITrackedResult<ISpellBook> Destruction()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfDestruction()
            };
        }

        [HttpGet("fire")]
        public ITrackedResult<ISpellBook> Fire()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfFire()
            };
        }

        [HttpGet("water")]
        public ITrackedResult<ISpellBook> Water()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfWater()
            };
        }

        [HttpGet("earth")]
        public ITrackedResult<ISpellBook> Earth()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfEarth()
            };
        }

        [HttpGet("air")]
        public ITrackedResult<ISpellBook> Air()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfAir()
            };
        }


        [HttpGet("essence")]
        public ITrackedResult<ISpellBook> Essence()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfEssence()
            };
        }

        [HttpGet("illusion")]
        public ITrackedResult<ISpellBook> Illusion()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfIllusion()
            };
        }

        [HttpGet("necromancy")]
        public ITrackedResult<ISpellBook> Necromancy()
        {
            return new TrackedResult<ISpellBook>
            {
                __Object__ = SpellBooks.GetBookOfNecromancy()
            };
        }
    }
}
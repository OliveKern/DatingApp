using DatingApp.Logic.Contracts;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.Logic.Entities
{
    public abstract class IdentityEntity : IIdentifyable
    {
        //lt Kurs Id automatisch als Key erkannt.
        //[Key]
        public int Id { get; internal set; }
    }
}

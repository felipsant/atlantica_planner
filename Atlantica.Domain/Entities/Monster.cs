using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlantica.Domain.Entities;
namespace Atlantica.Domain.Entities
{
    public class Monster : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int AtlanticaDBId { get; set; }
        public virtual string URL { get; set; }
        public virtual string Name { get; set; }
        public virtual int Level { get; set; }
        public virtual int Experience { get; set; }
        public virtual int Weapon{ get; set; }
    }
}

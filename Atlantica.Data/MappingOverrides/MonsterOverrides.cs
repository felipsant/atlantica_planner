using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlantica.Domain.Entities;
namespace Atlantica.Data.MappingOverrides
{
    public class MonsterOverrides : IAutoMappingOverride<Monster>
    {
        public void Override(AutoMapping<Monster> mapping)
        {
        }
    }
}

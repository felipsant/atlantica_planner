using Atlantica.Crawler;
using Atlantica.Domain.Entities;
using Atlantica.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Atlantica.Api.Controllers
{
    public class MonsterController : ApiController
    {
        private IMonsterService _monsterService;
        public MonsterController(IMonsterService monsterService)
        {
            _monsterService = monsterService;
        }

        // GET api/values
        [HttpGet]
        public IList<Monster> Get()
        {
            return _monsterService.GetAll();
        }

        // GET api/values
        public async System.Threading.Tasks.Task<bool> UpdateAtlanticaMonster()
        {
            
            try
            { 
                List<Monster> monsters = await MonsterCrawler.ReadMonsters();
                IList<Monster> currentmonsters = _monsterService.GetAll();
                for (int i = 0; i < monsters.Count; i++)
                {
                    Monster auxmonster = monsters[i];
                    if(currentmonsters.Count(c=>c.Id == auxmonster.Id) <= 0)
                        _monsterService.Create(auxmonster);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        // DELETE api/values/5
        public bool Delete(int id)
        {
            _monsterService.Delete(id);
            return true;
        }
    }
}

using Atlantica.Domain.Entities;
using Atlantica.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlantica.Domain.Services
{
     public interface IMonsterService
    {
        IList<Monster> GetAll();
        Monster GetById(int id);
        void Create(Monster product);
        void Update(Monster product);
        void Delete(int id);
    }

    public class MonsterService : IMonsterService
    {
        private IRepository<Monster> _monsterRepository;

        public MonsterService(IRepository<Monster> monsterRepository)
        {
            _monsterRepository = monsterRepository;
        }

        public IList<Monster> GetAll()
        {
            return _monsterRepository
                .GetAll()
                .ToList();
        }

        public Monster GetById(int id)
        {
            return _monsterRepository.GetById(id);
        }

        public void Create(Monster monster)
        {
            _monsterRepository.Create(monster);
        }

        public void Update(Monster monster)
        {
            _monsterRepository.Update(monster);
        }

        public void Delete(int id)
        {
            _monsterRepository.Delete(id);
        }

    }
}

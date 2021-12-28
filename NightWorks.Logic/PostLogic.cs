using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NigthWorks.Models;
using NigthWorks.Repository;

namespace NigthWorks.Logic
{
    public class PostLogic : IPostLogic
    {
        IPostRepository repo;

        public PostLogic(IPostRepository weaponRepository)
        {
            this.repo = weaponRepository;
        }
        public void Create(Post obj)
        {
            if (obj.Data == "")
            {
                throw new Exception("Must be a text");
            }
            repo.Create(obj);
        }

        public void Delete(int id)
        {
            if (repo.Read(id) != null)
            {
                repo.Delete(id);
            }
            else
            {
                throw new Exception("There is no Starship with thad id");
            }
        }

        public IEnumerable<Post> ReadAll()
        {
            return repo.ReadAll().ToList();
        }

        public Post Read(int id)
        {
            return repo.Read(id);
        }

        public Post MostUsedWeapon()
        {
            var query = (from l in ReadAll()
                         group l by l into gr
                         orderby gr.Count() descending
                         select gr.Key).First();
            return query;
        }

        public void Update(Post obj)
        {
            if (obj.Data != "")
            {
                repo.Update(obj);
            }
            else
            {
                throw new Exception("Some Data is not valid");
            }
        }

        public IEnumerable<Post> GetAllPostByUserId(int id)
        {
            var result = repo.ReadAll().Where(x => x.Postuserid == id);
            return result;
        }
    }
}

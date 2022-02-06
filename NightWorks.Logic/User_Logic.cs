using System;
using System.Collections.Generic;
using System.Linq;
using NightWorks.Logic;
using NigthWorks.Models;
using NigthWorks.Repository;

namespace NigthWorks.Logic
{
    public class User_Logic : IUser_Logic
    {
        IUser_Repository repo;

        public User_Logic(IUser_Repository repo)
        {
            this.repo = repo;
        }

        //CRUD
        public User Read(int id)
        {
            return repo.Read(id);
        }
        public IList<User> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Create(User o)
        {
            if (o.Email.Trim().Length <= 4)
            {
                //Kell egy email check
                throw new Exception("Email must be longer than 3 char");
            }
            o.Password = Secure.Encrypt(o.Password);
            repo.Create(o);
        }
        public void Update(User obj)
        {
            if (obj != null && obj.Username.Trim().Length>=4 && obj.Email.Trim().Length >= 4)
            {
                obj.Password = Secure.Encrypt(obj.Password);
                repo.Update(obj);
            }
            else
            {
                throw new Exception("Some Data is not valid");
            }

        }
        public void Delete(int id)
        {
            if (repo.Read(id) != null)
            {
                repo.Delete(id);
            }
            else
            {
                throw new Exception("There is no User with thad id");
            }

        }
        public double AVGMoney()
        {
            return repo.ReadAll().Average(t => t.Money) ?? 0;
        }


        //NON CRUD
        public User MostMoneyUser()
        {
            var elements = ReadAll();
            return elements.OrderByDescending(obj => obj.Money).First();
        }
        public User LessMoneyUser()
        {
            var elements = ReadAll();
            if (elements != null)
            {
                return elements.OrderByDescending(obj => obj.Money).Last();
            }
            else
            {
                throw new Exception("There is no data in our system");
            }
            
        }
        public User Login(string email, string password)
        {
            User temp = repo.GetUserbyEmail(email);
            if (email.Trim() != "" && password.Trim() != "")
            {
                if (temp.Email == email && temp.Password == Secure.Encrypt(password))
                {
                    return temp;
                }
                else
                {
                    throw new Exception("Email address and password combination is not valid");
                }
            }
            else throw new Exception("Email and password cant be empty");
            
        }

        public User GetUserByEmail(string email)
        {
            return repo.GetUserbyEmail(email);
        }
    }
}

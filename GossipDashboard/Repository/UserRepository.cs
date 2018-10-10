﻿using GossipDashboard.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GossipDashboard.Models;
using System.IO;

namespace GossipDashboard.Repository
{
    public class UserRepository : IRepository<User>
    {
        GossipSiteEntities context = new GossipSiteEntities();

        public User Add(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
            return entity;
        }



        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Select(int id)
        {
            var res = context.Users.FirstOrDefault(p => p.UserID == id);
            return res;
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }

   
    }
}
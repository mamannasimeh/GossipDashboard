using GossipDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GossipDashboard.Repository
{
    public class PubBaseRepository : IRepository<PubBase>
    {
        GossipSiteEntities context = new GossipSiteEntities();
        public PubBase Add(PubBase entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PubBase Select(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<PubBase> SelectAll(string condition)
        {
            if (condition != "")
            {
                var res = context.PubBases.Where(p => p.NameEn == condition);
                return res;
            }

            return context.PubBases;
        }

        public IQueryable<PubBase> SelectByParentName(string parentName)
        {
            if (parentName != "")
            {
                var parent = context.PubBases.FirstOrDefault(p => p.NameEn == parentName);
                if (parent != null)
                {
                    var res = context.PubBases.Where(p => p.ParentID == parent.ParentID);
                    return res;
                }
            }

            return null;
        }

        public PubBase Update(PubBase entity)
        {
            throw new NotImplementedException();
        }
    }
}
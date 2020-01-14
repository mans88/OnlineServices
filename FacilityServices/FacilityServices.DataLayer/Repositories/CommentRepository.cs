using OnlineServices.Common.FacilityServices.Interfaces.Repositories;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.DataLayer.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private FacilityContext facilityContext;

        public CommentRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public CommentTO Add(CommentTO Entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CommentTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public CommentTO GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(CommentTO entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new System.NotImplementedException();
        }

        public CommentTO Update(CommentTO Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
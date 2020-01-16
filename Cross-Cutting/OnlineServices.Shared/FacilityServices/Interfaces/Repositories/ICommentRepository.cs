using OnlineServices.Common.DataAccessHelpers;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using System.Collections.Generic;

namespace OnlineServices.Common.FacilityServices.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<CommentTO, int>
    {
        List<CommentTO> GetCommentsByIncidentId(int incidentId);
    }
}

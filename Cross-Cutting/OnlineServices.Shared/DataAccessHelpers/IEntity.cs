using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Common.DataAccessHelpers
{
    public interface IEntity<TIdType>
    {
        TIdType Id { get; set; }
    }
}

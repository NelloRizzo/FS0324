using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W7.D3.DataLayer.Data;

namespace W7.D3.DataLayer
{
    public interface IUserRoleDao
    {
        UserRoleEntity Create(UserRoleEntity userRoleEntity);
        UserRoleEntity Delete(int userId, int roleId);
    }
}

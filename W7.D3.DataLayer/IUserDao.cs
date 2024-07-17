using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W7.D3.DataLayer.Data;

namespace W7.D3.DataLayer
{
    public interface IUserDao
    {
        UserEntity Create(UserEntity user);
        UserEntity Read(int userId);
        UserEntity Update(int userId, UserEntity user);
        UserEntity Delete(int userId);

        UserEntity ReadByUsername(string username);
        List<UserEntity> ReadAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing
{
    public class dataaccesslayer
    {
        private readonly AppContext _appContext;
        public dataaccesslayer(AppContext appContext)
        {
            _appContext = appContext;
        }
        public void adduser(User user)
        {
            _appContext.users.Add(user);
            _appContext.SaveChanges();

        }
        public User GetUser(string name)
        {
            return _appContext.users.SingleOrDefault(user=>user.Naem==name);
        }
    }
}

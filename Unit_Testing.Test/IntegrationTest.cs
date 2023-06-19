using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing.Test
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void adduser()
        {
            User user = new User
            {
                DateTime = DateTime.Now,
                Email = "test@test.com",
                Naem = "noor"
            };
            dataaccesslayer dataaccesslayer=new dataaccesslayer(new AppContext());
            dataaccesslayer.adduser(user);

            User usertofind = dataaccesslayer.GetUser("noor");
            usertofind.Should().NotBeEquivalentTo(user);
        }
    }
}

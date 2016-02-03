using Cassandra;
using Cassandra.Mapping;
using NoSQLPOC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoSQLPOC.DAL.UserManagement
{
    public class UserDAO
    {
        public IEnumerable<User> GetUsersByLastName(string Lastname)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("demo");
            IMapper mapper = new Mapper(session);
            IEnumerable<User> users = mapper.Fetch<User>("SELECT * FROM users WHERE lastname = ?", Lastname);
            return users;
        }

        public static UserDAO GetInstance()
        {
            return new UserDAO();
        }
    }
}

using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSqlPoc.Model;

namespace NoSqlPoc.Dal.UserManagement
{
    public class UserDal
    {
        public void GetUsersByLastName(String LastName)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("demo");
            //session.Execute("insert into users (userid, firstname, lastname, age, city, email) values (now(), 'Mahesh', 'Patel', 34, 'bob@example.com', 'Bob')");
            List<Row> results = session.Execute("select * from users where lastname='Patel'").ToList();
            foreach (var item in results)
            {
                Console.WriteLine("{0}: {1} {2}", item["userid"], item["firstname"], item["age"]);
            }

        }

        public void InsertUser(User userobj)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("demo");
            session.Execute(
                String.Format("insert into users (userid, 'firstname', 'lastname', age, 'city', 'email') values ({0}, {1}, {2}, {3}, {4}, {5})",
                    "now()", userobj.FirstName, userobj.LastName, userobj.Age, userobj.City, userobj.Email));
        }
    }
}

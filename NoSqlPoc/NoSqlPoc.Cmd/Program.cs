using NoSQLPOC.Dal.UserManagement;
using NoSqlPoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoSqlPoc.DAL
{
    public class Class1
    {
        public static void Main()
        {
            try
            {
                //Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                //ISession session = cluster.Connect("demo");
                ////session.Execute("insert into users (userid, firstname, lastname, age, city, email) values (now(), 'Mahesh', 'Patel', 34, 'bob@example.com', 'Bob')");
                //List<Row> results = session.Execute("select * from users where lastname='Patel'").ToList();
                //foreach (var item in results)
                //{
                //    Console.WriteLine("{0}: {1} {2}", item["userid"], item["firstname"], item["age"]);
                //}

                //int a = 4, b = 5;
                //decimal plan = (decimal)10, update = (decimal)11, relative = (decimal)10;

                //Console.WriteLine("{0} + {1} = {2}", a, b, NoSqlPoc.Functional.MathOperations.add(a, b));
                //Console.WriteLine("plan: {0}, update:{1}, relativediff={2}, TLStatus={3}", plan, update, relative,
                //    NoSqlPoc.Functional.MathOperations.impactTL(true, plan, update, relative));
                
                IEnumerable<User> users = UserDao.GetInstance().GetUsersByLastName("Patel");
                foreach (var item in users)
                {
                    Console.WriteLine("{0}: {1} {2}", item.UserId, item.FirstName, item.Age);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Enter any key to continue...");
            Console.ReadLine();

        }
    }
}

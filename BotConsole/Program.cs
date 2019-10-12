using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotConsole
{
    class Program
    {


        static void Main(string[] args)
        {

            DoIt();

        }

        public static void DoIt()
        {
            try
            {
                var mng = new UserManagement();
                var mngLng = new LanguagueManagement();
                var user = new User();
                var languague = new Languague();

                Console.WriteLine("TranslationBot");
                Console.WriteLine("1.Añadir usuario");
                Console.WriteLine("2.Añadir idioma");
                Console.WriteLine("3.Traductor de idiomas");
                Console.WriteLine("4.UPDATE");
                Console.WriteLine("5.DELETE");

                Console.WriteLine("Choose an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("***************************");
                        Console.WriteLine("*****     Añadir Usuario    *******");
                        Console.WriteLine("***************************");
                        Console.WriteLine("Escribe el nombre de usuario");
                        var info = Console.ReadLine();
                        //var infoArray = info.Split(',');

                        user = new User(info);
                        mng.Create(user);

                        Console.WriteLine("Usuario  añadido");

                        break;

                    case "2":
                        Console.WriteLine("***************************");
                        Console.WriteLine("***** Añadir idioma   *****");
                        Console.WriteLine("***************************");
                        Console.WriteLine("Escribe el idioma que desea añadir");
                        var infoLang = Console.ReadLine();

                        languague = new Languague(infoLang);

                        mngLng.Create(languague);

                        Console.WriteLine("Idioma añadido");

                        //var lstCustomers = mng.RetrieveAll();
                        //var count = 0;

                        //foreach (var c in lstCustomers)
                        //{
                        //    count++;
                        //    Console.WriteLine(count + " ==> " + c.GetEntityInformation());
                        //}

                        break;
                    case "3":
                        //Console.WriteLine("Type the customer id:");
                        //customer.Id = Console.ReadLine();
                        //customer = mng.RetrieveById(customer);

                        //if (customer != null)
                        //{
                        //    Console.WriteLine(" ==> " + customer.GetEntityInformation());
                        //}

                        break;
                    case "4":
                        Console.WriteLine("***************************");
                        //Console.WriteLine("******  UPDATE  **    *****");
                        //Console.WriteLine("***************************");

                        //Console.WriteLine("Type the customer id:");
                        //customer.Id = Console.ReadLine();
                        //customer = mng.RetrieveById(customer);

                        //if (customer != null)
                        //{
                        //    Console.WriteLine(" ==> " + customer.GetEntityInformation());
                        //    Console.WriteLine("Type a new name, actual value is " + customer.Name);
                        //    customer.Name = Console.ReadLine();
                        //    Console.WriteLine("Type a new last name, actual value is " + customer.LastName);
                        //    customer.LastName = Console.ReadLine();
                        //    Console.WriteLine("Type a new age, actual value is " + customer.Age);
                        //    var textAge = Console.ReadLine();
                        //    customer.Age = Int32.TryParse(textAge, out int age) ? age : customer.Age;

                        //    mng.Update(customer);
                        //    Console.WriteLine("Customer was updated");
                        //}
                        //else
                        //{
                        //    throw new Exception("Customer not registered");
                        //}

                        break;

                    case "5":
                        //Console.WriteLine("Type the customer id:");
                        //customer.Id = Console.ReadLine();
                        //customer = mng.RetrieveById(customer);

                        //if (customer != null)
                        //{
                        //    Console.WriteLine(" ==> " + customer.GetEntityInformation());

                        //    Console.WriteLine("Delete? Y/N");
                        //    var delete = Console.ReadLine();

                        //    if (delete.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                        //    {
                        //        mng.Delete(customer);
                        //        Console.WriteLine("Customer was deleted");
                        //    }
                        //}
                        //else
                        //{
                        //    throw new Exception("Customer not registered");
                        //}

                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("ERROR: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("***************************");
            }
            finally
            {
                Console.WriteLine("Continue? Y/N");
                var moreActions = Console.ReadLine();

                if (moreActions.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                    DoIt();
            }


        }
    }
}

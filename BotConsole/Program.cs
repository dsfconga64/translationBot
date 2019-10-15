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
                var mngTrans = new TranslationManagement();
                var mgnTransHistory = new TranslationHistoryManagement();
                var user = new User();
                var languague = new Languague();

                Console.WriteLine("TranslationBot");
                Console.WriteLine("1.Añadir usuario");
                Console.WriteLine("2.Añadir idioma");
                Console.WriteLine("3.Traductor");
                Console.WriteLine("4.Idiomas disponibles");
                Console.WriteLine("5.Obtener idioma mas popular");
                Console.WriteLine("6.Obtener 1000 palabras mas populares");

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

                        Console.WriteLine("***************************");
                        Console.WriteLine("***** Traducir*****");
                        Console.WriteLine("***************************");
                        Console.WriteLine("Ingrese su Id de usuario");
                        var infoId = Console.ReadLine();
                        int infoIdUser = Int32.Parse(infoId);
                        user = new User(infoIdUser);

                        user = mng.RetrieveById(user);

                        if (user == null)
                        {
                            Console.WriteLine("El usuario no existe desea agregarlo?");


                            Console.WriteLine("Agregar? Y/N");
                            var addUser = Console.ReadLine();

                            if (addUser.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                            {
                                Console.WriteLine("Escriba el nombre del usuario");
                                var userName = Console.ReadLine();

                                var user1 = new User
                                {
                                    Name = userName
                                };
                                mng.Create(user1);

                                Console.WriteLine("Usuario añadido");

                                user = searchUser();
                            }
                            else
                            {
                                DoIt();
                            }
                        }

                        Console.WriteLine("***************************");
                        Console.WriteLine("***** Hola " + user.Name + "*****");
                        Console.WriteLine("***************************");

                        Console.WriteLine("Estos son los idiomas disponibles");

                        var lstLanguagues = mngLng.RetrieveAll();

                        var count = 0;

                        foreach (var l in lstLanguagues)
                        {
                            count++;

                            Console.WriteLine(count + "==>" + l.GetEntityInformation());
                        }

                        Console.WriteLine("Ingrese el idioma que desea traducir");

                        var lng = Console.ReadLine();
                        languague = new Languague(lng);
                        languague = mngLng.RetrieveById(languague);

                        if (languague == null)
                        {
                            Console.WriteLine("Idioma no existe desea agregarlo?");

                            Console.WriteLine("Agregar? Y/N");
                            var addLanguague = Console.ReadLine();

                            if (addLanguague.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                            {
                                var languague1 = new Languague
                                {
                                    languague = lng
                                };
                                mngLng.Create(languague1);
                                Console.WriteLine("Idioma añadido");
                            }
                            else
                            {
                                DoIt();
                            }


                        }


                        Console.WriteLine("***************************");
                        Console.WriteLine("***************************");
                        Console.WriteLine("***************************");

                        Console.WriteLine("Escriba la palabra o palabras que desea traducir separadas por un menos: " + "-");
                        var word = Console.ReadLine();
                        var infoArray = word.Split('-');

                        for (var i = 0; i < infoArray.Length; i++)
                        {
                            var item = infoArray[i];

                            languague = new Languague
                            {
                                languague = lng
                            };

                            var languagueTranslate = mngLng.RetrieveById(languague);

                            var translations = new Translations
                            {
                                word = item,
                                FkLanguagueId = languagueTranslate.IdLanguague
                            };

                            var translatedWord = mngTrans.RetrieveById(translations);

                            if (translatedWord == null)
                            {
                                Console.WriteLine("La palabra: " + item + " no existe en el idioma: " + languague.languague + " desea añadirla?");


                                Console.WriteLine("Agregar? Y/N");
                                var addTranslation = Console.ReadLine();

                                if (addTranslation.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Console.WriteLine("Ingrese la traduccion de la palabra: " + item + " en el idioma " + languague.languague);
                                    string tranWord = Console.ReadLine();
                                    var translation = new Translations
                                    {
                                        translationAmount = 1,
                                        word = item,
                                        translatedDate = System.DateTime.Now,
                                        translatedWord = tranWord,
                                        FkLanguagueId = languagueTranslate.IdLanguague
                                    };
                                    mngTrans.Create(translation);

                                    var translationHistory = new TranslationsHistory
                                    {
                                        word = item,
                                        translatedDate = System.DateTime.Now,
                                        translatedWord = tranWord,
                                        FkUserId = user.IdUser,
                                        FkLanguagueId = languagueTranslate.IdLanguague
                                    };

                                    var user2 = new User { IdUser = user.IdUser, Name = user.Name, amountTranslatedWords = user.amountTranslatedWords + 1 };

                                    mgnTransHistory.Create(translationHistory);

                                    mng.Update(user2);



                                    Console.WriteLine("Palabra añadida");

                                }
                                else
                                {
                                    DoIt();
                                }
                            }
                            else
                            {
                                var translatedWord1 = new Translations
                                {
                                    word = translatedWord.word,
                                    translatedWord = translatedWord.translatedWord,
                                    translationAmount = translatedWord.translationAmount + 1,
                                    FkLanguagueId = translatedWord.FkLanguagueId

                                };
                                var translationHistory = new TranslationsHistory
                                {
                                    word = item,
                                    translatedDate = System.DateTime.Now,
                                    translatedWord = translatedWord.translatedWord,
                                    FkUserId = user.IdUser,
                                    FkLanguagueId = translatedWord.FkLanguagueId
                                };

                                var user2 = new User { IdUser = user.IdUser, Name = user.Name, amountTranslatedWords = user.amountTranslatedWords + 1 };

                                mng.Update(user2);
                                mgnTransHistory.Create(translationHistory);
                                mngTrans.Update(translatedWord1);

                                var sentence = translatedWord.translatedWord;
                                Console.WriteLine(sentence);
                            }

                        }



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
                        Console.WriteLine("***************************");
                        Console.WriteLine("*****Mostrar Idiomas*******");
                        Console.WriteLine("***************************");
                        Console.WriteLine("***************************");

                        var lang = mngLng.RetrieveAll();
                        var count1 = 0;

                        foreach (var c in lang)
                        {
                            count1++;

                            Console.WriteLine(count1 + "===>" + c.GetEntityInformation());
                        }


                        break;

                    case "5":

                        Console.WriteLine("***************************");
                        Console.WriteLine("***************************");
                        Console.WriteLine("*****Idioma mas popular*******");
                        Console.WriteLine("***************************");
                        Console.WriteLine("***************************");

                        var languague2 = mngLng.RetrieveMostPopularLanguague();

                        if (languague != null)
                        {
                            Console.WriteLine("El idioma mas utilizado es: " + languague2.languague);
                        }
                        else
                        {
                            Console.WriteLine("Algo salio mal");
                        }

                        break;

                    case "6":

                        Console.WriteLine("***************************");
                        Console.WriteLine("***************************");
                        Console.WriteLine("*****Idioma mas popular*******");
                        Console.WriteLine("***************************");
                        Console.WriteLine("***************************");

                        var lstMostUSedWords = mgnTransHistory.RetrieveTopHundredWords();

                        var count3 = 0;

                        foreach (var c in lstMostUSedWords)
                        {
                            count3++;
                            Console.WriteLine(count3 + " ==> " + c.word);
                        }

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

        public static User searchUser()
        {
            var userMng = new UserManagement();

            var lstUsers = userMng.RetrieveAll();

            var count = 0;

            foreach (var l in lstUsers)
            {
                count++;

                Console.WriteLine(count + "==>" + l.GetEntityInformation());
            }

           
            Console.WriteLine("Ingrese el id de usuario");
            var infoId = Console.ReadLine();

            int inforUserId = Int32.Parse(infoId);

            var user = new User(inforUserId);

            user = userMng.RetrieveById(user);

            return user;
        }

    }
}

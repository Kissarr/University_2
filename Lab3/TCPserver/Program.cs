using System;
using System.Text;
using System.Net;      // потребуется
using System.Net.Sockets;
using System.Transactions;


public class Programm
{
    public static string for_first = "12}";
    public static string for_second = "21}";
    public static async Task Main()
    {
        TcpListener server = new TcpListener(IPAddress.Any, 1234);

        try
        {
            server.Start();    // запускаем сервер
            Console.WriteLine("Сервер запущен. Ожидание подключений... ");

            while (true)
            {
                var tcpClient = await server.AcceptTcpClientAsync();
                Task.Run(async () => await ProcessClientAsync(tcpClient));
            }
        }
        finally
        {
            server.Stop();
        }
    }

    static async Task ProcessClientAsync(TcpClient tcpClient)
    {
        var stream = tcpClient.GetStream();
        int count = 0;
        // буфер для входящих данных
        var response = new List<byte>();
        int bytesRead = 10;
        while (true)
        {
            // считываем данные до конечного символа
            while ((bytesRead = stream.ReadByte()) != '}')
            {
                // добавляем в буфер
                response.Add((byte)bytesRead);
            }
            var word = Encoding.UTF8.GetString(response.ToArray());
            if (word == "END") break;
            word = word + "}\n";
            count++;
            Console.Write($"Count client {count}: {tcpClient.Client.RemoteEndPoint} добавил: {word}");
            string str = Convert.ToString(tcpClient.Client.RemoteEndPoint);
            str = str.Substring(10);
            int port = Convert.ToInt32(str);
            if ( port % 2 == 0)
            {
                for_second = word;
                await stream.WriteAsync(Encoding.UTF8.GetBytes(for_first));
                
            }
            else
            {
                for_first = word;
                await stream.WriteAsync(Encoding.UTF8.GetBytes(for_second));
            }
            response.Clear();
        }
        tcpClient.Close();
    }

}



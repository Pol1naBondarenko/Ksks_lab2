using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        try
        {
            UdpClient udpClient = new UdpClient();
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            int serverPort = 5155;

            Console.WriteLine("Доступнi команди:");
            Console.WriteLine("clear display (color)");
            Console.WriteLine("draw pixel (color, x, y)");
            Console.WriteLine("draw line (color, x0, y0, x1, y1)");
            Console.WriteLine("draw rectangle (color, x0, y0, width, height)");
            Console.WriteLine("fill rectangle (color, x0, y0, width, height)");
            Console.WriteLine("draw ellipse (color, x0, y0, radius_x, radius_y)");
            Console.WriteLine("fill ellipse (color, x0, y0, radius_x, radius_y)");
            Console.WriteLine("draw circle (color, x0, y0, radius)");
            Console.WriteLine("fill circle (color, x0, y0, radius)");
            Console.WriteLine("draw rounded rectangle (color, x0, y0, width, height, radius)");
            Console.WriteLine("fill rounded rectangle (color, x0, y0, width, height, radius)");
            Console.WriteLine("draw text (color, x0, y0, font_number, length, text)");
            Console.WriteLine("draw image (data, x0, y0, width, height)\n");

            while (true)
            {
                Console.Write("Введiть команду: ");
                string command = Console.ReadLine();

                if (command == "exit")
                {
                    break;
                }

                Console.Write("Введiть параметри: ");
                string parameters = Console.ReadLine();

                string message = command + "|" + parameters;

                byte[] data = Encoding.UTF8.GetBytes(message);

                udpClient.Send(data, data.Length, new IPEndPoint(serverIP, serverPort));
            }

            udpClient.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}

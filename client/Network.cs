using System.Net;
using System.Net.Sockets;

public static class Network {

public static Socket sender;

	// Use this for initialization
	public static bool TryConnect()
	{
		//var ipHostEntry = Dns.GetHostEntry("localhost");
		var ipEndPoint = new IPEndPoint(Ip, Port);

		sender = new Socket(Ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		try
		{
			sender.Connect(ipEndPoint);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static IPAddress Ip = IPAddress.Parse("10.97.163.117");
	public static int Port = 11000;

}

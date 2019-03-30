using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Net : MonoBehaviour {

public static Socket sender;

	// Use this for initialization
	void Start()
	{
		//var ipHostEntry = Dns.GetHostEntry("localhost");
		var ipAddr = IPAddress.Parse("10.97.163.117");
		var ipEndPoint = new IPEndPoint(ipAddr, 11000);

		sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		sender.Connect(ipEndPoint);
	}
	// Update is called once per frame
	void Update () {
		
	}

	~Net()
	{
		sender.Shutdown(SocketShutdown.Both);
		sender.Close();	}
}

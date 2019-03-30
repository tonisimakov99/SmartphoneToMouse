using System.Text;
using System.Net.Sockets;
using UnityEngine;

public class buttonhandler : MonoBehaviour
{
	public void LeftButtonClick()
	{
		var command = new byte[] { 8, 0 };
		Net.sender.Send(command);
	}

	public void RightButtonClick()
	{
		var command = new byte[] { 9, 0 };
		Net.sender.Send(command);	}
}

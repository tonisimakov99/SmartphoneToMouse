using UnityEngine;
using System.Text;
using System.Linq;

public class TouchPad : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount == 1)
		{
			Debug.Log("1");
			var touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Moved)
			{
				Debug.Log("2");
				var deltaPosition = Encoding.UTF8.GetBytes(string.Format(" {0} {1}", (int)(touch.deltaPosition.x*200*Time.deltaTime), -1*(int)(touch.deltaPosition.y*200*Time.deltaTime)));
				var command = new byte[] { 1 };
				var end = new byte[] { 0 };
				Net.sender.Send(command.Concat(deltaPosition).Concat(end).ToArray());
			}
		}
	}
}

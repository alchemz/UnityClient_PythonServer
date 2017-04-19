using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Sockets;

public class TCP_Client : MonoBehaviour {

	public string server="127.0.0.1";
	public int port=50000;
	public string message;

	public void Start()
	{
		SendMessageToServer (message);
	}
	public void SendMessageToServer(string message)
	{
		Connect (server, port, message);
	}

	void Connect(String server, int port, String message)
	{
		message="Hello, this is from client";
		try{
			//create a TcpClient
			TcpClient client = new TcpClient(server, port);

			//Translate the passed message to ASCII and store it as a Byte Array
			Byte[] data= System.Text.Encoding.ASCII.GetBytes(message);

			//get a client stream for reading and writing
			NetworkStream stream= client.GetStream();

			//send message to connected TcpServer
			stream.Write(data, 0, data.Length);

			Debug.Log("Sent:{0}"+ message);

			//buffer to store the response bytes
			data= new Byte[256];

			//string to store the response ASCII representation
			String responseData= String.Empty;

			//Read the first batch of the TcpServer response bytes
			Int32 bytes= stream.Read(data, 0, data.Length);
			responseData=System.Text.Encoding.ASCII.GetString(data,0,bytes);
			Debug.Log("Received:{0}"+responseData);

			//close everything
			stream.Close();
			client.Close();
		}
		catch(ArgumentException e) {
			Debug.Log("ArgumentedNullException:{0}"+e);
		}
		catch(SocketException e) {
			Debug.Log("SocketException:{0}"+e);
		}

		//Debug.Log("Press Enter to continue...");
		Console.Read ();

	}
}

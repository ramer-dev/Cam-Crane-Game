using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using System.Text;
using System;
using System.IO;
using System.Runtime.InteropServices;
public class TCPManager : MonoBehaviour
{
    TcpClient client;
    string serverIP = "127.0.0.1";
    int port = 8000;
    byte[] receivedBuffer;
    StreamReader reader;
    bool socketReady = false;
    NetworkStream stream;
    public int action;

    // Start is called before the first frame update
    void Start()
    {
        CheckReceive();
        action = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (socketReady)
        {


            if (stream.DataAvailable)
            {
                receivedBuffer = new byte[100];
                stream.Read(receivedBuffer, 0, receivedBuffer.Length); 
                string msg = Encoding.UTF8.GetString(receivedBuffer, 0, receivedBuffer.Length); // byte[] to string
                
                Debug.Log((int)msg[0]);
                switch ((int)msg[0])
                {
                    case 117 : action = 1;  break;
                    case 114: action = 2;  break;
                    case 100 : action = 3;  break;
                    case 108: action = 4; break;
                    case 99 : action = 9; break;
                    case 111 : action = 0;  break;
                }

            }

        }
    }

    void CheckReceive()
    {
        if (socketReady) return;
        try
        {
            client = new TcpClient(serverIP, port);

            if (client.Connected)
            {
                stream = client.GetStream();
                Debug.Log("Connect Success");
                socketReady = true;
            }

        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception " + e);
        }

    }

    void OnApplicationQuit()
    {
        CloseSocket();
    }

    void CloseSocket()
    {
        if (!socketReady) return;

        reader.Close();
        client.Close();
        socketReady = false;
    }

}

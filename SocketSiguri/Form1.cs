using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Security.Cryptography;

namespace SocketSiguri
{
	public partial class Form1 : Form
	{
		public static double P = 13;
		public static double G = 6;
		private static double PrivateKey = 5;
		public double PublicKey;
		private double secretKey;
		private double ClientPubKey = 9;

		public static List<Socket> AllClients = new List<Socket>();

		public bool AddNewClient(Socket obj)
		{
			foreach (var item in AllClients)
			{
				if(item == obj)
				{
					return false;
				}
			}
			AllClients.Add(obj);	
			return true;
		}

		public void ShowAllConnectedClients()
		{
			string IPs = "";
			foreach (var item in AllClients)
			{
				IPs += ((IPEndPoint)(item.RemoteEndPoint)).Address.ToString()+ " \n";
			}
			MessageBox.Show(IPs);
		}

		Socket GetSocket;
		Socket listenerSocket;
		TcpListener	tcplistener;
		IPEndPoint ip;
		IPAddress ipAdresa;
		Socket Client;
		bool start = false;

		byte[] buffer;

	
		private void Form1_Load(object sender, EventArgs e)
		{
			//   sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			//sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

			//txtMyIP.Text = GetLocalIP();
		
		}
		public void ConnectAndShareKey()
		{

			//MessageBox.Show(PublicKey.ToString());
			//2
		}
		public void GetPubKeySetSecreteKey()
		{
			secretKey = Math.Pow(ClientPubKey, PrivateKey) % P;
		}

		public Form1()
		{
			InitializeComponent();
			btnStart.Text = "Starto serverin";
			PublicKey = Math.Pow(G, PrivateKey) % P;
			GetPubKeySetSecreteKey();
		}

		private bool TryConvertIP(string ip)
		{
			try
			{
				IPAddress.Parse(ip);
				return true;
			}
			catch (Exception)
			{
			  return false;
			}
		}
		private bool isNumber(string port)
		{
			try
			{
				Int32.Parse(port);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{


			if (btnStart.Text == "Starto serverin")
			{

				if (TryConvertIP(txtMyIP.Text) && isNumber(txtMyPort.Text))
				{

					btnStart.Text = "Ndalo serverin";
					start = true;
					Application.DoEvents();
					IPAddress ip = IPAddress.Parse(txtMyIP.Text);
					StartServer(ip,int.Parse(txtMyPort.Text));

				}else
				{
					MessageBox.Show("Port or IP wasn't in correct format!");
				}
			}
			else
			{
				btnStart.Text = "Starto serverin";
				tcplistener.Stop();
				lsAllText.Items.Add("U Ndal Serveri !!! ");

				start = false;
			}
		}













		private async void  StartServer(IPAddress ip , int porti)
		{
			    lsAllText.Items.Add("Serveri u leshua ");
				GetPubKeySetSecreteKey();
				tcplistener = new TcpListener(ip, porti);
				tcplistener.Start();
				while (start)
				{
					try
					{
						listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
						listenerSocket = await tcplistener.AcceptSocketAsync();
					    AddNewClient(listenerSocket);
				        ipAdresa = ((IPEndPoint)(listenerSocket.RemoteEndPoint)).Address;
		     	    	Application.DoEvents();

					     buffer = new byte[2048];
					     byte[] sendBuffer = new byte[2048];
			   
					     int byteNumbers = listenerSocket.Receive(buffer);
					     
					MessageBox.Show(secretKey.ToString() + "Server Secret");
					
					if (byteNumbers > 0)
					{
						//// pjesa per qelsin 
						//byte[] bufferPranues = new byte[1024];
						//byte[] madhMes = new byte[4];
						//byte[] mesazhiPr = new byte[byteNumbers - 4];
						//Buffer.BlockCopy(bufferPranues, 0, madhMes, 0, 4);
						//int msgSize = BitConverter.ToInt32(madhMes, 0);
						//Buffer.BlockCopy(bufferPranues, 4, mesazhiPr, 0, msgSize);
						//string msgText = ASCIIEncoding.ASCII.GetString(mesazhiPr);

						//if (ASCIIEncoding.ASCII.GetString(madhMes) == (100).ToString())
						//{
						//	//txtMesazhetServeri.AppendText("Celsi publik i serverit : " + msgText + "\n");
						//	GetPubKeySetSecreteKey(double.Parse(ASCIIEncoding.ASCII.GetString(mesazhiPr)));
						//	Application.DoEvents();

						//	byte[] bufferDergues;
						//	byte[] buffer;

						//	string mesazhi = PublicKey.ToString();
						//	buffer = ASCIIEncoding.ASCII.GetBytes(mesazhi);

						//	//byte[] buffer = new byte[mesazhi.Length + 4];
						//	int numDetect = 100;
						//	byte[] firstNumbers = new byte[4];
						//	firstNumbers = ASCIIEncoding.ASCII.GetBytes(numDetect.ToString());
						//	int totalGjatsia = firstNumbers.Length + buffer.Length;
						//	bufferDergues = new byte[totalGjatsia];
						//	Buffer.BlockCopy(firstNumbers, 0, bufferDergues, 0, 4);
						//	Buffer.BlockCopy(buffer, 0, bufferDergues, 4, bufferDergues.Length);

						//	listenerSocket.Send(bufferDergues);
						//}
						//else
						//{




						/// pjesa per jo qelsin 
						   string message = ASCIIEncoding.UTF8.GetString(buffer, 0, byteNumbers);
						  // MessageBox.Show(message);
					     	//string message = Convert.ToBase64String(buffer,0,byteNumbers);
					      //  lsAllText.Items.Add("Klienti : " + DESDecrypt(message));
						lsAllText.Items.Add("Klienti : " + message);

						//string dergoMesazh = DESEncrypt("Mesazhi u pranua nga serveri");
						string dergoMesazh = "Mesazhi u pranua nga serveri";

						//enkripton mesazhin
						byte[] MadhesiaMesazhit = new byte[4];

							int mesINT = dergoMesazh.Length;
							MadhesiaMesazhit = BitConverter.GetBytes(mesINT);
							byte[] bufferidergues = ASCIIEncoding.ASCII.GetBytes(dergoMesazh);
							int madhesiaTotale = 4 + bufferidergues.Length;
							byte[] mesazhiFinal = new byte[madhesiaTotale];
							Buffer.BlockCopy(MadhesiaMesazhit, 0, mesazhiFinal, 0, 4);
							Buffer.BlockCopy(bufferidergues, 0, mesazhiFinal, 4, bufferidergues.Length);

							Client = listenerSocket;
							listenerSocket.Send(mesazhiFinal);


						//}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		
		}

		private static string GetLocalIP()
		{
			//IPHostEntry host;
			//host = Dns.GetHostEntry(Dns.GetHostName());

			//foreach(IPAddress ip in host.AddressList)
			//{
			//	if(ip.AddressFamily == AddressFamily.InterNetwork)
			//	{
			//		return ip.ToString();
			//	}
			//}
			//return "127.0.0.1";
			return "";
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if(txtMyMessage.Text.Length >= 1) {

				//enkripton mesazhi
				try
				{
					byte[] MadhesiaMesazhit = new byte[4];
					int mesINT = txtMyMessage.Text.Length;
					MadhesiaMesazhit = BitConverter.GetBytes(mesINT);
					byte[] bufferidergues = ASCIIEncoding.ASCII.GetBytes(txtMyMessage.Text);
					int madhesiaTotale = 4 + bufferidergues.Length;
					byte[] mesazhiFinal = new byte[madhesiaTotale];
					Buffer.BlockCopy(MadhesiaMesazhit, 0, mesazhiFinal, 0, 4);
					Buffer.BlockCopy(bufferidergues, 0, mesazhiFinal, 4, bufferidergues.Length);
					Client.Send(mesazhiFinal);
					lsAllText.Items.Add("Serveri : " + txtMyMessage.Text);
				}
				catch (Exception)
				{
					MessageBox.Show("Coudln't send message to the Client");
				}
			}
				


		}

		private void MessageCallBack(IAsyncResult aResult )
		{
			//try
			//{
			//	byte[] recievedData = new byte[2000];
			//	recievedData = (byte[])aResult.AsyncState;

			//	ASCIIEncoding encoding = new ASCIIEncoding();
			//	string recievedMessage = encoding.GetString(recievedData);

			//	lsAllText.Items.Add("Other PC : "+ recievedData);
			//	buffer = new byte[2000];
			//	sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None,ref ipRemote, new AsyncCallback(MessageCallBack), buffer);
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show(ex.Message);
			//}
	
		}

		private void btnConnectedClients_Click(object sender, EventArgs e)
		{
			ShowAllConnectedClients();
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}
	}
}

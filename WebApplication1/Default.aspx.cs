using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string server = "192.168.1.3";
            int port = 55555;

            //open tcp connection to the telnet server
            TcpClient client = new TcpClient(server, port);
            NetworkStream stream = client.GetStream();

            //prepare to receive the data
            string responseData = string.Empty;
            byte[] data = new byte[4096];

            //read the stream
            int bytes = stream.Read(data, 0, 100);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

            //show to UI
            Label1.Text = responseData;

            //close everything
            stream.Close();
            client.Close();

        }
    }
}
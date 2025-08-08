using System.Net.Sockets;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isConnected = false;
        Socket? clientSocket;

        void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                clientSocket?.Shutdown(SocketShutdown.Send);
                clientSocket?.Close();
                isConnected = false;
                ShowRecvInfo("�ѶϿ����������ӡ�");
                btn_connect.Text = "���ӷ�����";
                return;
            }

            string ip = txt_ip.Text.Trim();
            string port = txt_port.Text.Trim();
            if (ip.Length == 0 || port.Length == 0)
            {
                ShowMessage("�����������IP�Ͷ˿ڡ�");
                return;
            }
            if (!int.TryParse(port, out int portNum) || portNum < 1 || portNum > 65535)
            {
                ShowMessage("�˿ںŷ�Χ�ǣ�1 ~ 65535.");
                return;
            }
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                btn_connect.Enabled = false;
                clientSocket.Connect(ip, int.Parse(port));
                isConnected = true;
                HandleClient(clientSocket);
                ShowRecvInfo("���ӷ������ɹ���");
                btn_connect.Enabled = true;
                btn_connect.Text = "�Ͽ�����";
            }
            catch (Exception ex)
            {
                btn_connect.Enabled = true;
                ShowMessage(ex.Message);
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ShowMessage("�������ӷ�������");
                return;
            }
            string msg = txt_msg.Text.Trim();
            if (msg.Length == 0)
            {
                ShowMessage("�����뷢�����ݡ�");
                return;
            }
            byte[] data = System.Text.Encoding.UTF8.GetBytes(msg);
            clientSocket?.Send(data);
            txt_msg.Clear();
        }

        private async void HandleClient(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];
            while (isConnected)
            {
                try
                {
                    int received = await clientSocket.ReceiveAsync(buffer);
                    if (received == 0)
                    {
                        ShowRecvInfo("�������Ѿ��رա�");
                        throw new SocketException();
                    }
                    string text = System.Text.Encoding.UTF8.GetString(buffer, 0, received);
                    ShowRecvInfo(text);
                }
                catch (SocketException)
                {
                    clientSocket.Close();
                    isConnected = false;
                    btn_connect.Text = "���ӷ�����";
                    break;
                }
            }
        }

        private void ShowRecvInfo(string message)
        {
            if (InvokeRequired)
            {
                Invoke((Action<string>)((_message) =>
                {
                    txt_recv.AppendText((txt_recv.TextLength == 0 ? "" : Environment.NewLine) + _message);
                }));
            }
            else
            {
                txt_recv.AppendText((txt_recv.TextLength == 0 ? "" : Environment.NewLine) + message);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_recv.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isConnected) return;
            clientSocket?.Shutdown(SocketShutdown.Send);
            clientSocket?.Close();
        }
    }
}

using System.Net;
using System.Net.Sockets;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isRunning = false;
        Socket? serverSocket;
        List<Socket> clientSockets = new List<Socket>();

        private void btn_start_Click(object sender, EventArgs e)
        {
            // ֹͣ����
            if (isRunning)
            {
                foreach (var clientSocket in clientSockets)
                {
                    try
                    {
                        clientSocket?.Shutdown(SocketShutdown.Send);
                        clientSocket?.Close();
                    }
                    catch (Exception ex)
                    {
                        ShowRecvInfo($"�رտͻ�������ʱ����: {ex.Message}");
                    }
                }
                clientSockets.Clear();
                serverSocket?.Close();
                ShowRecvInfo("��������ֹͣ���С�");
                btn_start.Text = "��������";
                isRunning = false;
                return;
            }

            // ��������
            string strPort = txt_port.Text.Trim();
            if (string.IsNullOrEmpty(strPort))
            {
                ShowMessage("������˿ںš�");
                return;
            }
            if (!int.TryParse(strPort, out int port) || port < 1 || port > 65535)
            {
                ShowMessage("�˿ںŷ�Χ�ǣ�1 ~ 65535.");
                return;
            }
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse(strPort)));
                serverSocket.Listen(10);
                ShowRecvInfo("���������ɹ����ȴ��ͻ�������...");
                isRunning = true;
                AcceptClient();
                btn_start.Text = "ֹͣ����";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void ShowMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke((Action<string>)((msg) => MessageBox.Show(msg, "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
            }
            else
            {
                MessageBox.Show(message, "��Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void AcceptClient()
        {
            while (isRunning)
            {
                try
                {
                    Socket clientSocket = await serverSocket!.AcceptAsync();
                    // ��ӵ��ͻ����б�
                    clientSockets.Add(clientSocket);
                    ShowRecvInfo($"�ͻ��� {clientSocket.RemoteEndPoint} �����ӡ�");
                    // ��������ͻ��˵�����
                    HandleClient(clientSocket);
                }
                catch (Exception)
                {
                    serverSocket?.Close();
                    break;
                }
            }
        }
        private async void HandleClient(Socket clientSocket)
        {
            bool isConnected = true;
            while (isConnected)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await clientSocket.ReceiveAsync(buffer);
                    string receivedData = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if (bytesRead == 0)
                    {
                        ShowRecvInfo($"�ͻ��� {clientSocket.RemoteEndPoint} �Ͽ����ӡ�");
                        throw new SocketException();
                    }
                    // ת����Ϣ�����������ӵĿͻ���
                    foreach (var sock in clientSockets)
                    {
                        sock.Send(buffer, bytesRead, SocketFlags.None);
                    }
                    ShowRecvInfo(receivedData);
                }
                catch (Exception)
                {
                    clientSocket.Close();
                    isConnected = false;
                    clientSockets.Remove(clientSocket);
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
            if (isRunning)
            {
                foreach (var clientSocket in clientSockets)
                {
                    try
                    {
                        clientSocket?.Shutdown(SocketShutdown.Send);
                        clientSocket?.Close();
                    }
                    catch (Exception ex)
                    {
                        ShowRecvInfo($"�رտͻ�������ʱ����: {ex.Message}");
                    }
                }
                clientSockets.Clear();
                serverSocket?.Close();
            }
        }
    }
}

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
            // 停止服务
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
                        ShowRecvInfo($"关闭客户端连接时出错: {ex.Message}");
                    }
                }
                clientSockets.Clear();
                serverSocket?.Close();
                ShowRecvInfo("服务器已停止运行。");
                btn_start.Text = "启动服务";
                isRunning = false;
                return;
            }

            // 启动服务
            string strPort = txt_port.Text.Trim();
            if (string.IsNullOrEmpty(strPort))
            {
                ShowMessage("请输入端口号。");
                return;
            }
            if (!int.TryParse(strPort, out int port) || port < 1 || port > 65535)
            {
                ShowMessage("端口号范围是：1 ~ 65535.");
                return;
            }
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, int.Parse(strPort)));
                serverSocket.Listen(10);
                ShowRecvInfo("服务启动成功，等待客户端连接...");
                isRunning = true;
                AcceptClient();
                btn_start.Text = "停止服务";
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
                Invoke((Action<string>)((msg) => MessageBox.Show(msg, "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
            }
            else
            {
                MessageBox.Show(message, "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void AcceptClient()
        {
            while (isRunning)
            {
                try
                {
                    Socket clientSocket = await serverSocket!.AcceptAsync();
                    // 添加到客户端列表
                    clientSockets.Add(clientSocket);
                    ShowRecvInfo($"客户端 {clientSocket.RemoteEndPoint} 已连接。");
                    // 启动处理客户端的任务
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
                        ShowRecvInfo($"客户端 {clientSocket.RemoteEndPoint} 断开连接。");
                        throw new SocketException();
                    }
                    // 转发消息给所有已连接的客户端
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
                        ShowRecvInfo($"关闭客户端连接时出错: {ex.Message}");
                    }
                }
                clientSockets.Clear();
                serverSocket?.Close();
            }
        }
    }
}

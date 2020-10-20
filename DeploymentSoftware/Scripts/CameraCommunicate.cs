using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeploymentSoftware{

    class CameraCommunicate {

        public static IPAddress serverAddr = null;
        public static Socket sock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);
        public static IPEndPoint endPoint = new IPEndPoint(0, 0);

        public static UIControl uiRef;

        public static async Task Connect(string ipAdr, string port) {
            if (sock.Connected) {
                CloseSock();
            }
            int.TryParse(port, out int checkedPort);
            if (!PingAdr(ipAdr, checkedPort).Result) {
                uiRef.NotConnected();
                return;
            }

            try {
                serverAddr = IPAddress.Parse(ipAdr);
                sock = new Socket(serverAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                endPoint = new IPEndPoint(serverAddr, Convert.ToInt32(port));
                sock.Connect(endPoint);
                uiRef.IsConnected();
            } catch (Exception e) {
                uiRef.NotConnected();
            }
        }

        public static async Task<string> GetResponseManual(byte[] code) {
            SendToSocket(code, true);

            if (!sock.Connected) {
                return null;
            }

            try {
                byte[] buffer = new byte[code.Length];
                Receive(sock, buffer, 0, buffer.Length, 1000);
                string msg = "";
                for (int i = 0; i < buffer.Length; i++) {
                    msg += MathStuff.ByteToHex(buffer[i]) + " ";
                }

                if (msg == "") {
                    msg = "Couldn't get a response";
                }

                return msg;
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

            public static async Task<string> GetResponse(Com c) {
            SendToSocket(c.sendCommand, true);

            if (!sock.Connected) {
                return null;
            }

            //if (c.duoVal) {
            //    target = target - 20;
            //}

            try {
                byte[] buffer = new byte[c.length];
                Receive(sock, buffer, 0, buffer.Length, 1000);
                string msg = "";
                //if (target != 0) {
                //    msg = MathStuff.ByteToHex(buffer[target]);
                //    if (twoByte) {
                //        msg += "," + MathStuff.ByteToHex(buffer[target + 1]);
                //    }
                //} else {
                for (int i = 0; i < buffer.Length; i++) {
                    msg += MathStuff.ByteToHex(buffer[i]) + " ";
                }
                //}

                if (msg == "") {
                    msg = "Couldn't get a response";
                }

                //MessageBox.Show(msg);

                return msg;
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public static async Task<bool> PingAdr(string address, int port) {
            Ping pinger = null;

            if (address == null) {
                MessageBox.Show("No address provided");
                return false;
            }

            try {
                pinger = new Ping();

                PingReply reply = pinger.Send(address, 2);
                if (reply.Status == IPStatus.Success) {
                    try {
                        if (address == "" || port == 0) {
                            MessageBox.Show("Invalid address/port");
                            return false;
                        }

                        using (var client = new TcpClient(address, port)) {
                            return true;
                        }
                    } catch (SocketException ex) {
                        MessageBox.Show("Error pinging host:'" + address + ":" + port.ToString() + "'");
                        return false;
                    }
                }
            } catch {
            } finally {
                pinger.Dispose();
            }
            MessageBox.Show("Failed to ping address:\n" + address);
            return false;
        }

        public static async Task<bool> SendToSocket(byte[] code, bool noUpdate = false) {
            //UpdateUI();

            if (!sock.Connected) {
                uiRef.NotConnected();
                return false;
            }

            if (code != null) {
                sock.SendTo(code, endPoint);
                if(!noUpdate)
                uiRef.UpdateUI();
                return true;
            }
            return false;
        }

        public static void CloseSock() {
            if (sock != null && sock.Connected) {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
        }

        private static async Task Receive(Socket socket, byte[] buffer, int offset, int size, int timeout) {
            int startTickCount = Environment.TickCount;
            int received = 0;  // how many bytes is already received

            while (received < size) {
                if (Environment.TickCount > startTickCount + timeout)
                    throw new Exception("Timeout.");
                try {
                    sock.ReceiveTimeout = timeout;
                    received += socket.Receive(buffer, offset + received, size - received, SocketFlags.None);
                } catch (SocketException ex) {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable) {
                        await Task.Delay(30);// socket buffer is probably empty, wait and try again
                    } else
                        throw ex;  // any serious error occurr
                }
            }
        }




    }
}

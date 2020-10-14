using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeploymentSoftware {

    public partial class Main : Form {

        static IPAddress serverAddr = null;
        static Socket sock = new Socket(AddressFamily.Unspecified, SocketType.Stream, ProtocolType.Tcp);
        static IPEndPoint endPoint = new IPEndPoint(0, 0);

        int brightLevel = 0;
        int contrastLevel = 0;
        int ddeLevel = 0;

        int paletteMode = 0;
        int flipMode = 0;
        int agcMode = 0;
        
        bool ddeOn = false;
        bool agcOn = false;


        bool stopUpdates;

        public Main() {
            InitializeComponent();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            CloseSock();
        }

        private void b_Connect_Click(object sender, EventArgs e) {
            GetData();
        }

        async Task UpdateUI() {
            stopUpdates = true;
            

            slider_Brightness.Value = brightLevel;
            slider_Contrast.Value = contrastLevel;
            slider_DDE.Value = ddeLevel;

            tB_Brightness.Text = brightLevel.ToString();
            tB_Contrast.Text = contrastLevel.ToString();
            tB_DDE.Text = ddeLevel.ToString();

            switch (paletteMode) {
                case 0:
                    cB_Palette.SelectedIndex = 0;
                    break;
                case 1:
                    cB_Palette.SelectedIndex = 1;
                    break;
                case 5:
                    cB_Palette.SelectedIndex = 2;
                    break;
                case 6:
                    cB_Palette.SelectedIndex = 3;
                    break;
                case 11:
                    cB_Palette.SelectedIndex = 4;
                    break;
                default:
                    cB_Palette.SelectedIndex = cB_Palette.Items.Count - 1;
                    break;
            }

            switch (flipMode) {
                case 8:
                    cB_Flip.SelectedIndex = 1;
                    break;
                case 1:
                    cB_Flip.SelectedIndex = 0;
                    break;
                default:
                    cB_Flip.SelectedIndex = cB_Flip.Items.Count - 1;
                    break;
            }

            switch (agcMode) {
                case 0:
                    cB_AGC.SelectedIndex = 0;
                    break;
                case 1:
                    cB_AGC.SelectedIndex = 1;
                    break;
                case 2:
                    cB_AGC.SelectedIndex = 2;
                    break;
                default:
                    cB_AGC.SelectedIndex = cB_AGC.Items.Count - 1;
                    break;
            }

            tB_DDE.Enabled = ddeOn;
            slider_DDE.Enabled = ddeOn;

            tB_Contrast.Enabled = !agcOn;
            slider_Contrast.Enabled = !agcOn;

            stopUpdates = false;
        }

        async Task GetData() {
            if (!sock.Connected) {
                await Connect(tB_IP.Text, cB_Port.Text);
            }
            await GetCameraStuff();
            UpdateUI();
        }

        async Task GetCameraStuff() {

            if (sock.Connected) { //need to have the program verify the received code every time otherwise we get random numbers
                SendToSocket(new byte[] { 0xAA, 0x05, 0x01, 0x3D, 0x02, 0x01, 0xF0, 0xEB, 0xAA }); //enables analogue video

                contrastLevel = ConvertToInt(GetResponse(new byte[] { 0xAA, 0x04, 0x00, 0x3B, 0x00, 0xE9, 0xEB, 0xAA }, 6, 8).Result, false); //working
                brightLevel = ConvertToInt(GetResponse(new byte[] { 0xAA, 0x04, 0x00, 0x3C, 0x00, 0xEA, 0xEB, 0xAA }, 25, 10).Result, true); //working

                paletteMode = ConvertToInt(GetResponse(new byte[] { 0xAA, 0x04, 0x00, 0x2D, 0x00, 0xDB, 0xEB, 0xAA }, 5, 8).Result, false); //working

                flipMode = ConvertToInt(GetResponse(new byte[] { 0xAA, 0x04, 0x00, 0x30, 0x00, 0xDE, 0xEB, 0xAA }, 6, 9).Result, false); //working
                agcMode = ConvertToInt(GetResponse(new byte[] { 0xAA, 0x04, 0x00, 0x3A, 0x00, 0xE8, 0xEB, 0xAA }, 6, 10).Result, false); //working

                ddeLevel = ConvertToInt(GetResponse(new byte[] { 0xAA, 0x04, 0x00, 0x3F, 0x00, 0xED, 0xEB, 0xAA }, 5, 9).Result, false); //not
                ddeOn = ConvertToBool(GetResponse(new byte[] { 0xAA, 0x04, 0x00, 0x3E, 0x00, 0xEC, 0xEB, 0xAA }, 5, 9).Result); //not working
                agcOn = ConvertToBool(GetResponse(new byte[] { 0xAA, 0x04, 0x00, 0x3A, 0x33, 0x00, 0xE8, 0xEB, 0xAA }, 5, 9).Result); //not working
            }
        }

        int ConvertToInt(string code, bool doubleValue) {
            int num1 = 0;
            int num2 = 0;

            string valueCode = code.Substring(0, 2);
            num1 = int.Parse(valueCode, System.Globalization.NumberStyles.HexNumber);

            if (doubleValue) {
                string valueCode2 = code.Substring(3, 2);
                num2 = int.Parse(valueCode2, System.Globalization.NumberStyles.HexNumber);
            }
            int total = num1 + num2;

            return total;
        }

        bool ConvertToBool(string code) {
            int returnedNumber = ConvertToInt(code, false);
            if (returnedNumber == 1) {
                return true;
            } else {
                return false;
            }
        }
        
        uint ConvertToHex(int val) {
            uint hexVal = Convert.ToUInt32(val);
            return hexVal;
        }

        public async Task<string> GetResponse(byte[] code, int target, int maxByte) {
            SendToSocket(code);

            if (!sock.Connected) {
                return null;
            }

            bool twoByte = false;

            if (target / 20 == 1) {
                twoByte = true;
                target = target - 20;
            }

            try {
                byte[] buffer = new byte[maxByte];
                Receive(sock, buffer, 0, buffer.Length, 1000);
                string msg = "";
                if (target != 0) {
                    msg = ByteToHex(buffer[target]);
                    if (twoByte) {
                        msg += "," + ByteToHex(buffer[target + 1]);
                    }
                }
                else { 
                    for (int i = 0; i < buffer.Length; i++) {
                        msg += ByteToHex(buffer[i]) + " ";
                    }
                }

                if(msg == "") {
                    msg = "Couldn't get a response";
                }

                //MessageBox.Show(msg);

                return msg;
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        string ByteToHex(byte msg) {
            string hex = msg.ToString("X");
            if (hex.ToArray().Length == 1) {
                hex = "0" + hex;
            }
            return hex;
        }

        private async Task Receive(Socket socket, byte[] buffer, int offset, int size, int timeout) {
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
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        await Task.Delay(30);// socket buffer is probably empty, wait and try again
                    }
                    else
                        throw ex;  // any serious error occurr
                }
            }
        }

        public async Task Connect(string ipAdr, string port) {
            if (sock.Connected) {
                CloseSock();
            }
            int.TryParse(port, out int checkedPort);
            if (!PingAdr(ipAdr, checkedPort).Result) {
                NotConnected();
                return;
            }

            try {
                serverAddr = IPAddress.Parse(ipAdr);
                sock = new Socket(serverAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                endPoint = new IPEndPoint(serverAddr, Convert.ToInt32(port));
                sock.Connect(endPoint);
                l_Connected.Text = "Connected";
                p_Control.Enabled = true;
            } catch (Exception e) {
                l_Connected.Text = "Not Connected";
            }
        }

        void NotConnected() {
            l_Connected.Text = "Not Connected";
            p_Control.Enabled = false;
            CloseSock();
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

        private async Task<bool> SendToSocket(byte[] code) {
            UpdateUI();

            if (!sock.Connected) {
                NotConnected();
                return false;
            }

            if (code != null) {
                sock.SendTo(code, endPoint);
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

        private void b_DDEOn_Click(object sender, EventArgs e) {
            ddeOn = true;
            byte[] code = new byte[] { 0xAA, 0x05, 0x00, 0x3E, 0x01, 0x01, 0xEF, 0xEB, 0xAA };
            SendToSocket(code);
        }

        private void b_DDEOff_Click(object sender, EventArgs e) {
            ddeOn = false;
            UpdateUI();
            byte[] code = new byte[] { 0xAA, 0x05, 0x00, 0x3E, 0x01, 0x00, 0xEF, 0xEB, 0xAA };
            SendToSocket(code);
        }

        private void cB_Palette_SelectedValueChanged (object sender, EventArgs e) {
            string selected = this.cB_Palette.GetItemText(this.cB_Palette.SelectedItem);

            byte[] code = new byte[9];

            if (stopUpdates) {
                return;
            }

            switch (selected) {
                case "White Hot":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x2D, 0x01, 0x00, 0xDD, 0xEB, 0xAA };
                    paletteMode = 0;
                    break;
                case "Black Hot":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x2D, 0x01, 0x01, 0xDE, 0xEB, 0xAA };
                    paletteMode = 1;
                    break;
                case "Rainbow1":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x2D, 0x01, 0x05, 0xE2, 0xEB, 0xAA };
                    paletteMode = 2;
                    break;
                case "Rainbow2":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x2D, 0x01, 0x06, 0xE3, 0xEB, 0xAA };
                    paletteMode = 3;
                    break;
                case "Red Hot":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x2D, 0x01, 0x0B, 0xE8, 0xEB, 0xAA };
                    paletteMode = 4;
                    break;
            }

            SendToSocket(code);

        }

        private void cB_Flip_SelectedValueChanged(object sender, EventArgs e) {
            string selected = this.cB_Flip.GetItemText(this.cB_Flip.SelectedItem);
            byte[] code = new byte[9];

            if (stopUpdates) {
                return;
            }

            switch (selected) {
                case "No Flip":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x30, 0x01, 0x01, 0xE1, 0xEB, 0xAA };
                    flipMode = 8;
                    break;
                case "Left - Right Flip":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x30, 0x01, 0x02, 0xE2, 0xEB, 0xAA };
                    flipMode = 2;
                    break;
                case "Up - Down Flip":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x30, 0x01, 0x04, 0xE4, 0xEB, 0xAA };
                    flipMode = 4;
                    break;
                case "Mirror Flip":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x30, 0x01, 0x08, 0xE8, 0xEB, 0xAA };
                    flipMode = 1;
                    break;
            }

            SendToSocket(code);
        }

        private void cB_AGC_SelectedIndexChanged(object sender, EventArgs e) {
             if (stopUpdates) {
                return;
            }

            switch (cB_AGC.Text) {
                case "Manual":
                    agcOn = false;
                    agcMode = 0;
                    SendToSocket(new byte[] { 0xAA, 0x05, 0x00, 0x3A, 0x01, 0x00, 0xEA, 0xEB, 0xAA });
                    break;
                case "Auto 0":
                    agcOn = true;
                    agcMode = 1;
                    SendToSocket(new byte[] { 0xAA, 0x05, 0x00, 0x3A, 0x01, 0x01, 0xEB, 0xEB, 0xAA });
                    break;
                case "Auto 1":
                    agcOn = true;
                    agcMode = 2;
                    SendToSocket(new byte[] { 0xAA, 0x05, 0x00, 0x3A, 0x01, 0x02, 0xEC, 0xEB, 0xAA });
                    break;
            }
        }

        private void check_Extend_CheckedChanged(object sender, EventArgs e) {
            if (check_Extend.Checked) {
                p_Extended.Show();
                p_Basic.Hide();
            } else {
                p_Basic.Show();
                p_Extended.Hide();
            }
        }

        private void b_Play_Click(object sender, EventArgs e) {
            Play();
        }

        async Task Play() {
            string combinedUrl;

            if (check_Extend.Checked) {
                string ipaddress = tB_Extend_IP.Text;
                string port = tB_Extend_Port.Text;
                string url = tB_Extend_RTSP.Text;
                string username = tB_Extend_Username.Text;
                string password = tB_Extend_Password.Text;

                combinedUrl = "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + url;
            } else {
                combinedUrl = tB_Basic_RTSP.Text;
            }

            Uri combined = new Uri(combinedUrl);
            if (!PingAdr(combined.Host, combined.Port).Result) {
                return;
            }

            tB_Basic_RTSP.Text = combinedUrl;
            Replay(VLCPlayer, combinedUrl);
        }

        public async Task Replay(AxAXVLC.AxVLCPlugin2 player, string combinedUrl) {
            if (player.playlist.isPlaying) {
                player.playlist.stop();
                player.playlist.items.clear();
            }

            player.playlist.add(combinedUrl, null, ":network-caching=200");
            player.playlist.next();
            player.playlist.play();
        }

        private void slider_Contrast_MouseUp(object sender, MouseEventArgs e) {
            ContrastChanged();
        }

        private void slider_Brightness_MouseUp(object sender, MouseEventArgs e) {
            BrightnessChanged();
        }

        private void slider_DDE_MouseUp(object sender, MouseEventArgs e) {
            DDEChanged();
        }

        void ContrastChanged() {
            contrastLevel = ChangeVal(slider_Contrast, tB_Contrast, contrastLevel);
            SendToSocket(new byte[] { 0xAA, 0x05, 0x00, 0x3B, 0x01, (byte)ConvertToHex(contrastLevel), 0x6D, 0xEB, 0xAA });
        }

        void BrightnessChanged() {
            brightLevel = ChangeVal(slider_Brightness, tB_Brightness, brightLevel);
            MessageBox.Show("CHANGED" + ConvertToHex(brightLevel).ToString());
            SendToSocket(new byte[] { 0xAA, 0x06, 0x00, 0x3C, 0x00, (byte)ConvertToHex(brightLevel), 0x01, 0x1A, 0xEB, 0xAA });
        }

        void DDEChanged() {
            ddeLevel = ChangeVal(slider_DDE, tB_DDE, ddeLevel);
            MessageBox.Show(ConvertToHex(ddeLevel).ToString());
            SendToSocket(new byte[] { 0xAA, 0x05, 0x00, 0x3F, 0x01, (byte)ConvertToHex(ddeLevel), 0xF2, 0xEB, 0xAA });
        }

        int ChangeVal(TrackBar slider, TextBox tb, int copyVar) {
            if (slider.Value != copyVar) {
                copyVar = slider.Value;
            }
            tb.Text = copyVar.ToString();
            return copyVar;
        }

        //private void tB_Contrast_TextChanged(object sender, EventArgs e) { // will need to come back to this
        //    KeepUpdated(tB_Contrast, slider_Contrast, contrastLevel);
        //}

        //private void tB_Brightness_TextChanged(object sender, EventArgs e) {
        //    KeepUpdated(tB_Brightness, slider_Brightness, brightLevel);
        //}

        //private void tB_DDE_TextChanged(object sender, EventArgs e) {
        //    KeepUpdated(tB_DDE, slider_DDE, ddeLevel);
        //}

        void KeepUpdated(TextBox tb, TrackBar slider, int variable) {
            bool success = int.TryParse(tb.Text, out int converted);
            if (converted == int.Parse(tb.Text) && slider.Value == slider.Value) {
                return;
            }
            if (success && converted > -1 && converted < 256) {
                    slider.Value = converted;
            } else {
                tb.Text = variable.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            p_Control.Enabled = true;
            MessageBox.Show(
                "contrastLevel =" + contrastLevel + "\n" +
                "brightLevel =" + brightLevel + "\n" +
                "ddeLevel =" + ddeLevel + "\n" +
                "paletteMode =" + paletteMode + "\n" +
                "flipMode =" + flipMode + "\n" +
                "agcMode =" + agcMode + "\n" +
                "agcEnabled = " + agcOn.ToString() + "\n" +
                "ddeEnabled = " + ddeOn.ToString() + "\n"
                );

        }
    }
}

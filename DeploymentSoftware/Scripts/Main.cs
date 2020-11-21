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


        VideoPlay playScript = new VideoPlay();
        UIControl uiRef = new UIControl();

        public Main() {
            InitializeComponent();
            
            CameraCommands.uiRef = uiRef;
            CameraCommands.mainRef = this;

            CameraCommunicate.uiRef = uiRef;

            UIControl.mainRef = this;

            VideoPlay.mainRef = this;
        }


        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            CameraCommunicate.CloseSock();
        }

        private void b_Connect_Click(object sender, EventArgs e) {
            playScript.Play(tB_IP.Text);
            GetData();
        }

        async Task GetData() {
            if (!CameraCommunicate.sock.Connected) {
                await CameraCommunicate.Connect(tB_IP.Text, cB_Port.Text);
            }
            await Task.Delay(300);
            await CameraCommands.GetCameraStuff();
            uiRef.UpdateUI();
        }

        private void b_DDEOn_Click(object sender, EventArgs e) {
            CameraCommands.DDEState(true);
            uiRef.UpdateUI();
        }

        private void b_DDEOff_Click(object sender, EventArgs e) {
            CameraCommands.DDEState(false);
            uiRef.UpdateUI();
        }

        private void cB_Palette_SelectedValueChanged (object sender, EventArgs e) {
            CameraCommands.ChangePalette(cB_Palette.Text);
        }

        private void cB_Flip_SelectedValueChanged(object sender, EventArgs e) {
            CameraCommands.ChangeFlip(cB_Flip.Text);
        }

        private void cB_AGC_SelectedIndexChanged(object sender, EventArgs e) {
            CameraCommands.ChangeAGCLevel(cB_AGC.Text);
        }

        private void check_Extend_CheckedChanged(object sender, EventArgs e) {
            uiRef.ShowExtended();
        }

        private void b_Play_Click(object sender, EventArgs e) {
            playScript.Play();
        }

        private void slider_Contrast_MouseUp(object sender, MouseEventArgs e) {
            uiRef.contrastLevel = uiRef.ChangeVal(slider_Contrast, tB_Contrast, uiRef.contrastLevel);
            CameraCommands.ChangeContrast(uiRef.contrastLevel);
        }

        private void slider_Brightness_MouseUp(object sender, MouseEventArgs e) {
            uiRef.brightLevel = uiRef.ChangeVal(slider_Brightness, tB_Brightness, uiRef.brightLevel);
            CameraCommands.ChangeBrightness(uiRef.brightLevel);
        }

        private void slider_DDE_MouseUp(object sender, MouseEventArgs e) {
            uiRef.ddeLevel = uiRef.ChangeVal(slider_DDE, tB_DDE, uiRef.ddeLevel);
            CameraCommands.ChangeDDELevel(uiRef.ddeLevel);
        }

        private void slider_Zoom_MouseUp(object sender, MouseEventArgs e) {
            int digitOne = Convert.ToInt32(Math.Floor((double)(slider_Zoom.Value / 100))) * 100;
            int withoutHundred = slider_Zoom.Value - digitOne;
            if (withoutHundred > 25 && withoutHundred < 75) {
                slider_Zoom.Value = digitOne + 50;
            } else if (withoutHundred > 75) {
                slider_Zoom.Value = digitOne + 100;
            } else if (withoutHundred < 25) {
                slider_Zoom.Value = digitOne;
            }

            uiRef.digitalZoom = uiRef.ChangeVal(slider_Zoom, tB_Zoom, uiRef.digitalZoom);
            CameraCommands.ChangeZoomLevel(uiRef.digitalZoom);
        }
        private void tB_Zoom_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                uiRef.digitalZoom = uiRef.ChangeVal(slider_Zoom, tB_Zoom, uiRef.digitalZoom);
                CameraCommands.ChangeZoomLevel(uiRef.digitalZoom);
            }
        }

        private void tB_Contrast_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                CameraCommands.ChangeContrast(uiRef.contrastLevel);
        }

        private void tB_Brightness_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                CameraCommands.ChangeBrightness(uiRef.brightLevel);
        }

        private void tB_DDE_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                CameraCommands.ChangeDDELevel(uiRef.ddeLevel);
        }

        private void tB_Zoom_TextChanged(object sender, EventArgs e) {
            uiRef.KeepUpdated(tB_Zoom, slider_Zoom, uiRef.digitalZoom);
        }

        private void tB_Contrast_TextChanged(object sender, EventArgs e) {
            uiRef.KeepUpdated(tB_Contrast, slider_Contrast, uiRef.contrastLevel);
        }

        private void tB_Brightness_TextChanged(object sender, EventArgs e) {
            uiRef.KeepUpdated(tB_Brightness, slider_Brightness, uiRef.brightLevel);
        }

        private void tB_DDE_TextChanged(object sender, EventArgs e) {
            uiRef.KeepUpdated(tB_DDE, slider_DDE, uiRef.ddeLevel);
        }
        
        private void slider_Zoom_Scroll(object sender, EventArgs e) {
            tB_Zoom.Text = slider_Zoom.Value.ToString();
        }

        private void slider_Contrast_Scroll(object sender, EventArgs e) {
            tB_Contrast.Text = slider_Contrast.Value.ToString();
        }

        private void slider_Brightness_Scroll(object sender, EventArgs e) {
            tB_Brightness.Text = slider_Brightness.Value.ToString();
        }

        private void slider_DDE_Scroll(object sender, EventArgs e) {
            tB_DDE.Text = slider_DDE.Value.ToString();
        }

        private void slider_Zoom_ValueChanged(object sender, EventArgs e) {

        }
    }
}

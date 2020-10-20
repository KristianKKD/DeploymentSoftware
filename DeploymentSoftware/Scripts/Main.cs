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
        UIControl uiScript = new UIControl();

        public Main() {
            InitializeComponent();
            
            CameraCommands.uiRef = uiScript;
            CameraCommands.mainRef = this;

            CameraCommunicate.uiRef = uiScript;

            UIControl.mainRef = this;

            VideoPlay.mainRef = this;
        }


        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            CameraCommunicate.CloseSock();
        }

        private void b_Connect_Click(object sender, EventArgs e) {
            GetData();
        }

        async Task GetData() {
            if (!CameraCommunicate.sock.Connected) {
                await CameraCommunicate.Connect(tB_IP.Text, cB_Port.Text);
            }
            await CameraCommands.GetCameraStuff();
            uiScript.UpdateUI();
        }

        private void b_DDEOn_Click(object sender, EventArgs e) {
            CameraCommands.DDEState(true);
        }

        private void b_DDEOff_Click(object sender, EventArgs e) {
            CameraCommands.DDEState(false);
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
            uiScript.ShowExtended();
        }

        private void b_Play_Click(object sender, EventArgs e) {
            playScript.Play();
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
            uiScript.contrastLevel = uiScript.ChangeVal(slider_Contrast, tB_Contrast, uiScript.contrastLevel);
            CameraCommands.ChangeContrast(uiScript.contrastLevel);
        }

        void BrightnessChanged() {
            uiScript.brightLevel = uiScript.ChangeVal(slider_Brightness, tB_Brightness, uiScript.brightLevel);
            CameraCommands.ChangeBrightness(uiScript.brightLevel);
        }

        void DDEChanged() {
            uiScript.ddeLevel = uiScript.ChangeVal(slider_DDE, tB_DDE, uiScript.ddeLevel);
            CameraCommands.ChangeDDELevel(uiScript.ddeLevel);
        }


        private void button1_Click(object sender, EventArgs e) {
            p_Control.Enabled = true;
            uiScript.Display();

        }

        private void tB_Contrast_TextChanged(object sender, EventArgs e) {
            uiScript.KeepUpdated(tB_Contrast, slider_Contrast, uiScript.contrastLevel);
        }

        private void tB_Brightness_TextChanged(object sender, EventArgs e) {
            uiScript.KeepUpdated(tB_Brightness, slider_Brightness, uiScript.brightLevel);
        }

        private void tB_DDE_TextChanged(object sender, EventArgs e) {
            uiScript.KeepUpdated(tB_DDE, slider_DDE, uiScript.ddeLevel);
        }

        private void tB_Contrast_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter)
                CameraCommands.ChangeContrast(uiScript.contrastLevel);
        }

        private void tB_Brightness_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                CameraCommands.ChangeBrightness(uiScript.brightLevel);
        }

        private void tB_DDE_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                CameraCommands.ChangeDDELevel(uiScript.ddeLevel);
        }

    }
}

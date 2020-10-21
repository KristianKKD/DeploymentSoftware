using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeploymentSoftware {

    class UIControl {

        public int brightLevel = 0;
        public int contrastLevel = 0;
        public int ddeLevel = 0;

        public int paletteMode = 0;
        public int flipMode = 0;
        public int agcMode = 0;

        public int digitalZoom = 0;

        public bool ddeOn = false;

        public bool stopUpdates;

        public static Main mainRef;

        public async Task UpdateUI() {
            stopUpdates = true;

            mainRef.slider_Brightness.Value = brightLevel;
            mainRef.slider_Contrast.Value = contrastLevel;
            mainRef.slider_DDE.Value = ddeLevel;

            mainRef.tB_Brightness.Text = brightLevel.ToString();
            mainRef.tB_Contrast.Text = contrastLevel.ToString();
            mainRef.tB_DDE.Text = ddeLevel.ToString();

            switch (paletteMode) {
                case 0:
                    mainRef.cB_Palette.SelectedIndex = 0;
                    break;
                case 1:
                    mainRef.cB_Palette.SelectedIndex = 1;
                    break;
                case 5:
                    mainRef.cB_Palette.SelectedIndex = 2;
                    break;
                case 6:
                    mainRef.cB_Palette.SelectedIndex = 3;
                    break;
                case 11:
                    mainRef.cB_Palette.SelectedIndex = 4;
                    break;
                default:
                    mainRef.cB_Palette.SelectedIndex = mainRef.cB_Palette.Items.Count - 1;
                    break;
            }

            switch (flipMode) {
                case 8:
                    mainRef.cB_Flip.SelectedIndex = 0;
                    break;
                case 1:
                    mainRef.cB_Flip.SelectedIndex = 1;
                    break;
                default:
                    mainRef.cB_Flip.SelectedIndex = mainRef.cB_Flip.Items.Count - 1;
                    break;
            }

            mainRef.slider_Contrast.Enabled = false;
            mainRef.tB_Contrast.Enabled = false;
            mainRef.slider_Brightness.Enabled = false;
            mainRef.tB_Brightness.Enabled = false;

            switch (agcMode) {
                case 0:
                    mainRef.cB_AGC.SelectedIndex = 0;
                    mainRef.slider_Contrast.Enabled = true;
                    mainRef.tB_Contrast.Enabled = true;
                    mainRef.slider_Brightness.Enabled = true;
                    mainRef.tB_Brightness.Enabled = true;
                    break;
                case 1:
                    mainRef.cB_AGC.SelectedIndex = 1;
                    break;
                case 2:
                    mainRef.cB_AGC.SelectedIndex = 2;
                    break;
                default:
                    mainRef.cB_AGC.SelectedIndex = mainRef.cB_AGC.Items.Count - 1;
                    break;
            }

            if (ddeOn) {
                mainRef.b_DDEOff.Enabled = true;
                mainRef.b_DDEOn.Enabled = false;
            } else {
                mainRef.b_DDEOff.Enabled = false;
                mainRef.b_DDEOn.Enabled = true;
            }

            mainRef.tB_DDE.Enabled = ddeOn;
            mainRef.slider_DDE.Enabled = ddeOn;

            stopUpdates = false;
        }

        public void Display() {
            MessageBox.Show(
                "contrastLevel =" + contrastLevel + "\n" +
                "brightLevel =" + brightLevel + "\n" +
                "ddeLevel =" + ddeLevel + "\n" +
                "paletteMode =" + paletteMode + "\n" +
                "flipMode =" + flipMode + "\n" +
                "agcMode =" + agcMode + "\n" +
                "ddeEnabled = " + ddeOn.ToString() + "\n"
                );
        }

        public void KeepUpdated(TextBox tb, TrackBar slider, int variable) {
            if (tb.Text == "") {
                return;
            }
            bool success = int.TryParse(tb.Text, out int converted);
            //if (converted == int.Parse(tb.Text) && slider.Value == slider.Value) {
            //    return;
            //}
            if (success && converted > -1 && converted < slider.Maximum + 1) {
                slider.Value = converted;
            } else {
                tb.Text = variable.ToString();
            }
        }

        public int ChangeVal(TrackBar slider, TextBox tb, int copyVar, bool half = false) {
            if (!half) {
                copyVar /= 2;
            }

            if (slider.Value != copyVar) {
                copyVar = slider.Value;
            }
            tb.Text = copyVar.ToString();
            return copyVar;
        }

        public void ShowExtended() {
            if (mainRef.check_Extend.Checked) {
                mainRef.p_Extended.Show();
                mainRef.p_Basic.Hide();
            } else {
                mainRef.p_Basic.Show();
                mainRef.p_Extended.Hide();
            }
        }

        public void NotConnected() {
            mainRef.l_Connected.Text = "Not Connected";
            mainRef.p_Control.Enabled = false;
            CameraCommunicate.CloseSock();
        }

        public void IsConnected() {
            mainRef.l_Connected.Text = "Connected";
            mainRef.p_Control.Enabled = true;
        }
        

    }
}

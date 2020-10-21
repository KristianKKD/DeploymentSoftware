using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeploymentSoftware {

    class CameraCommands {

        public static Main mainRef;
        public static UIControl uiRef;

        public static void ChangeAGCLevel(string text) {
            byte[] code = new byte[9];

            if (uiRef.stopUpdates) {
                return;
            }

            switch (text) {
                case "Manual":
                    uiRef.agcMode = 0;
                    code = (new byte[] { 0xAA, 0x05, 0x00, 0x3A, 0x01, 0x00, 0xEA, 0xEB, 0xAA });
                    break;
                case "Auto 0":
                    uiRef.agcMode = 1;
                    code = (new byte[] { 0xAA, 0x05, 0x00, 0x3A, 0x01, 0x01, 0xEB, 0xEB, 0xAA });
                    break;
                case "Auto 1":
                    uiRef.agcMode = 2;
                    code = (new byte[] { 0xAA, 0x05, 0x00, 0x3A, 0x01, 0x02, 0xEC, 0xEB, 0xAA });
                    break;
            }

            CameraCommunicate.SendToSocket(code);
        }

        public static void ChangeFlip(string selected) {
            byte[] code = new byte[9];

            if (uiRef.stopUpdates) {
                return;
            }

            switch (selected) {
                case "No Flip":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x30, 0x01, 0x01, 0xE1, 0xEB, 0xAA };
                    uiRef.flipMode = 8;
                    break;
                case "Left - Right Flip":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x30, 0x01, 0x02, 0xE2, 0xEB, 0xAA };
                    uiRef.flipMode = 2;
                    break;
                case "Up - Down Flip":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x30, 0x01, 0x04, 0xE4, 0xEB, 0xAA };
                    uiRef.flipMode = 4;
                    break;
                case "Mirror Flip":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x30, 0x01, 0x08, 0xE8, 0xEB, 0xAA };
                    uiRef.flipMode = 1;
                    break;
            }

            CameraCommunicate.SendToSocket(code);
        }

        public static void ChangePalette(string selected) {
            byte[] code = new byte[9];

            if (uiRef.stopUpdates) {
                return;
            }

            switch (selected) {
                case "White Hot":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x2D, 0x01, 0x00, 0xDD, 0xEB, 0xAA };
                    uiRef.paletteMode = 0;
                    break;
                case "Black Hot":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x2D, 0x01, 0x01, 0xDE, 0xEB, 0xAA };
                    uiRef.paletteMode = 1;
                    break;
                case "Rainbow1":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x2D, 0x01, 0x05, 0xE2, 0xEB, 0xAA };
                    uiRef.paletteMode = 2;
                    break;
                case "Rainbow2":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x2D, 0x01, 0x06, 0xE3, 0xEB, 0xAA };
                    uiRef.paletteMode = 3;
                    break;
                case "Red Hot":
                    code = new byte[] { 0xAA, 0x05, 0x00, 0x2D, 0x01, 0x0B, 0xE8, 0xEB, 0xAA };
                    uiRef.paletteMode = 4;
                    break;
            }

            CameraCommunicate.SendToSocket(code);
        }


        public static void DDEState(bool state) {
            byte[] code = new byte[9];
            if (state) {
                code = new byte[] { 0xAA, 0x05, 0x00, 0x3E, 0x01, 0x01, 0xEF, 0xEB, 0xAA };
            } else {
                code = new byte[] { 0xAA, 0x05, 0x00, 0x3E, 0x01, 0x00, 0xEE, 0xEB, 0xAA };
            }
            CameraCommunicate.SendToSocket(code);
            
            uiRef.ddeOn = state;
            uiRef.UpdateUI();
        }

        public static void ChangeZoomLevel(int zoom) {
            byte[] code = QuickFindZoom(zoom);

            CameraCommunicate.SendToSocket(code);

            uiRef.digitalZoom = zoom;
        }


        static byte[] QuickFindZoom(int zoom) {

            byte[] code = new byte[17];

            switch (zoom) {
                case 0:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x7F , 0x02 , 0xFF , 0x01 , 0x63 , 0xEB , 0xAA };
                    break;
                case 1:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0x6B , 0x00 , 0x55 , 0x00 , 0x14 , 0x02 , 0xA9 , 0x01 , 0x62 , 0xEB , 0xAA };
                    break;
                case 2:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0xA0 , 0x00 , 0x80 , 0x00 , 0xDF , 0x01 , 0x7F , 0x01 , 0x62 , 0xEB , 0xAA };
                    break;
                case 3:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0xC0 , 0x00 , 0x9A , 0x00 , 0xBF , 0x01 , 0x65 , 0x01 , 0x62 , 0xEB , 0xAA };
                    break;
                case 4:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0xD5 , 0x00 , 0xAB , 0x00 , 0xA9 , 0x01 , 0x54 , 0x01 , 0x61 , 0xEB , 0xAA };
                    break;
                case 5:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0xE5 , 0x00 , 0xB7 , 0x00 , 0x9A , 0x01 , 0x48 , 0x01 , 0x62 , 0xEB , 0xAA };
                    break;
                case 6:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0xF0 , 0x00 , 0xC0 , 0x00 , 0x8F , 0x01 , 0x3F , 0x01 , 0x62 , 0xEB , 0xAA };
                    break;
                case 7:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0x95 , 0x00 , 0x70 , 0x00 , 0xE9 , 0x00 , 0xAF , 0x00 , 0x7F , 0xEB , 0xAA };
                    break;
                case 8:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0x9A , 0x00 , 0x73 , 0x00 , 0xE5 , 0x00 , 0xAB , 0x00 , 0x7F , 0xEB , 0xAA };
                    break;
                case 9:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0x9D , 0x00 , 0x76 , 0x00 , 0xE1 , 0x00 , 0xA9 , 0x00 , 0x7F , 0xEB , 0xAA };
                    break;
                case 10:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0xA0 , 0x00 , 0x78 , 0x00 , 0xDF , 0x00 , 0xA7 , 0x00 , 0x80 , 0xEB , 0xAA };
                    break;
                case 11:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0xA2 , 0x00 , 0x7A , 0x00 , 0xDC , 0x00 , 0xA5 , 0x00 , 0x7F , 0xEB , 0xAA };
                    break;
                case 12:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0xA5 , 0x00 , 0x7B , 0x00 , 0xDA , 0x00 , 0xA3 , 0x00 , 0x7F , 0xEB , 0xAA };
                    break;
                case 13:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0xA6 , 0x00 , 0x7D , 0x00 , 0xD8 , 0x00 , 0xA2 , 0x00 , 0x7F , 0xEB , 0xAA };
                    break;
                case 14:
                    code = new byte[] { 0xAA , 0x0D , 0x00 , 0x2A , 0x01 , 0x00 , 0xA8 , 0x00 , 0x7E , 0x00 , 0xD7 , 0x00 , 0xA1 , 0x00 , 0x80 , 0xEB , 0xAA };
                    break;
            }

            return code;
        }



        public static void ChangeContrast(int contrast) { //WORKING
            byte contrastInByte = (byte)MathStuff.ConvertToHex(contrast);
            int checksum = 0;
            byte[] checksumWithoutVal = new byte[] { 0xAA, 0x05, 0x00, 0x3B, 0x01, contrastInByte };
            for (int i = 0; i < checksumWithoutVal.Length; i++) {
                checksum += Convert.ToInt32(checksumWithoutVal[i]);
            }
            checksum = checksum % 256;


            byte[] code = new byte[] { 0xAA, 0x05, 0x00, 0x3B, 0x01, contrastInByte, (byte)MathStuff.ConvertToHex(checksum), 0xEB, 0xAA };
            Com changeContrast = new Com(code, Com.contrastChangedResponse, 9); //might need to verify the command
            CameraCommunicate.GetResponseManual(code);
        }

        public static void ChangeBrightness(int bright) { //THIS ONE WONT WORK, NEED TO DO 2 VALUES
            int val1 = 0;
            int val2 = bright;
            if (val2 > 255) {
                val1 = 1;
                val2 = val2 - 255;
            }

            byte val1Byte = (byte)MathStuff.ConvertToHex(val1);
            byte val2Byte = (byte)MathStuff.ConvertToHex(val2);
            int checksum = 0;
            byte[] checksumWithoutVal = new byte[] { 0xAA, 0x06, 0x00, 0x3C, 0x01, val1Byte, val2Byte };
            for (int i = 0; i < checksumWithoutVal.Length; i++) {
                checksum += Convert.ToInt32(checksumWithoutVal[i]);
            }
            checksum = checksum % 256;

            byte[] code = new byte[] { 0xAA, 0x06, 0x00, 0x3C, 0x01, val2Byte, val1Byte, (byte)MathStuff.ConvertToHex(checksum), 0xEB, 0xAA };
            MessageBox.Show(val2Byte.ToString() + " " + val2Byte.ToString() + " " + MathStuff.ConvertToHex(checksum).ToString());
            MessageBox.Show(CameraCommunicate.GetResponseManual(code).Result);

        }

        public static void ChangeDDELevel(int DDE) {
            byte DDEInByte = (byte)MathStuff.ConvertToHex(DDE);
            int checksum = 0;
            byte[] checksumWithoutVal = new byte[] { 0xAA, 0x05, 0x00, 0x3F, 0x01, DDEInByte };
            for (int i = 0; i < checksumWithoutVal.Length; i++) {
                checksum += Convert.ToInt32(checksumWithoutVal[i]);
            }
            checksum = checksum % 256;


            byte[] code = new byte[] { 0xAA, 0x05, 0x00, 0x3F, 0x01, DDEInByte, (byte)MathStuff.ConvertToHex(checksum), 0xEB, 0xAA };
            CameraCommunicate.GetResponseManual(code);

        }

        //reading commands
        static Com contra = new Com(Com.contrastLevelCommand, Com.contrastLevelResponse, 9);
        static Com bright = new Com(Com.brightLevelCommand, Com.brightLevelResponse, 10, true);
        static Com palM = new Com(Com.paletteModeCommand, Com.paletteModeResponse, 9);
        static Com flipM = new Com(Com.flipModeCommand, Com.flipModeResponse, 10);
        static Com agcM = new Com(Com.agcModeCommand, Com.agcModeResponse, 9);
        static Com ddeL = new Com(Com.ddeLevelCommand, Com.ddeLevelResponse, 9);
        static Com ddeO = new Com(Com.ddeStateCommand, Com.ddeOnResponse, 9);
        static Com agcO = new Com(Com.agcOnCommand, Com.agcOnResponse, 9);

        public static async Task GetCameraStuff() {

            if (CameraCommunicate.sock.Connected) { 
                CameraCommunicate.SendToSocket(new byte[] { 0xAA, 0x05, 0x01, 0x3D, 0x02, 0x01, 0xF0, 0xEB, 0xAA }); //enables analogue video

                SendCommand(contra);
                uiRef.contrastLevel = contra.iValue;

                SendCommand(bright);
                uiRef.brightLevel = bright.iValue;

                SendCommand(palM);
                uiRef.paletteMode = palM.iValue;

                SendCommand(flipM);
                uiRef.flipMode = flipM.iValue;

                SendCommand(agcM);
                uiRef.agcMode = agcM.iValue;

                SendCommand(ddeL);
                uiRef.ddeLevel = ddeL.iValue;

                SendCommand(ddeO, true);
                uiRef.ddeOn = ddeO.bValue;

                //SendCommand(agcO, true);
                //uiRef.agcOn = agcO.bValue;

            }
        }

        public static async Task<Com> SendCommand(Com command, bool isBoolType = false) {
            string expected = PerfectFormat(command).Result.ToUpper();
            bool isGood = false;
            int savedWrongCount = 0;
            string returnedValue = "";

            int rightSpot = 10;

            while (!isGood) {
                savedWrongCount++;
                if (savedWrongCount > 10) {
                    MessageBox.Show("Failed to collect data");
                    break;
                }

                returnedValue = "";
                int wrongCount = 0;

                string response = CameraCommunicate.GetResponse(command).Result.ToUpper();
                
                string converted = "";
                for (int i = 0; i < expected.Length; i++) {
                    converted += expected[i];
                }

                response = response.Replace(" ", "");
                //MessageBox.Show("full response vs expected\n" + response.ToString() + "\n" + converted + "\nchar " + rightSpot + " = " + response[rightSpot].ToString());

                for (int i = 0; i < response.Length; i++) {
                    if (i > expected.Length - 1) {
                        break;
                    }
                    if (response[i] != expected[i]) {
                        //MessageBox.Show("Num: " + i.ToString() + " char: " + returnedValue[i] + "\nIs: " + expected[i].ToString() + " Should be: " + responseArray[i].ToString() +  "\n" + response.ToString() + "\n vs \n" + converted);
                        if (i == rightSpot && wrongCount == 0) {
                            if (command.duoVal) {
                                returnedValue = response[i].ToString() + response[i + 1].ToString()
                                    + response[i+2].ToString() + response[i + 3].ToString();
                            } else {
                                returnedValue = response[i].ToString() + response[i + 1].ToString();
                            }
                            isGood = true;
                            break;
                        } else {
                            wrongCount++;
                        }
                    }
                }

            }

            if (isBoolType) {
                command.bValue = MathStuff.ConvertToBool(returnedValue);
            } else {
                if (command.duoVal) {
                    command.iValue = MathStuff.ConvertToInt(returnedValue, true);
                } else {
                    command.iValue = MathStuff.ConvertToInt(returnedValue);
                }
            }
            //MessageBox.Show(command.iValue.ToString());

            return command;
        }

        public static async Task<string> PerfectFormat(Com command) {
            string responseCommand = "";
            for (int i = 0; i < command.returnCommand.Length; i++) {
                responseCommand += command.returnCommand[i];
            }
            responseCommand = responseCommand.Replace(" ", "");
            return responseCommand;
        }



    }

}

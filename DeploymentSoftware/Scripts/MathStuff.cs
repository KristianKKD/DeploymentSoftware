﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeploymentSoftware {

    class MathStuff {

        public static int ConvertToInt(string code, bool doubleValue = false) { //displaying the brightness dont work
            int num1 = 0;
            int num2 = 0;

            string valueCode = code.Substring(0, 2);
            num1 = int.Parse(valueCode, System.Globalization.NumberStyles.HexNumber);


            if (doubleValue) {
                string valueCode2 = code.Substring(2, 2);
                num2 = int.Parse(valueCode2, System.Globalization.NumberStyles.HexNumber);
                if (num1 > 0) {
                    num1 = 255;
                }
                MessageBox.Show(code + " 1: " + num1.ToString() + " 2: " + num2.ToString() + "\n" + (num1 + num2).ToString());

            }
            int total = num1 + num2;

            return total;
        }

        public static bool ConvertToBool(string code) {
            int returnedNumber = ConvertToInt(code, false);
            if (returnedNumber == 1) {
                return true;
            } else {
                return false;
            }
        }

        public static uint ConvertToHex(int val) {
            uint hexVal = Convert.ToUInt32(val);
            return hexVal;
        }

        public static string ByteToHex(byte msg) {
            string hex = msg.ToString("X");
            if (hex.ToArray().Length == 1) {
                hex = "0" + hex;
            }
            return hex;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeploymentSoftware {

    public class Com {

    //send commands
        //read
        public static byte[] contrastLevelCommand = new byte[] { 0xAA, 0x04, 0x00, 0x3B, 0x00, 0xE9, 0xEB, 0xAA };
        public static byte[] brightLevelCommand = new byte[] { 0xAA, 0x04, 0x00, 0x3C, 0x00, 0xEA, 0xEB, 0xAA };
        public static byte[] paletteModeCommand = new byte[] { 0xAA, 0x04, 0x00, 0x2D, 0x00, 0xDB, 0xEB, 0xAA };
        public static byte[] flipModeCommand = new byte[] { 0xAA, 0x04, 0x00, 0x30, 0x00, 0xDE, 0xEB, 0xAA };
        public static byte[] agcModeCommand = new byte[] { 0xAA, 0x04, 0x00, 0x3A, 0x00, 0xE8, 0xEB, 0xAA };
        public static byte[] ddeLevelCommand = new byte[] { 0xAA, 0x04, 0x00, 0x3F, 0x00, 0xED, 0xEB, 0xAA };
        public static byte[] ddeStateCommand = new byte[] { 0xAA, 0x04, 0x00, 0x3E, 0x00, 0xEC, 0xEB, 0xAA };
        public static byte[] agcOnCommand = new byte[] { 0xAA, 0x04, 0x00, 0x3E, 0x33, 0x00, 0xE8, 0xEB, 0xAA };


        //set
       

    //expected receive commands
    //read
        public static string[] contrastLevelResponse = new string[] { "55", "05", "00", "3B", "33", "4A", "EB", "AA" };
        public static string[] brightLevelResponse = new string[] { "55", "06", "00", "3C", "33", "BE", "EB", "AA" };
        public static string[] paletteModeResponse = new string[] { "55", "05", "00", "2D", "33", "BA", "EB", "AA" };
        public static string[] flipModeResponse = new string[] { "55", "05", "00", "30", "33", "EB", "AA" };
        public static string[] agcModeResponse = new string[] { "55", "05", "00", "3A", "33", "EB", "AA" };
        public static string[] ddeLevelResponse = new string[] { "55", "05", "00", "3F", "33", "CE", "EB", "AA" };
        public static string[] ddeOnResponse = new string[] { "55", "05", "00", "3E", "33", "CC", "EB", "AA" };
        public static string[] agcOnResponse = new string[] { "AA", "04", "00", "3A", "33", "00", "E8", "EB", "AA" };

        //set
        public static string[] contrastChangedResponse = new string[] { "55", "05", "00", "3B", "33", "C9", "EB", "AA" };
        public static string[] brightnessChangedResponse = new string[] { "55", "05", "00", "3C", "33", "CA", "EB", "AA" };
        public static string[] ddeLevelChangedResponse = new string[] { "55", "05", "00", "3F", "33", "CD", "EB", "AA" };

        public int iValue;
        public bool bValue;
        public int length;
        public bool duoVal;
        public byte[] sendCommand;
        public string[] returnCommand;

        public Com(byte[] sendByteArray, string[] returnByteArray, int l, bool duo = false, int iv = 0, bool bv = false) {
            iValue = iv;
            bValue = bv;
            length = l;
            duoVal = duo;
            sendCommand = sendByteArray;
            returnCommand = returnByteArray;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeploymentSoftware {

    class VideoPlay {

        public static Main mainRef;

        public async Task Play(string ConnectIP = "") {
            string combinedUrl;
            
            if (ConnectIP != "") {
                combinedUrl = "rtsp://admin:admin@" + ConnectIP + ":6791/videoinput_1:0/h264_1/onvif.stm";
            } else {
                if (mainRef.check_Extend.Checked) {
                    string ipaddress = mainRef.tB_Extend_IP.Text;
                    string port = mainRef.tB_Extend_Port.Text;
                    string url = mainRef.tB_Extend_RTSP.Text;
                    string username = mainRef.tB_Extend_Username.Text;
                    string password = mainRef.tB_Extend_Password.Text;

                    combinedUrl = "rtsp://" + username + ":" + password + "@" + ipaddress + ":" + port + url;
                } else {
                    combinedUrl = mainRef.tB_Basic_RTSP.Text;
                }
            }
            //rtsp://admin:admin@192.168.1.74:6791/videoinput_1:0/h264_1/onvif.stm
            //rtsp://admin:admin@192.168.1.74:554/videoinput_1:0/h264_1/onvif.stm


            Uri combined = new Uri(combinedUrl);
            if (!CameraCommunicate.PingAdr(combined.Host, combined.Port).Result) {
                return;
            }

            mainRef.tB_Basic_RTSP.Text = combinedUrl;
            Replay(mainRef.VLCPlayer, combinedUrl);
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

    }
}

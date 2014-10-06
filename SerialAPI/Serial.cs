using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace SerialAPI
{

    public class Serial
    {

        /* Serial Params */
        static SerialPort serial;
        private static string PORT = "COM1";
        private static int RATE = 9600;
        public string ERROR;

        /* Thread to Read serial data */
        private static Thread thread;

        /* Event Handler */
        public delegate void GameEventHandler(string foo);
        public event GameEventHandler GameAction;

        /* Class Constructor  */
        public Serial()
        {

            serial = new SerialPort(PORT, RATE, Parity.None, 8, StopBits.One)
            {
                Handshake = Handshake.None
            };

            try
            {
                serial.Open();

            }
            catch (Exception ex)
            {
                ERROR = "Error opening port: " + ex.Message;
               
            }



            /* 
             * Read Serial data on diffrent thread to avoid blocking
             * 
             * Note: Unity dosent support DataReceived Event
            */
            thread = new Thread(new ThreadStart(sendData));
            thread.Start();

        }

        /* Sends data to Event Handler registered by 3rd party */
        private void sendData()
        {

            while (true)
            {
                string tempData = serial.ReadLine();
                this.GameAction(tempData);
            }

        }

        /* Error Reporting */
        private void error(string error)
        {
            this.GameAction(error);
        }

        /* Close the Thread */
        public void close()
        {
            thread.Abort();
            serial.Close();
        }

        /* Test Function */
        public void start()
        {

            for (var i = 0; i < 500; i++)
            {
                GameAction("BRAKE:1");

            }
        }



    }


}

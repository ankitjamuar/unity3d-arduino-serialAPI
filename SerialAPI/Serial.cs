using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace SerialAPI
{

    public class Serial
    {

        /* Serial Params */
        static SerialPort serial;
        private static int RATE = 9600;
        public string ERROR;

        /* Thread to Read serial data */
        private static Thread thread;

        /* Event Handler */
        public delegate void GameEventHandler(string foo);
        public event GameEventHandler GameAction;

        /* Class Constructor  */
        public Serial(string PORT, bool isDummy) 
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
            thread = new Thread(() => sendData(ERROR, isDummy));
            thread.Start();
        }

       
        /* Sends data to Event Handler registered by 3rd party */
        private void sendData(string errMsg, bool dummy)
        {
            this.GameAction(errMsg);

            if (dummy)
            {

                /* 
                 * In case Hardware is not available, API can be initialised with true params to receive dummy data.
                 *  serial = new SerialAPI.Serial("COM1",true);  //true
                 * 
                 */


                //this.gameAction("YOUR DUMMY DATA");
                //Thread.Sleep(1000);

            }
            else
            {
                while (true)
                {
                    string tempData ="";
                    tempData = serial.ReadLine();
                    this.GameAction(tempData);                  
                    tempData = "";
                }
            }



        }


        /* Close the Thread */
        public void close()
        {
            thread.Abort();
            serial.Close();
        }

              
    }
}

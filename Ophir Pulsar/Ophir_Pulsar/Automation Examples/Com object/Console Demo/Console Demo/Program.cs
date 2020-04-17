using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Console_Demo
{

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> statusText;
            statusText = new Dictionary<int, string>();
            statusText.Add(0, "OK");
            statusText.Add(1, "OVERRANGE");
            statusText.Add(2, "SATURATED");
            statusText.Add(3, "MISSING PULSE");
            statusText.Add(4, "RESET STATE IN ENERGY MEASUREMENT");
            statusText.Add(5, "WAITING");
            statusText.Add(6, "SUMMING");
            statusText.Add(7, "TIMEOUT");
            statusText.Add(8, "PEAK OVER");
            statusText.Add(9, "ENERGY OVER");

            statusText.Add(0x10000, "OK");          // x position ok
            statusText.Add(0x10000 + 1, "ERROR");   // x position error
            statusText.Add(0x20000, "OK");          // y position ok
            statusText.Add(0x20000 + 1, "ERROR");   // y position error
            statusText.Add(0x30000, "OK");          // size ok
            statusText.Add(0x30000 + 1, "ERROR");   // size error
            statusText.Add(0x30000 + 2, "WARNING"); // size warning
            statusText.Add(0x40000 + 1, "EVENT - SETTING CHANGED"); // event

            ConsoleKeyInfo cki = new ConsoleKeyInfo();


            // init control
            OphirLMMeasurementLib.CoLMMeasurement CoLM = new OphirLMMeasurementLib.CoLMMeasurement();

            // open usb
            try
            {
                // Look for devices connected to the USB.
                Object serialNumbers;
                CoLM.ScanUSB(out serialNumbers);

                string[] serialNumberArray = ((string[])serialNumbers);
                if (serialNumberArray.Length != 0)
                {
                    for (int i = 0; i < serialNumberArray.Length; i++)
                        Console.WriteLine(serialNumberArray[i]);
                }
                else
                {
                    Console.WriteLine("No device connected.");
                    Console.Read();
                    return;
                }

                // Get handle of first connected device
                int hDevice;
                CoLM.OpenUSBDevice(serialNumberArray[0], out hDevice);
                Console.WriteLine("Device {0} has handle = {1}", serialNumberArray[0], hDevice);

                /*
                 * Get sensor properties.
                 */

                int channel = 0;
                int index;
                Object options;

                // Show wavelengths of channel 0
                Console.WriteLine("Displaying sensor's wavelengths");
                CoLM.GetWavelengths(hDevice, channel, out index, out options);

                string[] optionsArray = (string[])options;
                for (int i = 0; i < optionsArray.Length; i++)
                    Console.WriteLine(optionsArray[i]);
                Console.WriteLine("Current index = {0}", index);

                // Show ranges of channel 0
                Console.WriteLine("Displaying sensor's ranges");
                CoLM.GetRanges(hDevice, channel, out index, out options);

                optionsArray = (string[])options;
                for (int i = 0; i < optionsArray.Length; i++)
                    Console.WriteLine(optionsArray[i]);
                Console.WriteLine("Current index = {0}", index);

                Console.WriteLine("Press any key to go on");
                Console.ReadKey(true);

                /*
                 * Retrieving measurements
                 */
                
                Console.WriteLine("Demo StartStream (measuring process)");

                CoLM.StartStream(hDevice, channel);
                Console.WriteLine("Starting measuring process. Press the 'x' key to quit.");

                // Measurement loop
                do
                {
                    Object dataArray, timeStampArray, statusArray;

                    while (Console.KeyAvailable == false)
                    {
                        CoLM.GetData(hDevice, channel, out dataArray, out timeStampArray, out statusArray);

                        if (((double[])dataArray).Length > 0)
                        {
                            double[] dataArr = (double[])dataArray;
                            double[] tsArr = (double[])timeStampArray;
                            int[] statusArr = (int[])statusArray;
                            string stat;
                            for (int ind = 0; ind < dataArr.Length; ind++)
                            {
                                stat = "";
                                if(statusText.ContainsKey(statusArr[ind]))  // if unknown status - ignore it, else - get it
                                    stat = statusText[statusArr[ind]];
                                Console.WriteLine("handle:{0} channel:{1} value:{2} timestamp:{3}  status:{4}",
                                                  hDevice, channel, dataArr[ind], tsArr[ind], stat);
                            }

                        }
 
                        Thread.Sleep(500);  // wait 0.5 seconds for new measurements
                    }
 
                    if (Console.KeyAvailable)
                    {
                        cki = Console.ReadKey(true);
                        if (cki.Key != ConsoleKey.X)
                            Console.WriteLine(" Press the 'x' key to quit.");
                    }
                } while (cki.Key != ConsoleKey.X);

                Console.WriteLine("\nStopping measuring process.");
                CoLM.StopStream(hDevice, channel);
  
                CoLM.Close(hDevice);
                Console.WriteLine("Exit demo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.Read();
            }
        }
    }
}

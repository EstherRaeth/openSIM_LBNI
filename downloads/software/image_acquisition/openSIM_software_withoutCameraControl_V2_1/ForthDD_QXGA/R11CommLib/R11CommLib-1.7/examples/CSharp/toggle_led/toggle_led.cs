using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ForthDD.R11.Binding;

namespace ForthDD.R11.Examples
{
    class ToggleLED
    {
        private const ushort TIMEOUT = 1000;
        private const uint BAUDRATE = 115200;

        private const byte LED_LOW = 64;
        private const byte LED_HIGH = 128;

        private static void showDevices()
        {
            Console.WriteLine("Candidate Device IDs:");

            foreach (String devStr in R11CommLib.FDD_DevEnumerateWinUSB())
            {
                Console.WriteLine(devStr.Split(':')[1]);
            }

            foreach (String devStr in R11CommLib.FDD_DevEnumerateComPorts())
            {
                Console.WriteLine(devStr);
            }
        }

        private static void openDevice(String devID)
        {
            List<String> devList = R11CommLib.FDD_DevEnumerateWinUSB();

            foreach(String devStr in devList)
            {
                String[] strParts = devStr.Split(':');
                String devPath = strParts[0];
                String devSN = strParts[1];
                
                if(devID == devSN)
                {
                    R11CommLib.FDD_DevOpenWinUSB(devPath, TIMEOUT);
                    return;
                }
            }
            
            devList = R11CommLib.FDD_DevEnumerateComPorts();

            foreach (String devStr in devList)
            {
                if (devID == devStr)
                {
                    R11CommLib.FDD_DevOpenComPort(devID, TIMEOUT, BAUDRATE, true);
                    return;
                }
            }

            throw new System.InvalidOperationException(String.Format("Device '{0}' not found", devID));
        }

        static void Main(String[] args)
        {
            try
            {
                if ((args == null) || (args.Length != 1))
                {
                    Console.WriteLine("Usage: {0} <Device ID>\n", System.AppDomain.CurrentDomain.FriendlyName);

                    showDevices();
                }
                else
                {
                    byte ledVal;

                    openDevice(args[0]);

                    ledVal = R11CommLib.R11_RpcLedGet();
                    Console.WriteLine("Current LED Value = {0}", ledVal);

                    ledVal = (ledVal == LED_HIGH) ? LED_LOW : LED_HIGH;

                    R11CommLib.R11_RpcLedSet(ledVal);
                    Console.WriteLine("New LED Value = {0}", ledVal);

                    R11CommLib.R11_RpcSysSaveSettings();
                    Console.WriteLine("Settings Saved", ledVal);

                    R11CommLib.FDD_DevClose();
                }
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

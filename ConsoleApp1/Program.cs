using ScalesConnector;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            ScaleData sd = new ScaleData
            {
                BaudRate = 9600,
                DataBits = 7,
                Parity = (System.IO.Ports.Parity)2,
                PortName = "COM5",
                StartBits = 1,
                 StopBits = (System.IO.Ports.StopBits)1,
                 StartString = "ABCD,",
                 StopString="kg",
                 WeightRegex=@"[0-9 +-]*",
                 Tare = 800
            };

            //in this sample the received data is "ABCD,          -100kg"

            ScaleReader sr = new ScaleReader(sd);

            while(true)
            {
                sr.Read();
                Console.WriteLine(sr.LastReadWeight);
                Thread.Sleep(100);
            }
            
        }
    }
}

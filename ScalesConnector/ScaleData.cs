#region copyright
//Copyright 2018 Monteiro-s
//
//This file is part of ScaleConnector.
//ScaleConnector is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
//ScaleConnector is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
//You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
#endregion
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace ScalesConnector
{
    /// <summary>
    /// Data format to initialize the reader
    /// </summary>
    public class ScaleData
    {
        public StopBits StopBits { get; set; }
        public int StartBits { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public int BaudRate { get; set; }
        /// <summary>
        /// Name of the serial port
        /// </summary>
        public string PortName { get; set; }
        /// <summary>
        /// The first part string that the serial port will get (before the desired weight value)
        /// </summary>
        public string StartString { get; set; }
        /// <summary>
        /// The last part string that the serial port will get (after the desired weight value)
        /// </summary> 
        public string StopString { get; set; }

        /// <summary>
        /// The Regex expression to get the weight, e.g. [0-9 +-]*
        /// </summary>
        public string WeightRegex { get; set; }

        /// <summary>
        /// The scale tare given by the manufacturer
        /// </summary>
        public double Tare { get; set; }
    }
}

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
using System.Text.RegularExpressions;
using System.Threading;

namespace ScalesConnector
{
    /// <summary>
    /// This project works with serial port scales
    /// </summary>
    public class ScaleReader
    {
        private SerialPort _serialPort = new SerialPort();
        private string _startString;
        private string _stopString;
        private string _valueRegex;

        /// <summary>
        /// The last valid value gotten from the scale
        /// </summary>
        public string LastReadWeight { get; private set; }

        public ScaleReader(ScaleData initializer)
        {
            _serialPort.PortName = initializer.PortName;
            _serialPort.BaudRate = initializer.BaudRate;
            _serialPort.Parity = initializer.Parity;
            _serialPort.DataBits = initializer.DataBits;
            _serialPort.StopBits = initializer.StopBits;
            _serialPort.ReadTimeout = 500;

            _startString = initializer.StartString;
            _stopString = initializer.StopString;
            _valueRegex = initializer.WeightRegex;
        }

        /// <summary>
        /// Reads the value from the Scale and validate it with the given parameter
        /// </summary>
        /// <returns>Fills the LastReadWeight variable with the last valid read weight</returns>
        public void Read()
        {
            string regex = String.Format(@"(?<={0})({1})(?={2})", _startString, _valueRegex, _stopString);

            if (!_serialPort.IsOpen)
                _serialPort.Open();

            string input = _serialPort.ReadLine();


            LastReadWeight = Regex.IsMatch(input, regex, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.Singleline) ?
                 Regex.Match(input, regex, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.Singleline).ToString() :
                 LastReadWeight;
        }

        /// <summary>
        /// Disconnect from the scale
        /// </summary>
        public void Disconnect()
        {
            if (!_serialPort.IsOpen)
                return;

            _serialPort.Dispose();
            _serialPort.Close();
        }
    }
}

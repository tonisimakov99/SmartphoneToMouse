using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseImitation
{
    class ByteMessagesFormat
    {
        const byte EndMessageMark = 0;
        const byte ParametersSeparator = 32;

        public static byte[] BuildMessage(byte command, params int[] parameters)
        {
            var result = new List<byte>();
            result.Add(command);
            foreach (var p in parameters)
            {
                result.Add(ParametersSeparator);
                //версия без кодировки
                //result.AddRange(p.ToBytes());
                result.AddRange(Encoding.UTF8.GetBytes(p.ToString()));
            }
            result.Add(EndMessageMark);
            return result.ToArray();
        }

        public static byte[] BuildMessage(ByteMessage message)
        {
            return BuildMessage(message.Command, message.Parameters);
        }

        public static ByteMessage ParseMessage(byte[] message)
        {
            if (message.Length < 2) throw new Exception();
            var command = message[0];
            var parameters = new List<int>();
            var digits = new List<byte>();
            for (var i = 2; i < message.Length; i++)
            {
                if (message[i] != ParametersSeparator && message[i] != EndMessageMark)
                    digits.Add(message[i]);
                else
                {
                    //версия без кодировки
                    //parameters.Add(IntExtensions.GetNumber(digits.ToArray()));
                    parameters.Add(int.Parse(Encoding.UTF8.GetString(digits.ToArray())));
                    digits.Clear();
                }
            }
            return new ByteMessage()
            {
                Command = command,
                Parameters = parameters.ToArray()
            };
        }
    }
}

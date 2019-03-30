using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MouseImitation
{
    class ClientCommandsHandler : IClientCommandsHandler
    {
        readonly Dictionary<byte, MethodInfo> methodDecode;

        public ClientCommandsHandler()
        {
            var type = typeof(MouseAPI);
            methodDecode = new Dictionary<byte, MethodInfo>
            {
                { 1, type.GetMethod("MoveCursor") },
                { 2, type.GetMethod("HoldLeftButton") },
                { 3, type.GetMethod("UnholdLeftButton") },
                { 4, type.GetMethod("HoldRightButton") },
                { 5, type.GetMethod("UnholdRightButton") },
                { 6, type.GetMethod("Wheel") },
                { 7, type.GetMethod("HorizontalWheel") },
                { 8, type.GetMethod("LeftClick") },
                { 9, type.GetMethod("RightClick") }
            };
        }

        public void Handle(byte[] arr)
        {
            foreach (var command in GetCommands(arr))
            {
                var message = ByteMessagesFormat.ParseMessage(command);
                methodDecode[message.Command]
                    .Invoke(null, message.Parameters.Cast<object>().ToArray());
            }
        }

        readonly List<byte> savedData = new List<byte>();
        IEnumerable<byte[]> GetCommands(byte[] arr)
        {
            var buff = savedData;
            foreach (var b in arr)
            {
                buff.Add(b);
                if (b == 0)
                {
                    yield return buff.ToArray();
                    buff.Clear();
                }
            }
        }
    }
}

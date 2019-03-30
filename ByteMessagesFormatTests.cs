using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseImitation
{
    //Я создаю тестовый проект, добавляю ссылку на этот проект, но я, какого-то хрена, не вижу этого пространства имен,
    //и из-за этого приходится писать этот класс здесь и без поддержки тестов вижуалкой
    class ByteMessagesFormatTests
    {
        public void Start()
        {
            var methods = typeof(ByteMessagesFormatTests).GetMethods().Where(m => m.Name.StartsWith("Test"));
            foreach (var method in methods)
                method.Invoke(this, new object[0]);
        }

        void Check_BuildMessage(byte b, byte[] result, params int[] parameters)
        {
            var r = ByteMessagesFormat.BuildMessage(b, parameters);
            if (r.Length != result.Length)
                throw new Exception();
            for (var i = 0; i < r.Length; i++)
                if (r[i] != result[i])
                    throw new Exception();
        }

        void Check_ParseMessage(byte[] message, ByteMessage result)
        {
            var r = ByteMessagesFormat.ParseMessage(message);
            if (r.Command != result.Command)
                throw new Exception();
            if (r.Parameters == null)
                throw new Exception();
            if (r.Parameters.Length != result.Parameters.Length)
                throw new Exception();
            for (var i = 0; i < r.Parameters.Length; i++)
                if (r.Parameters[i] != result.Parameters[i])
                    throw new Exception();
        }

        public void Test1_BuildMessage()
        {
            Check_BuildMessage(1, new byte[] { 1, 0 });
        }

        public void Test2_BuildMessage()
        {
            Check_BuildMessage(2, new byte[] { 2, 32, 50, 0 }, 2);
        }

        public void Test3_BuildMessage()
        {
            Check_BuildMessage(3, new byte[] { 3, 32, 51, 32, 52, 0 }, 3, 4);
        }

        public void Test4_BuildMessage()
        {
            Check_BuildMessage(4, new byte[] { 4, 32, 51, 52, 32, 50, 49, 0 }, 34, 21);
        }

        public void Test5_BuildMessage()
        {
            Check_BuildMessage(5, new byte[] { 5, 32, 53, 53, 53, 0 }, 555);
        }

        public void Test6_BuildMessage()
        {
            Check_BuildMessage(6, new byte[] { 6, 32, 45, 51, 52, 50, 32, 50, 49, 0 }, -342, 21);
        }

        public void Test7_BuildMessage()
        {
            Check_BuildMessage(7, new byte[] { 7, 32, 52, 50, 32, 45, 49, 49, 49, 0 }, 42, -111);
        }

        public void Test8_BuildMessage()
        {
            Check_BuildMessage(8, new byte[] { 8, 32, 45, 49, 50, 51, 0 }, -123);
        }

        public void Test1_ParseMessage()
        {
            Check_ParseMessage(new byte[] { 1, 0 },
                new ByteMessage() { Command = 1, Parameters = new int[0] });
        }

        public void Test2_ParseMessage()
        {
            Check_ParseMessage(new byte[] { 2, 32, 50, 0 },
                new ByteMessage() { Command = 2, Parameters = new int[] { 2 } });
        }

        public void Test3_ParseMessage()
        {
            Check_ParseMessage(new byte[] { 3, 32, 51, 52, 0 },
                new ByteMessage() { Command = 3, Parameters = new int[] { 34 } });
        }

        public void Test4_ParseMessage()
        {
            Check_ParseMessage(new byte[] { 4, 32, 45, 53, 51, 52, 0 },
                new ByteMessage() { Command = 4, Parameters = new int[] { -534 } });
        }

        public void Test5_ParseMessage()
        {
            Check_ParseMessage(new byte[] { 5, 32, 51, 52, 32, 55, 55, 0 },
                new ByteMessage() { Command = 5, Parameters = new int[] { 34, 77 } });
        }

        public void Test6_ParseMessage()
        {
            Check_ParseMessage(new byte[] { 6, 32, 45, 49, 50, 51, 32, 49, 50, 0 },
                new ByteMessage() { Command = 6, Parameters = new int[] { -123, 12 } });
        }

        public void Test7_ParseMessage()
        {
            Check_ParseMessage(new byte[] { 7, 32, 50, 51, 32, 45, 57, 50, 49, 0 },
                new ByteMessage() { Command = 7, Parameters = new int[] { 23, -921 } });
        }

        public void Test8_ParseMessage()
        {
            Check_ParseMessage(new byte[] { 7, 32, 45, 49, 49, 49, 32, 45, 52, 51, 50, 0 },
                new ByteMessage() { Command = 7, Parameters = new int[] { -111, -432 } });
        }
    }
}

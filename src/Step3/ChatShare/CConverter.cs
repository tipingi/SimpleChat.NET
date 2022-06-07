using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatShare
{
    public class CConverter
    {
        public static string ClassToString(CPacket packet)
        {
            return JsonConvert.SerializeObject(packet);
        }
        public static byte[] ClassToBytes(CPacket packet)
        {
            var _json_string = CConverter.ClassToString(packet);
            return Encoding.UTF8.GetBytes(_json_string);
        }

        public static CPacket StringToClass(string message)
        {
            return JsonConvert.DeserializeObject<CPacket>(message);
        }

        public static CPacket BytesToClass(byte[] buffer, int length)
        {
            var _message = Encoding.UTF8.GetString(buffer, 0, length);
            return JsonConvert.DeserializeObject<CPacket>(_message);
        }
    }
}

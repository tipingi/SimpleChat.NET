namespace ChatShare
{
    public class CPacket
    {
        public PacketType type
        {
            get;
            set;
        }

        public string userid
        {
            get;
            set;
        }

        public string message
        {
            get;
            set;
        }    

       /* public bool isconnected
        {
            get;
            set;
        }*/
    }
    public enum PacketType
    {
        command,
        message
    }
}
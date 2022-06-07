namespace ChatShare
{
    public enum PacketType 
    {
        command,
        message
    }

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
    }
}
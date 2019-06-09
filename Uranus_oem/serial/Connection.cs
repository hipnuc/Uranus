using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uranus
{
    public class Connection
    {
        public delegate bool SendDataEventHandler(byte[] buffer, int index, int count);
        public event SendDataEventHandler OnSendData;

        public delegate void ReceivedDataEventHandler(byte[] buffer, int index, int count);
        public event ReceivedDataEventHandler OnReceviedData;

        public bool Send(byte[] buffer, int index, int count)
        {
            if (OnSendData != null)
            {
                return OnSendData(buffer, index, count);
            }
            else
            {
                return false;
            }
        }

        public void Input(byte[] buf)
        {
            if (OnReceviedData != null)
            {
                OnReceviedData(buf, 0, buf.Length);
            }
        }

    }
}

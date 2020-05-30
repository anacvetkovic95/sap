using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservations
{
    class Reservation
    {
        int size;

        int startDay;
        int endDay;

        string result;

        public Reservation(int size, int startDay, int endDay, string result)
        {
            this.Size = size;
            this.StartDay = startDay;
            this.EndDay = endDay;
            this.Result = result;
        }

        public int Size { get => size; set => size = value; }
        public int StartDay { get => startDay; set => startDay = value; }
        public int EndDay { get => endDay; set => endDay = value; }
        public string Result { get => result; set => result = value; }
    }
}

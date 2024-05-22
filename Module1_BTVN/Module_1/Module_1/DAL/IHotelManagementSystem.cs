using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1
{
    public interface IHotelManagementSystem
    {
        void AddRoom(int n);
        void RemoveRoom(Room room);
        void UpdateRoom(string input);
        Room SearchRoom(string input);
        void AddBooking();
        void RemoveBooking(Booking booking);
        void UpdateBooking();
        void DisplayBooking();
        Booking SearchBooking(string input);
    }
}

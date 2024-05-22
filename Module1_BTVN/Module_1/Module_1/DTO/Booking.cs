using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int RoomNumber { get; set; }
        public long Cost { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime NgayBook { get; set; }
        public Booking(int bookingId, int roomNumber, long cost, DateTime checkInDate, DateTime checkOutDate, DateTime ngayBook)
        {
            BookingId = bookingId;
            RoomNumber = roomNumber;
            Cost = cost;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            NgayBook = ngayBook;
        }
        public override string ToString()
        {
            return $"BookingID: {BookingId} - So phong: {RoomNumber} - Gia: {Cost * (CheckOutDate - CheckInDate).TotalDays} - Ngay bat dau: {CheckInDate} - Ngay ket thuc: {CheckOutDate} - Ngay dat phong: {NgayBook}.";
        }
    }
}

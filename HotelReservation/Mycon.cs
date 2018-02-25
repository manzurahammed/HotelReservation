using MySql.Data.MySqlClient;
namespace HotelReservation
{
    class Mycon
    {
        public static MySqlConnection con = new MySqlConnection("server=localhost; uid=root; password=; database=hotel");
    }
}

namespace Server
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RoomID { get; set; }

        public string FullInfo
        {
            get{
                return $"{ID} {Name} {RoomID}";
            }
        }
    }
}

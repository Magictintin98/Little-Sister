namespace API.Model
{
    public class Position 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CameraId { get; set; }

        public Position(int id, string name, int cameraId) {
            Id = id;
            Name = name;
            CameraId = cameraId;
        }

        public Position() {
            
        }
    }
}
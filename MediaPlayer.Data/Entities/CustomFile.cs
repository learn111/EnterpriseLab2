namespace MediaPlayer.Data.Entities
{
    public class CustomFile
    {
        public int CustomFileId { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public int? TrackId { get; set; }
        public virtual Track Track { get; set; }
    }
}
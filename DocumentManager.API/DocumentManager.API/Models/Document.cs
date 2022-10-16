using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DocumentManager.API.Models
{
    [DataContract]
    public class Document
    {
        [DataMember]
        public string DownloadUrl { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string FileType { get; set; }

        [DataMember]
        public DateTime UploadDate { get; set; }

        [DataMember]
        public string UplaodBy { get; set; }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public Guid FolderId { get; set; }

        [DataMember]
        public string FolderName { get; set; }

        [JsonIgnore]
        public IFormFile File { get; set; }
    }
}

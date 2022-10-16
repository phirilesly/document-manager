using DocumentManager.API.Models;

namespace DocumentManager.API.Repositories
{
    public interface IDocumentRepository
    {
        Task<Document> UploadDocument(Document command);
    }
}

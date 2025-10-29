using Olaru_Irina_Lab2.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Olaru_Irina_Lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public  IEnumerable<Book> Books { get; set; }
    }
}

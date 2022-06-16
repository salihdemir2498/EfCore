using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_2504.DAL.Entities
{
    public class BookAuthor
    {
        //kitap ile yazar arasında çoka çok ilişki var o yüzden bu classı oluşturduk.
        public int BookAuthorId { get; set; }
        //FK
        public int BookId { get; set; }
        //navigation Property
        public Book Book { get; set; }
        //FK
        public int AuthorId { get; set; }
        //navigation Property
        public Author Author { get; set; }
    }
}

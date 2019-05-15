using System;
using System.Collections.Generic;
using System.Text;

namespace netcore2_mongodb.Repository.Document
{
    public class Book : Document
    {
        public string Name { get; set; }

        public string Author { get; set; }
    }
}

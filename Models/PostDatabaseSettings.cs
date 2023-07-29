using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Postit.Models
{
    public class PostDatabaseSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string PostCollectionName { get; set; } = null;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query
{
    /// <summary>
    /// This class is used to store the previous search queries
    /// </summary>
    /// param name="previousSearchQueries">The list of previous search queries</param>
    public class SearchQuery
    {
        public List<string> previousSearchQueries  { get; set; }
    }
}

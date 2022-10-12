using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entities
{
    public class ResponseJokes
    {
        public List<Jokes> Jokes { get; set; }
        public string StatusCode { get; set; }

        public string Message { get; set; }
    }
}

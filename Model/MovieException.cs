using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesClassLibrary.Model
{
    public class MovieException:Exception
    {
        public MovieException(string msg) : base(msg) { }
    }
}

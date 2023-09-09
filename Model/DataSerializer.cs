using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MoviesClassLibrary.Model
{
    internal class DataSerializer
    {
        public static void BinarySerializer(string filePath, List<Movie> movies)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, movies);
            }
        }
        public static List<Movie> BinaryDeserializer(string filePath)
        {
            List<Movie> movies = new List<Movie>();
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (fileStream.Length > 0)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    movies = (List<Movie>)formatter.Deserialize(fileStream);
                }
            }
            return movies;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesClassLibrary.Model
{
    public class MovieManager
    {
        private string filePath = @"D:\AuroTraining\Session 17\MoviesClassLibrary\Movie.txt";
        private List<Movie> movies;
        public MovieManager()
        {
            movies = DataSerializer.BinaryDeserializer(filePath);
            if (movies == null)
            {
                movies = new List<Movie>();
            }
        }
        public List<Movie> GetAllMovies()
        {
            if (movies.Count == 0)
            {
                throw new MovieException("No movies to display. Enter again.");
            }
            return movies;
        }
        public List<Movie> GetMoviesByYear(int year)
        {
            List<Movie> moviesYear = movies.FindAll(movie => movie.Year == year);
            if (moviesYear.Count == 0)
            {
                throw new MovieException($"No movies found for the year {year}.");
            }
            return moviesYear;
        }
        public int GetMovieCount()
        {
            return movies.Count;
        }
        public void AddMovie(int id, string name, string genre, int year)
        {
            Movie movie = new Movie(id, name, genre, year);
            if (movies.Exists(existingMovie => existingMovie.Id == id))
            {
                throw new MovieException($"Movie with ID {id} already exists");
            }
            if (movies.Count >= 5)
            {
                throw new MovieException("Cannot have more than 5 movies");
            }
            movies.Add(movie);
            DataSerializer.BinarySerializer(filePath, movies);
        }
        public void RemoveMovie(int id)
        {
            Movie movieToRemove = movies.Find(movie => movie.Id == id);
            if (movieToRemove == null)
            {
                throw new MovieException($"Movie with ID {id} not found");
            }
            movies.Remove(movieToRemove);
            DataSerializer.BinarySerializer(filePath, movies);
        }
        public void ClearAllMovies()
        {
            if (movies.Count == 0)
            {
                throw new MovieException("No movies to clear");
            }
            movies.Clear();
            DataSerializer.BinarySerializer(filePath, movies);
        }
    }
}

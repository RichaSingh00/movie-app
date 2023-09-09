using MoviesClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    internal class MovieController
    {
        private const int MAX_MOVIES = 5;
        private MovieManager movieManager;
        public MovieController()
        {
            movieManager = new MovieManager();
            MainMenu();
        }
        private void MainMenu()
        {
            while (true)
            {
                Console.WriteLine($"Movie Store Status: {movieManager.GetMovieCount()}/{MAX_MOVIES}\n"
                    + $"Menu: \n1. Display All\n2. Display movie(s) by Year\n3. Add movie(s)\n"
                    + $"4. Remove Movie(s)\n5. Clear all movies\n6. Exit\nEnter your choice from 1-6: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    MenuChoice(choice);
                }
                else
                {
                    Console.WriteLine("Invalid input format. Please enter again");
                }
            }
        }
        public void MenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    DisplayAll();
                    break;
                case 2:
                    DisplayByYear();
                    break;
                case 3:
                    AddMovie();
                    break;
                case 4:
                    RemoveMovie();
                    break;
                case 5:
                    ClearAll();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter the number between 1-6 only.");
                    break;
            }
        }
        private void DisplayAll()
        {
            try
            {
                List<Movie> movies = movieManager.GetAllMovies();
                foreach (Movie movie in movies)
                {
                    Console.WriteLine($"Movie Id: {movie.Id}\nMovie Name: {movie.Name}\n" +
                                      $"Genre: {movie.Genre}\nYear: {movie.Year}");
                }
            }
            catch (MovieException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void DisplayByYear()
        {
            try
            {
                Console.WriteLine("Enter year to display movies for:");
                if (int.TryParse(Console.ReadLine(), out int year))
                {
                    List<Movie> moviesYear = movieManager.GetMoviesByYear(year);
                    Console.WriteLine($"Movies released in {year}:");
                    foreach (Movie movie in moviesYear)
                    {
                        Console.WriteLine($"Movie Id: {movie.Id}\nMovie Name: {movie.Name}\n" +
                                      $"Genre: {movie.Genre}\nYear: {movie.Year}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid year.");
                }
            }
            catch (MovieException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void AddMovie()
        {
            try
            {
                Console.WriteLine("Enter movie id");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Enter movie name:");
                    string name = (Console.ReadLine());

                    Console.WriteLine("Enter movie genre");
                    string genre = (Console.ReadLine());

                    Console.WriteLine("Enter movie year:");
                    if (int.TryParse(Console.ReadLine(), out int year))
                    {
                        movieManager.AddMovie(id, name, genre, year);
                        Console.WriteLine("Movie added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid year input. Please enter a valid input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid id input. Please enter a valid id");
                }
            }
            catch (MovieException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        private void RemoveMovie()
        {
            try
            {
                Console.WriteLine("Enter movie id to remove:");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    movieManager.RemoveMovie(id);
                    Console.WriteLine("Movie removed successfully");
                }
                else
                {
                    Console.WriteLine("Invalid id input. Please enter a valid id");
                }
            }
            catch (MovieException e)
            {
                Console.WriteLine($"Error :{e.Message}"); //accessing the property via variable
            }
        }
        private void ClearAll()
        {
            try
            {
                movieManager.ClearAllMovies();
                Console.WriteLine("Cleared all movies");
            }
            catch (MovieException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

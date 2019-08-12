using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldContinue = true;
            do
            {
                List<Movie> Movies = new List<Movie>();
                var sortedMovies = PopulateMovies(Movies);
                int category = StartPrompt(sortedMovies);
                ShowMovies(sortedMovies, category);
                shouldContinue = AskToContinue();
                Console.Clear();
            }
            while (shouldContinue);

            Console.WriteLine("Alrighty, enjoy your movie!");
        }


        static List<Movie> PopulateMovies(List<Movie> movies)
        {
            movies.Add(new Movie("2001: A Space Odyssey", "scifi"));
            movies.Add(new Movie("Blade Runner", "scifi"));
            movies.Add(new Movie("The Day the Earth Stood Still", "scifi"));
            movies.Add(new Movie("Metropolis", "scifi"));
            movies.Add(new Movie("Citizen Kane", "drama"));
            movies.Add(new Movie("Casablanca", "drama"));
            movies.Add(new Movie("12 Angry Men", "drama"));
            movies.Add(new Movie("Schindler's List", "drama"));
            movies.Add(new Movie("The Exorcist", "horror"));
            movies.Add(new Movie("Halloween", "horror"));
            movies.Add(new Movie("Psycho", "horror"));
            movies.Add(new Movie("The Shining", "horror"));
            movies.Add(new Movie("Snow White", "animated"));
            movies.Add(new Movie("The Little Mermaid", "animated"));
            movies.Add(new Movie("Fantasia", "animated"));
            movies.Add(new Movie("Bambi", "animated"));

            var sortedList = movies.OrderBy(movie => movie.Title);
            return sortedList.ToList();
        }

        static int StartPrompt(List<Movie> movies)
        {
            Console.WriteLine("Welcome to the movie application!");
            Console.WriteLine("What type of movie can I interest you in?");
            Console.WriteLine("[1] Scifi");
            Console.WriteLine("[2] Drama");
            Console.WriteLine("[3] Horror");
            Console.WriteLine("[4] Animated");

             int category = 0;
            bool validNumber = false;

            do
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out category))
                {
                    if (category <= 4 && category > 0)
                    {
                        validNumber = true;
                    }
                    else
                    {
                        validNumber = false;
                        Console.WriteLine("That's not an option, please enter an valid integer for a category");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter the interger for the desired category.");
                    validNumber = false;
                }

            } while (!validNumber);


            return category;


        }

        static void ShowMovies(List<Movie> movies, int category)
        {
            Console.Clear();
            Console.WriteLine("Here's some movies you might be interested in");

            foreach (var movie in movies)
            {

                int thisMovieCateogry = InterpretGenre(movie);
                if (thisMovieCateogry == category)
                {
                    Console.WriteLine(movie.Title);
                }
                else
                {

                };
            }
        }

        static int InterpretGenre(Movie movie)
        {
        
            if (movie.Genre == "scifi")
            {
                return 1;
            }
            else if (movie.Genre == "drama")
            {
                return 2;
            }
            else if (movie.Genre == "horror")
            {
                return 3;
            }
            else if (movie.Genre == "animated")
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        static bool AskToContinue()
        {
            bool shouldContinue = true;
            bool validInput = false;
            Console.WriteLine();
            Console.WriteLine("Want to go again? (y/n)");
            do
            {
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    validInput = true;
                    shouldContinue = true;
                }
                else if (input == "n")
                {
                    validInput = true;
                    shouldContinue = false;
                }
                else
                {
                    Console.WriteLine("Well, that's not the answer I was looking for... type either 'y' or 'n' to continue");
                    validInput = false;
                }


            } while (!validInput);



            return shouldContinue;
        }
    }




}

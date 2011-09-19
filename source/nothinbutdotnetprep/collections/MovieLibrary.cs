using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
			return movies.Filter(m => true);
        }

    	public void add(Movie movie)
        {
			if (!movies.Contains(movie))
			{
				movies.Add(movie);
			}
        }

    	public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
			return all_movies_from_studios(new List<ProductionStudio> { ProductionStudio.Pixar });
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
        	return all_movies_from_studios(new List<ProductionStudio> {ProductionStudio.Disney, ProductionStudio.Pixar});
        }

		private IEnumerable<Movie> all_movies_from_studios(IList<ProductionStudio> studios)
		{
			return movies.Filter(m => studios.Contains(m.production_studio));
		}

		private IEnumerable<Movie> all_movies_not_from_studios(IList<ProductionStudio> studios)
		{
			return movies.Filter(m=>!studios.Contains(m.production_studio));
		}

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
        	return all_movies_not_from_studios(new List<ProductionStudio> {ProductionStudio.Pixar});
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
			return movies.Filter(m => m.date_published.Year > year);
        }

    	public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
			return movies.Filter(movie => movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear);
        }

        public IEnumerable<Movie> all_kid_movies()
        {
			return movies.Filter(m => m.genre == Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
        	return movies.Filter(m => m.genre == Genre.action);
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }
    }

	public static class IEnumerableExtensions
	{
		public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Predicate<T> filter)
		{
			foreach (var item in list)
			{
				if (filter(item))
					yield return item;
			}
		}
	}
}
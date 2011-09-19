using System;
using nothinbutdotnetprep.utility;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

		public override string ToString()
		{
			return string.Format("{0} ({1})", title, date_published.Year);
		}

        public bool Equals(Movie other)
        {
            if (other == null) return false;
            return ReferenceEquals(this, other) || Equals(other.title, title);
        }

        public override bool Equals(object obj)
        {
            return (Equals(obj as Movie));
        }

        public override int GetHashCode()
        {
            return (title != null ? title.GetHashCode() : 0);
        }

        public static Condition<Movie> is_in_genre(Genre genre)
        {
            return new IsInGenre(genre).matches;
        }

        public static IMatchA<Movie> is_published_by(ProductionStudio  studio)
        {
            return new IsPublishedBy(studio);
        }

        public static IMatchA<Movie> is_published_by_pixar
        {
            get { return is_published_by(ProductionStudio.Pixar);}
        }

        public static IMatchA<Movie> is_published_by_pixar_or_disney()
        {
            return is_published_by(ProductionStudio.Pixar).or(
                is_published_by(ProductionStudio.Disney));

        }
    }
}
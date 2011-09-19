using System;

namespace nothinbutdotnetprep.collections
{
  public class Movie
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
  		if (ReferenceEquals(null, other)) return false;
  		if (ReferenceEquals(this, other)) return true;
  		return Equals(other.title, title) && Equals(other.production_studio, production_studio) && Equals(other.genre, genre) && other.rating == rating && other.date_published.Equals(date_published);
  	}

  	public override bool Equals(object obj)
  	{
  		if (ReferenceEquals(null, obj)) return false;
  		if (ReferenceEquals(this, obj)) return true;
  		if (obj.GetType() != typeof (Movie)) return false;
  		return Equals((Movie) obj);
  	}

  	public override int GetHashCode()
  	{
  		unchecked
  		{
  			int result = (title != null ? title.GetHashCode() : 0);
  			result = (result*397) ^ (production_studio != null ? production_studio.GetHashCode() : 0);
  			result = (result*397) ^ (genre != null ? genre.GetHashCode() : 0);
  			result = (result*397) ^ rating;
  			result = (result*397) ^ date_published.GetHashCode();
  			return result;
  		}
  	}

  	public static bool operator ==(Movie left, Movie right)
  	{
  		return Equals(left, right);
  	}

  	public static bool operator !=(Movie left, Movie right)
  	{
  		return !Equals(left, right);
  	}
  }
}

public class MoviesCtrl : ControllerBase
{
    private readonly List<Movie> _movies = new List<Movie>();

    public ActionResult<IEnumerable<Movie>> GetAllMovies()
    {
        return Ok(_movies);
    }


    public ActionResult<Movie> GetMovieById(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }


    public ActionResult<Movie> AddMovie([FromBody] Movie movie)
    {
        movie.Id = _movies.Count + 1;
        _movies.Add(movie);
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }


    public ActionResult<Movie> UpdateMovie(int id, [FromBody] Movie updatedMovie)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        movie.Title = updatedMovie.Title;
        movie.ReleaseYear = updatedMovie.ReleaseYear;
        movie.Director = updatedMovie.Director;
        return Ok(movie);
    }

  
    public ActionResult DeleteMovie(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        _movies.Remove(movie);
        return NoContent();
    }
}
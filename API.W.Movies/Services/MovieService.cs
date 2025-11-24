using API.W.Movies.DataAccessLayer.Models;
using API.W.Movies.DataAccessLayer.Models.Dtos;
using API.W.Movies.Repository.IRepository;
using API.W.Movies.Services.IServices;
using AutoMapper;

namespace API.W.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<bool> MovieExistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieCreateDto)
        {
            //Validar si la categoria ya existe
            var movieExists = await _movieRepository.MovieExistsByNameAsync(movieCreateDto.Name);

            if (movieExists)
            {
                throw new InvalidOperationException($"Ya existe una pelicula con el nombre de '{movieCreateDto.Name}'");
            }

            //Mapear el DTO a la entidad
            var movie = _mapper.Map<Movie>(movieCreateDto);

            //Crear la categoria en el repositorio
            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("Ocurrió un error al crear la pelicula");
            }

            //Mapear la entidad creada a DTO
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            //verificar si la categoria existe
            var  movieExists = await _movieRepository.GetMovieAsync(id);

            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontró la pelicula con ID: '{id}'");
            }

            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);

            if (!movieDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la pelicula.");
            }

            return movieDeleted;
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync(); //Solo estoy haciendo el llamado del metodo desde la capa de repository

            return _mapper.Map<ICollection<MoviesDto>>(movies); //Mapeo la lista de categorias a una lista de categorias Dto
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            //optener la categoria del repositorio
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la pelicula con ID: '{id}'");
            }

            //Mapear toda la colección de una vez
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            //Validar si la categoria ya existe
            var movieExists = await _movieRepository.GetMovieAsync(id);

            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontró la pelicula con ID: '{id}'");
            }

            var nameExists = await _movieRepository.MovieExistsByNameAsync(dto.Name);

            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una pelicula con el nombre de {dto.Name}");
            }

            //Mapear el DTO a la entidad
            _mapper.Map(dto, movieExists);

            //Actualizamos la categoria en el repositorio
            var movieUpdated = await _movieRepository.UpdateMovieAsync(movieExists);

            if (!movieUpdated)
            {
                throw new Exception("Ocurrió un error al actualizar la pelicula");
            }

            //Retornar el DTO actualizando
            return _mapper.Map<MovieDto>(movieExists);
        }
    }
}
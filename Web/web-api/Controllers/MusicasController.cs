using System.Web.Http;
using web_api.Models;
using web_api.Repository;

namespace web_api.Controllers
{
    public class MusicasController : ApiController
    {
        private readonly MusicaRepository repositorio;
        public MusicasController()
        {
            repositorio = new MusicaRepository();
        }

        // GET: api/Musicas
        public IHttpActionResult Get()
        {
            var musicas = repositorio.ListarTodas();
            
            return Ok(musicas);
        }

        // GET: api/Musicas/5
        public IHttpActionResult Get(int id)
        {
            Musica musica = repositorio.ObterPorId(id);

            if (musica != null)
                return Ok(musica);
            else
                return BadRequest("Id não encontrado!");
        }

        // POST: api/Musicas
        public IHttpActionResult Post([FromBody] Musica musica)
        {
            Musica musicaAdicionada = repositorio.Adicionar(musica);

            if (musicaAdicionada != null)
                return Ok(musicaAdicionada);
            else
                return BadRequest("Não foi possível realizar a inserção! Verifique as informações e tente novamente...");
        }
        
        // PUT: api/Musicas/5
        public IHttpActionResult Put(int id, [FromBody] Musica musica)
        {
            Musica musicaAlterada = repositorio.Alterar(id, musica);

            if (musicaAlterada != null)
                return Ok(musicaAlterada);
            else
                return BadRequest("Não foi possível realizar a inserção! Verifique as informações e tente novamente...");

        }

        // DELETE: api/Musicas/5
        public IHttpActionResult Delete(int id)
        {
            Musica musicaExcluida = repositorio.Excluir(id);

            if (musicaExcluida != null)
                return Ok(musicaExcluida);
            else
                return BadRequest("Não foi possível realizar a exclusão! Verifique as informações e tente novamente...");
        }

    }
}


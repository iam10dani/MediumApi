using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MidiumApi.Models;
using MidiumApi.Repositories.Interfaces;
using MidiumApi.Repositories;

namespace MidiumApi.Controllers
{
    public class ArticlesController : ApiController
    {

        private IArticleRepositorys repository = new ArticleRepository();

      

        // GET: api/Articles
        public IQueryable<Article> GetArticles()
        {
            return repository.GetAllArticles();
        }

        // GET: api/Articles/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticles(Guid id)
        {
            Article article = repository.GetArticle(id);
            if(article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        // PUT: api/Articles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticles(Guid id, Article articles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articles.id)
            {
                return BadRequest();
            }


            if (!repository.ArticlesExists(id))
            {
                return NotFound();
            }

                repository.EditArticle(articles);
          
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Articles
        [ResponseType(typeof(Article))]
        public IHttpActionResult PostArticles(Article articles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Article newArticle;
            try
            {
              newArticle =  repository.AddArticle(articles);
            }
            catch (DbUpdateException)
            {
                if (repository.ArticlesExists(articles.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = newArticle.id }, newArticle);
        }

        // DELETE: api/Articles/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult DeleteArticles(Guid id)
        {
            
            if (!repository.ArticlesExists(id))
            {
                return NotFound();
            }

            Article articles = repository.RemoveArticle(id);

            return Ok(articles);
        }


    }
}
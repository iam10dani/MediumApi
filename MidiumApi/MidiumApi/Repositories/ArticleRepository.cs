using MidiumApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MidiumApi.Models;
using System.Data.Entity;

namespace MidiumApi.Repositories
{
    public class ArticleRepository : IArticleRepositorys
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Article AddArticle(Article article)
        {
            article.id = Guid.NewGuid();
            article.datePublished = DateTime.Now;
            db.Articles.Add(article);
            db.SaveChanges();
            return article;
        }

        public Article EditArticle(Article article)
        {
            db.Entry(article).State = EntityState.Modified;
            db.SaveChanges();
            return article;
        }

      

        public Article GetArticle(Guid articleId)
        {
            Article articles = db.Articles.Find(articleId);

            return articles;
        }

        public Article RemoveArticle(Guid articleId)
        {
            Article articles = db.Articles.Find(articleId);

            return articles;

           
        }

        public bool ArticlesExists(Guid id)
        {
            return db.Articles.Count(e => e.id == id) > 0;
        }

        public IQueryable<Article> GetAllArticles()
        {
            return db.Articles;
        }
    }
}
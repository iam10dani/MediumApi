using MidiumApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MidiumApi.Repositories.Interfaces
{
    public interface IArticleRepositorys
    {
        Article AddArticle(Article article);
        Article RemoveArticle(Guid articleId);
        Article EditArticle(Article article);
        Article GetArticle(Guid articleId);
        IQueryable<Article> GetAllArticles();
        bool ArticlesExists(Guid id);
    }
}
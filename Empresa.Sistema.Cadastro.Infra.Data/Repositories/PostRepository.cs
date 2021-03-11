using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Repository;
using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using Empresa.Sistema.Infra.Shared.Data.Repositories.Base;
using Infra.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;

namespace Empresa.Sistema.Cadastro.Infra.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbContext dbContext, ILogFacede logger)
            : base(dbContext, logger)
        {

        }

        public IEnumerable<Post> ObterQueryManyToMany()
        {
            IEnumerable<Post> retorno;

            using (var db = _dbContext.GetConnection())
            {
                var sql = @"
select	p.postid
		, p.Headline
		, p.Content
		, p.DateCeated
		, p.DateUpdated
		, t.tagid
		, T.tagname
from post p 
left join posttagS pt on pt.postid = p.postid
left join tag t on t.tagid = pt.tagid
order by p.postid";

                var posts = db.Query<Post, Tag, Post>(
                    sql
                    , map: (post, tag) => 
                    {
                        post.Tags.Add(tag);
                        return post;
                    }
                    , splitOn: "tagid"
                    , commandType: System.Data.CommandType.Text);

                retorno = posts.GroupBy(p => p.PostId).Select(g =>
                {
                    var groupedPost = g.First();
                    groupedPost.Tags = g.Select(p => p.Tags.Single()).ToList();
                    return groupedPost;
                });
            }

            return retorno;
        }

        public IEnumerable<Post> ObterQueryMultipleRelationships()
        {
            IEnumerable<Post> retorno = null;

            var sql = @"	
            select	p.postid
			        , p.headline
                    , a.authorid 'authorid'
			        , firstname
			        , lastname
			        , t.tagid 'tagid'
			        , tagname
	        from post p 
	        inner join author a on p.authorid = a.authorid
	        inner join posttags pt on pt.postid = p.postid
	        inner join tag t on t.tagid = pt.tagid
            order by p.postid";

            using (var db = _dbContext.GetConnection())
            {
                var posts = db.Query<Post, Author, Tag, Post>(
                    sql
                    , map: (post, author, tag) => {
                        post.Author = author;
                        post.Tags.Add(tag);
                        return post;
                    }
                    , splitOn: "postid, authorid, tagid");

                retorno = posts.GroupBy(p => p.PostId).Select(g =>
                {
                    var groupedPost = g.First();
                    groupedPost.Tags = g.Select(p => p.Tags.Single()).ToList();
                    return groupedPost;
                });
            }

            return retorno;
        }
    }
}

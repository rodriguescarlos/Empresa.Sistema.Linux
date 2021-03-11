using Empresa.Sistema.Infra.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Domain.Entidade
{
    public class Post : EntityBase
    {
        private List<Tag> _tags = new List<Tag>();

        public int PostId { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public Author Author { get; set; }
        
        public DateTime DateCeated { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<Tag> Tags {
            get { return _tags; } 
            set { _tags = value; } 
        }
    }
}

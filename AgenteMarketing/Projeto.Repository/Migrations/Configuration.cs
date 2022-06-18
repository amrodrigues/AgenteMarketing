using Projeto.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Projeto.Repository.Context.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Projeto.Repository.Context.DataContext context)
        {

        }
    }
}

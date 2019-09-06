namespace GerenciaFrota.Migrations
{
    using GerenciaFrota.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GerenciaFrota.Models.FrotaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GerenciaFrota.Models.FrotaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            List<TipoVeiculo> tipoVeiculos = new List<TipoVeiculo>();
            tipoVeiculos.Add(new TipoVeiculo { TipoVeiculoDescricao = "Caminhões" });
            tipoVeiculos.Add(new TipoVeiculo { TipoVeiculoDescricao = "Ônibus" });

            FrotaContext db = new FrotaContext();
            foreach (var item in tipoVeiculos)
            {
                db.TipoVeiculos.AddOrUpdate(item);
            }
            
    }
    }
}

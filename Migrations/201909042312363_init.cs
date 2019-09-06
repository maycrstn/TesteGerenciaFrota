namespace GerenciaFrota.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoVeiculos",
                c => new
                    {
                        IdTipoVeiculo = c.Int(nullable: false, identity: true),
                        TipoVeiculoDescricao = c.String(),
                    })
                .PrimaryKey(t => t.IdTipoVeiculo);
            
            CreateTable(
                "dbo.Veiculos",
                c => new
                    {
                        VeiculoId = c.Int(nullable: false, identity: true),
                        Chassi = c.String(),
                        NumeroPassageiros = c.Byte(nullable: false),
                        Cor = c.String(),
                        IdTipoVeiculo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VeiculoId)
                .ForeignKey("dbo.TipoVeiculos", t => t.IdTipoVeiculo, cascadeDelete: true)
                .Index(t => t.IdTipoVeiculo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veiculos", "IdTipoVeiculo", "dbo.TipoVeiculos");
            DropIndex("dbo.Veiculos", new[] { "IdTipoVeiculo" });
            DropTable("dbo.Veiculos");
            DropTable("dbo.TipoVeiculos");
        }
    }
}

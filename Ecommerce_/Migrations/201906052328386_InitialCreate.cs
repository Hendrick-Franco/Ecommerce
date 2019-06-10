namespace Ecommerce_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.carrinhoproduto",
                c => new
                    {
                        carrinhoId = c.Int(nullable: false, identity: true),
                        quantidade = c.Int(nullable: false),
                        Conta_contaId = c.Int(),
                        Produto_produtoId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.carrinhoId)
                .ForeignKey("dbo.conta", t => t.Conta_contaId)
                .ForeignKey("dbo.produto", t => t.Produto_produtoId)
                .Index(t => t.Conta_contaId)
                .Index(t => t.Produto_produtoId);
            
            CreateTable(
                "dbo.conta",
                c => new
                    {
                        contaId = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        senha = c.String(),
                        nome = c.String(),
                        cpf = c.String(),
                        Cartao_pagamentoId = c.Int(),
                    })
                .PrimaryKey(t => t.contaId)
                .ForeignKey("dbo.formapagamento", t => t.Cartao_pagamentoId)
                .Index(t => t.Cartao_pagamentoId);
            
            CreateTable(
                "dbo.formapagamento",
                c => new
                    {
                        pagamentoId = c.Int(nullable: false, identity: true),
                        numero = c.String(),
                        valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.pagamentoId);
            
            CreateTable(
                "dbo.produto",
                c => new
                    {
                        produtoId = c.String(nullable: false, maxLength: 128),
                        preco = c.Double(nullable: false),
                        descricao = c.String(),
                        vitrine = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.produtoId);
            
            CreateTable(
                "dbo.endereco",
                c => new
                    {
                        cep = c.String(nullable: false, maxLength: 128),
                        rua = c.String(),
                        bairro = c.String(),
                        cidade = c.String(),
                        numeroResidencial = c.Int(nullable: false),
                        uf = c.String(),
                    })
                .PrimaryKey(t => t.cep);
            
            CreateTable(
                "dbo.venda",
                c => new
                    {
                        vendaId = c.Int(nullable: false, identity: true),
                        dataVenda = c.DateTime(nullable: false),
                        vlrTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.vendaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.carrinhoproduto", "Produto_produtoId", "dbo.produto");
            DropForeignKey("dbo.carrinhoproduto", "Conta_contaId", "dbo.conta");
            DropForeignKey("dbo.conta", "Cartao_pagamentoId", "dbo.formapagamento");
            DropIndex("dbo.conta", new[] { "Cartao_pagamentoId" });
            DropIndex("dbo.carrinhoproduto", new[] { "Produto_produtoId" });
            DropIndex("dbo.carrinhoproduto", new[] { "Conta_contaId" });
            DropTable("dbo.venda");
            DropTable("dbo.endereco");
            DropTable("dbo.produto");
            DropTable("dbo.formapagamento");
            DropTable("dbo.conta");
            DropTable("dbo.carrinhoproduto");
        }
    }
}

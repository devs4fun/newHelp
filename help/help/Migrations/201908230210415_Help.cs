namespace help.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Help : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Sobrenome = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 32),
                        Status = c.Boolean(nullable: false),
                        DataDeCadastro = c.DateTime(nullable: false),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
        }
    }
}

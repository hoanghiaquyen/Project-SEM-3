namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        Detail = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 250, fixedLength: true),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        ParentID = c.Long(),
                        DisplayOrder = c.Int(),
                        SeoTitle = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 250, fixedLength: true),
                        Status = c.Boolean(),
                        ShowOnHome = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(storeType: "ntext"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 500),
                        Images = c.String(maxLength: 250),
                        CategoryID = c.Long(),
                        Detail = c.String(storeType: "ntext"),
                        Warranty = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 250, fixedLength: true),
                        Status = c.Boolean(nullable: false),
                        TopHot = c.DateTime(),
                        ViewCount = c.Int(),
                        Tags = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContentTag",
                c => new
                    {
                        ContentId = c.Long(nullable: false),
                        TagId = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.ContentId, t.TagId });
            
            CreateTable(
                "dbo.Credential",
                c => new
                    {
                        UserGroupId = c.String(nullable: false, maxLength: 20),
                        RoleID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserGroupId);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Content = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, unicode: false),
                        Content = c.String(storeType: "ntext"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Icons = c.String(maxLength: 50),
                        Text = c.String(maxLength: 50),
                        Link = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
                        Target = c.String(maxLength: 50),
                        Status = c.Boolean(),
                        TypeID = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuType",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ProductId = c.Long(nullable: false),
                        OrderId = c.Long(nullable: false),
                        Quantity = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => new { t.ProductId, t.OrderId });
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedDate = c.DateTime(),
                        CustomerId = c.Long(),
                        ShipName = c.String(maxLength: 50),
                        ShipMobile = c.String(maxLength: 50, unicode: false),
                        ShipAddress = c.String(maxLength: 50),
                        ShipEmail = c.String(maxLength: 50),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        ParentID = c.Long(),
                        DisplayOrder = c.Int(),
                        SeoTitle = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 250, fixedLength: true),
                        Status = c.Boolean(),
                        ShowOnHome = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Code = c.String(maxLength: 10, unicode: false),
                        MetaTitle = c.String(maxLength: 250, unicode: false),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        MoreImages = c.String(storeType: "xml"),
                        Price = c.Decimal(precision: 18, scale: 0),
                        PromotionPrice = c.Decimal(precision: 18, scale: 0),
                        IncludedVAT = c.Boolean(),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Long(),
                        Detail = c.String(storeType: "ntext"),
                        Warranty = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 250, fixedLength: true),
                        Status = c.Boolean(),
                        TopHot = c.DateTime(),
                        ViewCount = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
                        Link = c.String(maxLength: 250),
                        Description = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50, unicode: false),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemConfig",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(maxLength: 50),
                        Type = c.String(maxLength: 50, unicode: false),
                        Value = c.String(maxLength: 250),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Tag");
            DropTable("dbo.SystemConfig");
            DropTable("dbo.Slide");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Role");
            DropTable("dbo.Product");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Order");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.MenuType");
            DropTable("dbo.Menu");
            DropTable("dbo.Footer");
            DropTable("dbo.Feedback");
            DropTable("dbo.Credential");
            DropTable("dbo.ContentTag");
            DropTable("dbo.Content");
            DropTable("dbo.Contact");
            DropTable("dbo.Category");
            DropTable("dbo.About");
        }
    }
}

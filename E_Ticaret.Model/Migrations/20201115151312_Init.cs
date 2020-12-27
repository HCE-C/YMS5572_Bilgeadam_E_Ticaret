using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Ticaret.Model.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Slug = table.Column<string>(maxLength: 65535, nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: false),
                    Sku = table.Column<string>(maxLength: 255, nullable: false),
                    Barcode = table.Column<string>(maxLength: 255, nullable: true),
                    Price1 = table.Column<decimal>(nullable: false),
                    Warranty = table.Column<int>(nullable: false),
                    Tax = table.Column<int>(nullable: false),
                    StockAmount = table.Column<decimal>(nullable: false),
                    VolumetricWeight = table.Column<decimal>(nullable: false),
                    BuyingPrice = table.Column<decimal>(nullable: false),
                    StockTypeLabel = table.Column<string>(nullable: true),
                    Discount = table.Column<decimal>(nullable: false),
                    DiscountType = table.Column<int>(nullable: false),
                    MoneyOrderDiscount = table.Column<decimal>(nullable: false),
                    TaxIncluded = table.Column<int>(nullable: false),
                    Distributor = table.Column<string>(maxLength: 255, nullable: true),
                    IsGifted = table.Column<int>(nullable: false),
                    Gift = table.Column<string>(maxLength: 255, nullable: true),
                    CustomShippingDisabled = table.Column<int>(nullable: false),
                    CustomShippingCost = table.Column<decimal>(nullable: false),
                    MarketPriceDetail = table.Column<string>(maxLength: 255, nullable: true),
                    MetaKeyword = table.Column<string>(maxLength: 65535, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 65535, nullable: true),
                    PageTitle = table.Column<string>(maxLength: 255, nullable: true),
                    Variant = table.Column<int>(nullable: false),
                    ShortDetails = table.Column<string>(maxLength: 255, nullable: true),
                    SearchKeyWords = table.Column<string>(maxLength: 255, nullable: true),
                    InstallmentTreshold = table.Column<string>(maxLength: 10, nullable: true),
                    HomeSortOrder = table.Column<int>(nullable: false),
                    PopularSortOrder = table.Column<int>(nullable: false),
                    BrandSortOrder = table.Column<int>(nullable: false),
                    FeaturedSortOrder = table.Column<int>(nullable: false),
                    CampaignedSortOrder = table.Column<int>(nullable: false),
                    NewSortOrder = table.Column<int>(nullable: false),
                    DiscountedSortOrder = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Product_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CartId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItemAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Value = table.Column<string>(nullable: true),
                    CartItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItemAttribute_CartItem_CartItemId",
                        column: x => x.CartItemId,
                        principalTable: "CartItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductToCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductToCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Firstname = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    SubLocation = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 65535, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    MobilePhoneNumber = table.Column<string>(maxLength: 32, nullable: false),
                    InvoiceType = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    TaxNo = table.Column<string>(maxLength: 64, nullable: true),
                    TaxOffice = table.Column<string>(maxLength: 255, nullable: true),
                    IdentityRegistrationNumber = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Predefined = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Firstname = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(maxLength: 10, nullable: false),
                    Title = table.Column<string>(maxLength: 10, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Birthdate = table.Column<string>(nullable: true),
                    Role = table.Column<string>(maxLength: 10, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: true),
                    MobilePhoneNumber = table.Column<string>(maxLength: 255, nullable: true),
                    OtherLocation = table.Column<string>(maxLength: 255, nullable: true),
                    Address = table.Column<string>(maxLength: 65535, nullable: true),
                    TaxNumber = table.Column<string>(maxLength: 255, nullable: true),
                    TcId = table.Column<string>(maxLength: 11, nullable: true),
                    MemberStatus = table.Column<int>(nullable: false),
                    LastLoginDate = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 50, nullable: true),
                    CommercialName = table.Column<string>(maxLength: 255, nullable: true),
                    TaxOffice = table.Column<string>(maxLength: 255, nullable: true),
                    LastMailSentDate = table.Column<string>(nullable: true),
                    LastIp = table.Column<string>(maxLength: 255, nullable: true),
                    GainedPointAmount = table.Column<decimal>(nullable: false),
                    SpentPonitAmount = table.Column<decimal>(nullable: false),
                    AllowedToCampaigns = table.Column<int>(nullable: false),
                    ReferredMemberGainedPointAmount = table.Column<decimal>(nullable: false),
                    District = table.Column<string>(maxLength: 255, nullable: true),
                    DeviceType = table.Column<string>(maxLength: 255, nullable: false),
                    DeviceInfo = table.Column<string>(maxLength: 65535, nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    MemberGroupId = table.Column<int>(nullable: true),
                    ReferredMemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Member_Member_ReferredMemberId",
                        column: x => x.ReferredMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Slug = table.Column<string>(maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    DistibutorCode = table.Column<string>(maxLength: 255, nullable: true),
                    Distributor = table.Column<string>(maxLength: 255, nullable: true),
                    ImageFilename = table.Column<string>(maxLength: 255, nullable: true),
                    ShowcaseContent = table.Column<string>(maxLength: 65535, nullable: true),
                    DisplayShowcaseContent = table.Column<int>(nullable: false),
                    MetaKeyWords = table.Column<string>(maxLength: 65535, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 65535, nullable: true),
                    PageTitle = table.Column<string>(maxLength: 255, nullable: true),
                    Attachment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brand_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Brand_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Slug = table.Column<string>(maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    DistributorCode = table.Column<string>(maxLength: 255, nullable: true),
                    Percent = table.Column<decimal>(nullable: false),
                    ImageFilename = table.Column<string>(maxLength: 255, nullable: true),
                    Distributor = table.Column<string>(maxLength: 128, nullable: true),
                    DisplayShowcaseContent = table.Column<int>(nullable: false),
                    ShowcaseContent = table.Column<string>(maxLength: 65535, nullable: true),
                    ShowcaseContentDisplayType = table.Column<int>(nullable: false),
                    HasChildren = table.Column<int>(nullable: false),
                    MetaKeywords = table.Column<string>(maxLength: 65535, nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 65535, nullable: true),
                    PageTitle = table.Column<string>(maxLength: 65535, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    Attachment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Label = table.Column<string>(maxLength: 50, nullable: true),
                    BuyingPrice = table.Column<decimal>(nullable: false),
                    SellingPrice = table.Column<decimal>(nullable: false),
                    Abbr = table.Column<string>(maxLength: 5, nullable: true),
                    IsPrimary = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currency_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Currency_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Currency_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MailListGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailListGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailListGroup_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MailListGroup_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    PriceIndex = table.Column<int>(nullable: false),
                    AllowedPaymentGateWays = table.Column<string>(maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberGroup_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberGroup_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemSubscription_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItemSubscription_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pimage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Filename = table.Column<string>(maxLength: 255, nullable: false),
                    Extension = table.Column<string>(nullable: false),
                    DirectoryName = table.Column<string>(maxLength: 10, nullable: true),
                    Revision = table.Column<string>(maxLength: 30, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Attachment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pimage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pimage_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pimage_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pimage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Price_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Price_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Price_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductToCountDown",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(nullable: true),
                    CreatedComputer = table.Column<string>(nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(nullable: true),
                    ModifiedComputer = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    ExpireDate = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToCountDown", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductToCountDown_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductToCountDown_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductToCountDown_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Label = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotion_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Promotion_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Region_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Code = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopToken_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopToken_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MailList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    LastMailSentDate = table.Column<string>(nullable: true),
                    MailListGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailList_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MailList_MailListGroup_MailListGroupId",
                        column: x => x.MailListGroupId,
                        principalTable: "MailListGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MailList_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    SessionId = table.Column<string>(maxLength: 255, nullable: false),
                    Locked = table.Column<int>(nullable: false),
                    PromotionId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    ShopTokenId = table.Column<int>(nullable: false),
                    ModifiedMemberCartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Member_ModifiedMemberCartId",
                        column: x => x.ModifiedMemberCartId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Promotion_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_ShopToken_ShopTokenId",
                        column: x => x.ShopTokenId,
                        principalTable: "ShopToken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    CustomerFirstname = table.Column<string>(maxLength: 255, nullable: false),
                    CustomerSurname = table.Column<string>(maxLength: 255, nullable: false),
                    CustomerEmail = table.Column<string>(maxLength: 255, nullable: false),
                    CustomerPhone = table.Column<string>(maxLength: 32, nullable: true),
                    PaymentTypeName = table.Column<string>(maxLength: 128, nullable: false),
                    PaymentProviderCode = table.Column<string>(maxLength: 128, nullable: false),
                    PaymentProviderName = table.Column<string>(maxLength: 128, nullable: false),
                    PaymentGatewayCode = table.Column<string>(maxLength: 128, nullable: false),
                    PaymentGatewayName = table.Column<string>(maxLength: 128, nullable: false),
                    BankName = table.Column<string>(maxLength: 128, nullable: true),
                    ClientIp = table.Column<string>(maxLength: 64, nullable: false),
                    UserAgent = table.Column<string>(maxLength: 255, nullable: false),
                    CurrencyRates = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CouponDiscount = table.Column<decimal>(nullable: false),
                    TaxAmount = table.Column<decimal>(nullable: false),
                    PromotionDiscount = table.Column<decimal>(nullable: false),
                    GeneralAmount = table.Column<decimal>(nullable: false),
                    ShippingAmount = table.Column<decimal>(nullable: false),
                    AdditionalServiceAmount = table.Column<decimal>(nullable: false),
                    FinalAmount = table.Column<decimal>(nullable: false),
                    SumOfGainedPoints = table.Column<decimal>(nullable: false),
                    Installment = table.Column<int>(nullable: false),
                    InstallmentRate = table.Column<decimal>(nullable: false),
                    ExtraInstallment = table.Column<int>(nullable: false),
                    TransactionId = table.Column<string>(maxLength: 255, nullable: true),
                    HasUserNote = table.Column<int>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    PaymentStatus = table.Column<int>(nullable: false),
                    ErrorMessage = table.Column<string>(maxLength: 65535, nullable: true),
                    DeviceType = table.Column<int>(nullable: false),
                    Referrer = table.Column<string>(maxLength: 65535, nullable: true),
                    InvoicePrintCount = table.Column<string>(nullable: true),
                    UseGiftPackage = table.Column<int>(nullable: false),
                    GiftNote = table.Column<string>(maxLength: 65535, nullable: true),
                    MemberGroupName = table.Column<string>(maxLength: 255, nullable: true),
                    UsePromotion = table.Column<int>(nullable: false),
                    ShippingProviderCode = table.Column<string>(maxLength: 128, nullable: true),
                    ShippingProviderName = table.Column<string>(maxLength: 128, nullable: true),
                    ShippingCompanyName = table.Column<string>(maxLength: 128, nullable: true),
                    ShippingPaymentType = table.Column<int>(nullable: false),
                    ShippingTrackingCode = table.Column<string>(maxLength: 255, nullable: true),
                    Source = table.Column<string>(maxLength: 255, nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    MailListId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_MailList_MailListId",
                        column: x => x.MailListId,
                        principalTable: "MailList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    VarKey = table.Column<string>(maxLength: 255, nullable: false),
                    VarValue = table.Column<string>(maxLength: 65535, nullable: true),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ProductName = table.Column<string>(maxLength: 255, nullable: false),
                    ProductSku = table.Column<string>(maxLength: 255, nullable: false),
                    ProductBarcode = table.Column<string>(maxLength: 255, nullable: true),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    ProductQuantity = table.Column<decimal>(nullable: false),
                    ProductTax = table.Column<int>(nullable: false),
                    ProductDiscount = table.Column<decimal>(nullable: false),
                    ProductMoneyOrderDiscount = table.Column<decimal>(nullable: false),
                    ProductWeight = table.Column<decimal>(nullable: false),
                    ProductStockTypeLabel = table.Column<int>(nullable: false),
                    IsProductPromotioned = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    OrderItemSubscriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_OrderItemSubscription_OrderItemSubscriptionId",
                        column: x => x.OrderItemSubscriptionId,
                        principalTable: "OrderItemSubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    Firstname = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    SubLocation = table.Column<string>(maxLength: 128, nullable: true),
                    Address = table.Column<string>(maxLength: 65535, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    MobilePhoneNumber = table.Column<string>(maxLength: 32, nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddress_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippingAddress_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShippingAddress_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShippingAddress_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShippingAddress_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemCustomization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedMemberId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedIp = table.Column<string>(maxLength: 64, nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ModifiedMemberId = table.Column<int>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIp = table.Column<string>(maxLength: 64, nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 250, nullable: true),
                    ProductCustomizationGroupId = table.Column<int>(nullable: false),
                    ProductCustomizationGroupName = table.Column<string>(maxLength: 255, nullable: true),
                    ProductCustomizationGroupSortOrder = table.Column<int>(nullable: false),
                    ProductCustomizationFieldId = table.Column<int>(nullable: false),
                    ProductCustomizationFieldType = table.Column<string>(maxLength: 64, nullable: true),
                    ProductCustomizationFieldName = table.Column<string>(maxLength: 255, nullable: true),
                    ProductCustomizationFieldValue = table.Column<string>(maxLength: 65535, nullable: true),
                    CartItemAttributeId = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemCustomization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemCustomization_Member_CreatedMemberId",
                        column: x => x.CreatedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItemCustomization_Member_ModifiedMemberId",
                        column: x => x.ModifiedMemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItemCustomization_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Attachment", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "DisplayShowcaseContent", "DistibutorCode", "Distributor", "ImageFilename", "MetaDescription", "MetaKeyWords", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "Name", "PageTitle", "ShowcaseContent", "Slug", "SortOrder", "Status" },
                values: new object[] { 3, null, null, null, null, null, 1, null, null, null, null, null, null, null, null, null, "Ercan Mandıra", null, null, "Apple", 1, 1 });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Abbr", "BuyingPrice", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "CurrencyId", "IsPrimary", "Label", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "SellingPrice", "Status" },
                values: new object[,]
                {
                    { 2, "TL", 1m, null, null, null, null, null, 1, "Türk Lirası", null, null, null, null, 1m, 1 },
                    { 3, "USD", 10m, null, null, null, null, null, 0, "Dolar", null, null, null, null, 9m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "Address", "AllowedToCampaigns", "Birthdate", "CommercialName", "CountryId", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "DeviceInfo", "DeviceType", "District", "Email", "Firstname", "GainedPointAmount", "Gender", "LastIp", "LastLoginDate", "LastMailSentDate", "LocationId", "MemberGroupId", "MemberStatus", "MobilePhoneNumber", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "OtherLocation", "Password", "PhoneNumber", "ReferredMemberGainedPointAmount", "ReferredMemberId", "Role", "SpentPonitAmount", "Status", "Surname", "TaxNumber", "TaxOffice", "TcId", "Title", "ZipCode" },
                values: new object[] { 1, null, 0, null, null, null, null, null, null, null, null, "Desktop", null, "can@hotmail.com", "Hüseyin", 0m, 0, null, null, null, null, null, 2, null, null, null, null, null, null, "123", null, 0m, null, null, 0m, 1, "Ercan", null, null, null, "Admin", null });

            migrationBuilder.InsertData(
                table: "MemberGroup",
                columns: new[] { "Id", "AllowedPaymentGateWays", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "Name", "PriceIndex", "Status" },
                values: new object[] { 1, "1", null, null, null, null, null, null, null, null, "Kullanıcılar", 1, 1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Attachment", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "DisplayShowcaseContent", "Distributor", "DistributorCode", "HasChildren", "ImageFilename", "MetaDescription", "MetaKeywords", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "Name", "PageTitle", "ParentId", "Percent", "ShowcaseContent", "ShowcaseContentDisplayType", "Slug", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, null, null, null, null, 1, 1, null, null, 0, "\\uploads\\11263-meyve_sebze-43b02f.jpg", null, null, null, null, null, null, "Meyve,Sebze", null, null, 1m, "1", 1, null, 1, 1 },
                    { 2, null, null, null, null, 1, 1, null, null, 0, "\\uploads\\35c329ba_c5d0_46a8_96e1_809e17f9bce1.jpeg", null, null, null, null, null, null, "Et,Tavuk,Balık", null, null, 1m, "1", 1, null, 1, 1 },
                    { 3, null, null, null, null, 1, 1, null, null, 0, "\\uploads\\33b521ee_6f2c_4f0f_b592_e8a0b5424479.jpeg", null, null, null, null, null, null, "Süt,Kahvaltılık", null, null, 1m, "1", 1, null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "Name", "Status" },
                values: new object[,]
                {
                    { 1, null, null, null, 1, null, null, null, null, "Türkiye", 1 },
                    { 2, null, null, null, 1, null, null, null, null, "Almanya", 1 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Barcode", "BrandId", "BrandSortOrder", "BuyingPrice", "CampaignedSortOrder", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "CurrencyId", "CustomShippingCost", "CustomShippingDisabled", "Discount", "DiscountType", "DiscountedSortOrder", "Distributor", "FeaturedSortOrder", "FullName", "Gift", "HomeSortOrder", "InstallmentTreshold", "IsGifted", "MarketPriceDetail", "MetaDescription", "MetaKeyword", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "MoneyOrderDiscount", "Name", "NewSortOrder", "PageTitle", "ParentId", "PopularSortOrder", "Price1", "SearchKeyWords", "ShortDetails", "Sku", "Slug", "Status", "StockAmount", "StockTypeLabel", "Tax", "TaxIncluded", "Variant", "VolumetricWeight", "Warranty" },
                values: new object[,]
                {
                    { 1, "Barcode", 3, 1, 4.99m, 1, null, null, null, 1, 2, 15m, 1, 0m, 0, 1, null, 1, "Starkin Elma", "0", 1, null, 0, null, null, null, null, null, null, null, 0m, "Elma", 1, null, null, 1, 6m, null, "1", "1234", null, 1, 2500m, null, 2, 0, 0, 1m, 1 },
                    { 29, "Barcode", 3, 1, 4.99m, 1, null, null, null, 1, 2, 15m, 1, 0m, 0, 1, null, 1, "Cherry Domates", "0", 1, null, 0, null, null, null, null, null, null, null, 0m, "Domates", 1, null, null, 1, 4.50m, null, "1", "1234", null, 1, 2500m, null, 2, 0, 0, 1m, 1 },
                    { 30, "Barcode", 3, 1, 4.99m, 1, null, null, null, 1, 2, 15m, 1, 0m, 0, 1, null, 1, "Çikita Muz", "0", 1, null, 0, null, null, null, null, null, null, null, 0m, "Muz", 1, null, null, 1, 14m, null, "1", "1234", null, 1, 2500m, null, 2, 0, 0, 1m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Promotion",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "Label", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "Status" },
                values: new object[,]
                {
                    { 1, null, null, null, 1, "Hepsi20", null, null, null, null, 1 },
                    { 2, null, null, null, 1, "Indirim15", null, null, null, null, 1 },
                    { 3, null, null, null, 1, "İndirimYOK", null, null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "Name", "Status" },
                values: new object[,]
                {
                    { 1, null, null, null, 1, null, null, null, null, "İç Anadolu", 1 },
                    { 3, null, null, null, 1, null, null, null, null, "Marmara", 1 }
                });

            migrationBuilder.InsertData(
                table: "ShopToken",
                columns: new[] { "Id", "Code", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "Status" },
                values: new object[] { 1, "1", null, null, null, 1, null, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "CountryId", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "Name", "Predefined", "RegionId", "Status" },
                values: new object[,]
                {
                    { 2, 1, null, null, null, 1, null, null, null, null, "Ankara", 0, 1, 1 },
                    { 5, 1, null, null, null, 1, null, null, null, null, "İstanbul", 0, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Pimage",
                columns: new[] { "Id", "Attachment", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "DirectoryName", "Extension", "Filename", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "ProductId", "Revision", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 7, null, null, null, null, 1, "uploads", ".jpeg", "\\uploads\\a07a9f9b_7cfb_4bb8_92b1_2ab0e53d8686.jpeg", null, null, null, null, 1, null, 1, 1 },
                    { 12, null, null, null, null, 1, "uploads", ".jpeg", "\\uploads\\b52d0061_2924_42db_ba94_5b0704a66106.jpeg", null, null, null, null, 29, null, 1, 1 },
                    { 17, null, null, null, null, 1, "uploads", ".jpeg", "\\uploads\\2d37217f_c8ca_47d5_8262_ea81d3c5528c.jpeg", null, null, null, null, 30, null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductToCategory",
                columns: new[] { "Id", "CategoryId", "CreatedComputer", "CreatedDate", "CreatedIp", "CreatedMemberId", "ModifiedComputer", "ModifiedDate", "ModifiedIp", "ModifiedMemberId", "ProductId", "SortOrder", "Status" },
                values: new object[] { 1, 1, null, null, null, 1, null, null, null, null, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddress_CountryId",
                table: "BillingAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddress_CreatedMemberId",
                table: "BillingAddress",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddress_LocationId",
                table: "BillingAddress",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddress_ModifiedMemberId",
                table: "BillingAddress",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddress_OrderId",
                table: "BillingAddress",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brand_CreatedMemberId",
                table: "Brand",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_ModifiedMemberId",
                table: "Brand",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_MemberId",
                table: "Cart",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ModifiedMemberCartId",
                table: "Cart",
                column: "ModifiedMemberCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ModifiedMemberId",
                table: "Cart",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PromotionId",
                table: "Cart",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ShopTokenId",
                table: "Cart",
                column: "ShopTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CategoryId",
                table: "CartItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CreatedMemberId",
                table: "CartItem",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ModifiedMemberId",
                table: "CartItem",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItemAttribute_CartItemId",
                table: "CartItemAttribute",
                column: "CartItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItemAttribute_CreatedMemberId",
                table: "CartItemAttribute",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItemAttribute_ModifiedMemberId",
                table: "CartItemAttribute",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CreatedMemberId",
                table: "Category",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ModifiedMemberId",
                table: "Category",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CreatedMemberId",
                table: "Country",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ModifiedMemberId",
                table: "Country",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_CreatedMemberId",
                table: "Currency",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_CurrencyId",
                table: "Currency",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_ModifiedMemberId",
                table: "Currency",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CountryId",
                table: "Location",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CreatedMemberId",
                table: "Location",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ModifiedMemberId",
                table: "Location",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_RegionId",
                table: "Location",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_MailList_CreatedMemberId",
                table: "MailList",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MailList_MailListGroupId",
                table: "MailList",
                column: "MailListGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MailList_ModifiedMemberId",
                table: "MailList",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MailListGroup_CreatedMemberId",
                table: "MailListGroup",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MailListGroup_ModifiedMemberId",
                table: "MailListGroup",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_CountryId",
                table: "Member",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_CreatedMemberId",
                table: "Member",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_LocationId",
                table: "Member",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_MemberGroupId",
                table: "Member",
                column: "MemberGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_ModifiedMemberId",
                table: "Member",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_ReferredMemberId",
                table: "Member",
                column: "ReferredMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberGroup_CreatedMemberId",
                table: "MemberGroup",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberGroup_ModifiedMemberId",
                table: "MemberGroup",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreatedMemberId",
                table: "Order",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CurrencyId",
                table: "Order",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MailListId",
                table: "Order",
                column: "MailListId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MemberId",
                table: "Order",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ModifiedMemberId",
                table: "Order",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_CreatedMemberId",
                table: "OrderDetail",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ModifiedMemberId",
                table: "OrderDetail",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CreatedMemberId",
                table: "OrderItem",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CurrencyId",
                table: "OrderItem",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ModifiedMemberId",
                table: "OrderItem",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderItemSubscriptionId",
                table: "OrderItem",
                column: "OrderItemSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemCustomization_CreatedMemberId",
                table: "OrderItemCustomization",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemCustomization_ModifiedMemberId",
                table: "OrderItemCustomization",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemCustomization_OrderItemId",
                table: "OrderItemCustomization",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemSubscription_CreatedMemberId",
                table: "OrderItemSubscription",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemSubscription_ModifiedMemberId",
                table: "OrderItemSubscription",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Pimage_CreatedMemberId",
                table: "Pimage",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Pimage_ModifiedMemberId",
                table: "Pimage",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Pimage_ProductId",
                table: "Pimage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_CreatedMemberId",
                table: "Price",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_ModifiedMemberId",
                table: "Price",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_ProductId",
                table: "Price",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedMemberId",
                table: "Product",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CurrencyId",
                table: "Product",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ModifiedMemberId",
                table: "Product",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ParentId",
                table: "Product",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToCategory_CategoryId",
                table: "ProductToCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToCategory_CreatedMemberId",
                table: "ProductToCategory",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToCategory_ModifiedMemberId",
                table: "ProductToCategory",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToCategory_ProductId",
                table: "ProductToCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToCountDown_CreatedMemberId",
                table: "ProductToCountDown",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToCountDown_ModifiedMemberId",
                table: "ProductToCountDown",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToCountDown_ProductId",
                table: "ProductToCountDown",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_CreatedMemberId",
                table: "Promotion",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_ModifiedMemberId",
                table: "Promotion",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CreatedMemberId",
                table: "Region",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_ModifiedMemberId",
                table: "Region",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_CountryId",
                table: "ShippingAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_CreatedMemberId",
                table: "ShippingAddress",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_LocationId",
                table: "ShippingAddress",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_ModifiedMemberId",
                table: "ShippingAddress",
                column: "ModifiedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_OrderId",
                table: "ShippingAddress",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopToken_CreatedMemberId",
                table: "ShopToken",
                column: "CreatedMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopToken_ModifiedMemberId",
                table: "ShopToken",
                column: "ModifiedMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Member_CreatedMemberId",
                table: "Product",
                column: "CreatedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Member_ModifiedMemberId",
                table: "Product",
                column: "ModifiedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Currency_CurrencyId",
                table: "Product",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Member_CreatedMemberId",
                table: "CartItem",
                column: "CreatedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Member_ModifiedMemberId",
                table: "CartItem",
                column: "ModifiedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Category_CategoryId",
                table: "CartItem",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItemAttribute_Member_CreatedMemberId",
                table: "CartItemAttribute",
                column: "CreatedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItemAttribute_Member_ModifiedMemberId",
                table: "CartItemAttribute",
                column: "ModifiedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToCategory_Member_CreatedMemberId",
                table: "ProductToCategory",
                column: "CreatedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToCategory_Member_ModifiedMemberId",
                table: "ProductToCategory",
                column: "ModifiedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductToCategory_Category_CategoryId",
                table: "ProductToCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddress_Country_CountryId",
                table: "BillingAddress",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddress_Member_CreatedMemberId",
                table: "BillingAddress",
                column: "CreatedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddress_Member_ModifiedMemberId",
                table: "BillingAddress",
                column: "ModifiedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddress_Location_LocationId",
                table: "BillingAddress",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddress_Order_OrderId",
                table: "BillingAddress",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Country_CountryId",
                table: "Location",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Member_CreatedMemberId",
                table: "Location",
                column: "CreatedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Member_ModifiedMemberId",
                table: "Location",
                column: "ModifiedMemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Region_RegionId",
                table: "Location",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Country_CountryId",
                table: "Member",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_MemberGroup_MemberGroupId",
                table: "Member",
                column: "MemberGroupId",
                principalTable: "MemberGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Country_CountryId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Country_CountryId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Member_CreatedMemberId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Member_ModifiedMemberId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberGroup_Member_CreatedMemberId",
                table: "MemberGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberGroup_Member_ModifiedMemberId",
                table: "MemberGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_Member_CreatedMemberId",
                table: "Region");

            migrationBuilder.DropForeignKey(
                name: "FK_Region_Member_ModifiedMemberId",
                table: "Region");

            migrationBuilder.DropTable(
                name: "BillingAddress");

            migrationBuilder.DropTable(
                name: "CartItemAttribute");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "OrderItemCustomization");

            migrationBuilder.DropTable(
                name: "Pimage");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "ProductToCategory");

            migrationBuilder.DropTable(
                name: "ProductToCountDown");

            migrationBuilder.DropTable(
                name: "ShippingAddress");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderItemSubscription");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "ShopToken");

            migrationBuilder.DropTable(
                name: "MailList");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "MailListGroup");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "MemberGroup");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}

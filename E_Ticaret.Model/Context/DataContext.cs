using E_Ticaret.Core.Map;
using E_Ticaret.Model.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using E_Ticaret.Core.Entity;
using System.Diagnostics;
using E_Ticaret.Model.Entities;
using E_Ticaret.Model.Maps;

namespace E_Ticaret.Model.Context
{
    public class DataContext : DbContext
    {
        private IHttpContextAccessor _accessor;
        public DataContext(DbContextOptions options, IHttpContextAccessor accessor)
            : base(options)
        {
            _accessor = accessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RegisterMapping(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserSeedData());
            modelBuilder.ApplyConfiguration(new PromotionSeedData());
            modelBuilder.ApplyConfiguration(new BrandSeedData());
            modelBuilder.ApplyConfiguration(new RegionSeedData());
            modelBuilder.ApplyConfiguration(new CategorySeedData());
            modelBuilder.ApplyConfiguration(new CountrySeedData());
            modelBuilder.ApplyConfiguration(new LocationSeedData());
            modelBuilder.ApplyConfiguration(new CurrencySeedData());
            modelBuilder.ApplyConfiguration(new MemberGroupSeedData());
            modelBuilder.ApplyConfiguration(new PimageSeedData());
            modelBuilder.ApplyConfiguration(new ProductSeedData());
            modelBuilder.ApplyConfiguration(new ProductToCategorySeedData());
            modelBuilder.ApplyConfiguration(new ShopTokenSeedData());

        }

        private void RegisterMapping(ModelBuilder modelBuilder)
        {
            var typeToRegister = new List<Type>();
            var dataAssembly = Assembly.GetExecutingAssembly();

            typeToRegister.AddRange(dataAssembly.DefinedTypes.Select(x => x.AsType()));

            foreach (var builderType in typeToRegister.Where(x=> typeof(IEntityBuilder).IsAssignableFrom(x)))
            {
                if (builderType != null && builderType != typeof(IEntityBuilder))
                {
                    var builder = (IEntityBuilder)Activator.CreateInstance(builderType);
                    builder.Build(modelBuilder);
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string computerName = Environment.MachineName;
            string IPaddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            DateTime date = DateTime.Now;

            foreach (var item in modifiedEntities)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            entity.ModifiedComputer = computerName;
                            entity.ModifiedDate = date;
                            entity.ModifiedIp = IPaddress;
                            entity.ModifiedMemberId = GetMemberId();
                            break;
                        case EntityState.Added:
                            entity.CreatedComputer = computerName;
                            entity.CreatedDate = date;
                            entity.CreatedIp = IPaddress;
                            entity.CreatedMemberId = GetMemberId();
                            break;
                        default:
                            break;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private int? GetMemberId()
        {
            var struserId = "";
            if (_accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = _accessor.HttpContext.User.Claims.ToList();
                struserId = claims?.FirstOrDefault(x=>x.Type.Equals("jti",StringComparison.OrdinalIgnoreCase))?.Value;
            }
            if (struserId == "" || struserId == " ")
                return null;
            return Convert.ToInt32(struserId);
        }
    }
}

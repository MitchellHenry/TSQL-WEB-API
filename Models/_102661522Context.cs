using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TSQL_WEB_API.Models
{
    public partial class _102661522Context : DbContext
    {
        public _102661522Context()
        {
        }

        public _102661522Context(DbContextOptions<_102661522Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Accountpayment1522> Accountpayment1522 { get; set; }
        public virtual DbSet<Authorisedperson1522> Authorisedperson1522 { get; set; }
        public virtual DbSet<Clientaccount1522> Clientaccount1522 { get; set; }
        public virtual DbSet<Generalledger1522> Generalledger1522 { get; set; }
        public virtual DbSet<Inventory1522> Inventory1522 { get; set; }
        public virtual DbSet<Location1522> Location1522 { get; set; }
        public virtual DbSet<Order1522> Order1522 { get; set; }
        public virtual DbSet<Orderline1522> Orderline1522 { get; set; }
        public virtual DbSet<Product1522> Product1522 { get; set; }
        public virtual DbSet<Purchaseorder1522> Purchaseorder1522 { get; set; }
        public virtual DbSet<Clientaccount1522Custom> Clientaccount1522Custom { get; set; }
        public virtual DbSet<Order1522Custom> Order1522Custom { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=db.swinswd.com;Database=102661522;User ID=102661522;Password=u&3ec40Q;Trusted_Connection=False;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "102661522");

            modelBuilder.Entity<Accountpayment1522>(entity =>
            {
                entity.HasKey(e => new { e.Accountid, e.Datetimereceived })
                    .HasName("PK_ACCOUNTPAYMENT");

                entity.ToTable("ACCOUNTPAYMENT1522");

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Datetimereceived)
                    .HasColumnName("DATETIMERECEIVED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Accountpayment1522)
                    .HasForeignKey(d => d.Accountid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTPAYMENT_ACCOUNT");
            });

            modelBuilder.Entity<Authorisedperson1522>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK_AUTHORISEDPERSON");

                entity.ToTable("AUTHORISEDPERSON1522");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("SURNAME")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Authorisedperson1522)
                    .HasForeignKey(d => d.Accountid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUTHORISEDPERSON_CLIENTACCOUNT");
            });

            modelBuilder.Entity<Clientaccount1522>(entity =>
            {
                entity.HasKey(e => e.Accountid)
                    .HasName("PK_CLIENTACCOUNT");

                entity.ToTable("CLIENTACCOUNT1522");

                entity.HasIndex(e => e.Acctname)
                    .HasName("UQ_CLENTACCOUNT_NAME")
                    .IsUnique();

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Acctname)
                    .IsRequired()
                    .HasColumnName("ACCTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Balance)
                    .HasColumnName("BALANCE")
                    .HasColumnType("money");

                entity.Property(e => e.Creditlimit)
                    .HasColumnName("CREDITLIMIT")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Generalledger1522>(entity =>
            {
                entity.HasKey(e => e.Itemid)
                    .HasName("PK_GENERALLEDGER");

                entity.ToTable("GENERALLEDGER1522");

                entity.HasIndex(e => e.Description)
                    .HasName("UQ_GENERALEDGER_DESCRIPTION")
                    .IsUnique();

                entity.Property(e => e.Itemid)
                    .HasColumnName("ITEMID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Inventory1522>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Locationid })
                    .HasName("PK_INVENTORY");

                entity.ToTable("INVENTORY1522");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Locationid)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Numinstock).HasColumnName("NUMINSTOCK");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory1522)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVENTORY_LOCATION");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory1522)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVENTORY_PRODUCT");
            });

            modelBuilder.Entity<Location1522>(entity =>
            {
                entity.HasKey(e => e.Locationid)
                    .HasName("PK_LOCATION");

                entity.ToTable("LOCATION1522");

                entity.Property(e => e.Locationid)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Locname)
                    .IsRequired()
                    .HasColumnName("LOCNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Manager)
                    .HasColumnName("MANAGER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Order1522>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK_ORDER");

                entity.ToTable("ORDER1522");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Datetimecreated)
                    .HasColumnName("DATETIMECREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datetimedispatched)
                    .HasColumnName("DATETIMEDISPATCHED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Shippingaddress)
                    .IsRequired()
                    .HasColumnName("SHIPPINGADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order1522)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_AUTHORISEDPERSON");
            });

            modelBuilder.Entity<Orderline1522>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.Productid })
                    .HasName("PK_ORDERLINE");

                entity.ToTable("ORDERLINE1522");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("decimal(3, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderline1522)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERLINE_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderline1522)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERLINE_PRODUCT");
            });

            modelBuilder.Entity<Product1522>(entity =>
            {
                entity.HasKey(e => e.Productid)
                    .HasName("PK_PRODUCT");

                entity.ToTable("PRODUCT1522");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Buyprice)
                    .HasColumnName("BUYPRICE")
                    .HasColumnType("money");

                entity.Property(e => e.Prodname)
                    .IsRequired()
                    .HasColumnName("PRODNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Sellprice)
                    .HasColumnName("SELLPRICE")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Purchaseorder1522>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Locationid, e.Datetimecreated })
                    .HasName("PK_PURCHASEORDER");

                entity.ToTable("PURCHASEORDER1522");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Locationid)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Datetimecreated)
                    .HasColumnName("DATETIMECREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Purchaseorder1522)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASEORDER_LOCATION");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Purchaseorder1522)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASEORDER_PRODUCT");
            });
            modelBuilder.Entity<Clientaccount1522Custom>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Acctname)
                    .IsRequired()
                    .HasColumnName("ACCTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Balance)
                    .HasColumnName("BALANCE")
                    .HasColumnType("money");

                entity.Property(e => e.Creditlimit)
                    .HasColumnName("CREDITLIMIT")
                    .HasColumnType("money");
                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("SURNAME")
                    .HasMaxLength(100);
            });
            modelBuilder.Entity<Order1522Custom>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Datetimecreated)
                    .HasColumnName("DATETIMECREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datetimedispatched)
                    .HasColumnName("DATETIMEDISPATCHED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Shippingaddress)
                    .IsRequired()
                    .HasColumnName("SHIPPINGADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("USERID");

               
                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("decimal(3, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("money");                  
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

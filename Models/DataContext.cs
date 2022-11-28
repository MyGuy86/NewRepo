using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestAPI.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveAdminComment> ActiveAdminComments { get; set; } = null!;
        public virtual DbSet<ActiveStorageAttachment> ActiveStorageAttachments { get; set; } = null!;
        public virtual DbSet<ActiveStorageBlob> ActiveStorageBlobs { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AdminUser> AdminUsers { get; set; } = null!;
        public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; } = null!;
        public virtual DbSet<Battery> Batteries { get; set; } = null!;
        public virtual DbSet<BlazerAudit> BlazerAudits { get; set; } = null!;
        public virtual DbSet<BlazerCheck> BlazerChecks { get; set; } = null!;
        public virtual DbSet<BlazerDashboard> BlazerDashboards { get; set; } = null!;
        public virtual DbSet<BlazerDashboardQuery> BlazerDashboardQueries { get; set; } = null!;
        public virtual DbSet<BlazerQuery> BlazerQueries { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<BuildingDetail> BuildingDetails { get; set; } = null!;
        public virtual DbSet<Column> Columns { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Elevator> Elevators { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Intervention> Interventions { get; set; } = null!;
        public virtual DbSet<Lead> Leads { get; set; } = null!;
        public virtual DbSet<Map> Maps { get; set; } = null!;
        public virtual DbSet<Quote> Quotes { get; set; } = null!;
        public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=myapp_development;user=root;password=password", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<ActiveAdminComment>(entity =>
            {
                entity.ToTable("active_admin_comments");

                entity.HasIndex(e => new { e.AuthorType, e.AuthorId }, "index_active_admin_comments_on_author_type_and_author_id");

                entity.HasIndex(e => e.Namespace, "index_active_admin_comments_on_namespace");

                entity.HasIndex(e => new { e.ResourceType, e.ResourceId }, "index_active_admin_comments_on_resource_type_and_resource_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.AuthorType).HasColumnName("author_type");

                entity.Property(e => e.Body)
                    .HasColumnType("text")
                    .HasColumnName("body");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Namespace).HasColumnName("namespace");

                entity.Property(e => e.ResourceId).HasColumnName("resource_id");

                entity.Property(e => e.ResourceType).HasColumnName("resource_type");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<ActiveStorageAttachment>(entity =>
            {
                entity.ToTable("active_storage_attachments");

                entity.HasIndex(e => e.BlobId, "index_active_storage_attachments_on_blob_id");

                entity.HasIndex(e => new { e.RecordType, e.RecordId, e.Name, e.BlobId }, "index_active_storage_attachments_uniqueness")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlobId).HasColumnName("blob_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.RecordId).HasColumnName("record_id");

                entity.Property(e => e.RecordType).HasColumnName("record_type");

                entity.HasOne(d => d.Blob)
                    .WithMany(p => p.ActiveStorageAttachments)
                    .HasForeignKey(d => d.BlobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_c3b3935057");
            });

            modelBuilder.Entity<ActiveStorageBlob>(entity =>
            {
                entity.ToTable("active_storage_blobs");

                entity.HasIndex(e => e.Key, "index_active_storage_blobs_on_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ByteSize).HasColumnName("byte_size");

                entity.Property(e => e.Checksum)
                    .HasMaxLength(255)
                    .HasColumnName("checksum");

                entity.Property(e => e.ContentType)
                    .HasMaxLength(255)
                    .HasColumnName("content_type");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Filename)
                    .HasMaxLength(255)
                    .HasColumnName("filename");

                entity.Property(e => e.Key).HasColumnName("key");

                entity.Property(e => e.Metadata)
                    .HasColumnType("text")
                    .HasColumnName("metadata");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressType)
                    .HasMaxLength(255)
                    .HasColumnName("address_type");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Entity)
                    .HasMaxLength(255)
                    .HasColumnName("entity");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.NumberAndStreet)
                    .HasMaxLength(255)
                    .HasColumnName("number_and_street");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.SuiteOrApartment)
                    .HasMaxLength(255)
                    .HasColumnName("suite_or_apartment");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.ToTable("admin_users");

                entity.HasIndex(e => e.Email, "index_admin_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken, "index_admin_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EncryptedPassword)
                    .HasMaxLength(255)
                    .HasColumnName("encrypted_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RememberCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("remember_created_at");

                entity.Property(e => e.ResetPasswordSentAt)
                    .HasColumnType("datetime")
                    .HasColumnName("reset_password_sent_at");

                entity.Property(e => e.ResetPasswordToken).HasColumnName("reset_password_token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<ArInternalMetadatum>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key).HasColumnName("key");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Battery>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId, "index_batteries_on_building_id");

                entity.HasIndex(e => e.EmployeeId, "index_batteries_on_employee_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Information).HasColumnType("text");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.OperationsCert).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_ceeeaf55f7");
            });

            modelBuilder.Entity<BlazerAudit>(entity =>
            {
                entity.ToTable("blazer_audits");

                entity.HasIndex(e => e.QueryId, "index_blazer_audits_on_query_id");

                entity.HasIndex(e => e.UserId, "index_blazer_audits_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(255)
                    .HasColumnName("data_source");

                entity.Property(e => e.QueryId).HasColumnName("query_id");

                entity.Property(e => e.Statement)
                    .HasColumnType("text")
                    .HasColumnName("statement");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<BlazerCheck>(entity =>
            {
                entity.ToTable("blazer_checks");

                entity.HasIndex(e => e.CreatorId, "index_blazer_checks_on_creator_id");

                entity.HasIndex(e => e.QueryId, "index_blazer_checks_on_query_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CheckType)
                    .HasMaxLength(255)
                    .HasColumnName("check_type");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Emails)
                    .HasColumnType("text")
                    .HasColumnName("emails");

                entity.Property(e => e.LastRunAt)
                    .HasColumnType("datetime")
                    .HasColumnName("last_run_at");

                entity.Property(e => e.Message)
                    .HasColumnType("text")
                    .HasColumnName("message");

                entity.Property(e => e.QueryId).HasColumnName("query_id");

                entity.Property(e => e.Schedule)
                    .HasMaxLength(255)
                    .HasColumnName("schedule");

                entity.Property(e => e.SlackChannels)
                    .HasColumnType("text")
                    .HasColumnName("slack_channels");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<BlazerDashboard>(entity =>
            {
                entity.ToTable("blazer_dashboards");

                entity.HasIndex(e => e.CreatorId, "index_blazer_dashboards_on_creator_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<BlazerDashboardQuery>(entity =>
            {
                entity.ToTable("blazer_dashboard_queries");

                entity.HasIndex(e => e.DashboardId, "index_blazer_dashboard_queries_on_dashboard_id");

                entity.HasIndex(e => e.QueryId, "index_blazer_dashboard_queries_on_query_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.DashboardId).HasColumnName("dashboard_id");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.QueryId).HasColumnName("query_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<BlazerQuery>(entity =>
            {
                entity.ToTable("blazer_queries");

                entity.HasIndex(e => e.CreatorId, "index_blazer_queries_on_creator_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.DataSource)
                    .HasMaxLength(255)
                    .HasColumnName("data_source");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Statement)
                    .HasColumnType("text")
                    .HasColumnName("statement");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.AddressId, "index_buildings_on_address_id");

                entity.HasIndex(e => e.CustomerId, "index_buildings_on_customer_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.EmailOfAdminOfBuilding).HasMaxLength(255);

                entity.Property(e => e.FullNameOfBuildingAdmin).HasMaxLength(255);

                entity.Property(e => e.FullNameOfTechContactForBuilding).HasMaxLength(255);

                entity.Property(e => e.TechContactEmailForBuilding).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_6dc7a885ab");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<BuildingDetail>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.BuildingId, "index_building_details_on_building_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.InformationKey).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.Value).HasMaxLength(255);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId, "index_columns_on_battery_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BatteryId).HasColumnName("battery_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Information).HasColumnType("text");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.AddressId, "index_customers_on_address_id");

                entity.HasIndex(e => e.UserId, "index_customers_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CompanyContactEmail)
                    .HasMaxLength(255)
                    .HasColumnName("CompanyContactEMail");

                entity.Property(e => e.CompanyContactPhone).HasMaxLength(255);

                entity.Property(e => e.CompanyDesc).HasColumnType("text");

                entity.Property(e => e.CompanyHqadress)
                    .HasMaxLength(255)
                    .HasColumnName("CompanyHQAdress");

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CustomerCreationDate).HasMaxLength(255);

                entity.Property(e => e.Date)
                    .HasMaxLength(255)
                    .HasColumnName("date");

                entity.Property(e => e.FullNameOfCompanyContact).HasMaxLength(255);

                entity.Property(e => e.FullNameServiceTechAuth).HasMaxLength(255);

                entity.Property(e => e.TechAuthPhoneService).HasMaxLength(255);

                entity.Property(e => e.TechManagerEmailService).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_3f9404ba26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevator>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId, "index_elevators_on_column_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Information).HasColumnType("text");

                entity.Property(e => e.InspectionCert).HasMaxLength(255);

                entity.Property(e => e.Model).HasMaxLength(255);

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId, "index_employees_on_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Intervention>(entity =>
            {
                entity.ToTable("interventions");

                entity.HasIndex(e => e.AuthorId, "index_interventions_on_author_id");

                entity.HasIndex(e => e.BatteryId, "index_interventions_on_battery_id");

                entity.HasIndex(e => e.BuildingId, "index_interventions_on_building_id");

                entity.HasIndex(e => e.ColumnId, "index_interventions_on_column_id");

                entity.HasIndex(e => e.CustomerId, "index_interventions_on_customer_id");

                entity.HasIndex(e => e.ElevatorId, "index_interventions_on_elevator_id");

                entity.HasIndex(e => e.EmployeeId, "index_interventions_on_employee_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.BatteryId).HasColumnName("battery_id");

                entity.Property(e => e.BuildingId).HasColumnName("building_id");

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.ElevatorId).HasColumnName("elevator_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.InterventionEnd)
                    .HasMaxLength(255)
                    .HasColumnName("interventionEnd");

                entity.Property(e => e.InterventionStart)
                    .HasMaxLength(255)
                    .HasColumnName("interventionStart");

                entity.Property(e => e.Report)
                    .HasMaxLength(255)
                    .HasColumnName("report");

                entity.Property(e => e.Result)
                    .HasMaxLength(255)
                    .HasColumnName("result");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.InterventionAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("fk_rails_6766059600");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_268aede6d6");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_911b4ef939");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_d05fb241b3");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_4242c0f569");

                entity.HasOne(d => d.Elevator)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.ElevatorId)
                    .HasConstraintName("fk_rails_11b5a4bd36");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.InterventionEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_rails_2e0d31b7ad");
            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttachedFile)
                    .HasColumnType("mediumblob")
                    .HasColumnName("Attached_file");

                entity.Property(e => e.BussinessName)
                    .HasMaxLength(255)
                    .HasColumnName("Bussiness_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_date");

                entity.Property(e => e.DepartmentIncharge)
                    .HasMaxLength(255)
                    .HasColumnName("Department_incharge");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FullNameOfTheContact)
                    .HasMaxLength(255)
                    .HasColumnName("Full_name_of_the_contact");

                entity.Property(e => e.Message).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.ProjectDescription)
                    .HasMaxLength(255)
                    .HasColumnName("Project_description");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("Project_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Map>(entity =>
            {
                entity.ToTable("maps");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuildingType)
                    .HasMaxLength(255)
                    .HasColumnName("building_type");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Department)
                    .HasMaxLength(255)
                    .HasColumnName("department");

                entity.Property(e => e.ElevatorPrice)
                    .HasMaxLength(255)
                    .HasColumnName("elevator_price");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FinalPrice)
                    .HasMaxLength(255)
                    .HasColumnName("final_price");

                entity.Property(e => e.InstallationFee)
                    .HasMaxLength(255)
                    .HasColumnName("installation_fee");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NumberOfApartments)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_apartments");

                entity.Property(e => e.NumberOfBasements)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_basements");

                entity.Property(e => e.NumberOfBusinesses)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_businesses");

                entity.Property(e => e.NumberOfCages)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_cages");

                entity.Property(e => e.NumberOfElevatorsNeeded)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_elevators_needed");

                entity.Property(e => e.NumberOfFloors)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_floors");

                entity.Property(e => e.NumberOfHours)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_hours");

                entity.Property(e => e.NumberOfOccupants)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_occupants");

                entity.Property(e => e.NumberOfParking)
                    .HasMaxLength(255)
                    .HasColumnName("number_of_parking");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.PricePerUnit)
                    .HasMaxLength(255)
                    .HasColumnName("price_per_unit");

                entity.Property(e => e.ProjectDescription)
                    .HasMaxLength(255)
                    .HasColumnName("project_description");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(255)
                    .HasColumnName("project_name");

                entity.Property(e => e.ServiceQuality)
                    .HasMaxLength(255)
                    .HasColumnName("service_quality");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<SchemaMigration>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken, "index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EncryptedPassword)
                    .HasMaxLength(255)
                    .HasColumnName("encrypted_password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RememberCreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("remember_created_at");

                entity.Property(e => e.ResetPasswordSentAt)
                    .HasColumnType("datetime")
                    .HasColumnName("reset_password_sent_at");

                entity.Property(e => e.ResetPasswordToken).HasColumnName("reset_password_token");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TheEviction.Entities.Models
{
    public partial class EvictionDevContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<Attorney> Attorney { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<CompanyType> CompanyType { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactType> ContactType { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<Courier> Courier { get; set; }
        public virtual DbSet<CourierDoc> CourierDoc { get; set; }
        public virtual DbSet<CourierInstructions> CourierInstructions { get; set; }
        public virtual DbSet<CourtDate> CourtDate { get; set; }
        public virtual DbSet<CourtType> CourtType { get; set; }
        public virtual DbSet<Defendant> Defendant { get; set; }
        public virtual DbSet<Eviction> Eviction { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<LeaseType> LeaseType { get; set; }
        public virtual DbSet<Matter> Matter { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<PhoneEntityType> PhoneEntityType { get; set; }
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<PropertyType> PropertyType { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'dbo.tblStaging2'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblStaging'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ClientList'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Statuslist'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.lease_typeList'. Please see the warning messages.

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer(@"Server=gm-mdv-sql2;Database=EvictionDev;Trusted_Connection=True;");
        //    }
        //}

        public EvictionDevContext(DbContextOptions<EvictionDevContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasColumnName("address_line1")
                    .HasMaxLength(128);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line2")
                    .HasMaxLength(128);

                entity.Property(e => e.AddressLine3)
                    .HasColumnName("address_line3")
                    .HasMaxLength(128);

                entity.Property(e => e.AddressTypeId).HasColumnName("address_type_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(64);

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(64);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(16);

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_address_type");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_country");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_address_state");
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.ToTable("address_type");

                entity.Property(e => e.AddressTypeId).HasColumnName("address_type_id");

                entity.Property(e => e.AddressTypeDesc)
                    .IsRequired()
                    .HasColumnName("address_type_desc")
                    .HasMaxLength(64);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Attorney>(entity =>
            {
                entity.ToTable("attorney");

                entity.Property(e => e.AttorneyId).HasColumnName("attorney_id");

                entity.Property(e => e.AttyName)
                    .IsRequired()
                    .HasColumnName("atty_name")
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(64);

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasColumnName("initials")
                    .HasMaxLength(8);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Osbnum)
                    .HasColumnName("osbnum")
                    .HasMaxLength(32);

                entity.Property(e => e.Wsbnum)
                    .HasColumnName("wsbnum")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("client_name")
                    .HasMaxLength(128);

                entity.Property(e => e.ClientNum).HasColumnName("client_num");

                entity.Property(e => e.CompanyTypeId).HasColumnName("company_type_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.CountyId).HasColumnName("county_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FacilityId).HasColumnName("facility_id");

                entity.Property(e => e.IsActiveFlg).HasColumnName("is_active_flg");

                entity.Property(e => e.IsOfficeAccessFlg).HasColumnName("is_office_access_flg");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(512);

                entity.Property(e => e.PhoneId).HasColumnName("phone_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_client_address_id");

                entity.HasOne(d => d.CompanyType)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.CompanyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_company_type_id");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_client_contact_id");

                entity.HasOne(d => d.County)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.CountyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_county_id");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.FacilityId)
                    .HasConstraintName("FK_client_facility_id");

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.PhoneId)
                    .HasConstraintName("FK_client_phone_id");
            });

            modelBuilder.Entity<CompanyType>(entity =>
            {
                entity.ToTable("company_type");

                entity.Property(e => e.CompanyTypeId).HasColumnName("company_type_id");

                entity.Property(e => e.CompanyTypeName)
                    .IsRequired()
                    .HasColumnName("company_type_name")
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasColumnName("contact_name")
                    .HasMaxLength(128);

                entity.Property(e => e.ContractTypeId).HasColumnName("contract_type_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ContractType)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.ContractTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contact_contact_type_id");
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.HasKey(e => e.ContractTypeId);

                entity.ToTable("contact_type");

                entity.Property(e => e.ContractTypeId).HasColumnName("contract_type_id");

                entity.Property(e => e.ContactTypeDesc)
                    .IsRequired()
                    .HasColumnName("contact_type_desc")
                    .HasMaxLength(16);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("country_name")
                    .HasMaxLength(32);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.ToTable("county");

                entity.Property(e => e.CountyId).HasColumnName("county_id");

                entity.Property(e => e.CountyName)
                    .IsRequired()
                    .HasColumnName("county_name")
                    .HasMaxLength(32);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.County)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_county_state_id");
            });

            modelBuilder.Entity<Courier>(entity =>
            {
                entity.ToTable("courier");

                entity.Property(e => e.CourierId).HasColumnName("courier_id");

                entity.Property(e => e.CourierName)
                    .IsRequired()
                    .HasColumnName("courier_name")
                    .HasMaxLength(64);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CourierDoc>(entity =>
            {
                entity.ToTable("courier_doc");

                entity.Property(e => e.CourierDocId).HasColumnName("courier_doc_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocName)
                    .IsRequired()
                    .HasColumnName("doc_name")
                    .HasMaxLength(128);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CourierInstructions>(entity =>
            {
                entity.ToTable("courier_instructions");

                entity.Property(e => e.CourierInstructionsId).HasColumnName("courier_instructions_id");

                entity.Property(e => e.CourierInstructions1)
                    .IsRequired()
                    .HasColumnName("courier_instructions")
                    .HasMaxLength(512);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CourtDate>(entity =>
            {
                entity.HasKey(e => e.CourtDtId);

                entity.ToTable("court_date");

                entity.Property(e => e.CourtDtId).HasColumnName("court_dt_id");

                entity.Property(e => e.CourtDt)
                    .HasColumnName("court_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.CourtTypeId).HasColumnName("court_type_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CourtType)
                    .WithMany(p => p.CourtDate)
                    .HasForeignKey(d => d.CourtTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_court_type_id");
            });

            modelBuilder.Entity<CourtType>(entity =>
            {
                entity.ToTable("court_type");

                entity.Property(e => e.CourtTypeId).HasColumnName("court_type_id");

                entity.Property(e => e.CourtTypeDesc)
                    .IsRequired()
                    .HasColumnName("court_type_desc")
                    .HasMaxLength(32);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Defendant>(entity =>
            {
                entity.ToTable("defendant");

                entity.Property(e => e.DefendantId).HasColumnName("defendant_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.DefendantFirstName)
                    .HasColumnName("defendant_first_name")
                    .HasMaxLength(64);

                entity.Property(e => e.DefendantLastName)
                    .IsRequired()
                    .HasColumnName("defendant_last_name")
                    .HasMaxLength(128);

                entity.Property(e => e.DefendantSsn)
                    .HasColumnName("defendant_ssn")
                    .HasMaxLength(16);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneId).HasColumnName("phone_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Defendant)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_defendant_address_id");

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.Defendant)
                    .HasForeignKey(d => d.PhoneId)
                    .HasConstraintName("FK_defendant_phone_id");
            });

            modelBuilder.Entity<Eviction>(entity =>
            {
                entity.ToTable("eviction");

                entity.Property(e => e.EvictionId).HasColumnName("eviction_id");

                entity.Property(e => e.AdditionalRentBeginDt)
                    .HasColumnName("additional_rent_begin_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.AdditionalRentEndDt)
                    .HasColumnName("additional_rent_end_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Agreement)
                    .HasColumnName("agreement")
                    .HasMaxLength(1024);

                entity.Property(e => e.AttorneyId).HasColumnName("attorney_id");

                entity.Property(e => e.AttyFeeAmt)
                    .HasColumnName("atty_fee_amt")
                    .HasColumnType("money");

                entity.Property(e => e.CaseName)
                    .HasColumnName("case_name")
                    .HasMaxLength(256);

                entity.Property(e => e.CaseNum)
                    .HasColumnName("case_num")
                    .HasMaxLength(64);

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CourierDocId).HasColumnName("courier_doc_id");

                entity.Property(e => e.CourierId).HasColumnName("courier_id");

                entity.Property(e => e.CourierInstructionId).HasColumnName("courier_instruction_id");

                entity.Property(e => e.CourtDtId).HasColumnName("court_dt_id");

                entity.Property(e => e.CourtroomNum)
                    .HasColumnName("courtroom_num")
                    .HasMaxLength(16);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.DefendantId).HasColumnName("defendant_id");

                entity.Property(e => e.DismissDt)
                    .HasColumnName("dismiss_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.EnterDt)
                    .HasColumnName("enter_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpireDt)
                    .HasColumnName("expire_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FaResetDt)
                    .HasColumnName("fa_reset_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.Is10dayPetRepeatWkToWkFlg).HasColumnName("is_10day_pet_repeat_wk_to_wk_flg");

                entity.Property(e => e.Is20dayRepeatViolationFlg).HasColumnName("is_20day_repeat_violation_flg");

                entity.Property(e => e.Is2448hrDrugAlcoholFlg).HasColumnName("is_24_48hr_drug_alcohol_flg");

                entity.Property(e => e.Is24DomesticViolenceStalkingFlg).HasColumnName("is_24_domestic_violence_stalking_flg");

                entity.Property(e => e.Is24hrOutrageousFlg).HasColumnName("is_24hr_outrageous_flg");

                entity.Property(e => e.Is3060180dayWoutCauseFlg).HasColumnName("is_30_60_180day_wout_cause_flg");

                entity.Property(e => e.Is30dWithCauseFlg).HasColumnName("is_30d_with_cause_flg");

                entity.Property(e => e.Is72144hrRentFlg).HasColumnName("is_72_144hr_rent_flg");

                entity.Property(e => e.Is7dayWkToWkFlg).HasColumnName("is_7day_wk_to_wk_flg");

                entity.Property(e => e.IsMustVacateFlg).HasColumnName("is_must_vacate_flg");

                entity.Property(e => e.IsNoNoticeFlg).HasColumnName("is_no_notice_flg");

                entity.Property(e => e.IsOtherNoticeFlg).HasColumnName("is_other_notice_flg");

                entity.Property(e => e.IsPaystayFlg).HasColumnName("is_paystay_flg");

                entity.Property(e => e.IsReciprocalSvcFlg).HasColumnName("is_reciprocal_svc_flg");

                entity.Property(e => e.IsTrialFeePaidFlg).HasColumnName("is_trial_fee_paid_flg");

                entity.Property(e => e.IsTrialFlg).HasColumnName("is_trial_flg");

                entity.Property(e => e.IssueDesc)
                    .HasColumnName("issue_desc")
                    .HasMaxLength(1024);

                entity.Property(e => e.LeaseDt)
                    .HasColumnName("lease_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeaseTypeId).HasColumnName("lease_type_id");

                entity.Property(e => e.MailingAddressId).HasColumnName("mailing_address_id");

                entity.Property(e => e.MatterId).HasColumnName("matter_id");

                entity.Property(e => e.MilitaryAffidavitNotes)
                    .HasColumnName("military_affidavit_notes")
                    .HasMaxLength(512);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.MonthlyRentAmt)
                    .HasColumnName("monthly_rent_amt")
                    .HasColumnType("money");

                entity.Property(e => e.NoNoticeDesc)
                    .HasColumnName("no_notice_desc")
                    .HasMaxLength(256);

                entity.Property(e => e.Noncompliant)
                    .HasColumnName("noncompliant")
                    .HasMaxLength(1024);

                entity.Property(e => e.NorDt)
                    .HasColumnName("nor_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(512);

                entity.Property(e => e.NoticeTypeId).HasColumnName("notice_type_id");

                entity.Property(e => e.OtherNoticeDesc)
                    .HasColumnName("other_notice_desc")
                    .HasMaxLength(256);

                entity.Property(e => e.OurCostAmt)
                    .HasColumnName("our_cost_amt")
                    .HasColumnType("money");

                entity.Property(e => e.PropertyTypeId).HasColumnName("property_type_id");

                entity.Property(e => e.ProratedDays).HasColumnName("prorated_days");

                entity.Property(e => e.ReceiveDt)
                    .HasColumnName("receive_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ServiceDt)
                    .HasColumnName("service_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WritDt)
                    .HasColumnName("writ_dt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Attorney)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.AttorneyId)
                    .HasConstraintName("FK_attorney_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_id");

                entity.HasOne(d => d.CourierDoc)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.CourierDocId)
                    .HasConstraintName("FK_courier_doc_id");

                entity.HasOne(d => d.Courier)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.CourierId)
                    .HasConstraintName("FK_courier_id");

                entity.HasOne(d => d.CourierInstruction)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.CourierInstructionId)
                    .HasConstraintName("FK_courier_instructions_id");

                entity.HasOne(d => d.CourtDt)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.CourtDtId)
                    .HasConstraintName("FK_dbo_eviction_1");

                entity.HasOne(d => d.Defendant)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.DefendantId)
                    .HasConstraintName("FK_defendant_id");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_gender_id");

                entity.HasOne(d => d.LeaseType)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.LeaseTypeId)
                    .HasConstraintName("FK_lease_type_id");

                entity.HasOne(d => d.MailingAddress)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.MailingAddressId)
                    .HasConstraintName("FK_eviction_mailing_address_id");

                entity.HasOne(d => d.Matter)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.MatterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_matter_id");

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.PropertyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_property_type_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_status_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Eviction)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_user_id");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("facility");

                entity.Property(e => e.FacilityId).HasColumnName("facility_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FacilityName)
                    .IsRequired()
                    .HasColumnName("facility_name")
                    .HasMaxLength(128);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Facility)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_facility_address_id");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Facility)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_facility_contact_id");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.GenderDesc)
                    .IsRequired()
                    .HasColumnName("gender_desc")
                    .HasMaxLength(32);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<LeaseType>(entity =>
            {
                entity.ToTable("lease_type");

                entity.Property(e => e.LeaseTypeId).HasColumnName("lease_type_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeaseTypeDesc)
                    .IsRequired()
                    .HasColumnName("lease_type_desc")
                    .HasMaxLength(64);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Matter>(entity =>
            {
                entity.ToTable("matter");

                entity.Property(e => e.MatterId).HasColumnName("matter_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientMatterNum)
                    .IsRequired()
                    .HasColumnName("client_matter_num")
                    .HasMaxLength(16);

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.MatterDesc)
                    .HasColumnName("matter_desc")
                    .HasMaxLength(256);

                entity.Property(e => e.MatterNum)
                    .IsRequired()
                    .HasColumnName("matter_num")
                    .HasMaxLength(8);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Matter)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_matter_client_id");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone");

                entity.Property(e => e.PhoneId).HasColumnName("phone_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneEntityTypeId).HasColumnName("phone_entity_type_id");

                entity.Property(e => e.PhoneExt)
                    .HasColumnName("phone_ext")
                    .HasMaxLength(8);

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasColumnName("phone_num")
                    .HasMaxLength(16);

                entity.Property(e => e.PhoneTypeId).HasColumnName("phone_type_id");

                entity.HasOne(d => d.PhoneEntityType)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.PhoneEntityTypeId)
                    .HasConstraintName("FK_phone_phone_entity_type_id");

                entity.HasOne(d => d.PhoneType)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.PhoneTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_phone_phone_type_id");
            });

            modelBuilder.Entity<PhoneEntityType>(entity =>
            {
                entity.ToTable("phone_entity_type");

                entity.Property(e => e.PhoneEntityTypeId).HasColumnName("phone_entity_type_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneEntityTypeDesc)
                    .HasColumnName("phone_entity_type_desc")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<PhoneType>(entity =>
            {
                entity.ToTable("phone_type");

                entity.Property(e => e.PhoneTypeId).HasColumnName("phone_type_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneTypeDesc)
                    .IsRequired()
                    .HasColumnName("phone_type_desc")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.ToTable("property_type");

                entity.Property(e => e.PropertyTypeId).HasColumnName("property_type_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.PropertyType1)
                    .IsRequired()
                    .HasColumnName("property_type")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.StateAbbr)
                    .IsRequired()
                    .HasColumnName("state_abbr")
                    .HasMaxLength(8);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasColumnName("state_name")
                    .HasMaxLength(32);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_country_state_id");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDt)
                    .HasColumnName("created_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDt)
                    .HasColumnName("modified_dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusDesc)
                    .IsRequired()
                    .HasColumnName("status_desc")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.GmUserId)
                    .HasColumnName("gm_user_id")
                    .HasMaxLength(8);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(64);
            });
        }
    }
}

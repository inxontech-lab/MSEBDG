using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.CampsModels.DBModels;

public partial class MsebdgcampsContext : DbContext
{
    public MsebdgcampsContext()
    {
    }

    public MsebdgcampsContext(DbContextOptions<MsebdgcampsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allergy> Allergies { get; set; }

    public virtual DbSet<ApplicationModule> ApplicationModules { get; set; }

    public virtual DbSet<Beneficiary> Beneficiaries { get; set; }

    public virtual DbSet<BeneficiaryAnswer> BeneficiaryAnswers { get; set; }

    public virtual DbSet<BeneficiaryMultiAnswer> BeneficiaryMultiAnswers { get; set; }

    public virtual DbSet<BeneficiaryQuestionAnswer> BeneficiaryQuestionAnswers { get; set; }

    public virtual DbSet<BenificieryDeclaration> BenificieryDeclarations { get; set; }

    public virtual DbSet<BenificieryGeneralHealth> BenificieryGeneralHealths { get; set; }

    public virtual DbSet<BenificieryMedicalHistory> BenificieryMedicalHistories { get; set; }

    public virtual DbSet<BenificieryRiskFactor> BenificieryRiskFactors { get; set; }

    public virtual DbSet<BloodGroup> BloodGroups { get; set; }

    public virtual DbSet<CampDetail> CampDetails { get; set; }

    public virtual DbSet<CampType> CampTypes { get; set; }

    public virtual DbSet<CampaignVolunteer> CampaignVolunteers { get; set; }

    public virtual DbSet<CountryMst> CountryMsts { get; set; }

    public virtual DbSet<DeclarationMst> DeclarationMsts { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<FemaleBenificiery> FemaleBenificieries { get; set; }

    public virtual DbSet<FemaleDonorQuestion> FemaleDonorQuestions { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<GeneralHealthQuestion> GeneralHealthQuestions { get; set; }

    public virtual DbSet<MedicalCondition> MedicalConditions { get; set; }

    public virtual DbSet<MedicalConditionCategory> MedicalConditionCategories { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<QuestionCategory> QuestionCategories { get; set; }

    public virtual DbSet<QuestionMaster> QuestionMasters { get; set; }

    public virtual DbSet<QuestionOption> QuestionOptions { get; set; }

    public virtual DbSet<RiskFactorQuestion> RiskFactorQuestions { get; set; }

    public virtual DbSet<ShahEmdadiaCommittee> ShahEmdadiaCommittees { get; set; }

    public virtual DbSet<Union> Unions { get; set; }

    public virtual DbSet<UnitCommittee> UnitCommittees { get; set; }

    public virtual DbSet<Upazila> Upazilas { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UserToAppModule> UserToAppModules { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MSEBDGCamps;Trusted_Connection=True;Integrated Security=false;User Id=sa;Password=123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.AllergyId).HasName("PK__Allergie__A49EBE425B09EDCB");

            entity.ToTable("Allergies", "master");

            entity.Property(e => e.AllergyName).HasMaxLength(100);
            entity.Property(e => e.AllergyType).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<ApplicationModule>(entity =>
        {
            entity.ToTable("ApplicationModule", "master");

            entity.Property(e => e.ModuleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Beneficiary>(entity =>
        {
            entity.ToTable("Beneficiary", "GroupCamp");

            entity.Property(e => e.Active).HasDefaultValue(1);
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Age).HasMaxLength(50);
            entity.Property(e => e.Bmi)
                .HasMaxLength(50)
                .HasColumnName("BMI");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Education).HasMaxLength(50);
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.HeightFeet).HasMaxLength(50);
            entity.Property(e => e.HeightInCm).HasMaxLength(50);
            entity.Property(e => e.HeightInch).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.MotherName).HasMaxLength(50);
            entity.Property(e => e.NationalId).HasMaxLength(50);
            entity.Property(e => e.Weight).HasMaxLength(50);
        });

        modelBuilder.Entity<BeneficiaryAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Benefici__3214EC07B292B89D");

            entity.ToTable("BeneficiaryAnswers", "trans");

            entity.Property(e => e.AnswerValue).HasMaxLength(500);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<BeneficiaryMultiAnswer>(entity =>
        {
            entity.HasKey(e => new { e.BeneficiaryId, e.QuestionId, e.OptionId }).HasName("PK__Benefici__11F454AE9ECBC179");

            entity.ToTable("BeneficiaryMultiAnswer", "Questions");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<BeneficiaryQuestionAnswer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__Benefici__D4825004F924AC13");

            entity.ToTable("BeneficiaryQuestionAnswer", "trans");

            entity.Property(e => e.AnswerNumeric).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.AnswerText).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<BenificieryDeclaration>(entity =>
        {
            entity.HasKey(e => e.DonorDeclarationId).HasName("PK__Benifici__DDFFD82379D419F8");

            entity.ToTable("BenificieryDeclaration", "GroupCamp");

            entity.Property(e => e.Remarks).HasMaxLength(200);
            entity.Property(e => e.ResponseDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<BenificieryGeneralHealth>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__DonorGen__D48250041D1FAB05");

            entity.ToTable("BenificieryGeneralHealth", "GroupCamp");

            entity.Property(e => e.AnswerValue).HasMaxLength(250);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Remarks).HasMaxLength(250);
        });

        modelBuilder.Entity<BenificieryMedicalHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__MedicalH__4D7B4ABD3C2720AD");

            entity.ToTable("BenificieryMedicalHistory", "GroupCamp");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Details).HasMaxLength(255);
            entity.Property(e => e.HasCondition).HasDefaultValue(false);
        });

        modelBuilder.Entity<BenificieryRiskFactor>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__Benifici__D482500443A06807");

            entity.ToTable("BenificieryRiskFactor", "GroupCamp");

            entity.Property(e => e.AnswerValue).HasMaxLength(250);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Remarks).HasMaxLength(250);
        });

        modelBuilder.Entity<BloodGroup>(entity =>
        {
            entity.HasKey(e => e.BloodGroupId).HasName("PK_blood_group_mst");

            entity.ToTable("BloodGroup", "master");

            entity.Property(e => e.BlodGroupNameEn).HasMaxLength(50);
            entity.Property(e => e.BloodGroupNameBn).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasColumnType("datetime");
        });

        modelBuilder.Entity<CampDetail>(entity =>
        {
            entity.ToTable("CampDetails", "trans");

            entity.Property(e => e.CampDate).HasColumnType("datetime");
            entity.Property(e => e.CampLocationBn).HasMaxLength(200);
            entity.Property(e => e.CampLocationEn).HasMaxLength(200);
            entity.Property(e => e.CampNameBn).HasMaxLength(100);
            entity.Property(e => e.CampNameEn).HasMaxLength(100);
            entity.Property(e => e.Coordinator).HasMaxLength(80);
            entity.Property(e => e.Lattitude).HasMaxLength(50);
            entity.Property(e => e.Longitude).HasMaxLength(50);
            entity.Property(e => e.Phone1).HasMaxLength(50);
            entity.Property(e => e.Phone2).HasMaxLength(50);
            entity.Property(e => e.SecommitteeId).HasColumnName("SECommitteeId");
        });

        modelBuilder.Entity<CampType>(entity =>
        {
            entity.ToTable("CampType", "master");

            entity.Property(e => e.CampTypeName).HasMaxLength(50);
        });


        modelBuilder.Entity<CampaignVolunteer>(entity =>
        {
            entity.HasKey(e => e.VolunteerId).HasName("PK_CampaignVolunteer");

            entity.ToTable("CampaignVolunteer", "GroupCamp");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(120);
            entity.Property(e => e.FatherNameBn).HasMaxLength(150);
            entity.Property(e => e.FatherNameEn).HasMaxLength(150);
            entity.Property(e => e.FullNameBn).HasMaxLength(150);
            entity.Property(e => e.FullNameEn).HasMaxLength(150);
            entity.Property(e => e.MotherNameBn).HasMaxLength(150);
            entity.Property(e => e.MotherNameEn).HasMaxLength(150);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PhotoLocation).HasMaxLength(300);
            entity.Property(e => e.PostOfficeName).HasMaxLength(120);
            entity.Property(e => e.UnitCommitteeName).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.WhatsAppNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<CountryMst>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__CountryM__10D1609FD1CDE1C0");

            entity.ToTable("CountryMst", "master");

            entity.Property(e => e.CountryName).HasMaxLength(100);
            entity.Property(e => e.DialCode).HasMaxLength(50);
            entity.Property(e => e.Iso2code)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISO2Code");
            entity.Property(e => e.Iso3code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISO3Code");
        });

        modelBuilder.Entity<DeclarationMst>(entity =>
        {
            entity.HasKey(e => e.DeclarationId).HasName("PK__Declarat__B4AA37DF1998874C");

            entity.ToTable("DeclarationMst", "master");

            entity.Property(e => e.DeclarationTextBn).HasMaxLength(500);
            entity.Property(e => e.DeclarationTextEn).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(1);
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("districts", "master");

            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BnName)
                .HasMaxLength(25)
                .HasColumnName("bn_name");
            entity.Property(e => e.DivisionId).HasColumnName("division_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lat)
                .HasMaxLength(15)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("lat");
            entity.Property(e => e.Lon)
                .HasMaxLength(15)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("lon");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("divisions", "master");

            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BnName)
                .HasMaxLength(50)
                .HasColumnName("bn_name");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .HasColumnName("url");
        });

        modelBuilder.Entity<FemaleBenificiery>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__FemaleBe__D48250048EE50F76");

            entity.ToTable("FemaleBenificiery", "GroupCamp");

            entity.Property(e => e.AnswerValue).HasMaxLength(250);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Remarks).HasMaxLength(250);
        });

        modelBuilder.Entity<FemaleDonorQuestion>(entity =>
        {
            entity.HasKey(e => e.FemaleQuestionId).HasName("PK__FemaleDo__CA5C6B5721463B47");

            entity.ToTable("FemaleDonorQuestions", "master");

            entity.Property(e => e.QuestionTextBn).HasMaxLength(250);
            entity.Property(e => e.QuestionTextEn).HasMaxLength(250);
            entity.Property(e => e.QuestionType)
                .HasMaxLength(20)
                .HasDefaultValue("YesNo");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender", "master");

            entity.Property(e => e.GenderName).HasMaxLength(50);
        });

        modelBuilder.Entity<GeneralHealthQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__GeneralH__0DC06FACA37BD99E");

            entity.ToTable("GeneralHealthQuestions", "master");

            entity.Property(e => e.QuestionTextBn).HasMaxLength(250);
            entity.Property(e => e.QuestionTextEn).HasMaxLength(250);
            entity.Property(e => e.QuestionType)
                .HasMaxLength(20)
                .HasDefaultValue("YesNo");
        });

        modelBuilder.Entity<MedicalCondition>(entity =>
        {
            entity.HasKey(e => e.ConditionId).HasName("PK__MedicalC__37F5C0CFBAA03911");

            entity.ToTable("MedicalConditions", "master");

            entity.Property(e => e.ConditionCategory).HasMaxLength(50);
            entity.Property(e => e.ConditionName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<MedicalConditionCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MedicalConditioncategory");

            entity.ToTable("MedicalConditionCategory", "master");

            entity.Property(e => e.MedicalConditionCategory1)
                .HasMaxLength(50)
                .HasColumnName("MedicalConditionCategory");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.MedicationId).HasName("PK__Medicati__62EC1AFAB0B87D1E");

            entity.ToTable("Medications", "master");

            entity.Property(e => e.MedicationName).HasMaxLength(100);
            entity.Property(e => e.Purpose).HasMaxLength(100);
        });

        modelBuilder.Entity<QuestionCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Question__19093A0BE19D4401");

            entity.ToTable("QuestionCategory", "Questions");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<QuestionMaster>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06FAC9765D4E9");

            entity.ToTable("QuestionMaster", "Questions");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.QuestionTextBn).HasMaxLength(300);
            entity.Property(e => e.QuestionTextEn).HasMaxLength(300);
            entity.Property(e => e.QuestionType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<QuestionOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__Question__92C7A1FFF35483FF");

            entity.ToTable("QuestionOption", "Questions");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.OptionText).HasMaxLength(200);
        });

        modelBuilder.Entity<RiskFactorQuestion>(entity =>
        {
            entity.HasKey(e => e.RiskFactorId).HasName("PK__RiskFact__7C28B91468A88238");

            entity.ToTable("RiskFactorQuestions", "master");

            entity.Property(e => e.QuestionTextBn).HasMaxLength(250);
            entity.Property(e => e.QuestionTextEn).HasMaxLength(250);
            entity.Property(e => e.QuestionType)
                .HasMaxLength(20)
                .HasDefaultValue("YesNo");
        });

        modelBuilder.Entity<ShahEmdadiaCommittee>(entity =>
        {
            entity.ToTable("ShahEmdadiaCommittee", "master");

            entity.Property(e => e.AddressBn).HasMaxLength(250);
            entity.Property(e => e.AddressEn).HasMaxLength(250);
            entity.Property(e => e.ContactPerson).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.SecommitteeNameBn)
                .HasMaxLength(100)
                .HasColumnName("SECommitteeNameBn");
            entity.Property(e => e.SecommitteeNameEn)
                .HasMaxLength(100)
                .HasColumnName("SECommitteeNameEn");
        });

        modelBuilder.Entity<Union>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("unions", "master");

            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BnName)
                .HasMaxLength(25)
                .HasColumnName("bn_name");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.UpazillaId).HasColumnName("upazilla_id");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .HasColumnName("url");
        });

        modelBuilder.Entity<UnitCommittee>(entity =>
        {
            entity.ToTable("UnitCommittee", "master");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.ContactPerson).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.UnitCommitteeNameBn).HasMaxLength(50);
            entity.Property(e => e.UnitCommitteeNameEn).HasMaxLength(50);
        });

        modelBuilder.Entity<Upazila>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("upazilas", "master");

            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BnName)
                .HasMaxLength(25)
                .HasColumnName("bn_name");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .HasColumnName("url");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users", "master");

            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.ToTable("UserProfile", "master");

            entity.Property(e => e.UserProfileName).HasMaxLength(50);
        });

        modelBuilder.Entity<UserToAppModule>(entity =>
        {
            entity.ToTable("UserToAppModule", "master");
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.HasKey(e => e.VaccinationId).HasName("PK__Vaccinat__46643047E4271630");

            entity.ToTable("Vaccinations", "master");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IsMandatory).HasDefaultValue(false);
            entity.Property(e => e.VaccineName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

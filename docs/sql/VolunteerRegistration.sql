-- Volunteer registry based on Google Form: https://docs.google.com/forms/d/e/1FAIpQLSfUp82KCjvwCAZhYpHBE1J5Kk1tdT65ek6GzQzgMb4g_2FW6w/viewform
-- Post office is stored as text for now because there is no master entity/table in the solution yet.
CREATE TABLE [GroupCamp].[CampaignVolunteer]
(
    [VolunteerId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FullNameEn] NVARCHAR(150) NOT NULL,
    [FullNameBn] NVARCHAR(150) NOT NULL,
    [FatherNameEn] NVARCHAR(150) NOT NULL,
    [FatherNameBn] NVARCHAR(150) NULL,
    [MotherNameEn] NVARCHAR(150) NOT NULL,
    [MotherNameBn] NVARCHAR(150) NULL,
    [GenderId] INT NOT NULL,
    [BloodGroupId] INT NOT NULL,
    [DivisionId] INT NOT NULL,
    [ZillaId] INT NOT NULL,
    [ThanaId] INT NOT NULL,
    [VillageId] INT NOT NULL,
    [PostOfficeName] NVARCHAR(120) NOT NULL,
    [PhoneNumber] NVARCHAR(20) NOT NULL,
    [WhatsAppNumber] NVARCHAR(20) NULL,
    [Email] NVARCHAR(120) NULL,
    [DateOfBirth] DATE NOT NULL,
    [UnitCommitteeName] NVARCHAR(200) NULL,
    [BloodDonationsCount] INT NOT NULL CONSTRAINT [DF_CampaignVolunteer_BloodDonationsCount] DEFAULT (0),
    [GroupingCampParticipationCount] INT NOT NULL CONSTRAINT [DF_CampaignVolunteer_GroupingCampParticipationCount] DEFAULT (0),
    [PhotoLocation] NVARCHAR(300) NULL,
    [Active] BIT NOT NULL CONSTRAINT [DF_CampaignVolunteer_Active] DEFAULT (1),
    [CreatedDate] DATETIME NOT NULL CONSTRAINT [DF_CampaignVolunteer_CreatedDate] DEFAULT (GETDATE()),
    [UpdatedDate] DATETIME NULL,
    CONSTRAINT [FK_CampaignVolunteer_Gender] FOREIGN KEY ([GenderId]) REFERENCES [master].[Gender]([Id]),
    CONSTRAINT [FK_CampaignVolunteer_BloodGroup] FOREIGN KEY ([BloodGroupId]) REFERENCES [master].[BloodGroup]([BloodGroupId])
);

CREATE INDEX [IX_CampaignVolunteer_DivisionId] ON [GroupCamp].[CampaignVolunteer]([DivisionId]);
CREATE INDEX [IX_CampaignVolunteer_ZillaId] ON [GroupCamp].[CampaignVolunteer]([ZillaId]);
CREATE INDEX [IX_CampaignVolunteer_ThanaId] ON [GroupCamp].[CampaignVolunteer]([ThanaId]);
CREATE INDEX [IX_CampaignVolunteer_VillageId] ON [GroupCamp].[CampaignVolunteer]([VillageId]);
CREATE INDEX [IX_CampaignVolunteer_PhoneNumber] ON [GroupCamp].[CampaignVolunteer]([PhoneNumber]);

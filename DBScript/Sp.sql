CREATE PROCEDURE sp_CreateTenant
    @Name NVARCHAR(100),
    @Id UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET @Id = NEWID();
    INSERT INTO Tenants (Id, Name) VALUES (@Id, @Name);
    SELECT @Id AS TenantId;
END


CREATE PROCEDURE sp_CreateUser
    @Name NVARCHAR(100),
    @Email NVARCHAR(255),
    @TenantId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Users (Name, Email, TenantId) VALUES (@Name, @Email, @TenantId);
END

CREATE PROCEDURE sp_GetUsersByTenant
    @TenantId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, Email FROM Users WHERE TenantId = @TenantId;
END


CREATE PROCEDURE sp_UpdateUser
    @Id UNIQUEIDENTIFIER,
    @Name NVARCHAR(100),
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id;
END


CREATE PROCEDURE sp_DeleteUser
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Users WHERE Id = @Id;
END

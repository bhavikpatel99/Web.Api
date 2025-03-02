CREATE TABLE Tenants (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL UNIQUE
);


CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    TenantId UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (TenantId) REFERENCES Tenants(Id) ON DELETE CASCADE
);

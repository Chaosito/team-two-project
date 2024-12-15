CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Clients" (
    "Id" uuid NOT NULL,
    "Login" text NOT NULL,
    "Password" text NOT NULL,
    "Email" text NOT NULL,
    "Name" text NOT NULL,
    "Address" text NOT NULL,
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_Clients" PRIMARY KEY ("Id")
);

CREATE TABLE "Farmer" (
    "Id" uuid NOT NULL,
    "Login" text NOT NULL,
    "Password" text NOT NULL,
    "Email" text NOT NULL,
    "Name" text NOT NULL,
    "Address" text NOT NULL,
    "UserId" uuid,
    CONSTRAINT "PK_Farmer" PRIMARY KEY ("Id")
);

CREATE TABLE "OrderStatus" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "StatusType" integer NOT NULL,
    CONSTRAINT "PK_OrderStatus" PRIMARY KEY ("Id")
);

CREATE TABLE "Products" (
    "Id" uuid NOT NULL,
    "Name" character varying(300) NOT NULL,
    "Price" numeric NOT NULL,
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_Products" PRIMARY KEY ("Id")
);

CREATE TABLE "Role" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL,
    CONSTRAINT "PK_Role" PRIMARY KEY ("Id")
);

CREATE TABLE "User" (
    "Id" uuid NOT NULL,
    "Login" text NOT NULL,
    "Password" text NOT NULL,
    "Email" text NOT NULL,
    CONSTRAINT "PK_User" PRIMARY KEY ("Id")
);

CREATE TABLE "Orders" (
    "Id" uuid NOT NULL,
    "Number" bigint NOT NULL,
    "OrderStatusId" uuid NOT NULL,
    "ClientId" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    CONSTRAINT "PK_Orders" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Orders_OrderStatus_OrderStatusId" FOREIGN KEY ("OrderStatusId") REFERENCES "OrderStatus" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Orders_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Products" ("Id") ON DELETE CASCADE
);

CREATE TABLE "UserRole" (
    "UserId" uuid NOT NULL,
    "RoleId" uuid NOT NULL,
    CONSTRAINT "PK_UserRole" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_UserRole_Role_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Role" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Clients_UserId" ON "Clients" ("UserId");

CREATE INDEX "IX_Farmer_UserId" ON "Farmer" ("UserId");

CREATE INDEX "IX_Orders_ClientId" ON "Orders" ("ClientId");

CREATE INDEX "IX_Orders_OrderStatusId" ON "Orders" ("OrderStatusId");

CREATE INDEX "IX_Orders_ProductId" ON "Orders" ("ProductId");

CREATE INDEX "IX_Products_UserId" ON "Products" ("UserId");

CREATE INDEX "IX_UserRole_RoleId" ON "UserRole" ("RoleId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240825143438_InitMigration', '8.0.8');

COMMIT;

START TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240930163007_initial', '8.0.8');

COMMIT;
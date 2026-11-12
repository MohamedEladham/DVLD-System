# DVLD System – Setup Guide

This guide explains how to set up the development environment, create and configure the database, configure the application connection, and run the DVLD System locally.

> **Project Status:** Currently Under Development.
>
> This project is intended for learning, development, and demonstration purposes. It is not a production-ready release.

## 1. Development Environment

The project was developed and tested using the following environment:

- **Operating System:** Windows
- **IDE:** Visual Studio 2022
- **Visual Studio Workload:** .NET desktop development
- **Framework:** .NET Framework 4.8 Developer Pack (Targeting Pack)
- **Database Engine:** SQL Server 2022
- **Database Management Tool:** SQL Server Management Studio (SSMS)

Runtime Requirement: .NET Framework 4.8 Runtime must be available on the machine running the application.

Visual Studio 2022 is the recommended development environment.

Other Visual Studio versions that support .NET Framework 4.8 may work, but have not been verified.

**Note:** SQL Server is the database engine, while SSMS is a separate management tool used to connect to and manage SQL Server instances.

## 2. Get the Project

1. Clone this repository or download it as a ZIP file.
2. Open the solution file (`.sln`) in Visual Studio 2022.
3. Allow Visual Studio to load all six projects.

The solution contains the following projects:

- `DVLD` – Windows Forms application.
- `DVLD_BL` – Business Logic Layer.
- `DVLD_DAL` – Data Access Layer.
- `DVLD_Infrastructure` – Infrastructure components.
- `DVLD_Models` – Application models.
- `DVLD_Shared` – Shared components.

## 3. Build the Solution

After opening the solution:

1. Select the `Debug` configuration.
2. In Solution Explorer, make sure all six projects are loaded.
3. Select **Build → Rebuild Solution**.
4. Check the Build output and Error List.

The solution should build successfully before proceeding to run the application.

## 4. Create and Initialize the Database

The database setup scripts are located in the repository's `Database` folder.

The first script creates the `DVLD2` database automatically. You do not need to create the database manually before running it.

**Required permissions for database setup:**

The SQL Server account used to execute the database scripts must have sufficient permissions to create the database, create its schema objects, and insert the required initial data.

Execute the scripts in the following order using SQL Server Management Studio (SSMS):

1. **`01_Create_DB_DVLD2_Schema.sql`**
   - Creates the `DVLD2` database.
   - Creates the database schema, including tables, relationships, constraints, and indexes.

2. **`02_SeedData.sql`**
   - Inserts the required reference and initial data.
   - Includes countries, application statuses, license classes, services, permissions, roles, and role-permission mappings.

3. **`03_CreateAdminAccount.sql`**
   - Creates the initial DVLD administrator account.
   - Review the script instructions and configure the initial administrator credentials before execution.
   - The initial administrator password must use printable ASCII characters.


**Important:**

- The initial administrator password must be at least 8 characters long and contain printable ASCII characters.
- Execute each script only after the previous script has completed successfully.
- Make sure all scripts are executed against the intended SQL Server instance.
- Do not use real or sensitive credentials in publicly shared files.

## 5. Configure the Database Connection

The application uses a connection string named `DB_DVLD2` to connect to the database.

Follow these steps:

1. Navigate to the `DVLD/DVLD` directory.
2. Locate `App.config.example`.
3. Create a copy in the same directory.
4. Rename the copied file to `App.config`.
5. Open `App.config` and update the connection string named `DB_DVLD2`.

Replace the following placeholders with your own SQL Server connection details:

- `YOUR_SERVER_NAME`
- `YOUR_SQL_USERNAME`
- `YOUR_SQL_PASSWORD`

The connection uses **SQL Server Authentication**.

**Important – Two Different Accounts:**

There are two separate authentication mechanisms in this project:

- **SQL Server Login:** Used by the application to establish a connection to the `DVLD2` database.
- **DVLD Administrator Account:** Used by a person to sign in to the DVLD application.

These accounts serve different purposes and are not interchangeable.

**Security Note:**

Use an appropriate SQL Server account with the database permissions required by the application. Avoid using the `sa` account for the application's connection.

The creation and management of SQL Server logins, authentication settings, and database permissions are the responsibility of the database administrator or the person managing the SQL Server environment.

Do not commit your actual `App.config` file or real database credentials to the repository.

## 6. Required Database Permissions

The SQL Server account configured in the application's connection string must have the database permissions required by the application's Data Access Layer (`DVLD_DAL`).

The following table summarizes the permissions identified by reviewing the current DAL implementation:

| Database Table | SELECT | INSERT | UPDATE | DELETE |
|---|:---:|:---:|:---:|:---:|
| `Applications` | Yes | Yes | — | — |
| `Persons` | Yes | Yes | Yes | — |
| `Services` | Yes | — | — | — |
| `ApplicationStatuses` | Yes | — | — | — |
| `FirstTimeLicenseApplicationDetails` | — | Yes | — | — |
| `LicenseClasses` | Yes | — | — | — |
| `Licenses` | Yes | — | — | — |
| `Permissions` | Yes | Yes | Yes | — |
| `Roles` | Yes | Yes | Yes | — |
| `UserRoles` | Yes | Yes | — | Yes |
| `RolePermissions` | Yes | Yes | — | Yes |
| `Users` | Yes | Yes | Yes | — |
| `Countries` | Yes | — | — | — |

**Important Notes:**

- These permissions are based on the SQL operations currently implemented in the Data Access Layer.

- Soft-delete and restore operations use `UPDATE`, not `DELETE`. This is why `DELETE` permission is only required for `UserRoles` and `RolePermissions`.

- Reference-data tables such as `Countries`, `Services`, `LicenseClasses`, and `ApplicationStatuses` require read access only.

- The `ArabCountries` table is not accessed by the reviewed DAL implementation and is therefore not included in the permission requirements.

- These requirements describe application runtime permissions. They do not include the database creation and schema setup permissions needed to execute the database setup scripts.

The database administrator or the person managing the SQL Server environment is responsible for granting the appropriate permissions to the SQL Server account used by the application.

The exact method of creating SQL Server logins, assigning database roles, and granting permissions depends on the target environment and its security policies.

## 7. Run the Application

After completing the database setup and connection configuration:

1. In Solution Explorer, right-click the `DVLD` project.
2. Select **Set as Startup Project**.
3. Select the `Debug` configuration.
4. Press **F5** or select **Start**.
5. Sign in using the administrator credentials created by executing `03_CreateAdminAccount.sql` in Step 4.

## 8. Troubleshooting

### Database Connection Failure

If the application cannot connect to the database:

- Verify that the SQL Server Database Engine is running.
- Check the server or instance name in `App.config`.
- Verify that SQL Server Authentication is enabled.
- Check that the SQL Server login credentials are correct.
- Confirm that the account has the database permissions required by the application.

### Database or Table Not Found

- Confirm that all three database scripts completed successfully.
- Verify that the database name is `DVLD2`.
- Check that the connection string points to the correct SQL Server instance.

### Login Failure

If you cannot sign in to the DVLD application:

- Verify the administrator username and password configured in `03_CreateAdminAccount.sql`.
- Make sure the initial administrator account was created successfully.
- Remember that the DVLD administrator credentials are different from the SQL Server login credentials.

### Build Errors

- Confirm that the .NET desktop development workload is installed.
- Verify that the .NET Framework 4.8 Developer Pack is available.
- Make sure all six projects are loaded in the solution.
- Rebuild the entire solution and review the Error List in Visual Studio.

---

**Documentation Status:** Reviewed against the current project setup and implementation.

# UCS Pyay Student Registration

A beginner-readable Windows Forms demonstration project for Visual Studio 2012, C# 5, and .NET Framework 4.5. It uses an Access 2000-2003 `.mdb` through `System.Data.OleDb`; SQL Server and SQL Express are not required.

## Requirements and first run

1. Install Visual Studio 2012 with .NET Framework 4.5 and the 32-bit Microsoft Jet 4.0 provider (normally included with Windows). The project intentionally targets **x86** so Jet works consistently.
2. Open `UCSPyayStudentRegistration.sln`, build, and press F5.
3. On first run, the program creates `Data\UCSPyayRegistration.mdb`, its tables, constraints, settings, and fictional demo records. The database password is `ucspyaydemo` and is used only for this school demonstration.
4. If the database must be reset, close the program, back up and delete the generated `.mdb`, then run again.

Demo administrator: `admin` / `Admin@123`. Only a PBKDF2 password hash and random salt are stored. Change this demo password before any non-classroom use.

Demo checks:

- First-year seat: `PYAY-2026-001` (eligible)
- Wrong-university seat: `OTHER-2026-009`
- Existing passed student roll: `PaKaPaTa-002198`

All names, NRC serials, admission entries, payment details, and accounts are fictional. This is not an official government admission database and does not transfer real money.

## Architecture

Forms call classes in `Queries`; query classes use the single connection factory in `Database/DbConnection.cs`; OleDb commands use positional `?` parameters. `Models` carry registration data, `NrcData` contains the shared region/township/type rules, and `Helpers` centralizes validation, password hashing, uploads, and CSV export.

The guided student flow is Welcome → year/eligibility check → Student → Parents → Academic → Documents → Payment → Review → Submit. Submission uses a transaction, captures the current fee permanently, creates one unique `APP-year-sequence` application number, and writes history.

The admin flow is Login → Dashboard → Applications → Details. Documents and payment are verified before approval. Correction and rejection require reasons and are distinct states. Approval runs in a serializable transaction: a first-year roll counter is incremented, the unique roll is saved, a registration code is generated, a student card record is created, and the application is finalized. Existing students keep their roll number.

The database fee is edited in System Settings. It affects only new submissions because every application/payment stores its required amount. Logo, university photo, and payment QR paths are also setting values and can be replaced without recompiling.

Rejected payments are not automatically refunded. Finance creates/reviews an eligible refund record and moves it through Pending → Approved → Processing → Completed, or marks it Not Eligible/Rejected according to the documented university policy.

Reports export an Excel-compatible UTF-8 `.csv` with headers. This avoids a NuGet dependency and opens directly in Excel 2010/2013, suitable for Visual Studio 2012.

## Important limitations

Jet/Access is file-based. Put the database on one trusted Windows computer, take backups, and do not expose it to the internet. The counter update, approval, roll allocation, and card creation are transaction-protected, but an enterprise deployment should use a server database. Uploaded files are copied under `Uploads` with generated safe names and a 5 MB limit.

The UI is constructed in readable C# instead of generated `.Designer.cs` files. This is fully supported by WinForms and prevents Visual Studio version-specific designer serialization problems; every control and event is created in the corresponding form class.

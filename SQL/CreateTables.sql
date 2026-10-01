-- Reference Access/Jet DDL. The application executes equivalent statements automatically.
-- Open the generated MDB in Access and use Create > Query Design > SQL View for individual statements.
CREATE TABLE Example_Only (Id AUTOINCREMENT PRIMARY KEY, Name TEXT(100) NOT NULL);
-- The authoritative schema is Database/DatabaseInitializer.cs because Access does not execute
-- a multi-statement SQL script as one batch.

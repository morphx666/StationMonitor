-- ================================
-- Create User-defined Table Type
-- ================================
USE fpdata
GO

-- Create the data type
CREATE TYPE dbo.CapturedHashes AS TABLE 
(
	id int IDENTITY NOT NULL, 
	Hash int  NOT NULL, 
    PRIMARY KEY (id)
)
GO

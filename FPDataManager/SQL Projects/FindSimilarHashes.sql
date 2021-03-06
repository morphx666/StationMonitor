USE [fpdata]
GO
/****** Object:  StoredProcedure [dbo].[FindSimilarHashes]    Script Date: 04/18/2013 18:30:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xavier Flix
-- Create date: 3/ 1/2012
-- Version 2.0: 4/19/2013
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[FindSimilarHashes] 
	-- Add the parameters for the stored procedure here
	@testHash int,
	@threshold int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT * INTO #Matches FROM (
		SELECT TrackID, MIN(ErrorLevel) AS ErrorLevel, Position
		FROM SubFingerprints WITH (NOLOCK)
				CROSS APPLY (
					SELECT ErrorLevel = dbo.HammingDistance(Hash, @testHash)
				) DistanceCalculation
		WHERE ErrorLevel <= @threshold
		GROUP BY TrackID, ErrorLevel, Position
	) Results

	SELECT TrackID, ErrorLevel, Position FROM #Matches
		WHERE #Matches.TrackID IN (
				SELECT TrackID
				FROM #Matches
				GROUP BY TrackID
				HAVING COUNT(*) = 1
			)
	ORDER BY ErrorLevel
END

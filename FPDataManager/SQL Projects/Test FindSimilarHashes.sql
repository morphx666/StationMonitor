USE fpdata

CREATE TABLE #tmp (
	TrackID int,
	ErrorLevel int,
	Position float
)

INSERT INTO #tmp EXEC dbo.FindSimilarHashes 9263930, 9

SELECT Tracks.Title, #tmp.* FROM #tmp
INNER JOIN Tracks ON #tmp.TrackID = Tracks.ID
ORDER BY ErrorLevel

DROP TABLE #tmp
USE fpdata

SELECT AVG(c) AS Fingerprints FROM 
	(
		SELECT c = COUNT(id) FROM Fingerprints GROUP BY TrackID
	) Result
	
SELECT AVG(c) AS SubFingerprints FROM 
	(
		SELECT c = COUNT(id) FROM SubFingerprints GROUP BY TrackID
	) Result
USE fpdata
SELECT  COUNT(Fingerprints.ID) AS FingerprintSize, (Artists.Name + ' - ' + Tracks.Title) AS TrackName
FROM Fingerprints
INNER JOIN Tracks ON Tracks.ID = TrackID
INNER JOIN Artists ON Artists.ID = Tracks.ArtistID
GROUP BY Artists.Name, Tracks.Title ORDER BY FingerprintSize DESC
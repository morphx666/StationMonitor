USE fpdata

DELETE FROM tmpPlayedTracks
DELETE FROM PlayedTracks

DBCC CHECKIDENT('tmpPlayedTracks', RESEED, 0)
DBCC CHECKIDENT('PlayedTracks', RESEED, 0)

USE [demo]

-- Cross Join
SELECT * FROM Ogrenci
CROSS JOIN OgrenciDanisman
ORDER BY Ogrenci.OgrenciID;
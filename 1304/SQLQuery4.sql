USE [demo]

-- Danismani olmayan ogrenciyi cektik.
SELECT * FROM Ogrenci
LEFT JOIN OgrenciDanisman
ON Ogrenci.OgrenciId = OgrenciDanisman.OgrenciID
WHERE OgrenciDanisman.OgrenciID IS NULL;
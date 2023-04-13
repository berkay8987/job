USE [demo]

-- Ayni left joinde oldugu gibi danismani olmayan ogrenciyi cektik.
SELECT * FROM OgrenciDanisman
RIGHT JOIN Ogrenci
ON OgrenciDanisman.OgrenciID=Ogrenci.OgrenciId
WHERE OgrenciDanisman.OgrenciDanismanId IS NULL;
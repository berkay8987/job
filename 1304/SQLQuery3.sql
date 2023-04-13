USE [demo]

-- Sonuç listesinde görüldüğü gibi 2 nolu öğrenci herhangi bir danışmana bağlı olmadığı için o satıra karşışık 
-- OgrenciDanisman tablosundaki kolonlar null dönmüştür. 
-- Bu alanlardan birini filtreleyerek herhangi bir danışmana atanmamış öğrencileri bulabiliriz.
SELECT * FROM 
	Ogrenci
LEFT JOIN 
	OgrenciDanisman
ON 
	Ogrenci.OgrenciId=OgrenciDanisman.OgrenciId;
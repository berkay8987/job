USE [demo]

--Öğrenci tablosu
CREATE TABLE Ogrenci(
    OgrenciId int,
    AdSoyad varchar(100)
)
--Danışman tablosu
CREATE TABLE Danisman(
    DanismanId int,
    AdSoyad varchar(100)
)
 
--Öğrenci Danışman tablosu
CREATE TABLE OgrenciDanisman(
    OgrenciDanismanId int,
    OgrenciId int,
    DanismanId int
)
 
--Ogrenci tablosuna kayıt girelim
INSERT Ogrenci VALUES(1,'Ogrenci_1')
INSERT Ogrenci VALUES(2,'Ogrenci_2')
INSERT Ogrenci VALUES(3,'Ogrenci_3')
INSERT Ogrenci VALUES(4,'Ogrenci_4')
 
--Danışman tablosuna kayıt girelim
INSERT Danisman VALUES(1,'Danisman_1')
INSERT Danisman VALUES(2,'Danisman_2')
INSERT Danisman VALUES(3,'Danisman_3')
INSERT Danisman VALUES(4,'Danisman_4')
 
--Danışmanı olan öğrenciler için kayıt girelim
--1 nolu öğrencinin danışmanı=2 nolu danışman
INSERT OgrenciDanisman VALUES(1,1,2)
--3 nolu öğrencinin danışmanı=2 nolu danışman
INSERT OgrenciDanisman VALUES(2,3,2)
--4 nolu öğrencinin danışmanı=1 nolu danışman
INSERT OgrenciDanisman VALUES(3,4,1)
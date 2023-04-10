USE [berkay]

UPDATE Customers SET Surname='Ates' WHERE Location='Hatay';
UPDATE Customers SET Surname='Su' WHERE Location='Istanbul';
UPDATE Customers SET Surname='Tahta' WHERE Location='Mersin';
UPDATE Customers SET Surname='Hava' WHERE Location='Trabzon';

UPDATE Customers SET Surname='Yabanci' WHERE Location!='Hatay' AND Location!='Trabzon' AND Location!='Mersin' AND Location!='Istanbul'

SELECT Name, Surname FROM Customers ORDER BY Surname;


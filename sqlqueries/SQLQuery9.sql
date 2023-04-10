USE  [berkay]

DELETE FROM Customers WHERE Surname='Yabanci';

SELECT CustomerID, Name, Surname FROM Customers ORDER BY Surname;
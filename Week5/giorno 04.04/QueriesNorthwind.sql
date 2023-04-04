--1) Numero totale degli ordini,
select count(*) as totOrdini
from Orders
--2) Numero totale di clienti,
select count(*) as totClienti
from Customers
--3) Numero totale di clienti che abitano a Londra,
select count(*) as totClientiInglesi
from Customers
where Customers.City='London'
--4) La media aritmetica del costo del trasporto di tutti gli ordini effettuati
select avg(Freight) as mediaOrdini
from Orders
--5) La media aritmetica del costo del trasporto dei soli ordini effettuati dal cliente “BOTTM”
select avg(Freight)as Media
from Orders as o
join Customers as c on o.CustomerID=c.CustomerID
where c.CustomerID='BOTTM'
-- 6) Totale delle spese di trasporto effettuate raggruppate per id cliente
select CustomerID, sum(Freight) as somma
from Orders
group by CustomerID
--7) Numero totale di clienti raggruppati per città di appartenenza
select City, count(ContactName) as conteggio
from Customers
group by City
--8) Totale di UnitPrice * Quantity raggruppato per ogni ordine
select OrderID, UnitPrice * Quantity
from [Order Details]

--9) Totale di UnitPrice * Quantity solo dell’ordine con id=10248
select OrderID, UnitPrice * Quantity
from [Order Details]
where OrderID='10248'
--10) Numero di prodotti censiti per ogni categoria
select distinct c.CategoryName as Categoria, COUNT(p.CategoryID)from Categories as c JOIN Products as p on c.CategoryID = p.CategoryIDgroup by c.CategoryName;
--11) Numero totale di ordini raggruppati per paese di spedizione (ShipCountry)
select ShipCountry, count(OrderID) as ordini
from Orders
group by ShipCountry
--12) La media del costo del trasporto raggruppati per paese di spedizione (ShipCountry)
select ShipCountry, avg(Freight) as media
from Orders
group by ShipCountry
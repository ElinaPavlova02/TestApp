# TestApp
/*1 запрос*/
SELECT DISTINCT s.Name
  FROM Salesperson AS s, Customer AS c
 WHERE 
   EXISTS 
     (SELECT * 
        FROM Orders AS o 
       WHERE s.ID = o.salesperson_id 
	 AND c.ID = o.cust_id)
   AND c.Name = 'Seamens';
 
 /*2 запрос*/
SELECT DISTINCT s.Name
  FROM Salesperson AS s, Customer AS c
 WHERE 
   NOT EXISTS 
     (SELECT * 
	FROM Orders AS o 
       WHERE s.ID = o.salesperson_id 
         AND c.ID = o.cust_id)
   AND c.Name = 'Seamens';
     
/*3 запрос*/
SELECT DISTINCT s.Name
  FROM Salesperson AS s 
 WHERE 
   EXISTS
     (SELECT s.ID
       WHERE 
         (SELECT COUNT(o.salesperson_id)
            FROM Orders AS o 
           WHERE s.ID = o.salesperson_id) >= 2);

/*4 запрос*/
INSERT INTO TopSales(Name, Age)
SELECT Name, Age
  FROM Salesperson s
 WHERE Salary > 100000;

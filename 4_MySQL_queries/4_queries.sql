#List the customers that have names starting with the letter 'S'
SELECT * FROM customers 
WHERE `Name` LIKE 's%' AND Is_Active=1;

#List the customers whose usernames and names are alike.
SELECT `Name`,User_Name FROM customers 
WHERE `Name`=User_Name;

#How many customers have Yahoo email address?
SELECT COUNT(`Name`) AS total_yahoo
FROM customers
WHERE Email LIKE '%@yahoo.com' AND Is_Active=1;

#List all the different email service providers that are used (in the customers.email column's data) and count the customers that have corresponding addresses. e.g.:
#	yahoo  	| 2 
#	gmail  	| 3
SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(Email,'@',-1),'.',1)AS domain,COUNT(*) AS total_users
FROM customers
GROUP BY domain;

#List the customers having usernames longer than 4 characters.
SELECT ID,`Name`,User_Name FROM customers
WHERE LENGTH(`User_Name`)>4 AND Is_Active=1;

#List the average length of usernames and passwords.
SELECT AVG(LENGTH(User_Name)) AS average_username_lenth,AVG(LENGTH(`Password`)) AS average_password_length
FROM customers;

#For each customer list the count of emails that they received.
SELECT c.ID AS customer_ID,c.`Name`,COUNT(ce.Customer_ID) AS number_of_emails
FROM customers c
LEFT JOIN customer_sent_emails ce ON ce.Customer_ID=c.ID
GROUP BY c.ID; 

#List the customers whose passwords contain at least 1 digit.
SELECT ID,`Name`,`Password` FROM customers
WHERE `Password` REGEXP '[0-9]' AND Is_Active=1;

#List the customers to whom at least two emails have been sent.
SELECT c.ID AS customer_ID,c.`Name`,COUNT(ce.Customer_ID) AS number_of_emails
FROM customers c
LEFT JOIN customer_sent_emails ce ON ce.Customer_ID=c.ID 
GROUP BY c.ID HAVING COUNT(c.ID)>=2; 

#Group the customers based on their initials and count the number of customers having each initial.
SELECT CONCAT(LEFT(`Name`,1),LEFT(SUBSTRING_INDEX(`Name`,' ',-1),1))AS initials,COUNT(*) AS initials
FROM customers
GROUP BY initials;

#List the customers whose names contain the same letter at least twice.
SELECT ID,`Name` 
FROM 
  customers
WHERE
`Name` LIKE '%a%a%' OR
`Name` LIKE '%b%b%' OR
`Name` LIKE '%c%c%' OR
`Name` LIKE '%d%d%' OR
`Name` LIKE '%e%e%' OR
`Name` LIKE '%f%f%' OR
`Name` LIKE '%g%g%' OR
`Name` LIKE '%h%h%' OR
`Name` LIKE '%i%i%' OR
`Name` LIKE '%j%j%' OR
`Name` LIKE '%k%k%' OR
`Name` LIKE '%l%l%' OR
`Name` LIKE '%m%m%' OR
`Name` LIKE '%n%n%' OR
`Name` LIKE '%o%o%' OR
`Name` LIKE '%p%p%' OR
`Name` LIKE '%q%q%' OR
`Name` LIKE '%r%r%' OR
`Name` LIKE '%s%s%' OR
`Name` LIKE '%t%t%' OR
`Name` LIKE '%u%u%' OR
`Name` LIKE '%v%v%' OR
`Name` LIKE '%w%w%' OR
`Name` LIKE '%x%x%' OR
`Name` LIKE '%y%y%' OR
`Name` LIKE '%z%z%' 
AND Is_Active=1
GROUP BY ID ASC;




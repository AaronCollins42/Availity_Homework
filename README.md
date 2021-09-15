# Availity_Homework

1. Tell me about your proudest professional achievement.

*I would say that my proudest achievement was when the person I trained at my last job was able to use the things I taught to start solving more complicated problems


2. Tell me about something you have read recently that you would recommend and why. (Can be a Github
Repo, Article, Blog, Book, etc)

*As far as professional reading materials I would probably recommend w3schools coding tutorials because I have found them to be a quick way to get comfortable with new coding languages


3. How would you explain to your grandmother what Availity does?

*Availity makes applications for medical providers and insurance companies. They do things like help providers get insurance claims through properly and handling sensitive medical data.


4. Coding exercise (using C#): You are tasked to write a checker that validates the parentheses of a LISP
code. Write a program which takes in a string as an input and returns true if all the parentheses in the
string are properly closed and nested.

*Found in LispChecker Folder

5. Coding exercise (using Angular, React, or a JavaScript framework of your choice): Healthcare providers
request to be part of the Availity system. Create a registration user interface so healthcare providers can
electronically join Availity. The following data points should be collected:
 First and Last Name
 NPI number
 Business Address
 Telephone Number
 Email address

6. Coding exercise (using C#): Availity receives enrollment files from various benefits management and
enrollment solutions (I.e. HR platforms, payroll platforms).  Most of these files are typically in EDI format. 
However, there are some files in CSV format.  For the files in CSV format, write a program that will read
the content of the file and separate enrollees by insurance company in its own file. Additionally, sort the
contents of each file by last and first name (ascending).  Lastly, if there are duplicate User Ids for the
same Insurance Company, then only the record with the highest version should be included. The
following data points are included in the file:
 User Id (string)
 First and Last Name (string)
 Version (integer)
 Insurance Company (string)

7. This database diagram is to be used for the questions that follow:
Customer
PKCustID
FirstName
LastName

Order
PKOrderID
FK1CustomerID
OrderDate

OrderLine
PKOrderLineID
FK1OrdID
ItemName
Cost
Quantity

a. Write a SQL query that will produce a reverse-sorted list (alphabetically by name) of customers (first
and last names) whose last name begins with the letter ‘S.’

© Availity, LLC, all rights reserved. | Confidential and proprietary.
Page 2 of 2 | Updated 9/14/2021
b. Write a SQL query that will show the total value of all orders each customer has placed in the past
six months. Any customer without any orders should show a $0 value.
c. Amend the query from the previous question to only show those customers who have a total order
value of more than $100 and less than $500 in the past six months.
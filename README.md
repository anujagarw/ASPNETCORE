# ASPNETCORE

# Lab1: Routing and Navigation
Create an Empty ASP.NET Core MVC app. 
Create two modules one for Admin and one for User using Areas.
Admin module will have three pages – Login, dashboard and profile. Create a separate layout for admin pages having a navigation menu for the pages.
After providing login details (username and password) admin will navigate to the admin dashboard
The user module will have three pages – dashboard and profile. Create a separate layout for user pages having a navigation menu for the pages.
After providing login details (username and password) user will navigate to the user dashboard
Use attribute routing to define the routes for Admin and User modules.

Note – Don’t use any database, just pass username and password and do navigation.

# Lab2: ViewComponents and Data Passing

- Create an Article page for displaying the article
- Show the article comments using nested components.
- Add the option to add comments 
- Show the comments count at the parent component level.

Note: Use a JavaScript object for the article with a comments array

# Lab3: Forms and Validations
- Create a User Registration form with the following fields and validations.

Name: Required
Username: Required, MinLength(3)
Email: Required, Email
Password: Required with (1 Uppercase, 1 Number, 1 Special Char and 1 Lowercase Char), Min Length (8 Chars)
ConfirmPassword: Required, Compare
Contact: Regular Expression
Gender: Required (Radio Button)
Accept Terms: Required (Check Box)

Note: Use Bootstrap For UI and Error Messages


25-Sep-22

# Lab4: EF Core
Suppose you have two entities – Department and Employee, where the Department entity has mandatory properties DeptId, Name and navigation property Employees; and the Employee entity has mandatory properties EmpId, Name, Address, DeptId, ImagePath and navigation property Department. Now do the following tasks:

Define database mapping with the help of the EF code first approach.
Create a database using EF code first migration.
Create CRUD operations for Department.
Create CRUD operations for Employees. Here, you have to add and edit employees based on department.
Show Error messages while performing CRUD operations.
Here, uploads the employee image in the upload folder of the project and saves its path in a database for accessing it.
Please add confirm box before deleting a record.

# Lab5: Cascading Dropdown List
- Create a Dropdown List of Countries
- Create another dropdown list for Cities where data will come based on the country

Note: Use a JSON file for the Country and City Database. Use jQuery Ajax

# Lab6: Listing, Paging and Sorting - done
- Create a List of Products
- Add Paging, Sorting Features
- Add Search Functionality

# Lab7: Creating a Shopping Cart
- Create a Home Page for Listing Products
- Each Product will have the Option Add To Cart
- Create a Shopping Cart page with Edit, Delete Functionality

Note: Use jQuery and Bootstrap UI

# Lab8: CRUD Operations Using ADO.NET and ASP.NET Core MVC6 - Done
- CREATE
- UPDATE
-DELETE
-RETRIEVE
-Calling Sps

# Lab9: CRUD Operations Using Dapper and ASP.NET Core MVC6 - done
- CREATE
- UPDATE
-DELETE
-RETRIEVE
-Calling Sps


EF Core Power Tools- Reverse Engineering

# MyShop
 A simple web shop created with MVC.<br />
<img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/Paradonized/MyShop?style=plastic">

## Deployment
In order to make the project run properly, you will need a database (MS SQL Server). Then, you need to edit `UseSqlServer(...)` in Data, MyShopDbContext. There you need to change the name of the server with your server name and the name of the database (optional). Then, you need to migrate the migration to the server. We use code first approach.

It's recomended to delete the `Migration` folder in Data. Then, in Package Manager Console you need to select Data as Default project and run the command that will generate the migrations.
```bash
  Add-Migration Initial -context MyShopDbContext
```

After the successful creation of the migration you need to create the database. This happens when you run the command below in Package Manager Console while Data is selected as a Default project. Every time you need to update the database, you also run this command the same way.
```bash
  Update-database -context MyShopDbContext
```

## Features
* Identification system (made with ASP.NET Core Identity).
* standard CRUD functions for products.

## Screenshots

![Index screen](https://user-images.githubusercontent.com/85744016/175287072-b363f58c-70ff-4acf-af47-b99698328eb5.png)
![Add product screen](https://user-images.githubusercontent.com/85744016/175287318-0ab4de96-16dc-4839-b760-276aa6670a37.png)
![View product screen](https://user-images.githubusercontent.com/85744016/175287407-d4961de6-b785-45d2-aafe-6e47aba3084c.png)
![Delete product screen](https://user-images.githubusercontent.com/85744016/175287618-9f4a69ff-d45c-4b9a-b35e-52c751144d6a.png)
![Profile screen](https://user-images.githubusercontent.com/85744016/175287759-748afc0d-127e-4e26-8639-a57afa4a4518.png)

## Future improvements
* Adding Cart functionality.
* Adding Search and Filter functionalities.
* Possibility to upload an image instead of using links for setting an image.

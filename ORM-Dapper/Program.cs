using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Data;
using ORM_Dapper;


var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
     .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);


// create DapperDepartmentRepository object to call method
var departmentRepo = new DapperDepartmentRepository(conn);

// created variable to hold collection of departments
var departments = departmentRepo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine($"Department ID: {department.DepartmentID}, {department.Name}");
}

var productRepo = new DapperProductRepository(conn);

//creates product
productRepo.CreateProduct("newStuff", 199, 1);

//deletes product
//productRepo.DeleteProduct(942);

var products = productRepo.GetAllProducts();

foreach (var item in products)
{
    Console.WriteLine($"{item.ProductID} {item.Name}");
}
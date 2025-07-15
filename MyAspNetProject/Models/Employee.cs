using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAspNetProject.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }
    [Column("EmployeeName", TypeName = "varchar(100)")]
    public string Name { get; set; }
    [Required]
    [Column("EmployeeGender", TypeName = "varchar(10)")]
    public Gender Gender { get; set; }
    [Required]
    public int Age { get; set; }
    [Column("EmployeeDesignation", TypeName = "varchar(200)")]
    [Required]
    public string Designation { get; set; }
    [Required]
    public int Salary { get; set; }
    [Required]
    [Column("EmployeeMarried", TypeName = "varchar(10)")]
    public string Married { get; set; }
    [Required]
    [Column("EmployeeDescription", TypeName = "varchar(200)")]
    public string Description { get; set; }
}

public enum Gender
{
    Male,
    Female
}
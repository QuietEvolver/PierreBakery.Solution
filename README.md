<h1 align="center">
  <a href="https://www.google.com/imgres?imgurl=https%3A%2F%2Fcdn-image.travelandleisure.com%2Fsites%2Fdefault%2Ffiles%2Fstyles%2F1600x1000%2Fpublic%2F1449517667%2FNico-Osteria-XMAS1215.jpg%3Fitok%3DWAIGAVRN&imgrefurl=https%3A%2F%2Fwww.travelandleisure.com%2Fslideshows%2Fbest-restaurants-open-on-christmas&docid=XQ496gQQlk3zuM&tbnid=Svoa8v5w8ClfUM%3A&vet=10ahUKEwiJ_PjD3aHlAhXKvZ4KHQbVCwQQMwh5KAEwAQ..i&w=1600&h=1000&bih=481&biw=1286&q=best%20restaurant&ved=0ahUKEwiJ_PjD3aHlAhXKvZ4KHQbVCwQQMwh5KAEwAQ&iact=mrc&uact=8">
    Pierre's Bakery
  </a>
</h1>

<p align="center">
  <strong>Your Food, Your Way:</strong><br>
  Catalogue: PierreBakery.Solution
</p>

<p align="center">

  <a href="https://github.blog/category/community/">
    <img src="https://github.blog/wp-content/uploads/2019/01/Community@2x.png" width=100px alt="GH-Community" />
  </a>
  <a href="https://github.com/QuietEvolver/PierreBakery.Solution.git">
    <img src="https://avatars0.githubusercontent.com/u/34698193?s=40&v=4" width=100px alt="quietevolver" />
  </a>
  <a href="https://github.blog/2016-08-22-publish-your-project-documentation-with-github-pages/">
    <img src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/collections/github-pages-examples/github-pages-examples.png" width=100px alt="gh-pages" />
  </a>
</p>

<h3 align="center">

  [Epicodus](https://www.epicodus.com/)
  <span> · </span>
  [QE's GH](https://github.com/QuietEvolver/PierreBakery.Solution.git)

</h3>



- **Deployed.** a version control system used to implement development workflows; allows code deployment to application from git repositories.
- **GitHub-Pages.** the default publishing source for GitHub Pages site so site will publish automatically.
- **Docs.** See local changes in seconds; Docs (GitHub) Pages helps you share your published work; Create a /docs/index.md file on your repository's master branch.


## 🎉 Contents

- [Specifications](#-specifications)
- [Requirements](#-epicodus)
- [Documentation](#-documentation)
- [Upgrading](#-upgrading-and-contributions)
- [Open Source](#-open-source)
- [Contact](#-contact)
- [License](#-license)

## 📋 Specifications
Add functionality to update the type  
 - | Input: Cheese | Output: Cheese | 
Allow employees to enter types. 
 - | Input: Rolls: Treat Apple:Flavor | Output: Apple Rolls |
 - | Input: Danish : Treat Apple:Flavor | Output: Cheese and Apple Danish  |


## 📋 Requirements
 You may use Windows, macOS, or Linux as your development operating system, though building and running apps may be limited.
 Tools used:  
 - [ASP.Net](https://dotnet.microsoft.com/apps/aspnet)
 - [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
 - [Entity Framework 6](https://docs.microsoft.com/en-us/ef/ef6/)
 - [Entity Framework Core](https://entityframeworkcore.com/)


## 📖 Documentation

The full documentation for [GH-Pages](https://github.blog/2016-08-22-publish-your-project-documentation-with-github-pages/)

The source for the Shoppe: PierreBakery documentation and website is hosted on a separate repo: [**quietevolver**][repo-website]. The deployed version is at [**quietevolver**](https://quietevolver.github.io/PierreBakery.Solution/).

[docs]: https://github.com/QuietEvolver/PierreBakery.Solution.git
[repo-website]: https://github.com/QuietEvolver/PierreBakery.Solution.git

PierreBakery
- [MySQL](https://www.mysql.com)
    SetUp Using MySQL:
    > DROP DATABASE IF EXISTS `PierreBakery_registrar_database`;
    > CREATE DATABASE `PierreBakery_registrar_database`;
    > USE `PierreBakery_registrar_database`;

    > CREATE TABLE `employees` ( `EmployeeId` int(11) 
    > NOT NULL AUTO_INCREMENT, 
    > `Name` varchar(255) DEFAULT NULL, 
    > PRIMARY KEY (`EmployeeId`)
    > );
  
    > CREATE TABLE `flavors` (
    >   `FlavorId` int(11) NOT NULL AUTO_INCREMENT,
    >   `Description` varchar(255) DEFAULT NULL,
    >   PRIMARY KEY (`FlavorId`);
    > );


    > CREATE TABLE `treats` ( `TreatId` int(11) 
    > NOT NULL AUTO_INCREMENT, 
    > `Name` varchar(255) DEFAULT NULL, 
    > PRIMARY KEY (`TreatId`)
    > );

    > CREATE TABLE `TreatFlavor` (
    > `TreatFlavorId` int(11) NOT NULL AUTO_INCREMENT,
    > `TreatId` int(11) NOT NULL,
    > `FlavorId` int(11) NOT NULL, 
    >  foreign key  (FlavorId) REFERENCES Flavors(FlavorId),
      
    > foreign key  (TreatId) REFERENCES Treats(TreatId),
    > primary key (TreatFlavorId)
    > );

  
Regarding database Initialization: 
* drop database 
* delete contents of  Migrations folder 
 - keep the following files: 
--[Timestamp]_Initial.cs
--[Timestamp]_Initial.Designer.cs
--MyContextModelSnapshot.cs
The replacement code belongs in the last file:
using Microsoft.EntityFrameworkCore.Migrations;

namespace YourProjectFolderNameHere.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
* run in terminal: dotnet ef migrations add Initial 
After Initial is implemented, run the following to update any made changes: 
* run in terminal: dotnet ef database update
If an error occurs prior to GitCommit, the following command reverts the migration: 
* dotnet ef migrations remove

## 🚀 Upgrading and Contributions 👏

The main purpose of this repository is to continue evolving. I am grateful to the community for feedback, contributing bugfixes, and improvements.

### [Open Source PierreBakery][pierre_bakery]

You can learn more about our vision for Pierre's Bakery in the [**PierreBakery**][pierre_bakery].

[pierre_bakery]: https://github.com/facebook/react-native/wiki/PierreBakery

### Contact
| Author | GitHub | Email |
|--------|:------:|:-----:|
| quietevolver| [quietevolver](https://github.com/quietevolver) |  [quiet.evolver@gmail.com](mailto:quietevolver@gmail.com) |

## 📄 License
 MIT licensed, as found in the [LICENSE][http://www.law.uh.edu/faculty/wstreng/Leiden/LLM1ChoiceofEntityCHARTS.pdf] file.

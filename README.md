# Code First with a New Database
[Entity Framework in Depth: The Complete Guide](https://www.udemy.com/entity-framework-tutorial/)

&nbsp;
## 00 Start the project
* In VS, create a Console Application project.

&nbsp;
## 01 Install Entity Framework
* In Package Manager Console, install Entity Framework:
```
PM> install-package EntityFramework
```

&nbsp;
## 02 Add the Course class
* Start adding the Pluto model. Create the Course class.
```
public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }
        public IList<Tag> Tags { get; set; }
    }
```

&nbsp;
## 03 Add the Author class
* In Course, Author is a navigation property to the Author type.
* The Author type contains a list of Courses. In this scenario, there is a one-to-many relationship between Author and Courses.
```
public class Author
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public IList<Course> Courses {get; set; }
    }
```

&nbsp;
## 04 Add the Tag class
* There is a many-to-many relationship between Courses and Tags.
```
public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }

    }
```

&nbsp;
## 05 Add the CourseLevel enum
* Add the CourseLevel enum type.
```
public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }
```

&nbsp;
## 06 Add the PlutoContext
* Create the PlutoContext class which inherits from DbContext, by `using System.Data.Entity`.
* It contains DbSets for Courses, Authors and Tags.
```
public class PlutoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
```

&nbsp;
## 07 Specify a connectionString to the database
* In App.config, add the appropriate connectionString.
```
<connectionStrings>
    <add name="DefaultConnection" connectionString="data source=.\SQLEXPRESS; initial catalog=PlutoCodeFirst; integrated security=SSPI" providerName="System.Data.SqlClient" />
  </connectionStrings>
```
* For demonstration purposes we did not go by the convention of giving the connectionString the same name we gave to the DbContext.
We named it DefaultConnection instead, and we will edit the PlutoContext class definition by adding a constructor overload that receives a string parameter, which specifies the name of the connectionString in the configuration file.
```
public PlutoContext()
            : base("name=DefaultConnection")
        { }
```

&nbsp;
## 08 Enable migrations
* Once in the lifetime of a project, we need to enable migrations. In PM console:
```
PM> enable-migrations
Checking if the context targets an existing database...
Code First Migrations enabled for project Code First with a New Database.
```

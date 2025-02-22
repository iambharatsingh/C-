# Entity Framework 6
The goal of EF is to allow you to interact with data from relational databases using an object model that maps directly to the objects  in your application. 

## Entities
Entities are a conceptual model of a database that maps to your business domain. This model is termed an entity data model (EDM). The **EDM** is a client-side set of classes that are mapped to a physical database by Entity Framework convention and configuration.

---
## DbContext Class
A DbContext instance represents a combination of the Unit Of Work and Repository patterns such that it can be used to query from a database and group together changes that will then be written back to the store as a unit.

```CSharp
using System.Data.Entity;
...
public partial class SongsDBEntities : DbContext {
    public SongsDBEntities() 
        : base() {

    } 
}
```

### Configuring Connection
#### 1. base()
```CSharp
namespace MyNameSpace.EF {
    public class MyContextClass : DbContext {
        public MyContextClass() : base() {
            
        }
    }
}
// Creates a database name MyNameSpace.EF.MyContextClass
```
#### 2. base("dbName")
```CSharp
namespace MyNameSpace {
    public class MyContextClass : DbContext {
        public MyContextClass() : base("MyDatabase") {

        }
    }
}
// Creates a database named MyDatabase
```
#### 3. Using App.config / Web.config
* If the name of the connection string matches the name of your context (either with or without namespace qualification) then it will be found by DbContext when the parameterless constructor is used.    

* If the connection string name is different from the name of your context then you can tell DbContext to use this connection in Code First mode by passing the connection string name to the DbContext constructor. 

* If Initial Catalog is specified in the connection string then it will be the database name.
```xml
<configuration>
    <connectionStrings>
        <add name="StudentDatabase" connectionString="data source=CHIRAG-DESK\SQLEXPRESS; initial catalog=studb; integrated security=true" provider="System.Data.SqlClient" />
    </connectionStrings>
</configuartion>
```
```CSharp
namespace MyNameSpace {
    public class MyContextClass : DbContext {
        public MyContextClass() : base("name=StudentDatabase") { } 
        // OR
        public MyContextClass() : base("StudentDatabase") { }   
        
    }
}
// Creates a database named StudentDatabase
```
---
## DbSet\<TEntity> Class
A DbSet represents the collection of all entities in the context, or that can be queried from the database, of a given type.
```CSharp
using System.Data.Entity;
...
public partial class SongsDBEntities : DbContext {
    // virtual so that it can be overriden if required
    public virtual DbSet<Album> Albums { get; set; }
    public virtual DbSet<Song> Songs { get; set; }
    public virtual DbSet<Artist> Artists { get; set; }
}
```

## DbContext.OnModelCreating(DbModelBuilder)
This method is called by the framework when your context is first created to build the model and its mappings in memory. You can override this method to add your own configurations.
```CSharp
using System.Data.Entity;
...
public partial class SongsDBEntities : DbContext {
    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        // Fluent API Configurations
    }
}
```
---
## Navigation Properties
In SQL Server, navigation properties are represented by foreign key relationships. To account for these foreign key relationships in EF, each class in your model contains virtual properties that connect your classes together

```CSharp
// artist can have many songs but the song can have only one artist

// Artist.cs
...
public partial class Artist {
    ...
    public virtual ICollection<Song> Songs { get; set; }
}

// Songs.cs
...
public partial class Song {
    ...
    public virtual Artist Artist { get; set; }
}
```
---
## Fluent API
Entity Framework Fluent API is used to configure domain classes to override conventions. EF Fluent API is based on a Fluent API design pattern (a.k.a Fluent Interface) where the result is formulated by method chaining.

In Entity Framework Core, the ModelBuilder class acts as a Fluent API. By using it, we can configure many different things, as it provides more configuration options than data annotation attributes.

#### Changing Default Schema
A schema in a SQL database is a collection of logical structures of data. The schema is owned by a database user and has the same name as the database user. 
```CSharp
modelBuilder.HasDefaultSchema("Admin");
```

#### Map Entity To Table
Code-First will create the database tables with the name of DbSet properties in the context class. You can change this using Fluent API.
```CSharp
modelBuilder.Entity<Artist>()
    .ToTable("ArtistInfo");
```
#### Map Entity To Multiple Tables  Using Map()
```CSharp
protected override void OnModelCreating(DbModelBuilder modelBuilder) {
modelBuilder.Entity<Inventory>()
    .HasKey(e => e.CarId)
    .Map(e => {
        e.Properties(x => new { x.CarId, x.PetName });
        e.ToTable("CarNameInfo");
    })
    .Map(e => {
        e.Properties(x => new { x.CarId, x.Color, x.Make });
        e.ToTable("CarDetailInfo");
    });
}
```
#### Define A Required & Optional Field
```Csharp
modelBuilder.Entity<Inventory>()
    .Property(x => x.Color).IsRequired();

modelBuilder.Entity<Inventory>()
    .Property(x => x.Make).IsOptional();            
```

#### Define Primary Key
```CSharp
modelBuilder.Entity<Inventory>()
    .HasKey(x => x.CarId);
``` 

#### Configuring Column
``` Csharp
modelBuilder.Entity<Inventory>()
    .Property(x => x.Make)
    .HasColumnName("Brand")
    .HasColumnOrder(2)
    .HasMaxLength(50)
    .IsRequired();
```

#### Unmapped Column
```CSharp
modelBuilder.Entity<Inventory>()
    .Ignore(p => p.Make);
```
### Relationships
#### One To Zero Or One
The table with zero-or-one relationship(Owner) must have its foreign key equal to primary key of base table(Inventory)
```CSharp

public class Owner {
    public int Id { get; set; }
    public string Name { get; set; }
    // Navigation Property
    public Inventory Car { get; set; }
}

public class Inventory {
    ...
    // Navigation Property
    public Owner Owner { get; set; }
}
...
protected override void OnModelCreating(DbModelBuilder modelBuilder) {
    modelBuilder.Entity<Owner>()
        .HasRequired(e => e.Car)
        .WithOptional(e => e.Owner);
    // an owner must have car but a car may have an owner
}
```

#### One To One
In one to one relationship we must add owner for every car we add before calling SaveChanges()
```CSharp
modelBuilder.Entity<Owner>()
    .HasRequired(e => e.Car)
    .WithRequiredPrincipal(e => e.Owner);
```

#### One To Many
```CSharp
public partial class Inventory {
    ...
    // Navigation Property
    public virtual Garage Garage { get; set; }
}

public class Garage {
    ...
    // Navigation Property
    public ICollection<Inventory> Cars { get; set; }
}
...
protected override void OnModelCreating(DbModelBuilder modelBuilder) {
    modelBuilder.Entity<Inventory>()
        .HasRequired(e => e.Garage)
        .WithMany(e => e.Cars)
        .HasForeignKey(e => e.GarageId)
        .WillCascadeOnDelete(false);  
}

```

### Many To Many
```CSharp
public partial class Inventory {
    ...
    // Navigation Property
    public virtual ICollection<Configuration> Configurations { get; set; }
}

public class Configuration {
    public int Id { get; set; }
    public EngineType EngineType { get; set; }
    public RadioType RadioType { get; set; }
    // Navigation Property
    public ICollection<Inventory> Cars { get; set; }
}
...
protected override void OnModelCreating(DbModelBuilder modelBuilder) {
    modelBuilder.Entity<Inventory>()
        .HasMany(e => e.Configurations)
        .WithMany(e => e.Cars); 
}

```
---
### Entity States
![States](https://github.com/iambharatsingh/C-Sharp/blob/master/Notes/20.%20Introduction%20To%20Entity%20Framework%206/03.%20Entity%20States.PNG?raw=true)

#### Data Annotations In System.ComponentModel.DataAnnotations.Schema
![Annotations](https://github.com/iambharatsingh/C-Sharp/blob/master/Notes/20.%20Introduction%20To%20Entity%20Framework%206/04.%20Data%20Annotations.PNG?raw=true)

---

### Seeding Database
A powerful EF feature is the ability to make sure the database matches the model as well as initializes the database with data.  There are two classes that you can derive from to turn this feature on:  
* **DropCreateDatabaseIfModelChanges\<TContext>** 
* **DropCreateDatabaseAlways\<TContext>**




```CSharp
using System.Data.Entity.Migrations;
public class AutoLotInit : DropCreateDatabaseAlways <AutoLotEntities> {
    protected override void Seed(AutoLotEntities context) {
        List<Inventory> cars = new List<Inventory>() {
            new Inventory() { Make = "Ford", PetName = "Zippy", Color = "Black" },
            new Inventory() { Make = "Ferrari", PetName = "Tim", Color = "Blue" },
            new Inventory () { Make = "BMW", PetName = "Carl", Color = "Yellow" }
        };

        context.Cars.AddOrUpdate(x => new { x.PetName, x.Make, x.Color }, cars.ToArray());
    }
}

...

using System.Data.Entity;
public class Program {
    public static void Main(string[] args) {
        // Initialize
        Database.SetInitializer(new AutoLotInit());

        AutoLotEntities context = new AutoLotEntities();
        context.Cars.ToList().ForEach(x => Console.WriteLine(new { x.CarId, x.Make, x.PetName, x.Color }.ToString()));
    }
}

```

---
## EF Migrations
Entity Framework introduced a migration tool that automatically updates the database schema when your model changes without losing any existing data or other database objects.

#### Enable Migrations
open the Package Manager Console (the command-line tool for managing NuGet packages) by selecting View ➤ Other Windows ➤ Package Manager Console. Now enter enable-migrations.

```bash
PM> enable-migrations
```

If Database already exists then enabling migrations will create a new migration corresponding to existing table in Project ➤ Migrations folder

#### Add Migration
Update the model according to your needs and create a new migration using 
```bash
PM> Add-migration MigrationName
```
#### Update Database 
To push the model changes onto the database use command
```bash
PM> update-database
```


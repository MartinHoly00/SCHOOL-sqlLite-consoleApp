using sqlLite1.Data;

AppDbContext db = new AppDbContext();
db.Database.EnsureDeleted();
db.Database.EnsureCreated();

var humans = db.Humans.ToList();
foreach (var human in humans)
{
    Console.WriteLine($"{human.FirstName}, {human.LastName}, {human.HumanId}");
}
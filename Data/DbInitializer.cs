using EVSec.Models;

namespace EVSec.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Inventaires.Any())
            {
                return;   // DB has been seeded
            }

            var inventaires = new Inventaire[]
            {
            new Inventaire{CodeVin=1,Annee=2000,Marque="Mercedes",Modele = "300",Finition="SL",DateAchat = DateTime.Parse("01-04-2023"),PrixAchat = 100000,PrixVente=200000},
            new Inventaire{CodeVin=2,Annee=2000,Marque="Chevrolet",Modele = "Corvette",Finition="C1",DateAchat = DateTime.Parse("05-04-2023"),PrixAchat = 80000,PrixVente=120000},
            new Inventaire{CodeVin=3,Annee=2000,Marque="BMW",Modele = "2002",Finition="TI",DateAchat = DateTime.Parse("08-04-2023"),PrixAchat = 50000,PrixVente=75000},
            new Inventaire{CodeVin=4,Annee=2000,Marque="Porsche",Modele = "911",Finition="RS 2.7",DateAchat = DateTime.Parse("12-04-2023"),PrixAchat = 200000,PrixVente=280000},
            };
            foreach (Inventaire i in inventaires)
            {
                context.Inventaires.Add(i);
            }
            context.SaveChanges();
        }
    }
}

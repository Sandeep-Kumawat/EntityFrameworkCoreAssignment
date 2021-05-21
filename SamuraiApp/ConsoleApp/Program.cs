using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        //private static SamuraiContext context = new SamuraiContext();
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            //    context.Database.EnsureCreated();
            //    GetSamurais("Befor Add:");
            //AddSamurai();
            //GetSamurais("After Add:");
            //InsertMultipleSamurais();
            //InsertVariousTypes();
            //GetSamuraisSimpler();
            //QueryFilters();

            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateSamurais();

            //RetrieveAndDeleteSamurai();

            //InsertNewSamuraiWithQuote();
            //InsertNewSamuraiWithManyQuotes();

            //AddQuoteToExistingSamuraiWhileTrack();
            //int id = 2;
            //AddQuoteToExistingSamuraiNoTracked(id);

            //EagerLoadSamuraiWithQuotes();
            //ProjectSomeProperties();
            //ProjectSamuraisWithQuotes();

            //ExplicitLoadQuotes();
            //LazyLoadQuotes();
            //FilteringWithRelatedData();
            //ModifyRelatedDataWhenTracked();
            //ModifyingRelatedDataWhenNotTracked();

            JoinBattleAndSamurai();
            //EnlistSamuraiIntoBattle();
            //GetSamuraiWithBattles();
            //RemoveJoinBetweenSamuraiAndBattleSimple();

            Console.WriteLine("Press any key to...");
            Console.ReadKey();


            //var clan1 = context.Clans.FirstOrDefault(s => s.Id == 1);
            //var clan1 = new Clan { ClanName = "Fds",Id=2 };
            //context.Add(new Samurai { Name = "Ninja Hatori2", Clan = clan1 });
            //context.SaveChanges();
            //context.Samurais.ToList().ForEach(i =>
            //{
            //    Console.WriteLine(i.Clan.Id);
            //});

        }
        public  static void GetSamuraiWithBattles()
        {
            var samuraiWithBattle = _context.Samurais
              .Include(s => s.SamuraiBattles)
              .ThenInclude(sb => sb.Battle)
              .FirstOrDefault(samurai => samurai.Id == 2);

            var samuraiWithBattlesCleaner = _context.Samurais.Where(s => s.Id == 2)
              .Select(s => new
              {
                  Samurai = s,
                  Battles = s.SamuraiBattles.Select(sb => sb.Battle)
              })
              .FirstOrDefault();
        }
        public static void RemoveJoinBetweenSamuraiAndBattleSimple()
        {
            var join = new SamuraiBattle { SamuraiId = 2, BattleId = 1 };
            _context.Remove(join);
            _context.SaveChanges();
        }
        public static void EnlistSamuraiIntoBattle()
        {
            var battle = _context.Battles.Find(1);
            battle.SamuraiBattles.Add(new SamuraiBattle { SamuraiId = 11 });
            _context.SaveChanges();
        }
        public static void JoinBattleAndSamurai()
        {
            var battle = new Battle { Name = "HaldiGhati" };
            _context.Battles.Add(battle);
            _context.SaveChanges();
            var sbjoin = new SamuraiBattle { SamuraiId = 11, BattleId = 1 };
            _context.Add(sbjoin);
            _context.SaveChanges();
        }
        public static void ModifyRelatedDataWhenTracked()
        {
            var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 1);
            samurai.Quotes[0].Text = "Did you hear that?";
           // _context.Quotes.Remove(samurai.Quotes[1]); //if we want to delete
            _context.SaveChanges();

        }
        private static void ModifyingRelatedDataWhenNotTracked()
        {
            var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 2);
            var quote = samurai.Quotes[0];
            quote.Text = "Did you hear that again?";
            using (var newContext = new SamuraiContext())
            {
                //newContext.Quotes.Update(quote);
                newContext.Entry(quote).State = EntityState.Modified;
                newContext.SaveChanges();
            }
        }
            public static void FilteringWithRelatedData()
        {
            var somePropertyWithQuotes = _context.Samurais
                .Where(q => q.Quotes.Any(s=>s.Text.Contains("will"))).ToList();
        }
        public static void LazyLoadQuotes()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name.Contains("Abhi"));
            var quotes = samurai.Quotes.Count();
        }
        public static void ExplicitLoadQuotes()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name.Contains("Abhi"));
            _context.Entry(samurai).Collection(s => s.Quotes).Load();
            _context.Entry(samurai).Reference(s => s.Horse).Load();
        }
        public static void ProjectSamuraisWithQuotes()
        {
            //var somePropertyWithQuotes = _context.Samurais.Select(s => new { s.Id, s.Name, s.Quotes.Count }).ToList();

            //if we want to search samurai with perticular quotes then 
            //var somePropertyWithQuotes = _context.Samurais
            //    .Select(s => new { s.Id, s.Name, WilQuotes = s.Quotes.Where(q => q.Text.Contains("will")) }).ToList();
            var somePropertyWithQuotes = _context.Samurais
               .Select(s => new { Samurai = s, WilQuotes = s.Quotes.Where(q => q.Text.Contains("will")) }).ToList();
        }
        public static void ProjectSomeProperties()
        {
            //var someProperties = _context.Samurais.Select(s => new { s.Id, s.Name }).ToList();
            //foreach(var i in someProperties)
            //{
            //    Console.WriteLine($" { i.Name} and Id {i.Id}");
            //}
            //we can also cast this list
            var idsAndNames = _context.Samurais.Select(s => new IDAndName(s.Id, s.Name)).ToList();
        }
        public struct IDAndName
        {
            // casting a list of defined type
            public IDAndName(int id,string name)
            {
                Id = id;
                Name = name;
                    
            }
            public int Id;
            public string Name;
        }
        public static void EagerLoadSamuraiWithQuotes()
        {  // left join -> or for join use Include()
            var samuraiWithQutoes = _context.Samurais.Include(s => s.Quotes).ToList();

            //var samuraiWithQutoes = _context.Samurais.Where(s => s.Name == "Abhi").Include(s => s.Quotes).ToList();
        }
        public static void AddQuoteToExistingSamuraiNoTracked(int SamuraiId)
        {
            //var samurai = _context.Samurais.Find(SamuraiId);
            //samurai.Quotes.Add(new Quote
            //{
            //    Text = "Run"
            //});
           
            //using(var newContext = new SamuraiContext())
            //{
            //    newContext.Samurais.Update(samurai);
            //    newContext.SaveChanges();
            //}
            var Quote = new Quote
            {
                Text = "I will Die",
                SamuraiId = SamuraiId
            };
            using (var newContext = new SamuraiContext())
            {
                newContext.Quotes.Add(Quote);
                newContext.SaveChanges();
            }

        }
        public static void AddQuoteToExistingSamuraiWhileTrack()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Quotes.Add(new Quote
            {
                Text = "I will Find you"

            }) ;
            _context.SaveChanges();
        }
        public static void InsertNewSamuraiWithManyQuotes()
        {
            var samnurai = new Samurai
            {
                Name = "Sandy",
                Quotes = new List<Quote>
                {
                    new Quote
                    {
                        Text = "I Win",

                    },
                    new Quote
                    {
                        Text="I will Kill you",
                    }
                }
            };
            _context.Samurais.Add(samnurai);
            _context.SaveChanges();
        }
        public static void InsertNewSamuraiWithQuote()
        {
            var samurai = new Samurai {

                Name = "Jack",
                Quotes = new List<Quote>
                {
                     new Quote
                     {
                         Text="I will Save you"
                     }
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        public static void  Tracking()
        { 
            // AsNoTracking()-> it returns a query not a DbSet
            var samurai = _context.Samurais.AsNoTracking().FirstOrDefault();
        }
        public static void RetrieveAndDeleteSamurai()
        {
            var samurai = _context.Samurais.Find(9);
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
        }
        public static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.SaveChanges();
        }
        public static void RetrieveAndUpdateSamurais()
        {
            // skip and take are great for paging the data 
            var samurai = _context.Samurais.Skip(1).Take(3).ToList();
            samurai.ForEach(s => s.Name += " San");
            _context.SaveChanges();
        }
        public static void QueryFilters()
        {
            var name = "Sandeep";
            /* var samurais = _context.Samurais.Where(s => s.Name == name).ToList(); */  // parameter
            //var samurais = _context.Samurais.Where(s => s.Name == "Sandeep").ToList(); hardcode data
            //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "S%")).ToList();
             var filter = "S%";
            //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, filter)).ToList();
            //aggregate function -firstOrDefault()-> return default null or object
            //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, filter)).FirstOrDefault();
            //var samurais = _context.Samurais.FirstOrDefault(s => EF.Functions.Like(s.Name, filter));

            //DbSet method Find() -> it return a key with value
            //var samuris = _context.Samurais.Find(2);

            //LastOrDefault()-> return no of order
            var last = _context.Samurais.OrderBy(s => s.Id).LastOrDefault(s => s.Name == name);


        }
        public static void GetSamuraisSimpler()
        {
            //var samurai = context.Samurais.ToList();
            var query = _context.Samurais;
            //var samurais = query.ToList();
            foreach(var samurai in query)
            {
                Console.WriteLine(samurai.Name);
            }
            
        }
        public static void InsertVariousTypes()
        {
            var samurai = new Samurai { Name = "Ding" };
            var clan = new Clan { ClanName = "Alwar" };
            _context.AddRange(samurai, clan);
            _context.SaveChanges();
        }
        public static void InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Ritik" };
            var samurai2 = new Samurai { Name = "Abhi" };
            _context.Samurais.AddRange(samurai, samurai2);
            //context.Samurais.Add(samurai);
            //context.Samurais.Add(samurai2);
            _context.SaveChanges();
        }
        public static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Sandeep" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        public static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{text} Samurai Count is:{samurais.Count}");
            foreach(var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}

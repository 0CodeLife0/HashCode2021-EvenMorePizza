using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EvenMorePizza
{
    class Program
    {
        static string path = @"inputdata\";
        //a_example.in,b_little_bit_of_everything.in,c_many_ingredients.in,d_many_pizzas.in,e_many_teams.in
        static string fileName = "b_little_bit_of_everything.in";
        static void Main(string[] args)
        {
            try
            {

                EvenMorePizza EvenMorePizza = ReadInputFile(path + fileName);

                OutPutFile outPutFile = UniqueIngPizzaDelivery(EvenMorePizza);

                WriteOutputFile(outPutFile);
            }
            catch (Exception exc) { Console.WriteLine(exc.Message); }
        }

        private static OutPutFile UniqueIngPizzaDelivery(EvenMorePizza evenMorePizza)
        {
            bool t4Fed = false;

            EvenMorePizza archivePizza = ObjectCopier.CloneJson(evenMorePizza);
            OutPutFile outPutFile = new OutPutFile();
            outPutFile.DeliveredPizza = 0;
            int totalPizza = evenMorePizza.AvailablePizza;

            List<Delivery> deliveries = new List<Delivery>();
            int T2 = evenMorePizza.Team2ppl, T3 = evenMorePizza.Team3ppl, T4 = evenMorePizza.Team4ppl;
            int NofTeams = evenMorePizza.Team2ppl + evenMorePizza.Team3ppl + evenMorePizza.Team4ppl;
            int totalppl = (T2 * 2) + (T3 * 3) + (T4 * 4);
            if (totalPizza != totalppl)
            {
                int t4Ate = (totalPizza - (T4 * 4));
                t4Fed = t4Ate > 0;
                if (t4Ate >= (T3 * 3))
                {
                    int t4t3Ate = (t4Ate - (T3 * 3));
                    bool t4t3Fed = t4t3Ate > 0;

                    int t2Left = (T2 * 2);
                    bool t2Fed = (totalPizza - (T2 * 2)) > 0;
                }

            }

            //-----
            int i = 0;
            //do
            {
                try
                {
                    totalPizza = evenMorePizza.Pizzas.Count;
                    Console.WriteLine("Pizza Left: " + totalPizza + "\n- - - - - - -\n");
                    totalppl = (evenMorePizza.Team2ppl * 2) + (T3 = evenMorePizza.Team3ppl * 3) + (evenMorePizza.Team4ppl * 4);
                    Console.WriteLine("Pizza PPL: " + totalppl + "\n- - - - - - -\n");
                    Console.WriteLine("evenMorePizza.Team4ppl\n- - - - - - -\n");
                }
                catch { }
                if (evenMorePizza.Team4ppl > 0 && (totalPizza > 0))
                {
                    int Team4pplIndex = 0;
                    do
                    {
                        var pizzads = new List<string>();

                        totalPizza = evenMorePizza.Pizzas.Count;
                        if ((totalPizza >= (4 * evenMorePizza.Team4ppl)) && (totalPizza % 4 >= 0))
                        {
                            List<int> pizzaindx = new List<int>();
                            List<string> LastPizzaIng = new List<string>();

                            var Pizza = GiveMePizza(pizzads, evenMorePizza, archivePizza, 4);
                            if (Pizza.Count > 0)
                            {
                                pizzaindx.AddRange(Pizza);
                                evenMorePizza.Pizzas.RemoveAll(p => Pizza.Contains(p.Id));
                            }

                            if (pizzaindx.Count == 4)
                            {
                                deliveries.Add(new Delivery(4, pizzaindx, LastPizzaIng));
                                outPutFile.Delivery = deliveries;
                                if (outPutFile.Delivery.Count() % (10 * 4) == 0)
                                {
                                    double teampercent = (double)100 / NofTeams;
                                    double percent = (outPutFile.Delivery.Count() * teampercent);
                                    Console.WriteLine(percent + " => " + outPutFile.Delivery.Count() + " - Delivery / " + NofTeams);
                                }
                                i++;

                                Team4pplIndex++;
                            }
                        }
                        evenMorePizza.Team4ppl -= 1;
                    } while (evenMorePizza.Team4ppl > 0);
                    try
                    {
                        Console.WriteLine("Pizza Left: " + totalPizza + "\n- - - - - - -\n");
                        totalppl = (evenMorePizza.Team2ppl * 2) + (T3 = evenMorePizza.Team3ppl * 3) + (evenMorePizza.Team4ppl * 4);
                        Console.WriteLine("Pizza PPL: " + totalppl + "\n- - - - - - -\n");
                        Console.WriteLine("evenMorePizza.Team3ppl\n- - - - - - -\n");
                        Console.WriteLine(outPutFile.Delivery.Count());
                        totalPizza = evenMorePizza.Pizzas.Count;
                    }
                    catch { }
                    if (evenMorePizza.Team3ppl > 0 && (totalPizza > 0))
                    {
                        int Team3pplIndex = 0;
                        do
                        {
                            var pizzads = new List<string>();

                            totalPizza = evenMorePizza.Pizzas.Count;
                            if ((totalPizza >= (3 * evenMorePizza.Team3ppl)) && (totalPizza % 3 >= 0))
                            {
                                List<int> pizzaindx = new List<int>();
                                List<string> LastPizzaIng = new List<string>();
                                var Pizza = GiveMePizza(pizzads, evenMorePizza, archivePizza, 3);
                                if (Pizza.Count > 0)
                                {
                                    pizzaindx.AddRange(Pizza);
                                    var removePizza = evenMorePizza.Pizzas.RemoveAll(p => Pizza.Contains(p.Id));
                                }

                                if (pizzaindx.Count == 3)
                                {
                                    deliveries.Add(new Delivery(3, pizzaindx, LastPizzaIng));
                                    outPutFile.Delivery = deliveries;
                                    if (outPutFile.Delivery.Count() % (10 * 3) == 0)
                                    {
                                        double teampercent = (double)100 / NofTeams;
                                        double percent = (outPutFile.Delivery.Count() * teampercent);
                                        Console.WriteLine(percent + " => " + outPutFile.Delivery.Count() + " - Delivery / " + NofTeams);
                                    }
                                    i++;
                                    Team3pplIndex++;
                                }
                            }
                            evenMorePizza.Team3ppl -= 1;
                        } while (evenMorePizza.Team3ppl > 0);
                    }
                    try
                    {
                        totalPizza = evenMorePizza.Pizzas.Count;
                        Console.WriteLine("Pizza Left: " + totalPizza + "\n- - - - - - -\n");
                        totalppl = (evenMorePizza.Team2ppl * 2) + (T3 = evenMorePizza.Team3ppl * 3) + (evenMorePizza.Team4ppl * 4);
                        Console.WriteLine("Pizza PPL: " + totalppl + "\n- - - - - - -\n");
                        Console.WriteLine("evenMorePizza.Team2ppl\n- - - - - - -\n");
                        Console.WriteLine(outPutFile.Delivery.Count());
                    }
                    catch { }
                    if (evenMorePizza.Team2ppl > 0 && (totalPizza > 0))
                    {
                        int Team2pplIndex = 0;
                        do
                        {
                            var pizzads = new List<string>();

                            totalPizza = evenMorePizza.Pizzas.Count;
                            if ((totalPizza >= (2 * evenMorePizza.Team2ppl)) && (totalPizza % 2 >= 0))
                            {
                                List<string> LastPizzaIng = new List<string>();
                                List<int> pizzaindx = new List<int>();
                                {
                                    var Pizza = GiveMePizza(pizzads, evenMorePizza, archivePizza, 2);
                                    if (Pizza.Count > 0)
                                    {
                                        pizzaindx.AddRange(Pizza);
                                        var removePizza = evenMorePizza.Pizzas.RemoveAll(p => Pizza.Contains(p.Id));
                                    }
                                }
                                if (pizzaindx.Count == 2)
                                {
                                    deliveries.Add(new Delivery(2, pizzaindx, LastPizzaIng));
                                    outPutFile.Delivery = deliveries;
                                    if (outPutFile.Delivery.Count() % (10 * 2) == 0)
                                    {
                                        double teampercent = (double)100 / NofTeams;
                                        double percent = (outPutFile.Delivery.Count() * teampercent);
                                        Console.WriteLine(percent + " => " + outPutFile.Delivery.Count() + " - Delivery / " + NofTeams);
                                    }
                                    i++;
                                    Team2pplIndex++;
                                }
                            }
                            evenMorePizza.Team2ppl -= 1;
                        } while (evenMorePizza.Team2ppl > 0);
                    }
                }
                totalPizza = evenMorePizza.Pizzas.Count;
            }
            //while (totalPizza > 0);

            outPutFile.DeliveredPizza = deliveries.Count();
            return outPutFile;
        }

        private static List<int> GiveMePizza(List<string> lastIng, EvenMorePizza evenMorePizza, EvenMorePizza ArEvenMorePizza, int type)
        {
            var PizzaIngTotal = string.Join(" ", evenMorePizza.Pizzas.Select(p => string.Join(" ", p.NumOfIng)).ToList()).Split(' ').ToList();
            var uniquePizzaIngs = PizzaIngTotal.Distinct().Select(p => int.Parse(p)).OrderByDescending(p => p).ToList();
            var res = from element in evenMorePizza.Pizzas//.Where(p => lastIng.Count == 0 || (!lastIng.Any(t1 => p.Ingredients.Contains(t1))))
                      group element by element.NumOfIng
                  into groups
                      select groups.OrderBy(p => p.NumOfIng).ToList().First();
            var rPizzaId = new List<int>();
            if (type > uniquePizzaIngs.Count)
            {
                for (int u = 0; u < type; u++)
                {
                    //loop more
                    var returnPizza = res.Where(p => p.NumOfIng == uniquePizzaIngs[u % uniquePizzaIngs.Count]).ToList();
                    if (returnPizza.Count > 0)
                    {
                        rPizzaId.Add(returnPizza.Select(p => p.Id).FirstOrDefault());

                        res = from element in evenMorePizza.Pizzas.Where(P => !rPizzaId.Contains(P.Id))
                              group element by element.NumOfIng
                              into groups
                              select groups.OrderBy(p => p.NumOfIng).First();
                        if (rPizzaId.Count == type)
                            return rPizzaId;
                    }
                }
            }
            else
            {
                for (int u = 0; u < uniquePizzaIngs.Count; u++)
                {
                    //last ing of team mate
                    lastIng = evenMorePizza.Pizzas.Where(p => rPizzaId.Contains(p.Id)).Select(p => string.Join(" ", p.Ingredients)).ToList();
                    //todo: test this
                    lastIng = string.Join(" ", lastIng).Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().Take(u).ToList();
                    if (lastIng.Count > 0)
                    {
                        res = from element in evenMorePizza.Pizzas.Where(p => lastIng.Count == 0 || (!lastIng.Any(t1 => p.Ingredients.Contains(t1))))
                              group element by element.NumOfIng
                              into groups
                              select groups.OrderBy(p => p.NumOfIng).ToList().First();
                    }
                    //loop more
                    var returnPizza = res.Where(p => p.NumOfIng == uniquePizzaIngs[u]).ToList();
                    if (returnPizza.Count > 0)
                    {
                        rPizzaId.Add(returnPizza.Select(p => p.Id).FirstOrDefault());
                        if (rPizzaId.Count == type)
                            return rPizzaId;
                    }
                }
            }
            return new List<int>();
        }

        //Tested
        private static void WriteOutputFile(OutPutFile outPut)
        {
            string createText = outPut.DeliveredPizza + Environment.NewLine;

            foreach (var op in outPut.Delivery)
            {
                var deliveredPizza = op.TeamType + " " + string.Join(" ", op.Pizza);
                createText += deliveredPizza + Environment.NewLine;
            }
            File.WriteAllText(path + fileName + "_Output.txt", createText);
        }

        private static EvenMorePizza ReadInputFile(string fileName)
        {
            List<EvenMorePizza> emplist = new List<EvenMorePizza>();
            var lines = File.ReadAllLines(fileName);

            int aPizza = 0, T2 = 0, T3 = 0, T4 = 0;
            var line = lines[0];
            var fline = line.Split(' ');
            aPizza = int.Parse(fline[0]);
            T2 = int.Parse(fline[1]);
            T3 = int.Parse(fline[2]);
            T4 = int.Parse(fline[3]);

            List<PizzaIng> pings = new List<PizzaIng>();
            for (var i = 1; i < lines.Length; i++)
            {
                var otherLines = lines[i].Split(' ');
                PizzaIng ping = new PizzaIng(i - 1, int.Parse(otherLines[0]), otherLines.Skip(1).OrderBy(p => p).ToList());
                pings.Add(ping);
            }
            pings = pings.OrderBy(p => string.Join(" ", p.Ingredients)).ToList();
            EvenMorePizza emp = new EvenMorePizza(aPizza, T2, T3, T4, pings);
            return emp;
        }
    }

    class OutPutFile
    {
        public int DeliveredPizza { get; set; }
        public List<Delivery> Delivery { get; set; }
    }
    class Delivery
    {
        public int TeamType { get; set; }
        public List<int> Pizza { get; set; }
        public List<string> LastNIngs { get; set; }

        public Delivery(int TeamType, List<int> Pizza)
        {
            this.TeamType = TeamType;
            this.Pizza = Pizza;
        }
        public Delivery(int TeamType, List<int> Pizza, List<string> LastNIngs)
        {
            this.TeamType = TeamType;
            this.Pizza = Pizza;
            this.LastNIngs = LastNIngs;
        }
    }
    class EvenMorePizza
    {
        public int AvailablePizza { get; set; }
        public int Team2ppl { get; set; }
        public int Team3ppl { get; set; }
        public int Team4ppl { get; set; }
        public List<PizzaIng> Pizzas { get; set; }
        public EvenMorePizza()
        {

        }
        public EvenMorePizza(int AvailablePizza, int Team2ppl, int Team3ppl, int Team4ppl, List<PizzaIng> pizzaIngs)
        {
            this.AvailablePizza = AvailablePizza;
            this.Team2ppl = Team2ppl;
            this.Team3ppl = Team3ppl;
            this.Team4ppl = Team4ppl;
            this.Pizzas = pizzaIngs;
        }
    }
    class PizzaIng
    {
        public int Id { get; set; }
        public int NumOfIng { get; set; }
        public List<string> Ingredients { get; set; }

        public PizzaIng(int Id, int NumOfIng, List<string> Ingredients)
        {
            this.Id = Id;
            this.NumOfIng = NumOfIng;
            this.Ingredients = Ingredients;
        }
    }
}

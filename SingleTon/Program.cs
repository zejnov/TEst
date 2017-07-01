using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTon
{
    //wzorzec który pozwala nam na stworzenie 1 instancji obiektu w naszym kodzie
    //vs klasa statyczna -> klasa od razu się ładuje, singleTon tworzy się dopiero kiedy go chcemy, wcześniej nie będzie tworzony
    //np przy dostępie do pliku - 1 instancja w całości

    class Program
    {
        static void Main()
        {
            new Program().Run();
        }


        private void Run()
        {
            var sim1 = new ResourceAccessSimulator();
            var sim2 = new ResourceAccessSimulator();

            sim1.SimulationFinished += PrintListOfPeople;
            sim2.SimulationFinished += PrintListOfPeople;


            sim1.Simulate(200,2100,"Sim1");
            sim2.Simulate(150,1000,"Sim2");
            
            Console.ReadKey();
        }

        private void PrintListOfPeople(object sender, EndSimulatorArgs args)
        {
            foreach (var entry in args.Register)
            {
                Console.WriteLine($"{entry.Name} {entry.Surname}");
            }

            Console.WriteLine($"Lista {args.SimulatorName} ma pól: {args.Register.Count}");
        }
    }
}

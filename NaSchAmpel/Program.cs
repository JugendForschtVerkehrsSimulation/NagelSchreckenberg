
using System;
using System.IO;

namespace NagelSchreckenberg
{
	class Program
	{
		public const string ausgabePfad = "C:\\Users\\freudis\\Documents\\Gregor\\Projekte\\Jugend forscht\\Grüne Welle\\animation\\Ausgabe.txt";

		public static void Main(string[] args)
		{
			Simulation sim = new Simulation();
			sim.initSimulation();
			sim.Clear(ausgabePfad);
			
//			for (int i = 0; i < 500; i++)						//Vorbereitung (500 Runden ohne Ausgabe)
//			{
//				sim.NaSch();
//			}
			for (int i = 0; i < 100; i++) 						//x-mal durchlaufen von Simulationsschritten, ...
			{
				sim.NaSch();
				sim.Ausgeben(ausgabePfad);
			}
			Console.WriteLine("Simulation beendet.");
			Console.ReadLine();
			
		}
	}
}
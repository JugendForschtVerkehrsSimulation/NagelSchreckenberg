
using System;
using System.IO;

namespace NagelSchreckenberg
{
	class Program
	{
		public const string ausgabePfad = "C:\\Users\\freudis\\Documents\\Gregor\\Projekte\\Jugend forscht\\Grüne Welle\\animation\\Ausgabe.txt";
		public const string einfacheAusgabePfad = "C:\\Users\\freudis\\Documents\\Gregor\\Projekte\\Jugend forscht\\Grüne Welle\\animation\\einfacheAusgabe.txt";
		
		public static void Main(string[] args)
		{
			Simulation sim = new Simulation();
			sim.initSimulation();
				
			using ( StreamWriter Ausgabe = File.CreateText(ausgabePfad))
			{
				Ausgabe.WriteLine("Neue Ampel-Simulation gestartet (Vorbereitung 500 Schritte)");
				Ausgabe.WriteLine("");
			}
			
//			using ( StreamWriter einfacheAusgabe = File.CreateText(einfacheAusgabePfad))
//			{
//				einfacheAusgabe.WriteLine("Neue Ampel-Simulation gestartet (Vorbereitung 500 Schritte)");
//				einfacheAusgabe.WriteLine("");
//			}
//			
//			sim.EinfacheAusgabe(einfacheAusgabePfad);
//			
//			using ( StreamWriter einfacheAusgabe = File.AppendText(einfacheAusgabePfad))
//			{
//				einfacheAusgabe.WriteLine("");
//			}
//			
			for (int i = 0; i < 500; i++)						//Vorbereitung (500 Runden ohne Ausgabe)
			{
				sim.NaSch();
			}
			
			for (int i = 0; i < 1000; i++) 						//1000 mal durchlaufen von Simulationsschritten, ...
			{
				sim.NaSch();
				sim.Ausgeben(ausgabePfad);
				sim.EinfacheAusgabe(einfacheAusgabePfad);
				
			}
			Console.WriteLine("Simulation beendet.");
			Console.ReadLine();
			
		}
	}
}
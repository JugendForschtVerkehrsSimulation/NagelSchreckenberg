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
			using ( StreamWriter Ausgabe = File.CreateText(ausgabePfad))
			{
				Ausgabe.WriteLine("Neue Simulation gestartet");
			}
			using ( StreamWriter einfacheAusgabe = File.CreateText(einfacheAusgabePfad))
			{
				einfacheAusgabe.WriteLine("Neue Simulation gestartet");
			}
			Simulation sim = new Simulation();
			sim.Ausgeben(ausgabePfad);
			for (int i = 0; i < 400; i++) {
//				Console.WriteLine("--------- Schritt Nr. " + i + " -------------");
				sim.NaSch();
				sim.Ausgeben(ausgabePfad);
				sim.EinfacheAusgabe(einfacheAusgabePfad);
				
				//Console.ReadKey(true);
			}
			Console.ReadLine();
		}
	}
}

/*public static void printStrasse(int[] Array)											//Starße ausgeben
		{
	for (int i = 0; i < Array.Length; i++) {
		if (Array[i] == -1) {
			Console.Write("   ");
		} else {

			Console.Write("[{0}]", Array[i]);
		}
	}
	Console.Write("\n");
}*/

/*int LAENGE = 180;
			int[] Auto = new int[LAENGE];																// Slot[Position] = Geschwindigkeit entweder mit oder ohne Auto (-1 = kein Auto; 0 bis 5 = Auto)
	int AnzahlAutos = 15;															// Soviele Autos stehen auf der Straße
	int Max = 5;																	// Maximale Geschwindigkeit
	int Beschleunigung = 1;															// Beschleunigung
	int Troedeln = 11;																// Zufallszahl zwischen (1 und Trödeln - 1) == 1 => trödelt

	Random Zufall = new Random();

	for (int A0 = 0; A0 < Auto.Length; A0++)												// Alle Slots mit leer belegen
		{
			Auto[A0] = -1;
		}

		for (int A1 = 0; A1 <= AnzahlAutos; A1++)									//Autos auf die Straße setzen
			{
				int B1;
				B1 = Zufall.Next(Auto.Length);

				if (Auto[B1] == -1) {
					int B2;
					B2 = Zufall.Next(Max);
					Auto[B1] = B2;
				}
				else
				{
					A1 = A1 - 1;
				}
			}

		printStrasse(Auto);													//gehe zu "Straße ausgeben"

		for (int A2 = 0; A2 < Auto.Length; A2++)										//Autos beschleunigen lassen (Geschwindigkeit +1)
			{
				if (Auto[A2] != -1 && Auto[A2] < Max)
				{
					Auto[A2] = Auto[A2] + Beschleunigung;
				}

				for (int j = 1; j <= Auto[A2]; j++)
					{
						if (Auto[A2 + j] >= 0)
						{
							Auto[A2] = j - 1;
						}
						break;
					}

				int B1 = Zufall.Next(1, 11);
				if (Auto[A2] != -1 && B1 == Troedeln)
					{
						Auto[A2] = Auto[A2] - 1;

					}
			}

//		for (int A3 = 179; A3 != -1; A3 = A3 - 1)									//Autos fahren lassen     ACHTUNG: Hier Fehler
//				{
//					if (Auto[A3] != -1)
//						{
//							int B2 = Auto[A3];
//							Auto[A3] = -1;
//							Auto[A3 + B2] = B2;
//						}
//				}

		printStrasse(Auto);													//gehe zu "Straße ausgeben"
		*/
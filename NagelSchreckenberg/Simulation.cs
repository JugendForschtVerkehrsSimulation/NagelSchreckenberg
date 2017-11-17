
/* Created by SharpDevelop.
 * User: freudis
 * Date: 06.10.2017
 * Time: 18:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;

namespace NagelSchreckenberg
{
	/// <summary>
	/// Description of Simulation.
	/// </summary>
	public class Simulation
	{
		private static Random Zufall = new Random();
		public static int Straße = 200;
		public int schritte = 0;
		public Auto[] autos = new Auto[120];
//		public int anzahl = 80;
		
		public Simulation()
		{
			for (int i = 0; i < autos.Length; i++) 
			{
				autos[i] = new Auto();
			}
			
			int positionsAbschnitt = Straße / autos.Length;
			int Position = 0;
			
			foreach (Auto a in autos)
			{
				a.Position = Position;
				Position = Position + positionsAbschnitt;
			}
			
//			int Position;
//			bool flagge;
//			
//			for (int i = 0; i < autos.Length; i++)
//			{
//				Position = Zufall.Next(0, Straße);
//				flagge = false;
//				
//				foreach (Auto a in autos)
// 				{
//					if (a.Position == Position && flagge == false)
//					{
//						i--;
//						flagge = true;
//					}
//				}
//				if (flagge == false)
//				{
//					autos[i].Position = Position;
//				}
//			}
		}
		public void NaSch() {
			for (int i = 0; i < autos.Length; i++) {
				Auto vordermann = autos[(i+1) % autos.Length];
//				Console.Write("Auto: " + i + " -> v: " + autos[i].Geschwindigkeit );
				autos[i].Beschleunigen();
//				Console.Write(" -> a: " + autos[i].Geschwindigkeit );
				autos[i].Bremsen(vordermann);
//				Console.Write(" -> b: " + autos[i].Geschwindigkeit );
				autos[i].Trödeln();
//				Console.WriteLine(" -> t: " + autos[i].Geschwindigkeit );
			}
			foreach (Auto a in autos)
			{
				a.Fahren();
			}
			schritte++;
		}
		
		public void EinfacheAusgabe(string pfadName) {
			
			using ( StreamWriter einfacheAusgabe = File.AppendText(pfadName))
			{
				System.Text.StringBuilder einfacheAusgabeText = new System.Text.StringBuilder();
				
				for (int Länge = 0; Länge < Auto.Straße; Länge++)
				{
					einfacheAusgabeText.Append("").Append(".").Append("");
				}
				
				foreach (Auto a in autos)
				{
//				Console.WriteLine("debug: " + a.Position + a.Geschwindigkeit);
					einfacheAusgabeText[Convert.ToInt32(a.Position)] = Convert.ToChar(Convert.ToString(Convert.ToInt32(a.Geschwindigkeit)));
				}
				
				einfacheAusgabe.WriteLine(einfacheAusgabeText.ToString());
				//Console.WriteLine();
				//Console.Write("Press any key to continue . . . ");
				//Console.Clear;
				//Console.ReadKey(true);
			}
		}
		
		public void Ausgeben(string pfadName) {
			using ( StreamWriter ausgabe = File.AppendText(pfadName))
			{
				
				//ausgabe.WriteLine("Schritt {0} der Simulation: ", schritte);
				
				foreach (Auto a in autos)
				{
					ausgabe.WriteLine("{0},{1}",schritte, a);
				}
				//ausgabe.WriteLine("--------------------------------");
				
			}
		}
	}
}

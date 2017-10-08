/*
 * Created by SharpDevelop.
 * User: freudis
 * Date: 06.10.2017
 * Time: 18:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NagelSchreckenberg
{
	/// <summary>
	/// Description of Simulation.
	/// </summary>
	public class Simulation
	{
		public int schritte = 0;
		public Auto[] autos = new Auto[10];
			
		public Simulation()
		{
			for (int i = 0; i < autos.Length; i++) {
				autos[i] = new Auto();
			}
			int Position = 2;
			foreach (Auto a in autos)
			{
				a.Position = Position;
				Position = Position + 3;
			}
		}
		public void NaSch() {
			for (int i = 0; i < autos.Length; i++) {
				Auto vordermann = autos[(i+1) % autos.Length];
				autos[i].Beschleunigen();
				autos[i].Bremsen(vordermann);
				autos[i].Trödeln();
			}
			foreach (Auto a in autos)
			{
				a.Fahren();
			}
			schritte++;
		}
			
		public void Ausgeben() {
			Console.WriteLine("Schritt {0} der Simulation: ", schritte);
			foreach (Auto a in autos)
			{
				Console.WriteLine(a);
			}
			Console.WriteLine("---------------------");
		}
	}
}

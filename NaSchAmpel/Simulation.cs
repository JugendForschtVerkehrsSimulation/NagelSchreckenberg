
/* Created by SharpDevelop.
 * User: freudis
 * Date: 06.10.2017
 * Time: 18:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Collections.Generic;

namespace NagelSchreckenberg
{
	/// <summary>
	/// Description of Simulation.
	/// </summary>
	public class Simulation
	{
		private static Random Zufall = new Random();
		public static int Straße = 400;
		public int schritte = 0;
		public int maxAutos = 100;
		public List<Auto> autos = new List<Auto>();
		//public Auto[] autos = new Auto[100];
		public Ampel[] ampeln = new Ampel[3];
		
		public Simulation()
		{
			int positionsAbschnitt = Straße / maxAutos;
			int Position = 0;
			
			foreach (Auto a in autos)
			{
				a.Position = Position;
				Position = Position + positionsAbschnitt;
			}
			
//			for (int i = 0; i < ampeln.Length; i++)						//initialisiere Ampeln
//			{
			ampeln[0] = new Ampel(88, 50, 40, 0);						//int ULZ, int POSI, int GPL, int VER
			ampeln[1] = new Ampel(88, 150, 40, 22);
			ampeln[2] = new Ampel(88, 250, 40, 44);
//			}
		}
		
		public void NaSch() {
			
			if ( autos.Count <= maxAutos) 
			{
        		if ( autos.Count == 0 ) 
        		{
            		autos.Add(new Auto());
        		}
	        	else 
	        	{
	        		Auto vordermann = autos[autos.Count-1];
	            	autos.Add(new Auto(vordermann));
	        	}
   			}		
			for (int i = 0; i < autos.Count; i++) 
			{
				if (i == 0)
				{
					Auto vordermann = new Auto(Straße + 10000);
				}
				else
				{
					Auto vordermann = autos[i-1];
				}
				
				autos[i].Beschleunigen();
				autos[i].Bremsen(vordermann, ampeln, schritte);				//hier ist ein fehler wo ich keine Ahnung hab was zu tun ist, vielleicht weißt du ja was
				autos[i].Trödeln();
			}
			foreach (Auto a in autos)
			{
				a.Fahren();
			}
			for (int i = 0; i < autos.Count; i++)
			{
				if ( autos[i].Position > Straße )
				{
					autos.RemoveAt(i);
				}
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
					einfacheAusgabeText[Convert.ToInt32(a.Position)] = Convert.ToChar(Convert.ToString(Convert.ToInt32(a.Geschwindigkeit)));
				}
				foreach (Ampel a in ampeln)
				{
					if (a.zeigePhase(schritte) == 0)
					{
						einfacheAusgabeText[Convert.ToInt32(a.Position)] = 'G';
					}
					else
					{
						einfacheAusgabeText[Convert.ToInt32(a.Position)] = 'R';
					}
				}
				einfacheAusgabe.WriteLine(einfacheAusgabeText.ToString());
			}
		}
		
		public void Ausgeben(string pfadName) {
			using ( StreamWriter ausgabe = File.AppendText(pfadName))
			{
				foreach (Auto a in autos)
				{
					ausgabe.WriteLine("{0},{1}",schritte, a);
				}
				
			}
		}
	}
}

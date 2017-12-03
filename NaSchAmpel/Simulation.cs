
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
		public double Zeit = 0;
		public double Zeitschritt = 0.1;
		
		public long SpurIndex = 0;
		
		public List<Spur> Spuren = new List<Spur>();
		
		public Simulation()
		{
			
		}
		
		public void NaSch()
		{
			for ( int i=0; i < Spuren.Count; i++ )
			{
				Spuren[i].setzeAuto(i);
				Spuren[i].Bewegung(Zeit);				
			}
			
			Zeit += Zeitschritt;
		}
		
		public void initSimulation()
		{
			Spuren.Add(new Spur(-250, -200, 0, 200, 250, 25));
			Spuren[0].initAmpelInSpur(88, 40, 0);							// ULZ, GPL, VER
		}
		
		public void EinfacheAusgabe(string pfadName) {
			
//			using ( StreamWriter einfacheAusgabe = File.AppendText(pfadName))
//			{
//				System.Text.StringBuilder einfacheAusgabeText = new System.Text.StringBuilder();
//				
//				for (int Länge = 0; Länge < Auto.Straße; Länge++)
//				{
//					einfacheAusgabeText.Append("").Append(".").Append("");
//				}
//				
//				foreach (Auto a in autos)
//				{
//					einfacheAusgabeText[Convert.ToInt32(a.Position)] = Convert.ToChar(Convert.ToString(Convert.ToInt32(a.Geschwindigkeit)));
//				}
//				foreach (Ampel a in ampeln)
//				{
//					if (a.zeigePhase(schritte) == 0)
//					{
//						einfacheAusgabeText[Convert.ToInt32(a.Position)] = 'G';
//					}
//					else
//					{
//						einfacheAusgabeText[Convert.ToInt32(a.Position)] = 'R';
//					}
//				}
//				einfacheAusgabe.WriteLine(einfacheAusgabeText.ToString());
//			}
		}
		
		public void Ausgeben(string pfadName)
		{
//			using ( StreamWriter ausgabe = File.AppendText(pfadName))
//			{
//				foreach (Auto a in autos)
//				{
//					ausgabe.WriteLine("{0},{1}",schritte, a);
//				}
//				
//			}
		}
		
		public long HoleSpurIndex()
		{
			long Index = this.SpurIndex;
			this.SpurIndex++;
			
			return Index;
		}
	}
}

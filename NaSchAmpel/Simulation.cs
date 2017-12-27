
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
using System.Globalization;

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
		// 0 = Wielanstraße West - Ost	1 = Wielandstraße Ost-West	2 = Eberhardtstraße - Talfingerstraße	3 = Talfingerstraße - Eberhardtstraße
		
		public List<Spur> Spuren = new List<Spur>();
		
		public Simulation()
		{
			
		}
		
		public void Clear (string ausgabePfad)
		{
			using ( StreamWriter ausgabe = File.CreateText(ausgabePfad))
			{
				ausgabe.Write("");
			}
		}
		
		public void NaSch()
		{
			for ( int i=0; i < Spuren.Count; i++ )
			{
				Spuren[i].setzeAuto(i);
				Spuren[i].Bewegung(Zeit, Zeitschritt);				
			}
			
			Zeit += Zeitschritt;
		}
		
		public void initSimulation()
		{
			Spuren.Add(new Spur(-250, -200, 0, 200, 250, 2, SpurIndex));
			SpurIndex++;
			Spuren.Add(new Spur(-250, -200, 0, 200, 250, 2, SpurIndex));
			SpurIndex++;
			Spuren.Add(new Spur(-250, -200, 0, 200, 250, 2, SpurIndex));
			SpurIndex++;
			Spuren.Add(new Spur(-250, -200, 0, 200, 250, 2, SpurIndex));

			Spuren[0].initAmpelInSpur(88, 40, 0);
								  // ULZ, GPL, VER
		}
		
		public void Ausgeben(string pfadName)
		{
			using ( StreamWriter ausgabe = File.AppendText(pfadName))
			{
				CultureInfo invC = CultureInfo.InvariantCulture;
				
				ausgabe.WriteLine("TIME " + Zeit.ToString("F2",invC) + " " + Zeitschritt.ToString("F2",invC) + " " + Spuren.Count);
				foreach (Spur s in Spuren)
				{
					ausgabe.WriteLine("SPUR " + s.SpurNummer + " " + Zeit.ToString("F2",invC) + " " + s.autos.Count);
					ausgabe.WriteLine("AMPEL " + s.SpurNummer + " " + Zeit.ToString("F2",invC) + " " + s.ampel.Position.ToString("F2",invC) + " " + s.ampel.zeigePhase(Zeit));
					foreach (Auto a in s.autos)
					{
						ausgabe.WriteLine("Auto " + a.Autonummer + " " + s.SpurNummer + " " + Zeit.ToString("F2",invC) + " " + a.Position.ToString("F2",invC) + " " + a.Geschwindigkeit.ToString("F2",invC) + " " + a.Beschleunigung.ToString("F2",invC));
					}
				}
			}
		}
		
		public long HoleSpurIndex()
		{
			long Index = this.SpurIndex;
			this.SpurIndex++;
			
			return Index;
		}
	}
}

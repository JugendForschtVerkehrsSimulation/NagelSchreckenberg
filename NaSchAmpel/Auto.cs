/*
 * Created by SharpDevelop.
 * User: freudis
 * Date: 06.10.2017
 * Time: 17:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

namespace NagelSchreckenberg
{
	/// <summary>
	/// Description of Auto.
	/// </summary>
	public class Auto
	{
		public static int Straße = 400;
		
		private static Random Zufall = new Random();
		
		public int Geschwindigkeit;
		
		public int MaximalGeschwindigkeit;
		
		public int Position;
		
		public int Beschleunigung;
		
//		public int Autonummer;
		
		public Auto()
		{
			MaximalGeschwindigkeit = 5;
			Geschwindigkeit = Zufall.Next(1, MaximalGeschwindigkeit + 1);
			Position = 0;
			Beschleunigung = 1;
		}
		
		public Auto( Auto vordermann ) 
		{
        	this.MaximalGeschwindigkeit = 5;
        	this.Geschwindigkeit = Zufall.Next(1, MaximalGeschwindigkeit + 1);
        	this.Position = vordermann.Position - 3;
        	this.Beschleunigung = 1;
    	}
		
		public Auto( int zielPosi ) 
		{
        	this.MaximalGeschwindigkeit = 0;
        	this.Geschwindigkeit = 0;
        	this.Position = zielPosi;
        	this.Beschleunigung = 0;
    	}
		
		public void Beschleunigen()
		{
			if (Geschwindigkeit < MaximalGeschwindigkeit)
			{
				Geschwindigkeit = Geschwindigkeit + Beschleunigung;
			}
		}
		private int EntfernungZumVordermann(Auto Vordermann)
		{
			if (Vordermann.Position - this.Position < 0)
			{
				return Vordermann.Position - this.Position + Straße;
			}
		    return Vordermann.Position - this.Position;
		}
		
		private int EntfernungZurAmpel(Ampel[] ampeln, int t)
		{
			int aktuellerAbstand;
			int minimalerAbstand = Straße;
				
			foreach (Ampel a in ampeln)
			{
				if (a.zeigePhase(t) == 1)
				{
					if (a.Position - this.Position < 0)
					{
						aktuellerAbstand = a.Position - this.Position + Straße;
					}
					else
					{
						aktuellerAbstand = a.Position - this.Position;
					}
					
					if (aktuellerAbstand < minimalerAbstand)
					{
						minimalerAbstand = aktuellerAbstand;
					}
				}
			}
			return minimalerAbstand;
		}
		
		public void Bremsen(Auto Vordermann, Ampel[] ampeln, int t)
		{
			int entfernungZumVordermann = EntfernungZumVordermann(Vordermann);
			int entfernungZurAmpel = EntfernungZurAmpel(ampeln, t);
			int entfernungHindernis;
			
			if (entfernungZurAmpel < entfernungZumVordermann)
			{
				entfernungHindernis = entfernungZurAmpel;
			}
			else
			{
				entfernungHindernis = entfernungZumVordermann;
			}
			
			if (Geschwindigkeit >= entfernungHindernis)
			{
				Geschwindigkeit = entfernungHindernis - 1;
			}
			
			if (Geschwindigkeit < 0)
			{
				Geschwindigkeit = 0;
			}
		}
		
		public void Trödeln()
		{
			if (Zufall.NextDouble() < 0.05 && Geschwindigkeit > 0)
			{
				Geschwindigkeit--;
			}
		}
		
		public void Fahren()
		{
			Position = Position + Geschwindigkeit;
		}
		
		public override string ToString()
		{

			return string.Format("{0},{1}", Geschwindigkeit, Position);
		}

	}
}

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
		private static Random Zufall = new Random();
		
		public double Geschwindigkeit;
		public double MaximalGeschwindigkeit;
		public double Position;
		public double Beschleunigung;
		public long Autonummer;
		
		public Auto()
		{
			MaximalGeschwindigkeit = 5;
			Geschwindigkeit = 0;
			Position = 0;
			Beschleunigung = 1;
		}
		
		public Auto(long index, Auto vordermann, double zielPosi) 
		{
        	this.MaximalGeschwindigkeit = 5;
        	this.Geschwindigkeit = 0;
        	
        	if (vordermann.Position > zielPosi + 10)
        	{
        		this.Position = zielPosi;
        	}
        	else
        	{
        		this.Position = vordermann.Position - 10;
        	}
        	
        	this.Beschleunigung = 1;
        	
        	this.Autonummer = index;
    	}
		
		public Auto(long index, double zielPosi) 
		{
        	this.MaximalGeschwindigkeit = 5;
        	this.Geschwindigkeit = 0;
        	this.Position = zielPosi;
        	this.Beschleunigung = 1;
        	
        	this.Autonummer = index;
    	}
		
		public void Beschleunigen()
		{
			if (Geschwindigkeit < MaximalGeschwindigkeit)
			{
				Geschwindigkeit = Geschwindigkeit + Beschleunigung;
			}
		}
		
		private double EntfernungZumVordermann(Auto Vordermann)
		{
		    return Vordermann.Position - this.Position;
		}
		
		private double EntfernungZurAmpel(Verkehrsregler a, double t)
		{
			double aktuellerAbstand;
			double minimalerAbstand = 10000000;
				
			
				if (a.zeigePhase(t) == 1)
				{
					aktuellerAbstand = a.Position - this.Position;
					
					if (aktuellerAbstand < minimalerAbstand)
					{
						minimalerAbstand = aktuellerAbstand;
					}
				}
			return minimalerAbstand;
		}
		
		public void Bremsen(Auto Vordermann, Verkehrsregler ampel, double t)
		{
			double entfernungZumVordermann = EntfernungZumVordermann(Vordermann);
			double entfernungZurAmpel = EntfernungZurAmpel(ampel, t);
			double entfernungHindernis;
			
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
			// printf("Auto: %3d Zeit: %7.2f")
		}

	}
}

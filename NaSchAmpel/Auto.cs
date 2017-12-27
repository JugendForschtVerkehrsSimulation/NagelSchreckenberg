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
		
		public double Geschwindigkeit;					// v
		public double Position;							// 
		public double Beschleunigung;					// dv
		
		public double MaximaleBeschleunigung = 0.3;		// a	m/s^2
		public double MaximalGeschwindigkeit = 16.7;	// v0	m/s		16.7 ~ 60 km/h
		public double BeschleunigungsExponent = 4;		// 4
		public double BremsExponent = 2;				// 2
		public double minimalerSicherheitsAbstand = 2;	// s0	 m		2
		public double minimaleAbstandsZeit = 1.5;		// T	 s		1.5
		public double Bremskraft = 3;					// b	m/s		3
		
		public long Autonummer;
		
		public Auto()
		{
			Geschwindigkeit = 0;
			Position = 0;
			Beschleunigung = 0;
		}
		
		public Auto(long index, Auto vordermann, double zielPosi) 
		{
			Geschwindigkeit = 0;
			Beschleunigung = 0;
			
        	if (vordermann.Position > zielPosi + 10)
        	{
        		this.Position = zielPosi;
        	}
        	else
        	{
        		this.Position = vordermann.Position - 10;
        	}
        	
        	this.Autonummer = index;
    	}
		
		public Auto(long index, double zielPosi) 
		{
			Geschwindigkeit = 0;
			Beschleunigung = 0;
			
        	this.Position = zielPosi;
        	
        	this.Autonummer = index;
    	}
		
		public void Beschleunigen(double Zeitschritt, Auto Vordermann, Verkehrsregler ampel, double t)
		{
			double entfernungZumVordermann = EntfernungZumVordermann(Vordermann);
			double entfernungZurAmpel = EntfernungZurAmpel(ampel, t);
			double entfernungHindernis;
			double sicherheitsAbstand;		// s*
			double Geschwindigkeitsunterschied;
			
			if (entfernungZurAmpel < entfernungZumVordermann)
			{
				entfernungHindernis = entfernungZurAmpel;
				Geschwindigkeitsunterschied = this.Geschwindigkeit - 0;
			}
			else
			{
				entfernungHindernis = entfernungZumVordermann;
				Geschwindigkeitsunterschied = this.Geschwindigkeit - Vordermann.Geschwindigkeit;
			}
			
			double HilfsAbstand = Geschwindigkeit * minimaleAbstandsZeit + this.Geschwindigkeit * (Geschwindigkeitsunterschied) / entfernungHindernis;
			
			if ( 0 > HilfsAbstand)
			{
				sicherheitsAbstand = minimalerSicherheitsAbstand + 0;			// s*
			}
			else
			{
			sicherheitsAbstand = minimalerSicherheitsAbstand + HilfsAbstand;			// s*
			}
			Beschleunigung = MaximaleBeschleunigung * ( 1 - Math.Pow(( Geschwindigkeit / MaximalGeschwindigkeit ), BeschleunigungsExponent));
			Beschleunigung = Beschleunigung - MaximaleBeschleunigung * Math.Pow(( sicherheitsAbstand / entfernungHindernis ), BremsExponent);
			Geschwindigkeit += Beschleunigung * Zeitschritt;
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

//		public void Trödeln()
//		{
//			if (Zufall.NextDouble() < 0.05 && Geschwindigkeit > 0)
//			{
//				Geschwindigkeit--;
//			}
//		}
		
		public void Fahren(double Zeitschritt)
		{
			Position = Position + Geschwindigkeit * Zeitschritt;
		}
		
		public override string ToString()
		{

			return string.Format("{0},{1}", Geschwindigkeit, Position);
			// printf("Auto: %3d Zeit: %7.2f")
		}

	}
}

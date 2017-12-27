/*
 * Created by SharpDevelop.
 * User: freudis
 * Date: 17.11.2017
 * Time: 18:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace NagelSchreckenberg
{
	/// <summary>
	/// Description of Spur.
	/// </summary>
	public class Spur
	{
		
		public double Setzen;
		public double Anfang;
		public double Ampelposition;
		public double Ende;
		public double Löschen;
		
		public long SpurReferenz;
		public long FahrzeugsIndex = 0;									// Index für Autonummern
		public int maxAutos;
		public long SpurNummer;
		
		public double Länge;											// Ende - Anfang
		public String Straßenname;
		
		public List<Auto> autos = new List<Auto>();
		public Verkehrsregler ampel = new Verkehrsregler();
		
		public Spur(double paramSetzen, double paramAnfang, double paramAmpelposition, double paramEnde, double paramLöschen, int paramMaxAutos, long Index)
		{
			this.Setzen = paramSetzen;
			this.Anfang = paramAnfang;
			this.Ampelposition = paramAmpelposition;
			this.Ende = paramEnde;
			this.Löschen = paramLöschen;
			
			this.maxAutos = paramMaxAutos;
			//this.SpurReferenz = sim.HoleSpurIndex();
			
			this.Länge = Ende - Anfang;
			
			this.SpurNummer = Index;
			
			if (Index == 0)
			{
				this.Straßenname = "Wielandstraße West-Ost";
			}
			else if (Index == 1)
			{
				this.Straßenname = "Wielandstraße Ost-West";
			}
			else if (Index == 2)
			{
				this.Straßenname = "Eberhardtstraße - Talfingerstraße";
			}
			else if (Index == 3)
			{
				this.Straßenname = "Talfingerstraße - Eberhardtstraße";
			}
		}
		
		public void initAmpelInSpur(double ULZ, double GPL, double VER)
		{
			this.ampel.initVerkehrsregler(ULZ, this.Ampelposition, GPL, VER);
		}
		
		public void setzeAuto(int i)
		{
			if ( this.autos.Count < this.maxAutos)
			{
        		if ( this.autos.Count == 0 ) 
        		{
        			this.autos.Add(new Auto(this.HoleIndex(), this.Setzen));
        		}
	        	else 
	        	{
	        		Auto vordermann = this.autos[this.autos.Count-1];
	            	this.autos.Add(new Auto(this.HoleIndex(), vordermann, this.Setzen));
	        	}
   			}
		}
		
		public void Bewegung(double Zeit, double Zeitschritt)
 		{
 			for (int i = 0; i < this.autos.Count; i++) 
 			{
				Auto vordermann = null;
 				if (i == 0)
 				{
					vordermann = new Auto(0, this.Löschen + 10000);
 				}
 				else
 				{
					vordermann = this.autos[i-1];
 				}
 				
 				this.autos[i].Beschleunigen(Zeitschritt, vordermann, this.ampel, Zeit);
// 				this.autos[i].Trödeln();
 			}
 			foreach (Auto a in autos)
 			{
 				a.Fahren(Zeitschritt);
 			}
 			for (int i = 0; i < autos.Count; i++)
 			{
 				if ( autos[i].Position > this.Löschen )
 				{
 					autos.RemoveAt(i);
 				}
 			}
		}
		
		public long HoleIndex()
		{
			long Index = FahrzeugsIndex;
			FahrzeugsIndex++;
			
			return Index;
		}
		
		public double MaximaleGeschwindigkeit(float Position) 
		{
			
			if(Position < -30.0 || Position > 5) {
				return 50/3.6;
			}
			double entfernung = Math.Abs(Position);
			// TODO: maximalgeschwindigkeit bis zur Ampel linear auf 30 km/h reduzieren
			return 30/3.6;
		}
	}
}

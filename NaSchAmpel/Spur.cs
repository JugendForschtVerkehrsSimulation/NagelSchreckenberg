/*
 * Created by SharpDevelop.
 * User: freudis
 * Date: 17.11.2017
 * Time: 18:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NaSchAmpel
{
	/// <summary>
	/// Description of Spur.
	/// </summary>
	public class Spur
	{
		public double Länge;
		public List<Auto> autos = new List<Auto>();
		public Spur()
		{
		}
		
		public double MaximaleGeschwindigkeit(float Position) {
			if(Position < -30.0 || Position > 5) {
				return 50/3.6;
			}
			double entfernung = Math.Abs(Position);
			// TODO: maximalgeschwindigkeit bis zur Ampel linear auf 30 km/h reduzieren
			return 30/3.6;
		}
	}
}

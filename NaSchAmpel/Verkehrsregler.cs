/*
 * Created by SharpDevelop.
 * User: freudis
 * Date: 04.11.2017
 * Time: 15:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace NagelSchreckenberg
{
	/// <summary>
	/// Description of Ampel.
	/// </summary>
	public class Verkehrsregler
	{
		public double Umlaufzeit;
		public double Position;
		public double GrünphasenLänge;
		public double Versetzung;
		
		public Verkehrsregler()
		{
			Umlaufzeit = 0;
			GrünphasenLänge = 0;
			Versetzung = 0;
		}
		
		public void initVerkehrsregler(double ULZ, double POS, double GPL, double VER)
		{
			Umlaufzeit = ULZ;
			Position = POS;
			GrünphasenLänge = GPL;
			Versetzung = VER;
		}
		
		
		public int zeigePhase (double t)
		{
			t = t - Versetzung;
			double a = t / Umlaufzeit;
			double x = t - a * Umlaufzeit;
			
			if (x < GrünphasenLänge)				// 0 = Grün		1 = Rot
			{
				return 0;
			}
			else
			{
				return 1;
			}
		}
	}
}

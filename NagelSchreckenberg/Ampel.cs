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
	public class Ampel
	{
		public int Umlaufzeit;
		public int Status;
		public int Position;
		public int GrünphasenLänge;
		public int Versetzung;
		
		public Ampel(int ULZ, int POSI, int GPL, int VER)
		{
			Umlaufzeit = ULZ;
			Position = POSI;
			GrünphasenLänge = GPL;
			Versetzung = VER;
		}
		
		
		
	}
}

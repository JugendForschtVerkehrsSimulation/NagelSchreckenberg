/*
 * Created by SharpDevelop.
 * User: freudis
 * Date: 06.10.2017
 * Time: 17:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace NagelSchreckenberg
{
	/// <summary>
	/// Description of Auto.
	/// </summary>
	public class Auto
	{
		public static int Straße = 200;
		
		private static Random Zufall = new Random();
		
		public int Geschwindigkeit;
		
		public int MaximalGeschwindigkeit;
		
		public int Position;
		
		public int Beschleunigung;
		
		public Auto()
		{
			MaximalGeschwindigkeit = 5;
			Geschwindigkeit = Zufall.Next(1, MaximalGeschwindigkeit + 1);
			Position = 0;
			Beschleunigung = 1;
		}
		
		public void Beschleunigen()
		{
			if (Geschwindigkeit < MaximalGeschwindigkeit)
			{
				Geschwindigkeit = Geschwindigkeit + Beschleunigung;
			}
		}
		private int Entfernung(Auto Vordermann)
		{
//			Console.Write(" [VM:" + Vordermann.Position );
//			Console.Write(" This:" + this.Position +"] ");
			if (Vordermann.Position - this.Position < 0)
			{
				return Vordermann.Position - this.Position + Straße;
			}
		    return Vordermann.Position - this.Position;
		}
		
		public void Bremsen(Auto Vordermann)
		{
			int entfernungZumVordermann = Entfernung(Vordermann);
			
			//Console.Write(" -> D: " + entfernungZumVordermann );
			if (Geschwindigkeit >= entfernungZumVordermann)
			{
				Geschwindigkeit = entfernungZumVordermann - 1;
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
			if (Position >= Straße)
			{
				Position = Position - Straße;
			}
		}
		public override string ToString()
		{
			//return string.Format("[Auto Geschwindigkeit={0}, Position={1}]", Geschwindigkeit, Position);
			return string.Format("{0},{1}", Geschwindigkeit, Position);
		}

	}
}

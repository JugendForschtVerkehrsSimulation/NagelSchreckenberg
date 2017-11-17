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
		public float Länge;
		public List<Auto> autos = new List<Auto>();
		public Spur()
		{
		}
	}
}

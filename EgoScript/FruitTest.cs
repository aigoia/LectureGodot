using System.Collections.Generic;
using System.Linq;
using Godot;

namespace GodotTest.EgoScript;

public partial class FruitTest : Node2D
{
	public override void _Ready()
	{
		MakeFruit();
	}
	
	void MakeFruit()
	{
		var fruits = new List<Fruit>
		{
			new Fruit(FruitType.Apple, Colors.Red),
			new Fruit(FruitType.Apple, Colors.Green),
			new Fruit(FruitType.Banana, Colors.Yellow),
			new Fruit(FruitType.Melon, Colors.Green),
			new Fruit(FruitType.Cherry, Colors.Red)
		};

		fruits.RemoveAll(i => i.FruitColor == Colors.Yellow);
		var fruit = fruits.Find(i => i.FruitType == FruitType.Apple);
		
		var isReal = (fruit.FruitType) switch
		{
			FruitType.Apple => true,
			FruitType.Banana => false,
			FruitType.Melon => false,
			FruitType.Cherry => false,
			_ => default
		};

		GD.Print(isReal);
	}

	public enum FruitType
	{
		None, Apple, Banana, Melon, Cherry,
	}

	public class Fruit
	{
		public readonly FruitType FruitType;
		public Color FruitColor;

		public Fruit(FruitType type, Color color)
		{
			FruitType = type;
			FruitColor = color;
		}
	}
}

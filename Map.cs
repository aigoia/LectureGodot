using System;
using Godot;

namespace GodotTest;

public partial class Map : Sprite2D
{
	public override void _Ready()
	{
		GD.Print("Hello World!");
	}
}


using Godot;

namespace GodotTest.EgoScript;

public partial class Main : Node2D
{
	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Escape)) GetTree().Quit();
	}
}

using Godot;

namespace GodotTest.EgoScript;

public partial class World : Sprite2D
{
	public override void _Ready() => GD.Print(Say("Hello Godot!"));
	
	string Say(string say)
	{
		return say.ToLower() switch 
		{
			"hello world!" => "Nice to meet you!",
			"hello world" => "Nice to meet you",
			"hello godot!" => "Good to see you again!",
			"hello godot" => "Good to see you again",
			_ => say
		};
	}
}

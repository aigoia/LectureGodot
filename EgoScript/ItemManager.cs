using System.Collections.Generic;
using System.Linq;
using Godot;

namespace GodotTest.EgoScript;

public partial class ItemManager : Node2D
{
	readonly List<Item> _items = new List<Item>();
	
	public override void _Ready() => InitItem();
	
	void InitItem()
	{
		GetChildren().ToList().ForEach(i =>
		{
			_items.Add(i.GetNode<Item>("."));
			i.GetNode<Node2D>(".").Hide();
		});

		_items.ForEach(i => GD.Print($"{i.Name} is hide"));
	}
}

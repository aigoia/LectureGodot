using System.Threading.Tasks;
using Godot;

namespace GodotTest.EgoScript;

public partial class Item : Node2D
{
	int DelayTime => 16;
	bool _isEntered = false;
	
	Player _player;

	async void ItemShowEvent()
	{
		if (_player is null) return;
		
		while (_isEntered)
		{
			await Task.Delay(DelayTime);

			if (_player.IsTrack is false) continue;
			

			Show();
			_isEntered = false;
		}
	}
	
	void _on_area_2d_body_entered(Node2D body)
	{
		_player = body.GetParent().GetNode<Player>(".");
		_isEntered = true;
		ItemShowEvent();
	}
	
	void _on_area_2d_body_exited(Node2D body)
	{
		_isEntered = false;
	}
}

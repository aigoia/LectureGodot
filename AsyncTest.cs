using System.Threading.Tasks;
using Godot;

namespace GodotTest;

public partial class AsyncTest : Node2D
{
	int DelayTime => 16;
	float RotateAngle => 1f;
	Node2D _icon;
	bool _isRotate = true;
	
	public override void _Ready()
	{
		_icon = GetNode<Sprite2D>("Icon");
		
		// AsyncRoutine();
	}

	async void AsyncRoutine()
	{
		while (_isRotate)
		{
			_icon.RotationDegrees += RotateAngle;
			await Task.Delay(DelayTime);
		}
	}
}

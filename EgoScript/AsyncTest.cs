using System;
using System.Threading.Tasks;
using Godot;

namespace GodotTest.EgoScript;

public partial class AsyncTest : Node2D
{
	int DelayTime => 16;
	float RotateAngle => 1f;
	
	bool _isRotate = true;
	
	Sprite2D IconNode => GetNode<Sprite2D>("Icon");
	
	public override void _Ready()
	{
		// AsyncRoutine();
	}

	async void AsyncRoutine()
	{
		while (_isRotate)
		{
			IconNode.RotationDegrees += RotateAngle;
			await Task.Delay(DelayTime); // dont use await Task.Yield() like Unity
		}
	}
	
	// unity-like wait until
	async Task WaitUntilAsync(Func<bool> condition)
	{
		while (!condition.Invoke())
		{
			await Task.Delay(DelayTime); 
		}
	}
}

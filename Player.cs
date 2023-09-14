using Godot;

namespace GodotTest;

public partial class Player : Node2D
{
	float _horizontalMovement = 0; 
	float MoveSpeed => 50;
	Vector2 _velocity = Vector2.Zero;
	Vector2 p = Vector2.Zero;
	bool _track = false;

	public override void _Process(double delta)
	{
		PlayerMovement(delta);
	}
	
	public override void _Input(InputEvent @event)
	{
		_horizontalMovement = 0;
		
		if (@event is not InputEventKey eventKey) return;
		
		var isLeft = eventKey.Keycode == Key.A;
		var isRight = eventKey.Keycode == Key.D;
		var isDown = eventKey.Keycode == Key.S;
		
		_horizontalMovement += isLeft ? -1 : 0;
		_horizontalMovement += isRight ? 1 : 0;
		_track = isDown ? true : false;
	}
	
	void PlayerMovement(double delta) {
		if (!(Input.IsKeyPressed(Key.A) || Input.IsKeyPressed(Key.D))) return;
		
		_velocity.X = _horizontalMovement * MoveSpeed;
		MoveLocalX((float)(_velocity.X * delta));
	}
}

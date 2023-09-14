using System.Reflection.Metadata.Ecma335;
using Godot;

namespace GodotTest;

enum PlayerState { Idle, Track, Walk }
enum PlayerDirection { None, Right, Left }

public partial class Player : Node2D
{
	float _horizontalMovement = 0; 
	float MoveSpeed => 50;
	Vector2 _velocity = Vector2.Zero;
	bool _track = false;
	
	Sprite2D _idle;
	
	Key Left => Key.A;
	Key Right => Key.D;
	Key Down => Key.S;

	public override void _Ready()
	{
		_idle = GetNode<Sprite2D>("Idle");
		_idle.GetNode<AnimationPlayer>("AnimationPlayer").Play("Idle");
	}

	public override void _Process(double delta)
	{
		Move(delta);
		State();
	}
	
	void Move(double delta) 
	{
		_horizontalMovement = 0;
		
		if (Input.IsKeyPressed(Left) && Input.IsKeyPressed(Right)) return;
		if (Input.IsKeyPressed(Left)) _horizontalMovement = -1;
		if (Input.IsKeyPressed(Right)) _horizontalMovement = 1;
		
		_velocity.X = _horizontalMovement * MoveSpeed;
		MoveLocalX((float)(_velocity.X * delta));
	}
	
	void State() 
	{
		PlayerState playerState = PlayerState.Idle;
		
		if (_velocity.X < 0) {
			_idle.FlipH = true;
		} else if (_velocity.X > 0) {
			_idle.FlipH = false;
		}

		playerState = (_velocity.X > 0 || _velocity.Y < 0) ? PlayerState.Walk : (_track) ? PlayerState.Track : PlayerState.Idle ;
		// current = playerState;
	}
}

using Godot;

namespace GodotTest.EgoScript;

public partial class Player : Node2D
{
	float MoveSpeed => 60;
	
	Key Left => Key.A;
	Key Right => Key.D;
	Key Down => Key.S;
	
	Vector2 _velocity = Vector2.Zero;
	float _horizontalMovement = 0;
	bool _track = false;
	
	Sprite2D _image;
	AnimationPlayer _animationPlayer;

	public override void _Ready()
	{
		_image = GetNode<Sprite2D>("Image");
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		
		_animationPlayer.Play("Idle");
	}

	public override void _Process(double delta)
	{
		Move(delta);
		State();
	}
	
	void Move(double delta) 
	{
		_horizontalMovement = Input.IsKeyPressed(Left) ? -1 : Input.IsKeyPressed(Right) ? 1 : 0;
		_track = Input.IsKeyPressed(Down);
		
		_velocity.X = _horizontalMovement * MoveSpeed;
		MoveLocalX((float)(_velocity.X * delta));
	}
	
	void State() 
	{
		_image.FlipH = _velocity.X is 0 ? _image.FlipH : _velocity.X < 0;
		_animationPlayer.Play(_velocity.X is > 0 or < 0 ? "Walk" : _track ? "Track" : "Idle");
	}
}

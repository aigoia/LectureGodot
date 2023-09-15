using Godot;

namespace GodotTest.EgoScript;

public partial class Player : Node2D
{
	float _horizontalMovement = 0; 
	float MoveSpeed => 60;
	Vector2 _velocity = Vector2.Zero;
	bool _track = false;
	
	Sprite2D _image;
	AnimationPlayer _animationPlayer;
	
	Key Left => Key.A;
	Key Right => Key.D;
	Key Down => Key.S;

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
		_horizontalMovement = 0;
		
		if (Input.IsKeyPressed(Left) && Input.IsKeyPressed(Right)) return;
		
		if (Input.IsKeyPressed(Left)) _horizontalMovement = -1;
		if (Input.IsKeyPressed(Right)) _horizontalMovement = 1;
		
		_track = Input.IsKeyPressed(Down);
		
		_velocity.X = _horizontalMovement * MoveSpeed;
		MoveLocalX((float)(_velocity.X * delta));
	}
	
	void State() 
	{
		if (_velocity.X is not 0) _image.FlipH = (_velocity.X < 0);
		_animationPlayer.Play((_velocity.X is > 0 or < 0) ? "Walk" : (_track) ? "Track" : "Idle");
	}
}

using System;
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
	public bool IsTrack => _isTrack;
	bool _isTrack = false;
	
	Sprite2D ImageNode => GetNode<Sprite2D>("Image");
	AnimationPlayer AnimationNode => GetNode<AnimationPlayer>("AnimationPlayer");

	public override void _Ready()
	{
		AnimationNode.Play("Idle");
	}

	public override void _Process(double delta)
	{
		Move(delta);
		State();
	}
	
	void Move(double delta)
	{
		_horizontalMovement = Input.IsKeyPressed(Left) ? -1 : Input.IsKeyPressed(Right) ? 1 : 0;
		_isTrack = Input.IsKeyPressed(Down);
		
		_velocity.X = _horizontalMovement * MoveSpeed;
		MoveLocalX((float)(_velocity.X * delta));
	}
	
	void State()
	{
		ImageNode.FlipH = _velocity.X is 0 ? ImageNode.FlipH : _velocity.X < 0;
		AnimationNode.Play(_velocity.X is not 0 ? "Walk" : _isTrack ? "Track" : "Idle");
	}
}



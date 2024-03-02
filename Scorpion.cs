using Godot;
using System;

public partial class Scorpion : CharacterBody2D
{
	public const float Speed = 2.0f;
	private AnimatedSprite2D _animatedSprite;
	
	public CharacterBody2D _Ouro;
	
	public Vector2 delayedPos;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	public override void _Ready()
	{	
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_Ouro = GetParent().GetNode<CharacterBody2D>("Ouro");
		base._Ready();
	}
	
	public override void _PhysicsProcess(double delta)
	{
		_animatedSprite.Play("default");
		if(Position.X > delayedPos.X)
			_animatedSprite.FlipH = false;
		else
			_animatedSprite.FlipH = true;
		Velocity += (delayedPos - Position) / 100;
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta * 2;
		Velocity = velocity;
		MoveAndSlide();
	}

	private void _on_attack_area_body_entered(Node2D body)
	{
		if(body.Name == "Ouro")
			GetTree().ChangeSceneToFile("res://menuLevel/menu.tscn");
	}
	private void _on_attack_timer_timeout()
	{
		delayedPos = _Ouro.Position;
	}
	private void _stomp(Node2D body)
	{
		if(body.Name == "Ouro")
			QueueFree();
	}
}

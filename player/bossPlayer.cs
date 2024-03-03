using Godot;
using System;

public partial class bossPlayer : CharacterBody2D
{
	public const float Speed = 5.0f;
	public const float JumpVelocity = -400.0f;
	
	private AnimatedSprite2D _animatedSprite;
	
	public CharacterBody2D _Ouro;
	
	public int startState = 0;
	
	public Vector2 delayedPos;
	
	public Timer _timer;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	public override void _Ready()
	{	
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_Ouro = GetParent().GetNode<CharacterBody2D>("Ouro");
		base._Ready();
		var random = new RandomNumberGenerator();
		_timer = GetParent().GetNode<Timer>("Countdown");
	}
	
	
	public override void _PhysicsProcess(double delta)
	{
		// Skuffed state machine
		if(_timer.TimeLeft > 70)
		{
			_animatedSprite.Play("bobbing");
			if(Position.X > delayedPos.X)
				_animatedSprite.FlipH = true;
			else
				_animatedSprite.FlipH = false;
			Velocity += (delayedPos - Position) / 100;
			Vector2 velocity = Velocity;
			// Add the gravity.
			if (!IsOnFloor())
				velocity.Y += gravity * (float)delta * 2;
			else
				velocity.Y = JumpVelocity;
			Velocity = velocity;
			MoveAndSlide();
		}
		if(_timer.TimeLeft <= 0)
			GetTree().ChangeSceneToFile("res://player/end_credit.tscn");
		else
		{
			_animatedSprite.Play("flying");
			if(Position.X > delayedPos.X)
				_animatedSprite.FlipH = true;
			else
				_animatedSprite.FlipH = false;
			Position += (delayedPos - Position) / 40;
		}
	}
	private void _on_timer_timeout()
	{
		delayedPos = _Ouro.Position;
	}
	private void _on_hit_box_area_shape_entered(Rid area_rid, Area2D area, long area_shape_index, long local_shape_index)
	{
		if(area.Name == "SwordArea")
			startState++;
			//QueueFree();
	}
	private void _on_attack_box_body_entered(Node2D body)
	{
		if(body.Name == "Ouro")
		{
			var global = (PlayerVariables) GetNode("/root/PlayerVariables");
			global.ResetSouls();
			GetTree().ChangeSceneToFile("res://player/boss.tscn");
		}
	}

}

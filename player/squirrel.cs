using Godot;
using System;

public partial class squirrel : CharacterBody2D
{
	public const float Speed = 2.0f;
	private AnimatedSprite2D _animatedSprite;
	
	//public CharacterBody2D _Ouro;
	
	public Vector2 delayedPos;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();


	public override void _Ready()
	{	
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		//_Ouro = GetParent().GetNode<CharacterBody2D>("Ouro");
		base._Ready();
	}
	
	public override void _PhysicsProcess(double delta)
	{
		_animatedSprite.Play("default");
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
		{
			var global = (PlayerVariables) GetNode("/root/PlayerVariables");
			global.ResetSouls();
			GetTree().ChangeSceneToFile("res://player/death_scene.tscn");
		}
	}
	private void _on_attack_timer_timeout()
	{
		//delayedPos = _Ouro.Position;
	}
	private void _on_hit_box_body_entered(Node2D body)
	{
		if(body.Name == "Ouro")
			QueueFree();
	}
}

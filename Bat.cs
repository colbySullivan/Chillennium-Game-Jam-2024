using Godot;
using System;

public partial class Bat : CharacterBody2D
{
	public const float Speed = 5.0f;
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
		var random = new RandomNumberGenerator();
		Position = _Ouro.Position + new Vector2(random.RandiRange(100, 500),random.RandiRange(100, 500));
	}
	
	
	public override void _PhysicsProcess(double delta)
	{
		_animatedSprite.Play("default");
		if(Position.X > delayedPos.X)
			_animatedSprite.FlipH = false;
		else
			_animatedSprite.FlipH = true;
		Position += (delayedPos - Position) / 40;
	}
	private void _on_area_2d_body_entered(Node2D body)
	{
		if(body.Name == "Ouro")
		{
			var global = (PlayerVariables) GetNode("/root/PlayerVariables");
			global.ResetSouls();
			GetTree().ChangeSceneToFile("res://menuLevel/menu.tscn");
		}
	}
	private void _on_timer_timeout()
	{
		delayedPos = _Ouro.Position;
	}
	private void _stomp(Node2D body)
	{
		if(body.Name == "Ouro")
			QueueFree();
	}
	private void _attacked(Rid area_rid, Area2D area, long area_shape_index, long local_shape_index)
	{
		if(area.Name == "SwordArea")
			QueueFree();
	}
}

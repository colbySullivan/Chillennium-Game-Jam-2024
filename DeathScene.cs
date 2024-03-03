using Godot;
using System;

public partial class DeathScene : Node2D
{
	private AnimatedSprite2D _animatedSprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_animatedSprite.Play("default");
	}
	private void _on_timer_timeout()
	{
		var global = (PlayerVariables) GetNode("/root/PlayerVariables");
		global.ResetSouls();
		GetTree().ChangeSceneToFile("res://menuLevel/menu.tscn");
	}

}

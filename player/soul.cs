using Godot;
using System;

public partial class soul : StaticBody2D
{
	private AnimatedSprite2D _animatedSprite;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Access to animation globally
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_animatedSprite.Play("default");
		
		
	}
	private void _on_area_2d_body_entered(Node2D body)
	{
		//Godot.GD.Print(body.Name);
		if(body.Name == "Ouro")
		{
			var global = (PlayerVariables) GetNode("/root/PlayerVariables");
			Godot.GD.Print("Player currently has " + global.GetSouls() + " souls");
			global.AddSoul();
			Godot.GD.Print("Player has collected " + global.GetSouls() + " souls");
			QueueFree();	
		}
	}
}



using Godot;
using System;

public partial class CanvasLayer : Godot.CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var global = (PlayerVariables) GetNode("/root/PlayerVariables");
		var message = GetNode<Label>("Soul count");
		message.Text = "Souls: " + global.GetSouls() + "\n" + "Lives: " + global.GetLives();
		message.Show();
	}
}

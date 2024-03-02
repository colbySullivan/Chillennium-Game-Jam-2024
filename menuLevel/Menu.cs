using Godot;
using System;

public partial class Menu : Control
{
	private AnimatedSprite2D LoadAnim;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Initializes the menu by grabbing focus on the "Start" button
		GetNode<Button>("VBoxContainer/Start").GrabFocus();
		LoadAnim = GetNode<AnimatedSprite2D>("LoadIn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Currently, no continuous processing logic in this method
	}

	// Called when the "Start" button is pressed
	private void _on_start_pressed()
	{
		// Changes the scene to the "level1.tscn" file
		LoadAnim.Play("default");
		// Moved this to after animation is done
		//GetTree().ChangeSceneToFile("res://levels/level1.tscn");
	}

	// Called when the "Quit" button is pressed
	private void _on_quit_pressed()
	{
		// Quits the game
		GetTree().Quit();
	}
	private void _on_load_in_animation_looped()
	{
		GetTree().ChangeSceneToFile("res://player/cutscene_1.tscn");
	}
}

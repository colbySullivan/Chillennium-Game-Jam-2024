using Godot;
using System;

public partial class end_credit : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void _on_audio_stream_player_finished()
	{
		GetTree().ChangeSceneToFile("res://scenes/menu.tscn");
	}
	private void _on_video_stream_player_finished()
	{
		GetTree().ChangeSceneToFile("res://scenes/menu.tscn");
	}
}

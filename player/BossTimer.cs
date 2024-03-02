using Godot;
using System;

public partial class BossTimer : CanvasLayer
{
	public Timer _timer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer = GetParent().GetNode<Timer>("Countdown");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var message = GetNode<Label>("TimeLeft");
		message.Text = "Time left: " + _timer.TimeLeft;
		message.Show();
	}
}

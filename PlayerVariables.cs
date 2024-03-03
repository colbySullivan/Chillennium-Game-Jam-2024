using System;
using Godot;

public partial class PlayerVariables : Node
{
  	private int souls;
	private int lives;

  	public override void _Ready()
  	{
		souls = 0;
		lives = 3;
  	}

  	public int GetSouls()
	{
		return souls;
  	}
	
	public void AddSoul()
	{
		souls++;
  	}
	public void ResetSouls()
	{
		souls = 0;
		lives = 3;
  	}
	public int GetLives()
	{
		return lives;
  	}
	public void RemoveLife()
	{
		lives--;
  	}
	public void FinalLevel()
	{
		lives = 5;
  	}

}

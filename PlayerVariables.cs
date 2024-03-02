using System;
using Godot;

public partial class PlayerVariables : Node
{
  private int souls;

  public override void _Ready()
  {
	souls = 0;
  }

  public int GetSouls(){
	return souls;
  }
	public void AddSoul(){
		souls++;
  }

}

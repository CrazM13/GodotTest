using Godot;
using System;

public partial class QuitButton : Button
{
	public void _on_pressed()
	{
		GetTree().Quit();
	}
}

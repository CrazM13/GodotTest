using Godot;
using System;

public partial class CameraFollow : Camera2D {

	[Export] private Node2D target;

	public override void _Process(double delta) {
		base._Process(delta);

		if (target != null && target.Position.Y < Position.Y) {
			Position = new Vector2(Position.X, target.Position.Y);
		}

	}


}

using Godot;
using System;
using System.Security.AccessControl;

public partial class PlayerMovement : CharacterBody2D {
	[Export] private float speed = 300.0f;
	[Export] private float jumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready() {

		Velocity = Vector2.Right * speed;

		base._Ready();
	}

	public override void _PhysicsProcess(double delta) {
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()) {
			velocity.Y += gravity * (float) delta;
		} else {
			velocity.Y = 0;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor()) {
			velocity.Y = jumpVelocity;
		}

		Velocity = velocity;
		KinematicCollision2D collision = MoveAndCollide(Velocity * (float) delta, true);

		if (collision != null) {

			Vector2 normal = collision.GetNormal();
			Velocity = new Vector2(Velocity.X + (Mathf.Abs(normal.X) * -2 * Velocity.X), Velocity.Y);
		}

		MoveAndSlide();
	}

	private void OnScreenExited() {
		GD.Print("LOSE");
	}

}

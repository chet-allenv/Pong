using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	[Export] public float Speed = 300f; 
	private Vector2 direction;

	public override void _Ready()
	{
		RandomizeDirection();
		InitializePosition();
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = direction * Speed;
		
		KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);

		if (collision != null)
		{
			direction = direction.Bounce(collision.GetNormal());

			direction = direction.Normalized();

			Speed *= 1.01f;
		}
	}

	private void RandomizeDirection()
	{
		float angle = (float)GD.RandRange(0, Mathf.Tau);
		direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
	}

	private void InitializePosition()
	{
		Position = new Vector2(0, 0);
	}
}

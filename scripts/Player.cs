using Godot;
using System;

public partial class Player : CharacterBody2D
{	
    public override void _Ready()
    {
        Sprite2D sprite2D = GetNode<Sprite2D>("PlayerPaddleSprite");

		CollisionShape2D collisionBox = GetNode<CollisionShape2D>("PlayerPaddleCollisionBox");

		RectangleShape2D rectangle = new();

		rectangle.Size = sprite2D.Texture.GetSize() / 2;

		collisionBox.Shape = rectangle;

		CollisionShape2D bottomWall = GetNode<CollisionShape2D>("../BottomWall/BottomWallCollisionBox");

    }
    

    public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;


		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.Y = Mathf.MoveToward(0, velocity.Y, Speed);
		}

		if (!(Input.IsActionPressed("ui_up") || Input.IsActionPressed("ui_down")))
		{
			velocity = Vector2.Zero;
		}



		Velocity = velocity;
		MoveAndSlide();
	}
}

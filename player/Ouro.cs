using Godot;
using System;

public partial class Ouro : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	
	private AnimatedSprite2D _animatedSprite;
	
	private RayCast2D _ray;
	
	private String _sceneName;

	public override void _Ready()
	{
		// Access to animation globally
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_ray = GetNode<RayCast2D>("RayCast2D");
		_sceneName = GetTree().CurrentScene.Name;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		_animatedSprite.Play("idle");
		
		//`draw_line(RaycastWeapon.position, RaycastWeapon.get_collision_point(), Color(1, 0, 0), 1)`
//
		//`draw_circle(RaycastWeapon.get_collision_point(), 5, Color(1,0,0))`
		//ToLocal(_ray.GetCollisionPoint());
		//if (_ray.IsColliding())
		//DrawLine(Position, new Vector2(10,10), new Color(1, 0, 0), 1);
		//_ray.DrawLine(Vector2.Zero, ToLocal(_ray.GetCollisionPoint()), new Color(1, 1, 0), 1);
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	private void _on_ray_cast_2d_draw()
	{
		DrawLine(Vector2.Zero, new Vector2(10,10), new Color(1, 1, 0), 1);
	}
}




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
	
	private bool grapple = false;
	
	public bool has_double_jump = true;

	public bool facing_left;
	
	public Vector2 direction;

	public override void _Ready()
	{
		// Access to animation globally
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_ray = GetNode<RayCast2D>("RayCast2D");
		_sceneName = GetTree().CurrentScene.Name;
		_animatedSprite.Play("walking");
	}
	
	public override void _Draw()
	{
		if (_ray.IsColliding())
		{
			DrawLine(Vector2.Zero, ToLocal(_ray.GetCollisionPoint()), new Color(0, 1, 0, 1), 1);
			DrawCircle(ToLocal(_ray.GetCollisionPoint()), 5, new Color(0, 1, 0, 1));
			has_double_jump = true;
		}
		
	}
	
	public override void _PhysicsProcess(double delta)
	{
		
		//`draw_line(RaycastWeapon.position, RaycastWeapon.get_collision_point(), Color(1, 0, 0), 1)`
//
		//`draw_circle(RaycastWeapon.get_collision_point(), 5, Color(1,0,0))`
		//ToLocal(_ray.GetCollisionPoint());
		if (_ray.IsColliding())
			_on_ray_cast_2d_draw();
		else
			grapple = false;
		//DrawLine(Position, new Vector2(10,10), new Color(1, 0, 0), 1);
		//_ray.DrawLine(Vector2.Zero, ToLocal(_ray.GetCollisionPoint()), new Color(1, 1, 0), 1);
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
			_animatedSprite.Play("jump");
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && ((IsOnFloor() || grapple) || has_double_jump))
		{
			velocity.Y = JumpVelocity;
			if (has_double_jump)
			{
				has_double_jump = false;
				velocity.Y = JumpVelocity;	
			}	
		}
		if(IsOnFloor())
		{
			_animatedSprite.Play("walking");
			has_double_jump = true;
		}
		

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("left", "right", "up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		
		if (direction.X > 0)
		{
			facing_left = false;
			_animatedSprite.FlipH = false;
		}
			
		else if (direction.X < 0)
		{
			facing_left = true;
			_animatedSprite.FlipH = true;
		}

		Velocity = velocity;
		MoveAndSlide();
		swing_sword();
	}
	
	public void swing_sword()
	{
		var node = GetNode<CollisionShape2D>("SwordArea/CollisionShape2D");
		// Sword starts to the right
		node.Position = node.right;
		if (Input.IsActionJustPressed("fight"))
		{
			//_animatedSprite.Play("fight");
			if(facing_left)
				node.Position = node.left;
			// Renable sword area hitbox
			node.Disabled = false;
		}
		else
			node.Disabled = true;
	}
	
	private void _on_ray_cast_2d_draw()
	{
		grapple = true;
		QueueRedraw();
	}
}

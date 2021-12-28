using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	public Vector2 velocity = new Vector2();
	public AnimatedSprite aSprite;
	public Label aLabel_Jumps;
	public Label aLabel_State;

	[Export]
	public int SPEED = 200;
	[Export]
	public int SPEED_MAX = 250;
	[Export]
	public int GRAVITY = 20;
	[Export]
	public int GRAVITY_MAX = 300;
	[Export]
	public int JUMP_FORCE = 500;
	[Export]
	public int JUMPS = 1;
	int jumpsCount = 0;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		aSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		aLabel_Jumps = GetNode<Label>("Label_Jumps");
		aLabel_State = GetNode<Label>("Label_State");

	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{

	}
	public override void _PhysicsProcess(float delta)
	{

	}

	public void Movement()
	{
		// Move LR
		Vector2 tmp_v = new Vector2();
		tmp_v.x = Input.GetActionStrength("Move_Right") - Input.GetActionStrength("Move_Left");
		velocity.x = tmp_v.x * SPEED;

		if (velocity.x != 0)
		{
			aSprite.FlipH = (velocity.x > 0) ? false : true;
			// aSprite.Play("Walk");
		}
		else
		{
			// aSprite.Play("Idle");

		}

		velocity = MoveAndSlide(velocity, Vector2.Up);
		GD.Print("Movement Velocity: ", velocity);
	}

	public void Gravity()
	{
		// Gravity
		velocity.y = Math.Min(velocity.y + GRAVITY, GRAVITY_MAX);
		GD.Print("Gravity Velocity: ", velocity);
	}
	public void Jump()
	{

		// Gravity
		if (Input.IsActionJustPressed("Button_A") && jumpsCount < JUMPS)
		{
			velocity.y = -JUMP_FORCE;
			GD.Print("Player ---------------- Jump: ", velocity);
			jumpsCount++;

		}
		if (IsOnFloor())
		{
			jumpsCount = 0;
		}
		// aLabel_Jumps.Text = jumpsCount.ToString();

	}

	public void Attack()
	{
		if (Input.IsActionJustPressed("Button_B"))
		{
			GD.Print("\n ---------------- Attack ");
			aSprite.Play("Attack");
		}
	}

}

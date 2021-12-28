using Godot;
using System;

public class Attack : ImpStates
{

	[Export]
	public Player pl;

	float x_detect = 0;
	float y_detect = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Attack Ready");
		pl = GetNode<Player>("../../../Player");
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }

	public override void Logic()
	{
		GD.Print("-------> Attack logic");

		// pl.Gravity();
		pl.Movement();
		// pl.Jump();

		// x_detect = Input.GetActionStrength("Move_Right") - Input.GetActionStrength("Move_Left");

		// if (!pl.IsOnFloor())
		// 	pl.velocity.y = Math.Max(pl.velocity.y + pl.GRAVITY, pl.GRAVITY_MAX);
		// pl.velocity = pl.MoveAndSlide(pl.velocity, Vector2.Up);
		// GD.Print("Fall Velocity: ", pl.velocity);
	}
	public override void GetInput() { }

	public override GSTATE GetTransition()
	// public override string GetTransition()
	{
		if (pl.IsOnFloor())
		{
			if (pl.velocity.y < 0)
			{
				GD.Print("Fall return Jump ");
				return GSTATE.JUMP;
				// return "Jump";
			}
			else
			{
				if (pl.velocity.x != 0)
				// if (x_detect != 0)
				{
					GD.Print("fall return walk");
					return GSTATE.WALK;
					// return "Walk";
				}
				else
				{
					GD.Print("fall return idle");
					return GSTATE.IDLE;
					// return "Idle";
				}
			}
		}
		else
		{
			if (pl.velocity.y < 0)
			{
				GD.Print("Fall return Jump ");
				return GSTATE.JUMP;
				// return "Jump";
			}
		}


		return GSTATE.EMPTY;
	}
	public override void Exit()
	{
		GD.Print("@@@@@@@@@@@@@@@@@@@@@@");
		pl.aSprite.Stop();
	}

	public override void Enter()
	{
		pl.aSprite.Play("Fall");
	}
}

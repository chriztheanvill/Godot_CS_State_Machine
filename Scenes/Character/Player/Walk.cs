using Godot;
using System;

public class Walk : ImpStates
{
	[Export]
	public Player pl;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		pl = GetNode<Player>("../../../Player");

	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
	public override void Logic()
	{
		GD.Print("\n++++++ Walk logic");
		pl.Gravity();
		pl.Movement();
		pl.Jump();
		pl.Attack();

	}
	public override GSTATE GetTransition()
	{

		if (!pl.IsOnFloor())
		{
			// if (pl.velocity.y < 0)
			// {
			// 	GD.Print("Walk return Jump");
			// 	return GSTATE.JUMP;
			// 	// return "Walk";
			// 	// return "Jump"; // Correct
			// }
			// else 
			if (pl.velocity.y > 0)
			{
				GD.Print("Walk return fall");
				// return "Walk";
				return GSTATE.FALL; // Correct
									// return "Fall"; // Correct
			}

		}
		else
		{
			if (pl.velocity.y < 0)
			{
				GD.Print("Walk return Jump");
				return GSTATE.JUMP;
				// return "Walk";
				// return "Jump"; // Correct
			}
			else if (pl.velocity.x == 0)
			{
				GD.Print("Walk return idle");
				return GSTATE.IDLE;
				// return "Idle";
			}
		}
		// else if (pl.velocity.x == 0)
		// {
		// 	GD.Print("Walk return idle");
		// 	return GSTATE.IDLE;
		// 	// return "Idle";
		// }
		// else
		// {
		// 	GD.Print("Walk return walk");

		// }

		return GSTATE.EMPTY;
		// return "";
	}
	public override void GetInput()
	{
	}

	public override void Exit()
	{
		GD.Print("@@@@@@@@@@@@@@@@@@@@@@");
		pl.aSprite.Stop();
	}

	public override void Enter()
	{
		GD.Print("==========================");
		pl.aSprite.Play("Run");
		// pl.aSprite.Play("Walk");
	}
}

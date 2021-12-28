using Godot;
using System;
using System.Collections.Generic;

public class Idle : ImpStates
{
	public Idle()
	{

	}

	[Export]
	public Player pl;

	[Export]
	public AnimatedSprite asprite;
	// [Export]
	// public States st;

	float x_detect = 0;
	float y_detect = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Idle Ready");
		pl = GetNode<Player>("../../../Player");
		asprite = GetNode<AnimatedSprite>("../../AnimatedSprite");
		// st = GetNode<States>("../States").state;

		// LSTATE.Add("Idle");
		// LSTATE.Add("Walk");
		// LSTATE.Add("Attack");
		// LSTATE.Add("Jump");
		// LSTATE.Add("Fall");
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }


	public override void Logic()
	{
		GD.Print("Idle logic");
		pl.Gravity();
		pl.Movement();
		pl.Jump();
		pl.Attack();
		// x_detect = Input.GetActionStrength("Move_Right") - Input.GetActionStrength("Move_Left");
		// if (!pl.IsOnFloor())
		// {
		// 	y_detect = Math.Max(pl.velocity.y + pl.GRAVITY, pl.GRAVITY_MAX);
		// }

	}
	public override GSTATE GetTransition()
	{

		if (!pl.IsOnFloor())
		{
			if (pl.velocity.y < 0)
			// if (y_detect < 0)
			{
				GD.Print("Idle return Jump");
				return GSTATE.JUMP;
				// return "Walk";
				// return "Jump"; // Correct
			}
			else if (pl.velocity.y > 0)
			// if (y_detect > 0)
			{
				GD.Print("Idle return fall");
				return GSTATE.FALL;
				// return LSTATE[0]; // Corrent
				// return "Fall"; // Corrent
			}
		}

		if (pl.velocity.x != 0)
		// if (x_detect != 0)
		{
			GD.Print("Idle return walk");
			return GSTATE.WALK;
			// return "Walk";
		}

		GD.Print("Idle return EMPTY SAME");
		return GSTATE.EMPTY;
	}
	public override void GetInput()
	{
	}

	public override void Exit()
	{

	}

	public override void Enter()
	{
		asprite.Play("Idle");
	}
}

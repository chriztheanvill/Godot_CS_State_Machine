using Godot;
using System;
using System.Collections.Generic;

public class ImpStates : IStates
{

	// [Export]
	// public States stIdle;
	// [Export]
	// public States stWalk;
	// [Export]
	// public States stJump;


	public enum GSTATE { WALK, IDLE, JUMP, FALL, EMPTY };
	public GSTATE gtCurrent;
	public GSTATE gtPrev;


	[Export]
	public ImpStates state;
	[Export]
	public ImpStates prevState;

	public ImpStates()
	{
		// GD.Print("Parent name: ", GetParentOrNull<Node2D>());
	}

	public override void _Ready()
	{
		// GD.Print("+++ ImpStates Ready");
		// pl = GetNode<Player>("../../Player");

		state = GetNode<Idle>("Idle");
		// stWalk = GetNode<Walk>("Walk");
		// stJump = GetNode<Jump>("Jump");
		SetState(GSTATE.IDLE);
		// SetState("Idle");

		// LSTATE.Add("Idle");
		// LSTATE.Add("Walk");
		// LSTATE.Add("Jump");
		// LSTATE.Add("Fall");

	}

	public override void _PhysicsProcess(float delta)
	{
		if (state != null)
		{
			// GD.Print("ImpStates physic process ");
			state.Logic();
			GSTATE tr = state.GetTransition();
			// string tr = state.GetTransition();
			// GD.Print("ImpStates transition: ", tr);

			if (tr != GSTATE.EMPTY)
			{
				SetState(tr);
			}
		}
	}

	public override void Logic()
	{
		GD.Print("Error ImpStates Logic ");
	}
	public override void GetInput() { }

	public void SetState(GSTATE newState)
	// public void SetState(string newState)
	{


		// LSTATE.Contains("");

		GD.Print("ImpStates SetState");
		GD.Print("\nNewState: ", newState);
		GD.Print("PrevState: ", prevState);
		prevState = state;
		// switch (newState)
		// {
		// 	case "Idle":
		// 		state = GetNode<Idle>(newState);
		// 		break;
		// 	case "Walk":
		// 		state = GetNode<Walk>(newState);
		// 		break;
		// 	case "Jump":
		// 		state = GetNode<Jump>(newState);
		// 		break;
		// 	case "Fall":
		// 		state = GetNode<Fall>(newState);
		// 		break;
		// }
		switch (newState)
		{
			case GSTATE.IDLE:
				state = GetNode<Idle>("Idle");
				break;
			case GSTATE.WALK:
				state = GetNode<Walk>("Walk");
				break;
			case GSTATE.JUMP:
				state = GetNode<Jump>("Jump");
				break;
			case GSTATE.FALL:
				state = GetNode<Fall>("Fall");
				break;
		}

		if (prevState != null) state.Exit();
		if (state != null) state.Enter();
	}

	public virtual GSTATE GetTransition()
	{
		return GSTATE.IDLE;
	}
	public override void Exit()
	{
	}

	public override void Enter()
	{
	}

	public void AddState(string newState)
	{
		LSTATE.Add(newState);
	}

}
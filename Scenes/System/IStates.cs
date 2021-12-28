using Godot;
using System;
using System.Collections.Generic;


public class IStates : Node2D
{

	// [Export]
	// public States stIdle;
	// [Export]
	// public States stWalk;
	// [Export]
	// public States stJump;


	public IStates()
	{
		// GD.Print("Parent name: ", GetParentOrNull<Node2D>());
	}

	public List<string> LSTATE = new List<string> { };

	// [Export]
	// public IStates state;
	// [Export]
	// public IStates prevState;

	public override void _Ready()
	{
		GD.Print("+++ IStates Ready");
	}

	// public override void _PhysicsProcess(float delta)
	// {
	// 	if (state != null)
	// 	{
	// 		GD.Print("IStates physic process ");
	// 		state.Logic();
	// 		string tr = state.GetTransition();
	// 		if (!tr.Empty())
	// 		{
	// 			SetState(tr);
	// 		}
	// 	}
	// }

	public virtual void Logic() { }
	public virtual void GetInput() { }

	// public void SetState(string newState)
	// {

	// 	GD.Print("---- ERROR States SetState");
	// 	GD.Print("\nNewState: ", newState);
	// 	GD.Print("PrevState: ", prevState);
	// 	prevState = state;

	// 	if (prevState != null) state.Exit();
	// 	if (state != null) state.Enter();
	// }

	// public virtual GSTATE GetTransition()
	// {
	// 	return "";
	// }
	public virtual void Exit()
	{

	}

	public virtual void Enter()
	{

	}

	// public void AddState(string newState)
	// {
	// 	LSTATE.Add(newState);
	// }

}
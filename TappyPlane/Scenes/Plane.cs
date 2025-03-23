using Godot;
using System;
using System.Diagnostics;

public partial class Plane : CharacterBody2D
{
	
	const float gravity = 800.0f;
	[Export] float jumpForce = -350.0f;
	[Export] AnimatedSprite2D Plane2D;	
	[Export] AnimationPlayer animationPlayer;
	[Signal] public delegate void OnDiedEventHandler();
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
			Vector2 velocity = Velocity;
			velocity.Y += gravity * (float)delta;
			Velocity = velocity;
			MoveAndSlide();
			Fly();

			if(IsOnFloor())
			{
				Die();
			}	
	}

	private void Fly()
	{
		if(Input.IsActionJustPressed("Fly"))
		{
			Vector2 velocity = Velocity;
			velocity.Y = jumpForce;
			Velocity = velocity;
			animationPlayer.Play("Power");
		}
	}

	public void Die()
	{
		SetPhysicsProcess(false);
		EmitSignal(SignalName.OnDied);
		Plane2D.Stop();
	}
}

	

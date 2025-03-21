using Godot;
using System;

public partial class Plane : CharacterBody2D
{
	
	const float gravity = 800.0f;
	[Export] float jumpForce = -350.0f;
	[Export] AnimationPlayer animationPlayer;
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

}

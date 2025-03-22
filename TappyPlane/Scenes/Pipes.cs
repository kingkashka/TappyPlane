using Godot;
using System;

public partial class Pipes : Node2D
{
	float speed = 120.0f;
	[Export] VisibleOnScreenNotifier2D visibleOnScreenNotifier;
	
	public delegate void OnScoredEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		visibleOnScreenNotifier.ScreenExited += OnScreenExited;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position -= new Vector2(speed * (float)delta, 0.0F);
	}

	private void OnScreenExited()
	{
		QueueFree();
	}
}

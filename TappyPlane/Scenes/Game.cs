using Godot;
using System;
using System.Collections;

public partial class Game : Node2D
{
	[Export] AudioStream scoreSound;
	[Export] PackedScene pipeScene;
	[Export] Timer timer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer.Timeout += SpawnPipes;
		SpawnPipes();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SpawnPipes()
	{
		// float margin = 100.0f;
		Rect2 VPR = GetViewportRect();
		RandomNumberGenerator random = new RandomNumberGenerator();
		float randomY = random.RandfRange(340, 540);
		Pipes pipes = (Pipes)pipeScene.Instantiate();
		AddChild(pipes);
		pipes.Position = new Vector2(VPR.End.X, randomY);
	}
	private void OnScored()
	{
		GD.Print("Scored");
	}
}

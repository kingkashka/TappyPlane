using Godot;
using System;
using System.Collections;

public partial class Game : Node2D
{
	[Export] AudioStreamPlayer2D scoreSound;
	[Export] PackedScene pipeScene;
	[Export] Timer timer;
	[Export] Marker2D spawnMarker1;
	[Export] Marker2D spawnMarker2;
	[Export] private Plane plane;
	[Export] Label ScoreLabel;
	public float playerScore = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer.Timeout += SpawnPipes;
		plane.OnDied += OnGameOver;
		// Pipes.OnScored += OnScored;
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
		float randomY = random.RandfRange(spawnMarker1.GlobalPosition.Y, spawnMarker2.GlobalPosition.Y);
		Pipes pipes = (Pipes)pipeScene.Instantiate();
		AddChild(pipes);
		pipes.Position = new Vector2(VPR.End.X, randomY);
	}
	private void OnScored()
	{
		scoreSound.Play();
		playerScore += 1;
		ScoreLabel.Text = playerScore.ToString();
		GD.Print("Scored");
	}

	private void OnDied()
	{
		GD.Print("Plane Died");
	}
	
	private void OnGameOver()
	{
		GD.Print("Game Over");
		foreach (Node node in GetChildren())
		{
			node.SetProcess(false);
		}
		timer.Stop();
	}
}

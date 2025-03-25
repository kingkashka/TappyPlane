using Godot;
using System;

public partial class Main : Control
{
	// private static readonly PackedScene GAMESCENE = GD.Load<PackedScene>("res://Scenes/Game.tscn");
	[Export] AudioStreamPlayer mainMenuMusic;
	[Export] Label HighScore;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		mainMenuMusic.Play();
		ShowHighScore();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("Fly"))
		{
			// GetTree().ChangeSceneToPacked(GAMESCENE);
			GameManager.LoadGame();
		}
	}

	private void ShowHighScore()
	{
		HighScore.Text = ScoreManager.GetHighScore().ToString();
	}
	
}

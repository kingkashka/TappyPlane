using Godot;
using System;

public partial class ScoreManager : Node
{
	public static ScoreManager Instance { get; private set; }
	int score = 0;
	int highScore;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public static int GetScore()
	{
		return Instance.score;
	}
	public static int GetHighScore()
	{
		return Instance.highScore;
	}

	private static void SetScore(int value)
	{
		Instance.score = value;
		if(Instance.score > Instance.highScore)
		{
			Instance.highScore = Instance.score;
		}
		GD.Print($"Score: {Instance.score}, High Score: {Instance.highScore}");
		SignalManager.EmitOnScored();
	}
	public static void ResetScore()
	{
		SetScore(0);
	}

	public static void IncrementScore()
	{
		SetScore(GetScore() + 1);
	}
}

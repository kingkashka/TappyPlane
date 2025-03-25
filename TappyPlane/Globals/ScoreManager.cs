using Godot;
using System;

public partial class ScoreManager : Node
{
	public static ScoreManager Instance { get; private set; }
	uint score = 0;
	uint highScore;
	private const string ScoreFile = "user://tappy.save";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		LoadScoreFromFile();
	}

	public override void _ExitTree()
	{
		SaveScoreToFile();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public static uint GetScore()
	{
		return (uint)Instance.score;
	}
	public static uint GetHighScore()
	{
		return (uint)Instance.highScore;
	}

	private static void SetScore(uint value)
	{
		Instance.score = value;
		if (Instance.score > Instance.highScore)
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
	private void LoadScoreFromFile()
	{
		using FileAccess file = FileAccess.Open(ScoreFile, FileAccess.ModeFlags.Read);
		if (file != null)
		{
			highScore = file.Get32();

		}
	}
	private void SaveScoreToFile()
	{
		using FileAccess file = FileAccess.Open(ScoreFile, FileAccess.ModeFlags.Write);
		if (file != null)
		{
			// file.StoreString(highScore.ToString());
			// file.StoreVar(highScore);
			file.Store32(highScore);

		}
	}
}

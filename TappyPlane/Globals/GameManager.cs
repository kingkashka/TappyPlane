using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class GameManager : Node
{
	public const float speed = 120.0f;
	public static GameManager Instance { get; private set; }

	private PackedScene GAMESCENE = GD.Load<PackedScene>("res://Scenes/Game.tscn");
	private PackedScene MAINSCENE = GD.Load<PackedScene>("res://Scenes/Main.tscn");
	private PackedScene GAMEOVERSCENE = GD.Load<PackedScene>("res://Scenes/GameOver.tscn");
	private PackedScene LoadingScreen = GD.Load<PackedScene>("res://Scenes/LoadingScreen.tscn");
	private PackedScene nextScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}
	public static PackedScene GetNextScene()
	{
		return Instance.nextScene;
	}

	private void LoadNextScreen(PackedScene ns)
	{
		nextScene = ns;
		Instance.GetTree().ChangeSceneToPacked(Instance.LoadingScreen);

	}
	public static void LoadMain()
	{
		// Instance.GetTree().ChangeSceneToPacked(Instance.MAINSCENE);
		Instance.LoadNextScreen(Instance.MAINSCENE);
	}
	public static void LoadGame()
	{
		// Instance.GetTree().ChangeSceneToPacked(Instance.GAMESCENE);
		Instance.LoadNextScreen(Instance.GAMESCENE);
	}
	public static void LoadGameOver()
	{
		Instance.GetTree().ChangeSceneToPacked(Instance.GAMEOVERSCENE);
	}
}

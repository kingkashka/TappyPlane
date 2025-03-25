using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }

	private PackedScene GAMESCENE = GD.Load<PackedScene>("res://Scenes/Game.tscn");
	private PackedScene MAINSCENE = GD.Load<PackedScene>("res://Scenes/Main.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	public static void LoadMain()
	{
		Instance.GetTree().ChangeSceneToPacked(Instance.MAINSCENE);
	}
	public static void LoadGame()
	{
		Instance.GetTree().ChangeSceneToPacked(Instance.GAMESCENE);
	}
}

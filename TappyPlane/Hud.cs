using Godot;
using System;

public partial class Hud : Control
{
	[Export] Label scoreLabel;
		// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalManager.Instance.OnScored += OnScored;
	}
    public override void _ExitTree()
    {
        SignalManager.Instance.OnScored -= OnScored;
    }
    private void OnScored()
	{
		scoreLabel.Text = ScoreManager.GetScore().ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

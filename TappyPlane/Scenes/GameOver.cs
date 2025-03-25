using Godot;
using System;

public partial class GameOver : Control
{
	[Export] Label GameOverLabel;
	[Export] Label PressSpaceLabel;
	[Export] AudioStreamPlayer GameOverMusic;
	[Export] Timer pressSpaceTimer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GameOverMusic.Play();
		pressSpaceTimer.Timeout += OnTimerTimeout;
	}

    private void OnTimerTimeout()
    {
       PressSpaceLabel.Show(); 
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		BackToMainMenu();
	}
	private void BackToMainMenu()
	{
		if(Input.IsActionPressed("Fly") && PressSpaceLabel.Visible)
		{
			GameManager.LoadMain();
		}
	}
}

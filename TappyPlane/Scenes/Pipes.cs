using Godot;
using System;

public partial class Pipes : Node2D
{
	
	[Export] VisibleOnScreenNotifier2D visibleOnScreenNotifier;
	[Export] private Area2D LowerPipe;
	[Export] private Area2D UpperPipe;
	[Export] private Area2D laser;
	[Export] AudioStreamPlayer2D ScoreSound;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		visibleOnScreenNotifier.ScreenExited += OnScreenExited;
		LowerPipe.BodyEntered += OnPipeBodyEntered;
		UpperPipe.BodyEntered += OnPipeBodyEntered;
		laser.BodyEntered += OnLaserBodyEntered;
		SignalManager.Instance.OnDied += StopPipes;
	}
    public override void _ExitTree()
    {
        SignalManager.Instance.OnDied -= StopPipes;
    }

    private void OnLaserBodyEntered(Node2D body)
	{
		if(body is Plane)
		{
			ScoreSound.Play();
			ScoreManager.IncrementScore();
		}
		

		// Great way to detect collision by using scene group names
		// if(body.IsInGroup("plane"))
		// {
		// 	GD.Print("EmittingSignal");
		// 	EmitSignal(SignalName.OnScored);
		// }
	}


	private void OnPipeBodyEntered(Node2D body)
	{
		if (body.IsInGroup("plane"))
		{
			// Great way to check collisions
			GD.Print("Pipe Body Entered", body.Name);
			(body as Plane).Die();
		}
	}

	private void StopPipes()
	{
		SetProcess(false);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position -= new Vector2(GameManager.speed * (float)delta, 0.0F);
	}

	private void OnScreenExited()
	{
		QueueFree();
	}
	private void BodyEntered(Area2D area)
	{
		if (LowerPipe.GetOverlappingBodies().Contains(area) || UpperPipe.GetOverlappingBodies().Contains(area))
		{
			// EmitSignal(nameof(OnScored));
		}
	}
}

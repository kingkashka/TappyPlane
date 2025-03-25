using Godot;
using System;

public partial class ParallaxImage : Parallax2D
{
	[Export] private Texture2D srcTexture;
	[Export] private Sprite2D sprite;
	[Export] private float speedScale;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Autoscroll = new Vector2(-speedScale * GameManager.speed, 0);
		float scaleFactor = GetViewportRect().Size.Y / srcTexture.GetHeight();

		sprite.Texture = srcTexture;
		sprite.Scale = new Vector2(scaleFactor, scaleFactor);

		RepeatSize = new Vector2(srcTexture.GetWidth() * scaleFactor, 0);

		// Adjust the position to center it
		sprite.Position = new Vector2(0, GetViewportRect().Size.Y / 2);
	}


}

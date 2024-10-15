using Godot;
using System;

public partial class Scoreboard : Node2D
{
	int playerScore = 0; int opponentScore = 0;

	string[] scorePictureList = { 
		"res://resources/zero.png", // 0
		"res://resources/one.png", // 1
		"res://resources/two.png", // 2
		"res://resources/three.png", // 3
		"res://resources/four.png", // 4
		"res://resources/five.png", // 5
		"res://resources/six.png",  // 6
		"res://resources/seven.png" // 7
	};

	Sprite2D playerScoreSprite;
	Sprite2D opponentScoreSprite;

	private Texture2D[] scoreTextures;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		scoreTextures = new Texture2D[scorePictureList.Length];
		for (int i = 0; i < scorePictureList.Length; i++)
		{
			scoreTextures[i] = (Texture2D)ResourceLoader.Load(scorePictureList[i]);
		}

		playerScoreSprite =  GetNode<Sprite2D>("PlayerScore");
		opponentScoreSprite =  GetNode<Sprite2D>("OpponentScore");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_player_goal_body_entered(Node body)
	{
		if (opponentScore < scorePictureList.Length)
		{
			opponentScore++;

			opponentScoreSprite.Texture = (Texture2D)GD.Load(scorePictureList[opponentScore]);
		}
	}
}

using Godot;
using System;
using System.ComponentModel;

public partial class MusicManager : Node
{
	#region Singleton
	// Static autoproperty.
	// Get on public, so MusicManager can be accessed from anywhere.
	// Set private, so it can't be easily overwritten.
	public static MusicManager Instance
	{
		get;
		private set;
	}

	public MusicManager()
	{
		//Singleton guarantees only one object of the class can be made at a time
		if (Instance == null)
		{
			//There is no object yet, this will be it
			Instance = this;
		}
		else if (Instance != this)
		{
			//There's already a Singleton object, destroy the one that was just made
			QueueFree();
			return;
		}
	}
	#endregion

	#region MusicData
	[Export] private AudioStreamPlayer musicPlayer;
	[Export] private AudioStreamPlayer soundPlayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Make it play if it isnt already, makes sure the music or sound doesn't restart if it was playing already:
		if (!musicPlayer.Playing)
		{
			musicPlayer.Play();
		}
		if (!soundPlayer.Playing)
		{
			soundPlayer.Play();
		}
	}

	//Play the wanted sound:
	public void PlayMusic(AudioStream music)
	{
		if (musicPlayer.Stream != music)
		{
			musicPlayer.Stream = music;
			musicPlayer.Play();
		}
	}

	//Stop all music:
	public void StopMusic()
	{
		musicPlayer.Stop();
	}

	public void PlaySound(AudioStream sound)
	{
		soundPlayer.Stream = sound;
		soundPlayer.Play();
	}
	#endregion
}

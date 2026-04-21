using Godot;
using System;
using System.ComponentModel;
using System.IO;

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
	[Export] private AudioStream musicOfWhereMuteButtonIs;
	private bool muted = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (!muted)
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
	}

	public void MuteAllSounds()
	{
		muted = true;
		StopMusic();
	}

	public void UnmuteAllSounds()
	{
		muted = false;
		musicPlayer.Play();
	}

	public bool GetMuteStatus()
	{
		return muted;
	}

	//Play the wanted sound:
	public void PlayMusic(AudioStream music)
	{
		if (!muted)
		{
			if (musicPlayer.Stream != music)
			{
				musicPlayer.Stream = music;
				musicPlayer.Play();
			}
		}
	}

	//Stop all music:
	public void StopMusic()
	{
		musicPlayer.Stop();
	}

	public void PlaySound(AudioStream sound)
	{
		if (!muted)
		{
			soundPlayer.Stream = sound;
			soundPlayer.Play();
		}
	}
	#endregion
}

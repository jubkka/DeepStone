using System;
using UnityEngine;

[Serializable]
public class VolumeSetting : Setting
{
    [SerializeField] private int music;
    [SerializeField] private int effects;

    [SerializeField] private int defaultValue = 50;

    public int Music
    {
        get => music;
        set
        {
            music = value;
            Save();
        }
    }

    public int Effects
    {
        get => effects;
        set
        {
            effects = value;
            Save();
        }
    }

    public override void Load()
    {
        music = PlayerPrefs.GetInt("VolumeSound", defaultValue);
        effects = PlayerPrefs.GetInt("VolumeEffects", defaultValue);
    }

    public override void Save()
    {
        PlayerPrefs.SetInt("VolumeSound", music);
        PlayerPrefs.SetInt("VolumeEffects", effects);
        PlayerPrefs.Save();
    }

    public override void Default()
    {
        music = defaultValue;
        effects = defaultValue;
    }

    public override void Apply()
    {
        AudioSystems.Instance.GetMusic.ChangeVolume(music / 100f);
    }
}
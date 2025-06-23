using System;
using UnityEngine;

[Serializable]
public class VolumeSetting : Setting
{
    [SerializeField] private int music;
    [SerializeField] private int sfx;

    [SerializeField] private int defaultValue = 25;

    public int Music
    {
        get => music;
        set
        {
            music = value;
            Save();
        }
    }

    public int SFX
    {
        get => sfx;
        set
        {
            sfx = value;
            Save();
        }
    }

    public override void Load()
    {
        music = PlayerPrefs.GetInt("VolumeMusic", defaultValue);
        sfx = PlayerPrefs.GetInt("VolumeSFX", defaultValue);
    }

    public override void Save()
    {
        PlayerPrefs.SetInt("VolumeMusic", music);
        PlayerPrefs.SetInt("VolumeSFX", sfx);
        PlayerPrefs.Save();
    }

    public override void Default()
    {
        music = defaultValue;
        sfx = defaultValue;
    }

    public override void Apply()
    {
        SFXAudioManager.Instance.ChangeVolume(sfx / 100f);
        MusicManager.Instance.ChangeVolume(music / 100f);
    }
}
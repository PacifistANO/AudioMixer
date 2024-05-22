using UnityEngine;
using UnityEngine.Audio;

public class SoundsMaster : MonoBehaviour
{
    private readonly string MasterVolume = nameof(MasterVolume);
    private readonly string MusicVolume = nameof(MusicVolume);
    private readonly string EffectsVolume = nameof(EffectsVolume);

    [SerializeField] private AudioMixerGroup _mixer;

    private bool _isEnabled;

    private void Start()
    {
        PlayerPrefs.SetFloat(MasterVolume, 0);
        _isEnabled = true;
    }

    public void ToggleMusic(bool enabled)
    {
        _isEnabled = enabled;

        if (enabled)
            ChangeMasterVolume(PlayerPrefs.GetFloat(MasterVolume));
        else
            ChangeVolume(0, MasterVolume);
    }

    public void ChangeMasterVolume(float volume)
    {
        if (_isEnabled)
            ChangeVolume(volume, MasterVolume);

        PlayerPrefs.SetFloat(MasterVolume, volume);
    }

    public void ChangeSoundsVolume(float volume)
    {
        ChangeVolume(volume, EffectsVolume);
    }

    public void ChangeMusicVolume(float volume)
    {
        ChangeVolume(volume, MusicVolume);
    }

    private void ChangeVolume(float volume, string category)
    {
        _mixer.audioMixer.SetFloat(category, volume > 0 ? Mathf.Log10(volume) * 20 : -80);
    }
}

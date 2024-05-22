using UnityEngine;
using UnityEngine.Audio;

public class SoundsMaster : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private readonly string _masterVolume = "MasterVolume";
    private readonly string _musicVolume = "MusicVolume";
    private readonly string _effectsVolume = "EffectsVolume";
    private bool _isEnabled;
    private float _volume;

    private void Start()
    {
        _isEnabled = true;
    }

    public void ToggleMusic(bool enabled)
    {
        _isEnabled = enabled;

        if (enabled)
            ChangeMasterVolume(_volume);
        else
            ChangeVolume(0, _masterVolume);
    }

    public void ChangeMasterVolume(float volume)
    {
        if (_isEnabled)
            ChangeVolume(volume, _masterVolume);

        _volume = volume;
    }

    public void ChangeSoundsVolume(float volume)
    {
        ChangeVolume(volume, _effectsVolume);
    }

    public void ChangeMusicVolume(float volume)
    {
        ChangeVolume(volume, _musicVolume);
    }

    private void ChangeVolume(float volume, string category)
    {
        _mixer.audioMixer.SetFloat(category, volume > 0 ? Mathf.Log10(volume) * 20 : -80);
    }
}

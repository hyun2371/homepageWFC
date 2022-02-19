using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    [SerializeField] Image SoundOnIcon;
    [SerializeField] Image SoundOffIcon;
    private bool isMuted = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
            Load();
        UpdateButtonIcon();
        AudioListener.pause = isMuted;
    }
    public void OnButtonPressed()
    {
        if (isMuted == false)
        {
            isMuted = true;
            AudioListener.pause = true;
        }
        else
        {
            isMuted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (isMuted == false)
        {
            SoundOnIcon.enabled = true;
            SoundOffIcon.enabled = false;
        }
        else
        {
            SoundOnIcon.enabled = false;
            SoundOffIcon.enabled =true;
        }
    }

    private void Load()
    {
        isMuted = PlayerPrefs.GetInt("isMuted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("isMuted", isMuted ? 1 : 0);
    }


}

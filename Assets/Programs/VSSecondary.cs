using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VSSecondary : MonoBehaviour
{
    [SerializeField] public AudioMixer myMixer;
    // Start is called before the first frame update
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("musicVolume");
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
    }

}

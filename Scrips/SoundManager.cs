using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource bgSound;
    [SerializeField]
    private AudioMixer  mixer;
    [SerializeField]
    private Slider      BGMVolumeSlider;
    [SerializeField]
    private Slider      SFXVolumeSlider;

    public static SoundManager instance;

    private void Awake()
    {
        if ( instance == null )
        {
            instance = this;
        }
    }

    private void Start()
    {
        if ( PlayerPrefs.HasKey("BGMVolume") )
        {
            LoadVolume();
        }
        else
        {
            BGMVolumeSetter();
            SFXVolumeSetter();
        }
    }

    public void BGMVolumeSetter()
    {
        float volume = BGMVolumeSlider.value;
        mixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void SFXVolumeSetter()
    {
        float volume = SFXVolumeSlider.value;
        mixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject  gameObject  = new GameObject(sfxName + "Sound");
        AudioSource audiosource = gameObject.AddComponent<AudioSource>();
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("Sfx")[0];
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(gameObject, clip.length);
    }

    private void LoadVolume()
    {
        BGMVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        BGMVolumeSetter();
        SFXVolumeSetter();
    }
}

/*
 * File : SoundManager.cs
 * Desc
 *  : SoundMgr 오브젝트에게 부착
 *  
 *  Functions
 *  : BGMVolumeSetter() - 슬라이더를 통해 배경음악 볼륨을 조절
 *  : SFXVolumeSetter() - 슬라이더를 통해 효과음 볼륨을 조절
 *  : SFXPlay()         - 외부에서 호출해 버튼 클릭시 효과음을 재생
 *  : LoadVolume()      - 플레이어 프리팹에 저장한 배경음악과 효과음 볼륨을 불러온다
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonController : MonoBehaviour
{
    [SerializeField]
    private ObjectDetecter  objectDetecter;
    [SerializeField]
    private TowerDataViewer towerDataViewer;
    [SerializeField]
    private TowerSpawner    towerSpawner;
    [SerializeField]
    private PlayerCoin      playerCoin;
    [SerializeField]
    private GameObject      settingsWindow;
    [SerializeField]
    private GameObject      shopWindow;
    [SerializeField]
    private AudioClip       clip;
    [SerializeField]
    private SoundManager    soundMgr;
    [SerializeField]
    private WaveSystem      waveSystem;

    private bool  isPaused             = false;
    private bool  isDoubleSpeed        = false;
    private float normalTimeScale      = 1.0f;
    private float doubleSpeedTimeScale = 2.0f;

    private void Start()
    {
        Time.timeScale = normalTimeScale;
    }

    public void LoadPlaySceneToggle()
    {
        SoundManager.instance.SFXPlay("SFX", clip);

        SceneManager.LoadScene("Play");
    }

    public void StartWaveToggle()
    {
        SoundManager.instance.SFXPlay("SFX", clip);

        waveSystem.StartWave();
    }

    public void ReturnToHomeToggle()
    {
        SoundManager.instance.SFXPlay("SFX", clip);

        SceneManager.LoadScene("Menu");
    }

    public void ExitGameToggle()
    {
        SoundManager.instance.SFXPlay("SFX", clip);

        Application.Quit();
    }

    public void SettingToggle()
    {
        SoundManager.instance.SFXPlay("SFX", clip);

        if ( !settingsWindow.activeSelf )
        {
            settingsWindow.SetActive(true);
        }
        else
        {
            settingsWindow.SetActive(false);
        }
    }

    public void ShopToggle()
    {
        SoundManager.instance.SFXPlay("SFX", clip);

        if ( !shopWindow.activeSelf )
        {
            shopWindow.SetActive(true);
        }
        else
        {
            shopWindow.SetActive(false);
        }
    }

    public void PauseToggle()
    {
        SoundManager.instance.SFXPlay("SFX", clip);

        isPaused = !isPaused;
        UpdateTimeScale();
    }

    public void DoubleSpeedToggle()
    {
        SoundManager.instance.SFXPlay("SFX", clip);

        isDoubleSpeed = !isDoubleSpeed;
        UpdateTimeScale();
    }

    private void UpdateTimeScale()
    {
        if ( isPaused )
        {
            Time.timeScale = 0.0f;
        }
        else if ( isDoubleSpeed )
        {
            Time.timeScale = doubleSpeedTimeScale;
        }
        else
        {
            Time.timeScale = normalTimeScale;
        }
    }

    private void Update()
    {
        if ( Input.GetButtonDown("Cancel") )
        {
            SettingToggle();
        }
    }
}

/*
 * File : UIButtonController.cs
 * Desc
 *  : UIController 오브젝트에게 부착
 *  
 *  Functions
 *  : LoadPlaySceneToggle() - 게임시작 버튼 클릭되면 Play 씬을 불러옴
 *  : StartWaveToggle()     - 웨이브 시작 버튼이 클릭되면 웨이브를 시작 
 *  : ReturnToHomeToggle()  - 홈 버튼이 클릭되면 Menu 씬을 불러옴
 *  : ExitGameToggle()      - ExitGame 버튼이 클릭되면 게임을 종료
 *  : SettingToggle()       - 설정 버튼이 클릭되면 설정창을 활성화, 비활성화
 *  : ShopToggle()          - 상점 버튼이 클릭되면 상점창을 활성화, 비활성화
 *  : PauseToggle()         - 설정 버튼이 클릭되면 TimeScale을 0.0f으로 설정
 *  : DoubleSpeedToggle()   - DoubleSpeed 버튼이 클릭되면 TimeScale을 2.0f로 설정
 *  : UpdateTimeScale()     - TimeScale을 업데이트
 */
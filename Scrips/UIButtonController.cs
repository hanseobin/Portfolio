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
 *  : UIController ������Ʈ���� ����
 *  
 *  Functions
 *  : LoadPlaySceneToggle() - ���ӽ��� ��ư Ŭ���Ǹ� Play ���� �ҷ���
 *  : StartWaveToggle()     - ���̺� ���� ��ư�� Ŭ���Ǹ� ���̺긦 ���� 
 *  : ReturnToHomeToggle()  - Ȩ ��ư�� Ŭ���Ǹ� Menu ���� �ҷ���
 *  : ExitGameToggle()      - ExitGame ��ư�� Ŭ���Ǹ� ������ ����
 *  : SettingToggle()       - ���� ��ư�� Ŭ���Ǹ� ����â�� Ȱ��ȭ, ��Ȱ��ȭ
 *  : ShopToggle()          - ���� ��ư�� Ŭ���Ǹ� ����â�� Ȱ��ȭ, ��Ȱ��ȭ
 *  : PauseToggle()         - ���� ��ư�� Ŭ���Ǹ� TimeScale�� 0.0f���� ����
 *  : DoubleSpeedToggle()   - DoubleSpeed ��ư�� Ŭ���Ǹ� TimeScale�� 2.0f�� ����
 *  : UpdateTimeScale()     - TimeScale�� ������Ʈ
 */
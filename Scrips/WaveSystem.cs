using UnityEngine;

[System.Serializable]
public struct Wave
{
    public float        spawnTime;
    public int          maxEnemyCount;
    public GameObject[] enemyPrefabs;
}

public class WaveSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[]       waves;
    [SerializeField]
    private EnemySpawner enemySpawner;

    [SerializeField]
    private GameObject   gameClearWindow;

    private int          currentWaveIndex = -1;

    public int CurrentWaveIndex => currentWaveIndex;

    private void Update()
    {
        if ( currentWaveIndex == waves.Length  )
        {
            GameClear();
        }
    }

    public void StartWave()
    {
        if ( enemySpawner.EnemyList.Count == 0 && currentWaveIndex < waves.Length - 1 )
        {
            currentWaveIndex ++;

            enemySpawner.StartWave(waves[currentWaveIndex]);
        }
    }

    private void GameClear()
    {
        Time.timeScale = 0.0f;
        gameClearWindow.SetActive(true);
    }
}

/*
 * File : WaveSystem.cs
 * Desc
 *  : EnemySpawner ������Ʈ���� ����
 *  
 *  Functions
 *  : StartWave() - �ܺο��� ȣ���� ���� ���̺긦 ����
 *  : GameClear() - ��� ���̺갡 ������ GameClear ������Ʈ�� Ȱ��ȭ
 */
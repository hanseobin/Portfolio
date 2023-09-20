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
 *  : EnemySpawner 오브젝트에게 부착
 *  
 *  Functions
 *  : StartWave() - 외부에서 호출해 몬스터 웨이브를 시작
 *  : GameClear() - 모든 웨이브가 끝나면 GameClear 오브젝트를 활성화
 */
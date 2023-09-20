using TMPro;
using UnityEngine;

public class PlayerStatusViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerHP;
    [SerializeField]
    private PlayerHealth    playerHealth;
    [SerializeField]
    private TextMeshProUGUI textPlayerCoin;
    [SerializeField]
    private PlayerCoin      playerCoin;
    [SerializeField]
    private TextMeshProUGUI textWaveSystem;
    [SerializeField]
    private WaveSystem      waveSystem;
    [SerializeField]
    private TextMeshProUGUI textEnemyCount;
    [SerializeField]
    private EnemySpawner    enemySpawner;

    private void Update()
    {
        textPlayerHP.text   = playerHealth.CurrentHP + "/" + playerHealth.MaxHP;
        textPlayerCoin.text = playerCoin.CurrentCoin.ToString();
        textWaveSystem.text = (waveSystem.CurrentWaveIndex + 1) + "/" + 20;
        textEnemyCount.text = enemySpawner.CurrentEnemyCount + "/" + enemySpawner.MaxEnemyCount;
    }
}

/*
 * File : PlayerStatusViewer.cs
 * Desc
 *  : StatusPanel 오브젝트에게 부착
 */
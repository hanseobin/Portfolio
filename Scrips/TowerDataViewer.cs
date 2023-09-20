using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net;

public class TowerDataViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI  textDamage;
    [SerializeField]
    private TextMeshProUGUI  textRate;
    [SerializeField]
    private TextMeshProUGUI  textRange;
    [SerializeField]
    private TextMeshProUGUI  textSlow;
    [SerializeField]
    private TowerAttackRange towerAttackRange;

    private TowerWeapon      currentTower;

    private void Awake()
    {
        OffPanel();
    }

    public void OnPanel(Transform towerWeapon)
    {
        currentTower = towerWeapon.GetComponent<TowerWeapon>();

        gameObject.SetActive(true);

        UpdateTowerData();

        if ( currentTower.Range > 0  )
        {
            towerAttackRange.OnAttackRange(currentTower.transform.position, currentTower.Range);
        }
    }
    
    public void OffPanel()
    {
        gameObject.SetActive(false);

        towerAttackRange.OffAttackRange();
    }

    private void UpdateTowerData()
    {
        if ( currentTower.Damage > 0 )
        {
            textDamage.text = "Dmg : " + currentTower.Damage;
        }

        if ( currentTower.Rate > 0 )
        {
            textRate.text = "Rate : 1/" + currentTower.Rate + "s";
        }

        if ( currentTower.Range > 0 )
        {
            textRange.text = "Range : " + currentTower.Range;
        }

        if ( currentTower.Slow > 0 )
        {
            textSlow.text = "Slow : " + (100 * (1 - currentTower.Slow)) + "%";
        }
    }
}

/*
 * File : TowerDataViewer.cs
 * Desc
 *  : TowerPanel ������Ʈ���� ����
 *  
 *  Functions
 *   : OnPanel()         - �ܺο��� ȣ���� �Ű������� ������ Ȱ��ȭ
 *   : OffPanel()        - �ܺο��� ȣ���� TowerPanel�� ��Ȱ��ȭ
 *   : UpdataTowerData() - TowerPanel�� ������ Ÿ���� ������ ���
 */
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ButtonPrefabPair
{
    public Button     button;
    public GameObject towerPrefab;
}

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private ButtonPrefabPair[] buttonPrefabPairs;
    [SerializeField] 
    private TowerSpawner       towerSpawner;

    private void Start()
    {
        foreach ( ButtonPrefabPair pair in buttonPrefabPairs )
        {
            pair.button.onClick.AddListener(() => OnButtonClick(pair.towerPrefab));
        }
    }

    private void OnButtonClick(GameObject prefab)
    {
        towerSpawner.TowerPrefab = prefab;
    }
}

/*
 * File : ShopManager.cs
 * Desc
 *  : ShopManager ������Ʈ���� ����
 *  
 *  Functions
 *  : OnButtonClick() - ��ư�� Ŭ���ϸ� ��ư�� ��� �������� ����
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _equpmentSlotPrefab; // 装備スロットのプレハブ
    [SerializeField] private GameObject _weaponSlotPrefab; // 武器スロットのプレハブ
    [SerializeField] private Transform[] slotParent;           // スロットを配置する親オブジェクト
    [SerializeField] private int _equpmentSlotCount = 5;    //装備スロット数
    [SerializeField] private int _weaponSlotCount = 3;     // 武器スロット数

    private List<Image> _equpmentInventorySlots = new List<Image>();
    private List<Image> _weaponInventorySlots = new List<Image>();

    void Start()
    {
        GenerateEqupmentInventorySlots();
        GenerateWeaponInventorySlots();
    }

    /// <summary>
    /// インベントリの枠を生成
    /// </summary>
    private void GenerateEqupmentInventorySlots()
    {
        for (int number = 0; number < _equpmentSlotCount; number++)
        {
            // プレハブからスロットを生成
            GameObject slot = Instantiate(_equpmentSlotPrefab, slotParent[0]);

            // RectTransformを取得して位置を設定
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            if (slotTransform != null)
            {
                slotTransform.anchoredPosition = new Vector2(number * 150, 0); // 150間隔で配置
            }

            // スロットをリストに追加
            _equpmentInventorySlots.Add(slot.GetComponent<Image>());
        }
    }

    private void GenerateWeaponInventorySlots()
    {
        for (int number = 0; number < _weaponSlotCount; number++)
        {
            // プレハブからスロットを生成
            GameObject slot = Instantiate(_weaponSlotPrefab, slotParent[1]);

            // RectTransformを取得して位置を設定
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            if (slotTransform != null)
            {
                slotTransform.anchoredPosition = new Vector2(number * 150, 0); // 150間隔で配置
            }

            // スロットをリストに追加
            _weaponInventorySlots.Add(slot.GetComponent<Image>());
        }
    }
    public void UpdateEquipmentInventoryUI(BodyEquipmentData bodyEquipmentData,int index)
    {
        _equpmentInventorySlots[index].sprite = bodyEquipmentData.Icon;
    }
    public void UpdateWeaponInventoryUI(WeaponEqupmentData weaponEquipmentData, int index)
    {
        _equpmentInventorySlots[index].sprite = weaponEquipmentData.Icon;
    }

}

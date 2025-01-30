using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// インベントリＵＩ更新
/// </summary>
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _equipmentSlotPrefab; // 装備スロットのプレハブ
    [SerializeField] private GameObject _weaponSlotPrefab; // 武器スロットのプレハブ
    [SerializeField] private Transform[] slotParents;           // スロットを配置する親オブジェクト
    [SerializeField] private int _equipmentSlotCount = 5;    //装備スロット数
    [SerializeField] private int _weaponSlotCount = 3;     // 武器スロット数

    private const float SLOT_SPACING = 150f;

    private List<Image> _equipmentInventorySlots = new List<Image>();
    private List<Image> _weaponInventorySlots = new List<Image>();

    void Start()
    {
       
        GenerateEqupmentInventorySlots();
        GenerateWeaponInventorySlots();
    }

    /// <summary>
    /// 装備インベントリのスロットを生成
    /// </summary>
    private void GenerateEqupmentInventorySlots()
    {
        for (int number = 0; number < _equipmentSlotCount; number++)
        {
            // プレハブからスロットを生成
            GameObject slot = Instantiate(_equipmentSlotPrefab, slotParents[0]);

            // RectTransformを取得して位置を設定
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            if (slotTransform != null)
            {
                slotTransform.anchoredPosition = new Vector2(number * SLOT_SPACING, 0); // 150間隔で配置
            }

            // スロットをリストに追加
            _equipmentInventorySlots.Add(slot.GetComponent<Image>());
        }
    }
    /// <summary>
    /// 武器インベントリのスロットの生成
    /// </summary>
    private void GenerateWeaponInventorySlots()
    {
        for (int number = 0; number < _weaponSlotCount; number++)
        {
            // プレハブからスロットを生成
            GameObject slot = Instantiate(_weaponSlotPrefab, slotParents[1]);

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
    /// <summary>
    /// 装備変更した時のUIの更新
    /// </summary>
    /// <param name="bodyEquipmentData">装備データ</param>
    /// <param name="index">インベント番号</param>
    public void UpdateEquipmentInventoryUI(BodyEquipmentData bodyEquipmentData,int index)
    {
        if (index < 0 || index >= _equipmentInventorySlots.Count) return;
        _equipmentInventorySlots[index].sprite = bodyEquipmentData.Icon[0];
    }
    /// <summary>
    /// 武器変更した時のUIの更新
    /// </summary>
    /// <param name="weaponEquipmentData">武器データ</param>
    /// <param name="index">インベント番号</param>
    public void UpdateWeaponInventoryUI(WeaponEquipmentData weaponEquipmentData, int index)
    {
        if (index < 0 || index >= _weaponInventorySlots.Count) return;
        _weaponInventorySlots[index].sprite = weaponEquipmentData.Icon;
    }

}

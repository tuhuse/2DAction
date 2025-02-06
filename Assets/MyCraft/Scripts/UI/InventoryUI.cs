using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// インベントリＵＩ更新
/// </summary>
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _equipmentSlotPrefab; // 装備スロットのプレハブ
    [SerializeField] private GameObject _equipmentFramePrefab; // 装備フレームのプレハブ
    [SerializeField] private GameObject _weaponSlotPrefab; // 武器スロットのプレハブ
    [SerializeField] private GameObject _weaponFramePrefab; // 武器フレームのプレハブ
    [SerializeField] private Transform[] slotParents;           // スロットを配置する親オブジェクト
    [SerializeField] private int _equipmentSlotCount = 5;    //装備スロット数
    [SerializeField] private int _weaponSlotCount = 3;     // 武器スロット数

    private const float SLOT_SPACING = 150f;

   [SerializeField] private List<Image> _equipmentInventorySlots = new List<Image>();
   [SerializeField] private List<Image> _weaponInventorySlots = new List<Image>();
    private List<GameObject> _equipmentInventoryFrame = new List<GameObject>();
    private List<GameObject> _weaponInventoryFrame = new List<GameObject>();

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

            // プレハブからふれーむを生成
            GameObject frameSlot = Instantiate(_equipmentFramePrefab, slotParents[0]);
            // プレハブからスロットを生成
            GameObject slot = Instantiate(_equipmentSlotPrefab, slotParents[0]);
            // RectTransformを取得して位置を設定
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            RectTransform frameTransform = frameSlot.GetComponent<RectTransform>();
            if (slotTransform != null && frameTransform != null)
            {
                slotTransform.anchoredPosition = new Vector2(number * SLOT_SPACING, 0); // 150間隔で配置
                frameTransform.anchoredPosition = new Vector2(number * SLOT_SPACING, 0); // 150間隔で配置
            }

            // スロットをリストに追加
            _equipmentInventorySlots.Add(slot.GetComponent<Image>());
            _equipmentInventoryFrame.Add(frameSlot);

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
            GameObject frameSlot = Instantiate(_weaponFramePrefab, slotParents[1]);
            // プレハブからスロットを生成
            GameObject slot = Instantiate(_weaponSlotPrefab, slotParents[1]);

            // RectTransformを取得して位置を設定
            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            RectTransform frameTransform = frameSlot.GetComponent<RectTransform>();

            if (slotTransform != null && frameTransform != null)
            {
                slotTransform.anchoredPosition = new Vector2(number * SLOT_SPACING, 0); // 150間隔で配置
                frameTransform.anchoredPosition = new Vector2(number * SLOT_SPACING, 0); // 150間隔で配置

            }

            // スロットをリストに追加
            _weaponInventorySlots.Add(slot.GetComponent<Image>());
            // スロットをリストに追加
            _weaponInventoryFrame.Add(frameSlot);
        }
    }
    /// <summary>
    /// 装備入手時のUIの更新
    /// </summary>
    /// <param name="bodyEquipmentData">装備データ</param>
    /// <param name="index">インベント番号</param>
    public void UpdateAddEquipmentInventoryUI(BodyEquipmentData bodyEquipmentData, int index)
    {
        if (index < 0 || index >= _equipmentInventorySlots.Count)
        {
            return;
        }
        if (!_equipmentInventorySlots[index].enabled)
        {
            _equipmentInventorySlots[index].enabled = true;
        }
        _equipmentInventorySlots[index].sprite = bodyEquipmentData.Icon[8];
    }
    /// <summary>
     /// 装備変更した時のUIの更新
     /// </summary>
     /// <param name="bodyEquipmentData">装備データ</param>
     /// <param name="index">インベント番号</param>
    //public void UpdateRemoveEquipmentInventoryUI(BodyEquipmentData bodyEquipmentData, int index)
    //{
    //    if (index < 0 || index >= _equipmentInventorySlots.Count)
    //    {
    //        return;
    //    }
    //    _equipmentInventorySlots[index].sprite =null;
    //}

    /// <summary>
    /// 武器入手時のUIの更新
    /// </summary>
    /// <param name="weaponEquipmentData">武器データ</param>
    /// <param name="index">インベント番号</param>
    public void UpdateAddWeaponInventoryUI(WeaponEquipmentData weaponEquipmentData, int index)
    {
        if (index < 0 || index >= _weaponInventorySlots.Count)
        {
            return;
        }
        if (!_weaponInventorySlots[index].enabled)
        {
            _weaponInventorySlots[index].enabled = true;
        }
        _weaponInventorySlots[index].sprite = weaponEquipmentData.Icon;
    }

    /// <summary>
    /// 武器変更した時のUIの更新
    /// </summary>
    /// <param name="weaponEquipmentData">装備データ</param>
    /// <param name="index">インベント番号</param>
    //public void UpdateRemoveWeaponInventoryUI(WeaponEquipmentData weaponEquipmentData, int index)
    //{
    //    if (index < 0 || index >= _equipmentInventorySlots.Count)
    //    {
    //        return;
    //    }
    //    _weaponInventorySlots[index].sprite = null;

    //}
}

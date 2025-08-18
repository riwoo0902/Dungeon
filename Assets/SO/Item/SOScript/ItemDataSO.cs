using UnityEngine;
using WeaponSO;

namespace Item
{
    [CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/ItemSO")]
    public class ItemDataSO : ScriptableObject
    {
        [SerializeField] private ItemTypeEnum itemType;
        public ItemTypeEnum ItemType => itemType;

        [SerializeField] private int itemID;
        public int ItemID => itemID;

        [SerializeField] private string itemName = "1";
        public string ItemName => itemName;

        [SerializeField] private Sprite itemSprite;
        public Sprite ItemSprite => itemSprite;

        [SerializeField] private int maxItemStack = 1;
        public int MaxItemStack => maxItemStack;


        #region Consumable


        #endregion

        #region Weapon
        [SerializeField] private WeaponDataSO weaponSO;
        public WeaponDataSO WeaponSO => weaponSO;
        #endregion

        private void OnValidate()
        {
            if (itemType == ItemTypeEnum.Weapon) maxItemStack = 1;
            else if (maxItemStack <= 0) Debug.LogError($"maxItemStack Error \n now maxItemStack = {maxItemStack}");
            if (itemName.Trim() == "") Debug.LogError($"itemName Error \n now itemName = \"{itemName}\"");


            
        }

    }

    public enum ItemTypeEnum
    {
        Resource,//재료
        Consumable,//소모품
        Weapon,//무기
    }
}

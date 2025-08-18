using Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UI.inventory.Item
{
    public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [field:SerializeField] public ItemDataSO itemData { get; private set; }
        private Image image;
        public int ItemID { get; private set; }
        [SerializeField] private int itemStack = 1;
        
        private void Awake()
        {
            image = GetComponent<Image>();
            image.sprite = itemData.ItemSprite;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {

        }


        public void ChangeItemData(ItemDataSO a, int itemstack)
        {
            gameObject.SetActive(true);
            itemData = a;
            image.sprite = itemData.ItemSprite;
            itemStack = itemstack;
            ItemID = itemData.ItemID;
        }

        public void Destroy()
        {
            gameObject.SetActive(false);

        }



    }
}


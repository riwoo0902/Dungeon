using Item;
using TMPro;
using UI.inventory.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UI.inventory.Item
{
    public class Item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [field:SerializeField] public ItemDataSO itemData { get; private set; }
        private Image image;
        [SerializeField] private int itemStack = 1;
        private TextMeshProUGUI TextMeshProUGUI;
        private void Awake()
        {
            image = GetComponent<Image>();
            TextMeshProUGUI = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            ChangeItemData(itemData, itemStack);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            
        }


        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;

        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.pointerEnter.TryGetComponent<Slot>(out Slot slot))
            {
                Debug.Log("asda");
                slot.HaveItem = GetComponent<Item>();
            }
        }

        public void ChangeItemData(ItemDataSO a, int itemstack)
        {
            if(itemstack >= 1)
            {
                gameObject.SetActive(true);
                itemData = a;
                image.sprite = itemData.ItemSprite;
                itemStack = itemstack;
                TextMeshProUGUI.text = itemStack.ToString();
            }
            else
            {
                gameObject.SetActive(false);
                itemData = null;
                image.sprite = null;
                itemStack = 0;
                TextMeshProUGUI.text = "";
            }
            
        }

        public void Destroy()
        {
            gameObject.SetActive(false);

        }

        
    }
}




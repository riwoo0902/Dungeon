using Item;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace UI.inventory.Item
{
    public class Item : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

        
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            
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


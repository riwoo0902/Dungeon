using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.inventory.Item
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Item haveItem;
        public Item HaveItem
        {
            get => haveItem;
            set
            {
                haveItem = value;
            }
        }


        private void Awake()
        {
            
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}


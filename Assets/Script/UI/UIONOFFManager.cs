using UnityEngine;
using UnityEngine.InputSystem;


namespace UI.inventory
{
    public class UIONOFFManager : MonoBehaviour
    {
        [field:SerializeField] public GameObject inventory { get; private set; }


        void Update()
        {
            Inventory();

        }

        
        public void Inventory()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                inventory.SetActive(false);
            }

            if (Keyboard.current.bKey.wasPressedThisFrame)
            {
                inventory.SetActive(!inventory.activeSelf);
            }
            
        }
    }
}


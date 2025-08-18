using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Item
{
    [CustomEditor(typeof(ItemDataSO))]
    public class ItemDataSOEditer :UnityEditor.Editor
    {
        private SerializedProperty _itemType;
        private SerializedProperty _itemID;
        private SerializedProperty _itemName;
        private SerializedProperty _itemSprite;
        private SerializedProperty _maxItemStack;


        private SerializedProperty _weaponSO;
        
        private void OnEnable()
        {
            _itemType = serializedObject.FindProperty("itemType");
            _itemID = serializedObject.FindProperty("itemID");
            _itemName = serializedObject.FindProperty("itemName");
            _itemSprite = serializedObject.FindProperty("itemSprite");
            _maxItemStack = serializedObject.FindProperty("maxItemStack");


            _weaponSO = serializedObject.FindProperty("weaponSO");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_itemType);
            GUILayout.Label("\nCommon", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_itemID);
            EditorGUILayout.PropertyField(_itemName);
            EditorGUILayout.PropertyField(_itemSprite);
            EditorGUILayout.PropertyField(_maxItemStack);

            var outlineInfo = target as ItemDataSO;

            if (outlineInfo != null)
            {

                if (outlineInfo.ItemType == ItemTypeEnum.Resource)
                {
                    GUILayout.Label("\nResource_Settings", EditorStyles.boldLabel);
                    

                }

                else if (outlineInfo.ItemType == ItemTypeEnum.Consumable)
                {
                    GUILayout.Label("\nConsumable_Settings", EditorStyles.boldLabel);


                }

                else if (outlineInfo.ItemType == ItemTypeEnum.Weapon)
                {
                    GUILayout.Label("\nWeapon_Settings", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(_weaponSO);
                }

            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}


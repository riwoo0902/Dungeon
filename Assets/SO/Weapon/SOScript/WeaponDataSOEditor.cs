using UnityEditor;
using UnityEngine;

namespace WeaponSO
{
    [CustomEditor(typeof(WeaponDataSO))]
    public class WeaponDataSOEditor : UnityEditor.Editor
    {
        private SerializedProperty _weaponTypeProp;

        private SerializedProperty _sprite;
        private SerializedProperty _attackCoolTime;
        private SerializedProperty _damage;
        private SerializedProperty _scale;
        private SerializedProperty _mouseLookAngleCorrectionValue;

        private SerializedProperty _swordRotation;
        private SerializedProperty _swordAttackSpeed;
        private SerializedProperty _swordInclination;
        private SerializedProperty _addSwordScripts;


        
        private SerializedProperty _bulletSO;
        private SerializedProperty _addBowScripts;

        private SerializedProperty _addEtcScripts;
        private void OnEnable()
        {
            _weaponTypeProp = serializedObject.FindProperty("weaponType");

            _sprite = serializedObject.FindProperty("sprite");
            _damage = serializedObject.FindProperty("damage");
            _attackCoolTime = serializedObject.FindProperty("attackCoolTime");
            _scale = serializedObject.FindProperty("scale");
            _mouseLookAngleCorrectionValue = serializedObject.FindProperty("mouseLookAngleCorrectionValue");

            #region Melee
            _swordRotation = serializedObject.FindProperty("swordRotation");
            _swordAttackSpeed = serializedObject.FindProperty("swordAttackSpeed");
            _swordInclination = serializedObject.FindProperty("swordInclination");
            _addSwordScripts = serializedObject.FindProperty("addSwordScripts");

            #endregion

            #region Ranger
            _bulletSO = serializedObject.FindProperty("bulletSO");
            _addBowScripts = serializedObject.FindProperty("addBowScripts");
            #endregion

            #region Etc
            _addEtcScripts = serializedObject.FindProperty("addEtcScripts");

            #endregion

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();



            EditorGUILayout.PropertyField(_weaponTypeProp);
            GUILayout.Label("\nCommon", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_damage);
            EditorGUILayout.PropertyField(_sprite);
            EditorGUILayout.PropertyField(_attackCoolTime);
            EditorGUILayout.PropertyField(_scale);
            EditorGUILayout.PropertyField(_mouseLookAngleCorrectionValue);


            var outlineInfo = target as WeaponDataSO;

            if (outlineInfo != null)
            {

                if (outlineInfo.WeaponType == WeaponType.Sword)
                {
                    GUILayout.Label("\nSword_Settings", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(_swordRotation);
                    EditorGUILayout.PropertyField(_swordAttackSpeed);
                    EditorGUILayout.PropertyField(_swordInclination);
                    EditorGUILayout.PropertyField(_addSwordScripts);
                }

                else if (outlineInfo.WeaponType == WeaponType.Bow)
                {
                    GUILayout.Label("\nBow_Settings", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(_bulletSO);
                    EditorGUILayout.PropertyField(_addBowScripts);
                }
                else if (outlineInfo.WeaponType == WeaponType.Etc)
                {
                    GUILayout.Label("\nEtc_Settings", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(_addEtcScripts);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }

}

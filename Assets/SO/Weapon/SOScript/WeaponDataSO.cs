using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;



namespace WeaponSO
{
    [CreateAssetMenu(fileName = "WeaponSo", menuName = "WeaponSO/WeaponDataSO")]
    public class WeaponDataSO : ScriptableObject
    {
        [SerializeField] private WeaponType weaponType;
        public WeaponType WeaponType => weaponType;


        [SerializeField] private Sprite sprite;
        public Sprite Sprite => sprite;


        [SerializeField] private int damage = 10;
        public int Damage => damage;
        

        [SerializeField] private float attackCoolTime;
        public float AttackCoolTime => attackCoolTime;


        [SerializeField] private Vector3 scale = new Vector3(1.0f, 1.0f, 1.0f);
        public Vector3 Scale => scale;


        [SerializeField] private float mouseLookAngleCorrectionValue = -90;
        public float MouseLookAngleCorrectionValue => mouseLookAngleCorrectionValue;



        [SerializeField] private float swordRotation = 120;
        public float SwordRotation => swordRotation;

        [SerializeField] private float swordAttackSpeed = 0.5f;
        public float SwordAttackSpeed => swordAttackSpeed;

        [SerializeField] private float swordInclination  = 60;
        public float SwordInclination => swordInclination;



        [SerializeField] public MonoScript[] addSwordScripts;
        public MonoScript[] AddSwordScript => addSwordScripts;


        [SerializeField] private BulletSO bulletSO;
        public BulletSO BulletSO => bulletSO;

        [SerializeField] public MonoScript[] addBowScripts;
        public MonoScript[] AddBowScript => addBowScripts;


        [SerializeField] public MonoScript[] addEtcScripts;
        public MonoScript[] AddEtcScript => addEtcScripts;
    }

    public enum WeaponType
    {
        Sword, Bow, Etc
    }

}

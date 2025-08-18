using UnityEditor;
using UnityEngine;

namespace WeaponSO
{
    [CreateAssetMenu(fileName = "BulletDataSO", menuName = "WeaponSO/BowDataSO")]
    public class BulletSO : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public float Speed { get; private set; } = 5;
        [field: SerializeField] public float LifeTime { get; private set; } = 5;
        [field: SerializeField] public float MouseLookAngleCorrectionValue { get; private set; }
        [field: SerializeField] public MonoScript[] AddBulletScript { get; private set; }
    }

}


using System;
using UnityEngine;
[Serializable]
public class PlayerFacade : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerHp _playerHp;
    
    public void ApplyDamage(int damage)
    {
       _playerHp.ApplyDamage(damage);
    }
}

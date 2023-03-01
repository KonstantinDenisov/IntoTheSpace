using System;
using UnityEngine;
[Serializable]
public class PlayerFacade : MonoBehaviour
{
    public PlayerMovement _playerMovement;
    public PlayerHp _playerHp;

    private void Awake()
    {
        _playerHp = gameObject.AddComponent<PlayerHp>();
        _playerMovement = gameObject.AddComponent<PlayerMovement>();
    }
}

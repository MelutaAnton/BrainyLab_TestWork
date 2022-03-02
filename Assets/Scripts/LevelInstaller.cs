using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInstaller : MonoBehaviour
{
    [SerializeField]
    private IntVariable scorePlayer;
    [SerializeField]
    private IntVariable scoreEnemy;

    private void Awake()
    {
        scorePlayer.Value = 0;
        scoreEnemy.Value = 0;
    }
}

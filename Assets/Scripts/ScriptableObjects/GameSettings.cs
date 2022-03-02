using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Game Settings", menuName ="Create Game Settings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    [Range(5,10)]
    private float speedPlayer = 5;
    [SerializeField]
    [Range(6, 12)]
    private float speedEnemy = 12;
    [SerializeField]
    [Range(0.5f, 2)]
    private float enemyDelayOnSpot = 2;
    [SerializeField]
    [Range(0.1f, 1)]
    private float intervalShootsPlayer = 0.3f;
    


    public float SpeedPlayer => speedPlayer;
    public float SpeedEnemy => speedEnemy;
    public float EnemyDelayOnSpot => enemyDelayOnSpot;
    public float IntervalShootsPlayer => intervalShootsPlayer;

}

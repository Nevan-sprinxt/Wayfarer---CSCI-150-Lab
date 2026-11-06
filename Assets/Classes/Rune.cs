using UnityEngine;

[CreateAssetMenu(fileName = "Rune", menuName = "Scriptable Objects/Rune")]
public class Rune : ScriptableObject
{
    [SerializeField] private string runeName;
    [SerializeField] private bool isAbilityRune;
    [SerializeField] private string statAffected1;
    [SerializeField] private double statChangePercent1;
    [SerializeField] private string statAffected2;
    [SerializeField] private double statChangePercent2;
    [SerializeField] private int strain;
}

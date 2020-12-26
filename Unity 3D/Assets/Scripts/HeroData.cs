using UnityEngine;
[CreateAssetMenu(fileName = "HeroData", menuName = "Chris/Hero")]
public class HeroData : ScriptableObject
{
    [Header("HP"), Range(100, 800)]
    public float HP;
    [Header("MP"), Range(50, 400)]
    public float MP;
    [Header("Speed"), Range(1, 10)]
    public float speed;
    [Header("Attack"), Range(10, 1000)]
    public float attack;
    [Header("Attack CD"), Range(1, 100)]
    public float cd;

    public Skill[] skills;
}

[System.Serializable]
public class Skill
{
    public string name;
    [Header("Attack"), Range(10, 1000)]
    public float attack;
    [Header("Cost"), Range(10, 100)]
    public float cost;
    [Header("Image")]
    public Sprite image;
    [Header("CD"), Range(1, 100)]
    public float cd;
}

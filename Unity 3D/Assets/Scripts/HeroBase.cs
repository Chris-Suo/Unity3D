using UnityEngine;

public class HeroBase : MonoBehaviour
{
    [Header("Hero Data")]
    public HeroData hero;

    private Animator ani;

    private float[] skillTimer = new float[4];
    private bool[] isSkill = new bool[4];

    protected virtual void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void Move()
    {

    }

    public void Skill_1()
    {
        ani.SetTrigger("move1");
    }
    public void Skill_2()
    {
        ani.SetTrigger("move2");

    }
    public void Skill_3()
    {
        ani.SetTrigger("move3");

    }
    public void Big_Skill()
    {
        ani.SetTrigger("bigMove");

    }
}

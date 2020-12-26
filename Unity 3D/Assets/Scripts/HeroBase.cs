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

    private void Update()
    {
        TimerControl();
    }

    private void TimerControl()
    {
        for (int i = 0; i < isSkill.Length; i++)
        {
            if (isSkill[i])
            {
                skillTimer[i] += Time.deltaTime;

                if (skillTimer[i] >= hero.skills[i].cd)
                {
                    skillTimer[i] = 0;
                    isSkill[i] = false;
                }
            }
        }

    }

    public void Move()
    {

    }

    public void Skill_1()
    {
        if (isSkill[0]) return;
        ani.SetTrigger("move1");
        isSkill[0] = true;

    }
    public void Skill_2()
    {
        if (isSkill[1]) return;
        ani.SetTrigger("move2");
        isSkill[1] = true;
    }
    public void Skill_3()
    {
        if (isSkill[2]) return;
        ani.SetTrigger("move3");
        isSkill[2] = true;
    }
    public void Big_Skill()
    {
        if (isSkill[3]) return;
        ani.SetTrigger("bigMove");
        isSkill[3] = true;
    }
}

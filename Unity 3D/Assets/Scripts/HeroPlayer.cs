using UnityEngine;
using UnityEngine.UI;

public class HeroPlayer : HeroBase
{
    public float moveDis = 2;
    private Button[] btnSkills = new Button[3];
    private Button btnBigSkill;

    private Image[] imgSkills = new Image[4];
    private Image[] imgSkillsCD = new Image[4];
    private Text[] textCD = new Text[4];
    private Transform target;
    private Joystick joy;
    private Transform camRoot;

    protected override void Awake()
    {
        base.Awake();
        SetButton();
        target = GameObject.Find("target").transform;
        joy = GameObject.Find("Dynamic Joystick").GetComponent<Joystick>();
        camRoot = GameObject.Find("CameraRoot").transform;
    }
    protected override void Update()
    {
        base.Update();
        MoveControl();
        UpdateSkllCD();
    }

    private void MoveControl()
    {
        float v = joy.Vertical;
        float h = joy.Horizontal;

        target.position = transform.position + (camRoot.forward * v * moveDis) + (camRoot.right * h * moveDis);
        Move(target);
    }
    private void SetButton()
    {
        btnSkills[0] = GameObject.Find("Btn_Skill_1").GetComponent<Button>();
        btnSkills[1] = GameObject.Find("Btn_Skill_2").GetComponent<Button>();
        btnSkills[2] = GameObject.Find("Btn_Skill_3").GetComponent<Button>();
        btnBigSkill = GameObject.Find("Btn_Big_Skill").GetComponent<Button>();

        btnSkills[0].onClick.AddListener(Skill_1);
        btnSkills[1].onClick.AddListener(Skill_2);
        btnSkills[2].onClick.AddListener(Skill_3);
        btnBigSkill.onClick.AddListener(Big_Skill);

        for (int i = 0; i < imgSkills.Length - 1; i++)
        {
            imgSkills[i] = GameObject.Find("Btn_Skill_" + (i + 1) + "_Pic").GetComponent<Image>();
            imgSkills[i].sprite = hero.skills[i].image;
            textCD[i] = GameObject.Find("Text_Skill_" + (i + 1)).GetComponent<Text>();
            textCD[i].text = "";

            imgSkillsCD[i] = GameObject.Find("Btn_Skill_" + (i + 1) + "_Pic_Cold").GetComponent<Image>();
        }
        imgSkills[3] = GameObject.Find("Btn_Big_Skill_Pic").GetComponent<Image>();
        imgSkills[3].sprite = hero.skills[3].image;
        textCD[3] = GameObject.Find("Text_Big_Skill").GetComponent<Text>();
        textCD[3].text = "";

        imgSkillsCD[3] = GameObject.Find("Btn_Big_Skill_Pic_Cold").GetComponent<Image>();

    }

    private void UpdateSkllCD()
    {
        for (int i = 0; i < 4; i++)
        {

            if (isSkill[i])
            {
                textCD[i].text = (hero.skills[i].cd - skillTimer[i]).ToString("f0");
                imgSkillsCD[i].fillAmount = (hero.skills[i].cd - skillTimer[i]) / hero.skills[i].cd;
            }
            else
            {
                textCD[i].text = "";
                imgSkillsCD[i].fillAmount = 0;
            }
        }
    }
}

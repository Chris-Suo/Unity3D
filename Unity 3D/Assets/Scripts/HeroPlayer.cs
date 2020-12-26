using UnityEngine;
using UnityEngine.UI;

public class HeroPlayer : HeroBase
{
    private Button[] btnSkills = new Button[3];
    private Button btnBigSkill;

    private Image[] imgSkills = new Image[4];
    private Text[] textCD = new Text[4];

    protected override void Awake()
    {
        base.Awake();
        SetButton();
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
        }
        imgSkills[3] = GameObject.Find("Btn_Big_Skill_Pic").GetComponent<Image>();
        imgSkills[3].sprite = hero.skills[3].image;
        textCD[3] = GameObject.Find("Text_Big_Skill").GetComponent<Text>();
        textCD[3].text = "";

    }


}

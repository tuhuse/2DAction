using UnityEngine;

public class Skill : PlayerController,ISkill
{
    void Start()
    {

    }
    void ISkill.Skill()
    {
        throw new System.NotImplementedException();
    }
}

using UnityEngine;

public class Skill : Player,ISkill
{
    void Start()
    {

    }
    void ISkill.Skill()
    {
        throw new System.NotImplementedException();
    }
}

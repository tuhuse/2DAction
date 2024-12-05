using UnityEngine;

public class Skill : MonoBehaviour,ISkill
{
    void Start()
    {

    }
    void ISkill.Skill()
    {
        throw new System.NotImplementedException();
    }
}

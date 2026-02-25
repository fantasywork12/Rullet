using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int EffectCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpinning == true)
        {
            if (EffectCount < 6)
            {
                //광대 환하게 웃는 모습<이펙트>
            }
              else if (EffectCount < 3)
                {
                    //광대 좀 웃는 모습<이펙트>
                }
                else (EffectCount < 0);
                    {
                        //광대 좀 웃는 모습<이펙트>
                    }
        
        }
    }
}

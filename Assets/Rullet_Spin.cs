using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Roulette : MonoBehaviour
{
    public int Bet;
    int Result;
    string Bet_Type = "All_In";
    int Bet_Dollar = 200;
    bool Winnig;

    float spinDuration = 3f;
    float spinSpeed = 1080f; 
    public bool reverseSpin = false; 
    public bool isSpinning = false;
    
    public bool usePhysics2D = true; 
    void Start()
    {
        Result = Random.Range(0, 37);
        Debug.Log("결과:" + Result);

        if (Bet == Result)
        {
            Winnig = true;
            Debug.Log("당첨!");
        }
        else
        {
            Winnig = false;
            Debug.Log("꽝");
        }

        if (Winnig == true)
        {
            if (Bet_Type == "Straight_Bet") ;
        }

    }

    
    void OnMouseDown()
    {
        if (!isSpinning)
            StartCoroutine(SpinRoutine());
    }

   
    void Update()
    {
        if (isSpinning)
            return;

        if (Camera.main == null)
        {
            Debug.LogWarning("No Camera.main found for click detection.");
            return;
        }

        var pointer = Pointer.current;
        if (pointer != null && pointer.press != null && pointer.press.wasPressedThisFrame)
        {
            Vector2 screenPos = pointer.position.ReadValue();

            if (usePhysics2D)
            {
                Vector2 wp = Camera.main.ScreenToWorldPoint(screenPos);
                Collider2D c = Physics2D.OverlapPoint(wp);
                if (c != null)
                {
                    Debug.Log("Clicked object: " + c.gameObject.name);
                    if (c.gameObject == gameObject)
                        StartCoroutine(SpinRoutine());
                }
                else
                {
                    Debug.Log("Click: no 2D collider at position " + wp);
                }
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(screenPos);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Clicked object: " + hit.collider.gameObject.name);
                    if (hit.collider.gameObject == gameObject)
                        StartCoroutine(SpinRoutine());
                }
                else
                {
                    Debug.Log("Click: no 3D collider hit from camera.");
                }
            }
        }
    }

    IEnumerator SpinRoutine()
    {
        isSpinning = true;
        float elapsed = 0f;
        float startSpeed = spinSpeed;

        while (elapsed < spinDuration)
        {
            float t = elapsed / spinDuration; 
            float currentSpeed = Mathf.Lerp(startSpeed, 0f, t);
            float delta = currentSpeed * Time.deltaTime;
            float dir = reverseSpin ? 1f : -1f;
            transform.Rotate(0f, 0f, dir * delta);
            elapsed += Time.deltaTime;
            yield return null;
        }

        isSpinning = false;
    }

    public class RouletteColor : MonoBehaviour
    {
        SpriteRenderer sr;

        void Update()
        {

        }
    }

}


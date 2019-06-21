using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifter : MonoBehaviour
{
    private static string playerName = "player";
    private static string counterUI = "startCounter";
    private static string lifterName = "lifter";
    bool startCounting = false;
    bool triggered = false;
    float counter = 0.1f;
    public bool elevatorEnd = false; // the direction of the elevator
    Vector3 originalLifterPosition; // dont revise the value
    Vector3 teleportedLifterPosition; // dont revise the value
    // Start is called before the first frame update
    GameObject ui;
    public bool Triggered {
        get {
            return triggered;
        }
    }
    private void Start()
    {
        originalLifterPosition = transform.Find(lifterName).gameObject.transform.position;
        teleportedLifterPosition = originalLifterPosition + new Vector3(0, 110, 0);
        ui = transform.Find(counterUI).gameObject;
        if (elevatorEnd) {
            elevatorEnd = false;
            Lift();
        }
    }

    private void Update()
    {
        if (startCounting) {
            ui.SetActive(true);
        }

        if (startCounting)
        {
            counter -= Time.deltaTime;
        }

        if (counter < 0)
        {
            counter = 0;
            Lift();
        }
    }
    public void Trigger() {
        startCounting = true;
    }

    public void Lift() {
        triggered = true;
        GameObject target = transform.Find(lifterName).gameObject;
        Vector3 start = originalLifterPosition;
        Vector3 end = teleportedLifterPosition;
        if (!elevatorEnd)
        {
            StartCoroutine(MoveInSecond(target, start, end, 10));
        }

        else {
            StartCoroutine(MoveInSecond(target, end, start, 10));
        }
    }

    private IEnumerator MoveInSecond(GameObject target, Vector3 start , Vector3 end, float second) {
        float currentTime = 0;
        while (currentTime < second) {
            target.transform.position = Vector3.Lerp(start, end, currentTime / second);
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        target.transform.position = end;
        yield return new WaitForSeconds(3f);
        elevatorEnd = !elevatorEnd;
        Reset();
    }
    /// <summary>
    /// reset the elevator state
    /// </summary>
    private void Reset()
    {
        triggered = false;
        startCounting = false;
        counter = 0.1f;
        ui.SetActive(false);
    }
}

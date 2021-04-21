using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogModel : ScriptableObject
{
    public string text = "";

    public bool goToNextMap = false;
    public float nextXPosition;
    public float nextYPosition;
    public Vector2 nextMaxPosition;
    public Vector2 nextMinPosition;

    public DialogModel next;
    public DialogModel back;
 }

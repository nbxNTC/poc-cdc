using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogModel : ScriptableObject
{
    public string text = "";
    public DialogModel next;
    public DialogModel back;
 }

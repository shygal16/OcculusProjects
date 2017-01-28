using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    
    public enum Type
    {
        Simple,
        Death
    }
    public int score;
    public Type type;

   
}

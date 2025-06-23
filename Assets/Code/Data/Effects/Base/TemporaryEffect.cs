using UnityEngine;
using UnityEngine.UI;

public abstract class TemporaryEffect : Effect
{
    [SerializeField] protected Sprite icon;
    [SerializeField] protected float durationEffect;
    public Sprite Icon => icon;
    public float DurationEffect => durationEffect;
}
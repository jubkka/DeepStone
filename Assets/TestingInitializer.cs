using UnityEngine;

public class TestingInitializer : MonoBehaviour
{
    [SerializeField] private SpellData spellData;

    private Item item;
    private SpellComponent spellComponent;
    
    private void Start()
    {
        spellComponent = GearSystems.Instance.Spell;

        //item = new Item(spellData);
        //spellComponent.AddItem(item, 0);
    }
}

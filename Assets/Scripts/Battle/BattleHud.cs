using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] Image statusBG;
    [SerializeField] Text statusText;
    [SerializeField] HPBar hpBar;


    [SerializeField] Color noColor;
    [SerializeField] Color psnColor;
    [SerializeField] Color brnColor;
    [SerializeField] Color parColor;
    [SerializeField] Color frzColor;
    [SerializeField] Color slpColor;

    Pokemon _pokemon;
    Dictionary<ConditionID, Color> statusColors;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;
        nameText.text = pokemon.Base.Name;
        levelText.text = "Lvl " + pokemon.Level;
        hpBar.SetHP((float)pokemon.HP / pokemon.MaxHp);

        statusColors = new Dictionary<ConditionID, Color>()
        {
            {ConditionID.psn, psnColor },
            {ConditionID.brn, brnColor },
            {ConditionID.par, parColor },
            {ConditionID.frz, frzColor },
            {ConditionID.slp, slpColor },
            {ConditionID.none, noColor},
        };


        SetStatusText();
        _pokemon.OnStatusChanged += SetStatusText;
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.ColorHP();
        if (_pokemon.HpChanged)
        {
            yield return hpBar.SetHPSmooth((float)_pokemon.HP / _pokemon.MaxHp);
            _pokemon.HpChanged = false;
        }
    }
    public void SetStatusText()
    {
        if (_pokemon.Status == null)
        {
            statusText.text = "";
            statusBG.color = statusColors[ConditionID.none];
        }
        else
        {
            statusText.text = _pokemon.Status.Id.ToString().ToUpper();
            statusBG.color = statusColors[_pokemon.Status.Id];
        }
    }    
}

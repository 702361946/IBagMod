# CIF Item Module

## config file
```json
{
    "ItemName": {
        "Desc": "ItemDocs",
        "AttributeTypes": [
            "The length of AttributeCurveFuncList must be equal to the length of AttributeTypes"
        ],
        "AttributeCurveFuncList": [
            "AttributeType",
            [
                "CurveFunc",
                [
                    "parameter"
                ]
            ]
        ],
        "BarColorStr": "#FFFFFF",
        "NumColorStr": "#FFFFFF",
        "IsLive": 0
    }
}
```

### copy JSON

```json
{
    "ItemName": {
        "Desc": "ItemDocs",
        "AttributeTypes": [
            
        ],
        "AttributeCurveFuncList": [
            
        ],
        "BarColorStr": "#FFFFFF",
        "NumColorStr": "#FFFFFF",
        "IsLive": 0
    }
}
```

### key info
> *.AttributeTypes

| id  | name                            | info |
|-----|---------------------------------|------|
| 0   | forgeAtk                        |      |
| 1   | autoAtk                         |      |
| 2   | energyPct                       |      |
| 3   | dissolvePct                     |      |
| 4   | autoAtk2                        |      |
| 5   | ExpPct                          |      |
| 6   | generatePotion                  |      |
| 7   | copyItem                        |      |
| 8   | newWorld                        |      |
| 10  | weapon_atk                      |      |
| 11  | cloth_hp_max                    |      |
| 12  | potion_food_recover             |      |
| 13  | arrow_count                     |      |
| 14  | defence                         |      |
| 15  | evade                           |      |
| 16  | speed                           |      |
| 17  | hp_add_per_second               |      |
| 18  | arrow_atk                       |      |
| 20  | hot_potion_cure_exp             |      |
| 21  | cold_potion_cure_exp            |      |
| 22  | erosion_add_protect_exp         |      |
| 23  | hot_poison_lv                   |      |
| 24  | cold_poison_lv                  |      |
| 25  | erosion_poison_exp              |      |
| 30  | stone                           |      |
| 31  | jewel                           |      |
| 32  | trap                            |      |
| 40  | protect_from_hot                |      |
| 41  | protect_from_cold               |      |
| 42  | protect_from_erosion            |      |
| 50  | add_hot_exp_from_cloth_perXsec  |      |
| 51  | add_cold_exp_from_cloth_perXsec |      |
| 60  | add_hot_exp_per_attack          |      |
| 61  | add_cold_exp_per_attack         |      |
| 62  | add_erosion_per_attack          |      |
| 70  | suck_blood_pml                  |      |
| 71  | reflect_demage_pml              |      |
| 99  | other                           |      |
| 100 | add_steal_rate                  |      |
| 101 | add_drop_rate                   |      |
| 102 | add_abyss_wait_time             |      |
| 103 | add_shop_rate                   |      |
| 104 | abyss_port_down                 |      |
| 105 | abyss_port_up                   |      |
| 106 | abyss_insurance                 |      |
| 107 | abyss_risk                      |      |
| 108 | abyss_exp_bonus                 |      |
| 110 | add_atk_buff_exp                |      |
| 111 | fix_worst_equipment             |      |
| 112 | add_hp_generate_exp             |      |
| 113 | add_abyss_exp_bonus_buff_exp    |      |
| 114 | add_hpmax_buff_exp              |      |
| 120 | never_fade                      |      |
| 121 | evolve_equip                    |      |
| 122 | fast_debuff_fade                |      |                                                                                                                            
| 130 | attack_unit_atk_value           |      |
| 131 | attack_target_unit_atk_value    |      |                                                                                                                       
| 140 | law_item_maxup                  |      |
| 141 | law_hero_maxup                  |      |
| 142 | law_buff_maxup                  |      |
| 143 | law_shop_lv                     |      |
| 144 | law_arrow_powerup               |      |                                                                                

> *.AttributeCurveFuncList
 
`List`\[`Corresponding to the position in AttributeTypes`]

`List`\[`List`\[`is curve func`]]

`List`\[`List`\[`List`\[`is curve func parameter`]]]

| parameter len | func                                              |
|---------------|---------------------------------------------------|
| 1             | f(`a`)                                            |
| 2             | f(`a + lv * b`)                                   |
| 3             | f(`a * lv ^ b + c`)                               |
| 4             | f(`a * lv % d ^ 2 + b * lv % d + c`)              |
| 6             | f(`a * lv % d ^ 2 + b * lv % d + c + lv * e + f`) |

> *.IsLive
 
\> 0 is Live

= 0 is not Live

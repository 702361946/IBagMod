# CIF Module

## scan mod

The scan root is the `Mod` directory under the folder where the CIF mod framework is installed.

The mod framework folder is usually located under `GameRoot/BepInEx/plugins/`, but the actual installation path may vary.

Scan path pattern:

`<ModFrameworkFolder>/Mod/*(folder)/config.json`

If the mod framework is installed under `plugins`, the path is:

`GameRoot/BepInEx/plugins/<ModFrameworkFolder>/Mod/*(folder)/config.json`

The mod must meet the following requirements

1. There is a config.json under `Mod/*(folder)/`
2. The config.json file must contain a key "name"

## config file
```json
{
    "name": "ModName",
    "ItemConfig": ["ItemConfigFilePath(From the folder where config.json is located)"]
}
```

> copy JSON

```json
{
    "name": "ModName",
    "ItemConfig": []
}
```

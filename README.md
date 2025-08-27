# Uconomy XP
Synchronizes player experience with Uconomy balance and works with all Uconomy-dependent plugins.

## Features
* Seamless experience-to-balance synchronization
* Local JSON database storage (balances.json)
* Drop-in replacement for Uconomy (Uconomy.dll)
* Zero-configuration setup
* Safe for existing servers that use experience as currency as it will not reset player balances

## Important Notes
* File name is Uconomy.dll but loads as UconomyXP in server logs
* Data location: `Rocket/Plugins/Uconomy/`
* Single-server usage only (no cross-server sync)
* Compatible with all plugins that require original Uconomy
* Cannot be used alongside original Uconomy plugin
* Cannot copy balances from original Uconomy plugin

> **💡 PRO TIP**
> Looking to share balances across multiple servers or use a separate currency system? Check out the original [Uconomy](https://restoremonarchy.com/servers/plugins/uconomy) plugin with MySQL support.

## Configuration
```xml
<?xml version="1.0" encoding="utf-8"?>
<UconomyConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Comment>You only have to configure Database if you want to use ZaupShop</Comment>
  <DatabaseAddress>localhost</DatabaseAddress>
  <DatabaseUsername>unturned</DatabaseUsername>
  <DatabasePassword>password</DatabasePassword>
  <DatabaseName>unturned</DatabaseName>
  <DatabaseTableName>uconomy</DatabaseTableName>
  <DatabasePort>3306</DatabasePort>
  <InitialBalance>30</InitialBalance>
  <MoneySymbol>$</MoneySymbol>
  <MoneyName>Credits</MoneyName>
</UconomyConfiguration>
```

## Translations
```xml
<?xml version="1.0" encoding="utf-8"?>
<Translations xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Translation Id="command_balance_show" Value="Your current balance is: {0} {1}" />
  <Translation Id="command_pay_invalid" Value="Invalid arguments" />
  <Translation Id="command_pay_error_pay_self" Value="You cant pay yourself" />
  <Translation Id="command_pay_error_invalid_amount" Value="Invalid amount" />
  <Translation Id="command_pay_error_cant_afford" Value="Your balance does not allow this payment" />
  <Translation Id="command_pay_error_player_not_found" Value="Failed to find player" />
  <Translation Id="command_pay_private" Value="You paid {0} {1} {2}" />
  <Translation Id="command_pay_console" Value="You received a payment of {0} {1} " />
  <Translation Id="command_pay_other_private" Value="You received a payment of {0} {1} from {2}" />
</Translations>
```

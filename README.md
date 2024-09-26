# Uconomy XP
Saves player experience to a json file and works as Uconomy.

## Information
* Plugin file name is `Uconomy.dll` and data is stored in `Rocket/Plugins/Uconomy/` directory
* Stores players experience in balances.json file, so they can be paid while they are offline
* Balances cannot be shared across the servers
* Works for all plugins that reference original Uconomy plugin  

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
  <MoneyName>Credits</MoneyName>
</UconomyConfiguration>
```

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

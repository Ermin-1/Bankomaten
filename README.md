# Bankomaten

Inledning:

Det här är en enkel konsolapplikation för en bankomat. Programmet hanterar fem olika användare, deras pinkoder och bankkonton med saldon. Användare kan logga in, se sina konton och saldon, föra över pengar mellan konton, ta ut pengar och logga ut.

Användning:

Starta programmet och följ instruktionerna för att logga in med användarnamn och pinkod.
Välj ett av alternativen i huvudmenyn och följ intstruktioner
När du är klar, välj "Logga ut" för att avsluta programmet.

Funktioner:

Användare och Pinkoder
Användare och deras pinkoder lagras i arrays som Användare och PinKod. Pinkoderna är kopplade till användarna med samma index i respektive array. Om en användare har rätt användarnamn och pinkod vid inloggning loggas anävndaren in.

Bankkonton:

Bankkonton lagras som "jugged" arrayer i KontoNamn och KontoSaldo. Varje användare har ett antal konton med namn och tillhörande saldo. Dessa kopplas också med samma index.

Inloggning:

Användaren har tre försök att logga in med rätt användarnamn och pinkod. Efter tre felaktiga försök stängs programmet ned.

Huvudmeny:

När en användare är inloggad, visas en meny med följande alternativ:

1. Se konton och saldon
2. Föra över pengar mellan konton
3. Ta ut pengar
4. Logga ut

Se konton och saldon:

Denna funktion visar användarens konton och deras saldo. Den använder informationen från KontoNamn och KontoSaldo och visar den för inloggad användare.

Föra över pengar:

Användaren kan föra över pengar mellan sina konton. Programmet ber användaren välja från vilket konto de vill föra över pengar och till vilket som tar emot. Det kontrollerar att det finns tillräckligt med pengar på avsändande konto innan överföringen genomförs.

Ta ut pengar:

Användaren kan ta ut pengar från ett av sina konton. Det kräver att användaren anger rätt pinkod igen för att bekräfta uttaget. Användaren har tre försök på sig. Kontroll utförs för att se till att det finns tillräckligt med pengar på det valda kontot.

Utloggning:

När användaren väljer att logga ut, avslutas progarmmet.

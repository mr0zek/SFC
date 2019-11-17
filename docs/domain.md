# Opis ogólny
W związku z rosnącym poziomem SMOGu w Polsce rozpoczynasz projekt który ma pomóc ludności w walce z tym zagrożeniem.

Celem jest realizacja aplikacji która zbiera informacje o poziomu smogu i ostrzegania ludność przed tym zagrożeniem.
Głównymi aspektami jest:
- monitorowanie poziomów zanieczyszczeń w powietrzu z ogólnopolskiej sieci czujników jak i pobieranie danych z baz publicznych 
- informowanie o przekroczeniu dopuszczalnych poziomów po tym jak użytkownik zarejestruje alert.

# Rejestracja użytkownika:
Aplikacja pozwala na zarejestrowanie konta użytkownika. Do użytkownika zostaje wysłany email z linkiem potwierdzającym. Jeżeli użytkownik nie potwierdzi emaila w ciągu 3 dni to konto jest usuwane. Po zarejestrowaniu zakładana jest czujka na adres który użytkownik poda w formularzu rejestracyjnym. Formularz ten zawiera również domyślny sposób komunikacji z użytkownikiem - Email/Sms.

# Czujki:
Zarejestrowani użytkownicy mogą rejestrować dowolną ilość czujek. Czujka monitoruje parametry smogu dla danego obszaru. Jeżeli zostaną przekroczone to wysyła powiadomienie do użytkownika (według domyślnego sposobu komunikacji). 
Po założeniu czujki użytkownik dostaje powiadomienie mailowe potwierdzające jej aktywność.

# Panel administracyjny:
Dla administratora udostępniony jest specjalny dashboard prezentujący : dane użytkownika, ilość założonych czujek, ilość wysłanych powiadomień. W razie wątpliwości administrator może zablokować konto użytkownika.

# Rejestracja czujników smogu:
Każdy z użytkowników może zarejestrować fizyczny czujnik smogu i podłączyć go do aplikacji. Rejestracja polega na wygenerowaniu unikalnego kodu z poziomu aplikacji. Czujniki mogą się komunikować z aplikacja za pomocą REST'owego API. Podczas przekazywania pomiarów czujnik wysyła również swój unikalny identyfikator.
Użytkownicy mogą zarejestrować wiele czujników w różnych lokalizacjach.


# Wymagania techniczne:
- Dla całej aplikacji dostępne jest API Rest'owe
- Aplikacja jest podzielona na moduły
- Aplikacja wdrażana jest jako jeden element (jedna jednostka deploymentu)



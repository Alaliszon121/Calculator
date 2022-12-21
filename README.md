# Dokumentacja program Kalkulator
Autor: Alicja Janeczko 4G

___

## Budowa i funkcjonalości programu:

___

* CalculatorPage.xaml.cs:
  * void WriteHistory()
  * void OnNumberClicked()
  * void ClearLastChar()
  * void OnClear()
  * void OnChangeSign()
  * void OnSelectOperator()
  * void CalculateAndSave()
  * void OnLog()
  * void OnAbsolute()
  * void OnRoot()
  * void OnSin()
  * void OnCos()
  * void OnPi()
  * void OnPower()
  * void OnDenominator()
  * void OnPercentage()
* Calculator.cs:
  * void SaveHistory(string)

___

## Opisy funkcji

___

### WriteHistory()
To funcja typu void, znajdująca się w pliku CalculatorPage.xaml.cs. Odpowiada za:
* Stworzenie nowego obiektu StreamReader i ustawienia ścieżki do pliku "history.txt" w folderze Documents użytkownika.
* Odczytanie każdego wiersza tekstu z pliku i dodanie go do obiektu Label z tekstem wiersza jako jego etykietą.

![WriteHistory](images/wh1.png)

___

### OnNumberClicked()
To funcja typu void, znajdująca się w pliku CalculatorPage.xaml.cs. Odpowiada za:

* Sprawdzenie, czy tekst w editableEquations jest równy "0" lub czy istnieje operator. Jeśli tak, to kod ustawi tekst w editableEquations jako pusty. Jeśli nie, to doda to, co zostało kliknięte do tekstu.

![OnNumberClicked](images/onc2.png)

___

### ClearLastChar()
To funcja typu void, znajdująca się w pliku CalculatorPage.xaml.cs. Odpowiada za:

* Usuwanie po jednym znaku z ciągu znaków w równaniu
* Jeśli w róznaniu nie ma żadnego znaku, ustawienie jego wartości na 0

![ClearLastChar](images/clc3.PNG)
___

### OnClear()
To funcja typu void, znajdująca się w pliku CalculatorPage.xaml.cs. Odpowiada za:

* Przypisanie równianu wartości początkowej (0)
 
![OnClear](images/oc4.PNG)
___

### OnChangeSign()
To funcja typu void, znajdująca się w pliku CalculatorPage.xaml.cs. Odpowiada za:

* Zmianie znaku równania na przeciwny i wyświetlenie go jako wynik działania

![OnChangeSign](images/ocs5.PNG)

___

### OnSelectOperator()
To funcja typu void, znajdująca się w pliku CalculatorPage.xaml.cs. Odpowiada za:

* Sprawdzenie, czy użytkownik wpisał liczbę w editableEquations.Text. Jeśli tak, to kod przetwarza tę liczbę i przypisuje ją do firstdigit.
* Przypisuje warość wybranego operatora do zmiennej, w której będzie przechowywany pod warunkiem, że nie jest on "-", a w równanie nie jest puste

![OnSelectOperator](images/oso6.PNG)

___

### CalculateAndSave()
To funcja typu void, znajdująca się w pliku CalculatorPage.xaml.cs. Odpowiada za:

* Obliczenie równania w zależności od wybranego operatora: +, -, *, / lub % (modulo)
* Dodanie do historii obliczeń równania i wywołanie funkcji **SaveHistory(string)** z argumentem, który jest ciągiem znaów zawierającym równanie
* Zabezpieczenie przed próbą podzielenia przez 0
* Wyzerowanie zmiennych
  
![CalculateAndSave](images/cas7.PNG)
___

### Funkcje kalkulatora naukowego
* **OnLog()**: Oblicza logarytm o podstawie 10 z liczby
* **OnAbsolute()**: Oblicza wartość bezwzględną z liczby
* **OnRoot()**: Oblicza pierwiastek drugiego stopnia z liczby
* **OnSin()**: Oblicza sinus równania
* **OnCos()**: Oblicza cosinus równania
* **OnPi()**: Ustawia wartość liczby w równaniu na liczbę pi
* **OnPower()**: Oblicza potęgę kwadratową z liczby
* **OnDenominator()**: Oblicza ułamek, gdzie licznikiem jest 1 a mianowanikiem liczba z równania
* **OnPercentage()**: Zamienia procent na liczbę
* Wszystkie powyższe funkcje dodają wynik do historii obliczeń równania i wywołują funkcję **SaveHistory(string)** z argumentem, który jest ciągiem znaów zawierającym równanie
___

### SaveHistory(string)
To funcja typu void, znajdująca się w pliku Calculator.cs i przyjmująca jako argument zmienną string, w której jest przechowywane równanie. Odpowiada za:

* Utworzenie pliku o nazwie "history.txt" w folderze Moje dokumenty użytkownika, a następnie wpisze do tego pliku zawartość zmiennej history.
 
![SaveHistory](images/sh8.PNG)
___

### Przykładowe działanie programu: 

* Odejmowanie  
![Odejmwanie](images/minus.mp4)

* Mnożenie  
![Mnożenie](images/mnozenie.mp4)

* Próba dzielenia przez 0  
![Odejmwanie](images/dzielenie0.mp4)

* Historia działań po otwarciu i zamknięciu programu  
![Odejmwanie](images/historia.mp4)

* Logarytm  
![Odejmwanie](images/log.PNG)

___
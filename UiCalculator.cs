using UnityEngine;
using UnityEngine.UI;

public class UiCalculator : MonoBehaviour
{
    [SerializeField] Text Math;
    [SerializeField] Text Ans;
    
    //variabel voor nummer invoeren
    [SerializeField] string number;
    
    //Variabelen voor de nummers en berekenen (operatorVar is ook input)
    [SerializeField] int num1;
    [SerializeField] string operatorVar;
    [SerializeField] int num2;
    [SerializeField] int sum;

    //bools die checken of dingen zijn gebeurt
    [SerializeField] bool numHeeftValue1;
    [SerializeField] bool numHeeftValue2;
    [SerializeField] bool eersteSom;

    /// <summary>
    /// values assignes voor aan het begin van het programma
    /// </summary>
    public void Start()
    {
        numHeeftValue1 = false;
        numHeeftValue2 = false;
        eersteSom = true;
    }

    /// <summary>
    /// Update de text net zoals een echte calculator
    /// </summary>
    public void TextUpdate()
    {
        Math.text = number;
    }

    /// <summary>
    /// Update De Operator die verschijnt in de text object als die ingeklikt word
    /// </summary>
    public void OperatorTextUpdate()
    {
        Math.text = operatorVar;
    }

    //Hier zitten alle knoppen voor de nummers
    #region NummerKnoppen
    /// <summary>
    /// knoppen voor de nummers 0 t/m 9
    /// </summary>
    public void ButtonZero()
    {
        number += "0";
        TextUpdate();
    }
    public void ButtonOne()
    {
        number += "1";
        TextUpdate();
    }
    public void ButtonTwo()
    {
        number += "2";
        TextUpdate();
    }
    public void ButtonThree()
    {
        number += "3";
        TextUpdate();
    }
    public void ButtonFour()
    {
        number += "4";
        TextUpdate();
    }
    public void ButtonFive()
    {
        number += "5";
        TextUpdate();
    }
    public void ButtonSix()
    {
        number += "6";
        TextUpdate();
    }
    public void ButtonSeven()
    {
        number += "7";
        TextUpdate();
    }
    public void ButtonEight()
    {
        number += "8";
        TextUpdate();
    }
    public void ButtonNine()
    {
        number += "9";
        TextUpdate();
    }
    #endregion

    /// <summary>
    /// Reset alles zodat je nieuwe som kan beginnen
    /// </summary>
    public void ButtonCrl()
    {
        operatorVar = "";
        Math.text = "";
        number = "";
        num1 = 0;
        numHeeftValue1 = false;
        num2 = 0;
        numHeeftValue2 = false;
        sum = 0;
        Ans.text = "Ans";
        eersteSom = true;

    }
   
    /// <summary>
    /// Operator knop met een waarde voor operatorVar en 2 methods voor logica die ik bij de methods uitleg
    /// </summary>
    public void buttonMultiply()
    {
        operatorVar = "";
        operatorVar = "*";
        secondNumCheck();
        OperatorTextUpdate();
    }
    
    public void ButtonMinus()
    {
        operatorVar = "";
        operatorVar = "-";
        secondNumCheck();
        OperatorTextUpdate();
        //poging om mingetallen als input mee uit te rekenen maar het is moeilijker dan ik dacht

        /*if (number == "" && operatorVar != "-")
        {
            number += "-";
            TextUpdate();
        }
        else
        {
            operatorVar = "-";
            secondNumCheck();
            OperatorTextUpdate();
        }*/
    }

    public void ButtonPlus()
    {
        operatorVar = "";
        operatorVar = "+";
        secondNumCheck();
        OperatorTextUpdate();
    }

    /// <summary>
    /// berekent num1 en num2 met de gegeven Operator
    /// </summary>
    public void ButtonEquals()
    {
        //extraNumCheck bij equals Zodat er gecheckt wordt of er berekent kan worden
        secondNumCheck();
        switch (operatorVar)
        {
            case "+":
                sum = num1 + num2;
                break;

            case "-":
                //checkt of het de eerste som is die je doet of een opeenvolgende som op ans(num2)
                if (eersteSom == false)
                {
                    sum = num2 - num1;
                }
                else
                {
                    sum = num1 - num2;
                    eersteSom = false;
                }
                break;

            case "*":
                sum = num1 * num2;
                break;

            default:
                Math.text = "Syntax Error";
                break;
        }
        print(sum);
        Math.text = sum.ToString();
        //Voorbereiding van calculator voor de volgende som
        numHeeftValue1 = false;
        numHeeftValue2 = false;
        num2 = sum;
        Ans.text = "Ans:" + num2.ToString();
    }

    /// <summary>
    /// Checkt bij elke operatorKnop zodat het programma weet of wat je intikt Nummer1 is of Nummer2 in de berekening is
    /// </summary>
    public void secondNumCheck()
    {
        //checkt of num1 een int gemaakt kan worden als er nog geen waarde ingezet is
        if (numHeeftValue1 == false)
        {
            if (int.TryParse(number, out num1))
            {
                numHeeftValue1 = true;
                print("Number = num1");
                number = "";
            }
            else
            {
                print("Number != num1");
            }
        }
        else if (numHeeftValue1 == true && numHeeftValue2 == false)
        {
            //checkt of num2 een int gemaakt kan worden als er nog geen waarde ingezet is en num1 wel al een waarde heeft
            if (int.TryParse(number, out num2))
            {
                numHeeftValue2 = true;
                print("Number = num2");
                number = "";
            }
            else
            {
                print("Number != num2");
            }
        }
        //als ze beide een waarde hebben dan kun je ze berekenen
        else if (numHeeftValue1 == true && numHeeftValue2 == true)
        {
            ButtonEquals();
        }
    }
}

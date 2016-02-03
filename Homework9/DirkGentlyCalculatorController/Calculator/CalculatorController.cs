using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Calculator
{
    public class CalculatorController
    {
        private double _currentValue;
        private double _previousValue;
        private string _operator;
        private bool _isWaitingForSecondOperand;
        private bool _equalsWasJustPressed;
        private bool _isDivideZeroByZero;
        private bool _isDivideNumberByZero;
        private bool _isSuffusedWithYellow;
        private string _lastOperatorBeforeEquals;
        private double _currentValueBeforeEquals;

        public CalculatorController()
        {
            ResetCalculatorState();
        } 

        public void AcceptCharacter(char input)
        {
            switch (input)
            {
                case 'c':
                    ResetCalculatorState();
                    break;
                case '+':
                case '-':
                case '*':
                case '/':
                    OperatorState(input.ToString());
                    break;
                case '=':
                    EqualsState();
                    break;
                case 'r':
                    IChingState();
                    break;
                default:
                    NumberInputState(input);
                    break;
            }
        }

        private void NumberInputState(char input)
        {
            _isWaitingForSecondOperand = false;
            if (_currentValue.ToString().Length < 15)
            {   
                if (_equalsWasJustPressed == false)
                {
                    _currentValue = _currentValue*10 + int.Parse(input.ToString());
                }
                else
                {
                    _currentValue = int.Parse(input.ToString());
                    _previousValue = _currentValue;
                    _operator = null;
                }
            }
            _equalsWasJustPressed = false;
        }

        private void IChingState()
        {
            using (var client = new WebClient())
            {
                var contents = client.DownloadString("//I Ching website URL, I think.");
                Console.WriteLine(contents);
            }
        }

        private void EqualsState()
        {
            if (_isWaitingForSecondOperand)
            {
                _currentValue = _previousValue;
            }
            if (_equalsWasJustPressed)
            {
                string temp = _operator;
                _currentValue = _currentValueBeforeEquals;
                _operator = _lastOperatorBeforeEquals;
                DoMathWithSavedOperator();
                _operator = temp;
                _previousValue = _currentValue;
                return;
            }
            _currentValueBeforeEquals = _currentValue;
            DoMathWithSavedOperator();
            _lastOperatorBeforeEquals = _operator;
            _operator = null;
            _isWaitingForSecondOperand = false;
            _previousValue = _currentValue;
            _equalsWasJustPressed = true;
        }

        private void OperatorState(string op)
        {
            if (_isWaitingForSecondOperand)
            {
                _operator = op;
                return;
            }
            if (_operator != null)
            {
                DoMathWithSavedOperator();
                _operator = null;
            }
            _previousValue = _currentValue;
            _currentValue = 0;
            _operator = op;
            _isWaitingForSecondOperand = true;
            _equalsWasJustPressed = false;
        }

        private void MultiplicationState()
        {
            OperatorState("*");
        }

        private void SubtractionState()
        {
            OperatorState("-");
        }

        private void AdditionState()
        {
            OperatorState("+");
        }

        private void ResetCalculatorState()
        {
            _currentValue = 0;
            _previousValue = 0;
            _operator = null;
            _isWaitingForSecondOperand = false;
            _equalsWasJustPressed = false;
            _isDivideZeroByZero = false;
            _isDivideNumberByZero = false;
            _isSuffusedWithYellow = false;
        }

        private void DoMathWithSavedOperator()
        {
            if (_operator == "+")
            { 
                _currentValue = _previousValue + _currentValue;
            }
            else if (_operator == "-")
            {
                _currentValue = _previousValue - _currentValue;
            }
            else if (_operator == "*")
            {
                _currentValue = _previousValue * _currentValue;
            }
            else if (_operator == "/")
            {
                if (_currentValue == 0)
                {
                    if (_previousValue == 0)
                    {
                        _isDivideZeroByZero = true;
                    }
                    else
                    {
                        _isDivideNumberByZero = true;
                    }
                }
                else
                {
                    _currentValue = _previousValue/_currentValue;
                }
            }

            if (_currentValue > 4.0 || _currentValue < -4.0)
            {
                _isSuffusedWithYellow = true;
            }
        }

        public string GetOutput()
        {
            if (_isDivideNumberByZero)
            {
                return "Cannot divide by zero";
            }
            if (_isDivideZeroByZero)
            {
                return "Result is undefined";
            }
            if (_isSuffusedWithYellow)
            {
                return "A Suffusion of Yellow";
            }
            return _isWaitingForSecondOperand ? _previousValue.ToString() : _currentValue.ToString();
        }
    }
}

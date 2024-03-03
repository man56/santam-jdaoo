using System;
using System.Collections;
using System.Linq;

namespace STM.BLayer.Reporting
{
    public class Calculator
    {
        public static double GetValue(string infixExperssion)
        {
            return InfixPostfix(infixExperssion);
        }

        static double InfixPostfix(string str)
        {
            str = str.TrimStart();
            str = str.Replace("ln", "0@");
            if (str[0] == '-')
                str = str.Insert(0, "0");
            var chars = str.ToCharArray();
            var postFix = new Stack();
            var oprs = new Stack();
            var num = "";
            foreach (var ch in chars)
            {
                if (char.IsDigit(ch) || ch == '.')
                    num += ch;
                else if (num.Length > 0)
                {
                    postFix.Push(double.Parse(num));
                    num = "";

                }

                if (ch == '(')
                {
                    oprs.Push('(');
                }
                else if (ch == ')')
                {
                    var st = (char) oprs.Pop();
                    while (st != '(')
                    {
                        postFix.Push(st);
                        st = (char) oprs.Pop();
                    }
                }
                else if ("+*/^-@".Contains(ch))
                {
                    if (oprs.Count == 0)
                        oprs.Push(ch);
                    else
                    {
                        while (oprs.Count > 0)
                        {
                            var op = oprs.Peek();
                            if (GetPerd((char) op) >= GetPerd(ch))
                            {
                                postFix.Push(oprs.Pop());
                            }
                            else
                                break;
                        }
                        oprs.Push(ch);
                    }
                }
            }

            if (num.Length > 0)
                postFix.Push(double.Parse(num));

            while (oprs.Count > 0)
                postFix.Push(oprs.Pop());

            return Compute(postFix);
        }

        private static double Compute(Stack postFix)
        {
            var list = postFix.ToArray().Reverse().ToList();
            while (list.Count > 1)
            {
                for (int i = 0; i <= list.Count; i++)
                {
                    if ("+-*/^@".Contains(list[i].ToString()) && i > 1)
                    {
                        var value = 0.0;
                        switch ((char)list[i])
                        {
                            case '+': value = (double)list[i - 1] + (double)list[i - 2]; break;
                            case '-': value = (double)list[i - 2] - (double)list[i - 1]; break;
                            case '*': value = (double)list[i - 1] * (double)list[i - 2]; break;
                            case '/': value = (double)list[i - 2] / (double)list[i - 1]; break;
                            case '^': value = Math.Pow((double)list[i - 2], (double)list[i - 1]); break;
                            case '@': value = Math.Log((double)list[i - 1], Math.E); break;
                        }

                        list[i - 2] = value;
                        list.RemoveAt(i);
                        list.RemoveAt(i - 1);

                        break;
                    }
                }
            }
            return double.Parse(list[0].ToString());
        }

        private static int GetPerd(char op1)
        {
            switch (op1)
            {
                case '@': return 4;
                case '*':
                case '/':
                case '^':
                    return 3;
                case '-':
                case '+':
                    return 2;
                case '=':
                    return 1;
            }
            return 0;
        }
    }
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Game.Forms
{
    public partial class GameForm : Form
    {
        public GameForm(int gameMode)
        {
            InitializeComponent();
            _gameMode = gameMode;
        }

        Random random = new Random();
        private Button[,] operationButtons = new Button[5, 5];
        private Button[] numberButtons = new Button[6];
        private int[] numberButtonsBacup = new int[6];
        private int numOfOperation = 0;
        private int[] locationoperationButtons = { 32, 150 };
        private int buttonSize = 48;
        private int _gameMode;


        private void GameModeDefaultForm_Load(object sender, EventArgs e)
        {
            SetNumberButton();
            CreateOperationButton();
            GetNumber(_gameMode);
        }

        private void GetNumber(int x)
        {
            if (x == 0)
            {
                GetRandomNumber();
            }
            else if (x == 1)
            {
                GetCalculatedNumber();
            }
        }

        private void SetNumberButton()
        {
            numberButtons[0] = btnNum1;
            numberButtons[1] = btnNum2;
            numberButtons[2] = btnNum3;
            numberButtons[3] = btnNum4;
            numberButtons[4] = btnNum5;
            numberButtons[5] = btnNum6;
        }

        private void CreateOperationButton()
        {
            int x, y;
            for (int i = 0; i < 5; i++)
            {
                x = locationoperationButtons[0];
                y = locationoperationButtons[1];
                for (int j = 0; j < 5; j++)
                {
                    operationButtons[i, j] = new Button
                    {
                        Location = new Point(x, y),
                        Size = new Size(buttonSize, buttonSize),
                        UseVisualStyleBackColor = true,
                        Enabled = false
                    };
                    x += buttonSize + 6;
                    if (j == 0 || j == 2)
                    {
                        operationButtons[i, j].Click += btnOperationNum_Click;
                    }
                    else if (j == 4)
                    {
                        operationButtons[i, j].Click += btnOperationResult_Click;
                    }
                    if (j == 1 || j == 3)
                    {
                        operationButtons[i, j].FlatStyle = FlatStyle.Flat;
                        operationButtons[i, j].BackColor = Color.Transparent;
                        operationButtons[i, j].FlatAppearance.BorderSize = 0;
                        operationButtons[i, j].FlatAppearance.MouseDownBackColor = Color.Transparent;
                        operationButtons[i, j].FlatAppearance.MouseOverBackColor = Color.Transparent;
                    }
                    if (j == 3)
                    {
                        operationButtons[i, j].Text = "=";
                    }
                }
                locationoperationButtons[1] += buttonSize + 6;
            }
            OperationButtonAddForm();
        }

        private void OperationButtonAddForm()
        {
            for (int i = 0; i < 5; i++)
            {
                Controls.Add(operationButtons[numOfOperation, i]);
            }
        }

        private void GetRandomNumber()
        {
            for (int i = 0; i < 5; i++)
            {
                numberButtons[i].Text = random.Next(1, 10).ToString();
            }
            numberButtons[5].Text = (random.Next(1, 10) * 10).ToString();

            for (int i = 0; i < 6; i++)
            {
                numberButtonsBacup[i] = Convert.ToInt32(numberButtons[i].Text);
            }

            lblTargetTotal.Text = random.Next(100, 1000).ToString();
        }

        private void GetCalculatedNumber()
        {
            List<int> numbers = new List<int>();
            List<int> numbersBackup = new List<int>();
            int total, a, aBackup, b, bBackup, temp, op;
            decimal result = 0;
            string deneme1 = null, deneme2 = null;
            do
            {
                numbers.Clear();
                numbersBackup.Clear();
                for (int i = 0; i < 6; i++)
                {
                    numbers.Add(random.Next(1, 10));
                }
                numbers[5] *= 10;
                for (int i = 0; i < 6; i++)
                {
                    numbersBackup.Add(numbers[i]);
                    deneme1 += (numbers[i] + " ");
                }
                deneme1 += "\n";

                for (int i = 0; i < 5; i++)
                {
                    temp = random.Next(0, numbers.Count);
                    a = numbers[temp];
                    aBackup = a;
                    numbers.RemoveAt(temp);
                    temp = random.Next(0, numbers.Count);
                    b = numbers[temp];
                    bBackup = b;
                    numbers.RemoveAt(temp);

                    op = random.Next(0, 4);
                    switch (op)
                    {
                        case 0:
                            result = a + (decimal)b;
                            break;
                        case 1:
                            result = a - (decimal)b;
                            break;
                        case 2:
                            result = a * (decimal)b;
                            break;
                        case 3:
                            result = a / (decimal)b;
                            break;
                    }
                    if (result % 1 == 0 && result > 0 && result < 2147483647)
                    {
                        numbers.Add((int)result);
                        deneme2 += (result + " ");
                    }
                    else
                    {
                        numbers.Add(aBackup);
                        numbers.Add(bBackup);
                        i--;
                    }
                }
                total = (int)result;
                deneme2 += "\n";
            } while (total < 100 || total >= 1000);

            //MessageBox.Show(deneme1);
            //MessageBox.Show(deneme2);
            for (int i = 0; i < 6; i++)
            {
                numberButtons[i].Text = numbersBackup[i].ToString();
                numberButtonsBacup[i] = numbersBackup[i];
            }
            lblTargetTotal.Text = total.ToString();
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            int temp = 2;
            Button button = (Button)sender;
            if (operationButtons[numOfOperation, 0].Text == "" || operationButtons[numOfOperation, 2].Text == "")
            {
                if (operationButtons[numOfOperation, 0].Text == "")
                {
                    temp = 0;
                }
                button.Enabled = false;
                operationButtons[numOfOperation, temp].Text = button.Text;
                button.Text = "";
                operationButtons[numOfOperation, temp].Enabled = true;
            }
            GetValue();
        }

        private void btnOp_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationButtons[numOfOperation, 1].Enabled = true;
            operationButtons[numOfOperation, 1].Text = button.Text;
            GetValue();
        }

        private void btnOperationResult_Click(object sender, EventArgs e)
        {
            int temp = 0;
            if (operationButtons[numOfOperation, 0].Text != "" && operationButtons[numOfOperation, 1].Text != "" && operationButtons[numOfOperation, 2].Text != "")
            {
                if (operationButtons[numOfOperation, 4].Text != "")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        operationButtons[numOfOperation, i].Enabled = false;
                    }
                    lblTotal.Text = operationButtons[numOfOperation, 4].Text;

                    if (numOfOperation < 4)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (numberButtons[i].Text == "")
                            {
                                temp = i;
                                break;
                            }
                        }
                        numberButtons[temp].Text = operationButtons[numOfOperation, 4].Text;
                        numberButtons[temp].Enabled = true;
                    }
                    numOfOperation++;
                    if (numOfOperation < 5)
                    {
                        OperationButtonAddForm();
                    }
                }
                else
                {
                    MessageBox.Show("Sonuç int değil");
                }
            }
            else
            {
                MessageBox.Show("Eksik");
            }
        }

        private void btnOperationNum_Click(object sender, EventArgs e)
        {
            int temp = 0;
            Button button = (Button)sender;
            for (int i = 0; i < 6; i++)
            {
                if (numberButtons[i].Text == "")
                {
                    temp = i;
                    break;
                }
            }

            numberButtons[temp].Text = button.Text;
            button.Text = "";
            numberButtons[temp].Enabled = true;
            button.Enabled = false;
            GetValue();
        }

        private void GetValue()
        {
            decimal temp;
            if (operationButtons[numOfOperation, 0].Text != "" && operationButtons[numOfOperation, 1].Text != "" && operationButtons[numOfOperation, 2].Text != "")
            {
                if (operationButtons[numOfOperation, 1].Text == "+")
                {
                    temp = (decimal)(Convert.ToInt32(operationButtons[numOfOperation, 0].Text) + Convert.ToInt32(operationButtons[numOfOperation, 2].Text) * 1.0);
                    if (temp % 1 == 0 && temp > 0)
                    {
                        operationButtons[numOfOperation, 4].Text = temp.ToString();
                        operationButtons[numOfOperation, 4].Enabled = true;
                    }
                    else
                    {
                        ClearResult();
                    }
                }
                else if (operationButtons[numOfOperation, 1].Text == "-")
                {
                    temp = (decimal)(Convert.ToInt32(operationButtons[numOfOperation, 0].Text) - Convert.ToInt32(operationButtons[numOfOperation, 2].Text) * 1.0);
                    if (temp % 1 == 0 && temp > 0)
                    {
                        operationButtons[numOfOperation, 4].Text = temp.ToString();
                        operationButtons[numOfOperation, 4].Enabled = true;
                    }
                    else
                    {
                        ClearResult();
                    }
                }
                else if (operationButtons[numOfOperation, 1].Text == "*")
                {
                    temp = (decimal)(Convert.ToInt32(operationButtons[numOfOperation, 0].Text) * Convert.ToInt32(operationButtons[numOfOperation, 2].Text) * 1.0);
                    if (temp % 1 == 0 && temp > 0)
                    {
                        operationButtons[numOfOperation, 4].Text = temp.ToString();
                        operationButtons[numOfOperation, 4].Enabled = true;
                    }
                    else
                    {
                        ClearResult();
                    }
                }
                else if (operationButtons[numOfOperation, 1].Text == "/")
                {
                    temp = (decimal)(Convert.ToInt32(operationButtons[numOfOperation, 0].Text) * 1.0 / Convert.ToInt32(operationButtons[numOfOperation, 2].Text));
                    if (temp % 1 == 0 && temp > 0)
                    {
                        operationButtons[numOfOperation, 4].Text = temp.ToString();
                        operationButtons[numOfOperation, 4].Enabled = true;
                    }
                    else
                    {
                        ClearResult();
                    }
                }
            }
            else
            {
                ClearResult();
            }
        }

        private void ClearResult()
        {
            operationButtons[numOfOperation, 4].Text = "";
            operationButtons[numOfOperation, 4].Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearOperation();
            OperationButtonAddForm();
            lblTotal.Text = "0";
            LoadBackup();
        }

        private void LoadBackup()
        {
            for (int i = 0; i < 6; i++)
            {
                numberButtons[i].Text = numberButtonsBacup[i].ToString();
            }
            EnableToNumberButton();
        }

        private void ClearOperation()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Controls.Remove(operationButtons[i, j]);
                    operationButtons[i, j].Enabled = false;
                    if (j != 3)
                    {
                        operationButtons[i, j].Text = "";
                    }
                }
            }
            numOfOperation = 0;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (numOfOperation < 5 && _gameMode == 1)
            {
                MessageBox.Show("Bu oyun modunda bütün sayıları kullanmak zorundasınızdır.");
            }
            else
            {
                int temp;
                temp = 10 - Math.Abs(Convert.ToInt32(lblTargetTotal.Text) - Convert.ToInt32(lblTotal.Text));
                if (temp <= 10 && temp > 0)
                {
                    lblLastScore.Text = temp.ToString();
                    lblTotalScore.Text = (Convert.ToInt32(lblTotalScore.Text) + temp).ToString();
                }
                else
                {
                    lblLastScore.Text = "0";
                }
                lblGameCount.Text = (Convert.ToInt32(lblGameCount.Text) + 1).ToString();
                ClearOperation();
                OperationButtonAddForm();
                lblTotal.Text = "0";
                GetNumber(_gameMode);
                EnableToNumberButton();
            }
        }

        private void EnableToNumberButton()
        {
            for (int i = 0; i < 6; i++)
            {
                numberButtons[i].Enabled = true;
            }
        }
    }
}

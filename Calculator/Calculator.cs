namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }
        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        static float InitialNumber = 0;
        static char? Operator = null;
        static float SecondNumber = 0;

        static float Result = 0;

        static bool Binary = false;
        static bool Locational = false;



        private string ConvertToLocational(float inputNumber)
        {
            int PowerOfTwo = 1;
            int Exponent = 0;

            string Alphabet = "abcdefghijklmnopqrstuvwxyz";

            inputNumber = (int)Math.Round(inputNumber);
            while (PowerOfTwo * 2 <= inputNumber)
            {
                PowerOfTwo *= 2;
                Exponent++;
            }

            List<char> LocationalNumberList = new List<char>();

            while (Exponent >= 0 && inputNumber > 0)
            {
                if (inputNumber - PowerOfTwo >= 0)
                {
                    inputNumber -= PowerOfTwo;

                    LocationalNumberList.Add(Alphabet[Exponent]);
                }

                Exponent--;
                PowerOfTwo /= 2;
            }
            LocationalNumberList.Reverse();

            return new string(LocationalNumberList.ToArray());
        }

        private void Display()
        {
            if (Operator != null)
            {
                textbox_operator.Text = Operator.ToString();
            }
            else
            {
                textbox_operator.Text = " ";
            }
            
            float NumberToDisplay = 0;

            if (InitialNumber != 0)
            {
                NumberToDisplay = InitialNumber;
            }
            if (SecondNumber != 0)
            {
                NumberToDisplay = SecondNumber;
            }
            if (Result != 0)
            {
                NumberToDisplay = Result;
            }

            string display = "";
            
            if (Locational)
            {
                display = ConvertToLocational(NumberToDisplay);
            }
            else if (Binary)
            {
                int IntToDisplay = (int)Math.Round(NumberToDisplay);
                display = Convert.ToString(IntToDisplay, 2);
            }

            if (!Binary && !Locational)
            {
                display = $"{NumberToDisplay}";
            }

            textbox_number.Text = display;
        }
        

        static void CE()
        {
            if (Result != 0)
            {
                Result = 0;
            }
            else if (SecondNumber != 0)
            {
                SecondNumber = 0;
            }
            else if (Operator != null)
            {
                Operator = null;
            }
            else if (InitialNumber != 0)
            {
                InitialNumber = 0;
            }

        }

        static void C()
        {
            InitialNumber = 0;
            Operator = null;
            SecondNumber = 0;
            Result = 0;
        }

        static void AddNumber(int number)
        {
            if (Result != 0)
            {
                Result = 0;
            }

            if (Operator == null)
            {
                InitialNumber *= 10;
                InitialNumber += number;
            }
            else
            {
                SecondNumber *= 10;
                SecondNumber += number;
            }
        }

        //switch(Console.ReadKey().KeyChar)

        // top row:
        private void button_bin_Click(object sender, EventArgs e)
        {
            Binary = true;
            Locational = false;
            Display();
        }

        private void button_dec_Click(object sender, EventArgs e)
        {
            Binary = false;
            Locational = false;
            Display();
        }

        private void button_loc_Click(object sender, EventArgs e)
        {
            Binary = false;
            Locational = true;
            Display();
        }

        private void button_ce_Click(object sender, EventArgs e)
        {
            CE();
            Display();
        }

        private void button_c_Click(object sender, EventArgs e)
        {
            C();
            Display();

        }

        // numbers:

        private void button_9_Click(object sender, EventArgs e)
        {
            AddNumber(9);
            Display();
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            AddNumber(8);
            Display();
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            AddNumber(7);
            Display();
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            AddNumber(6);
            Display();
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            AddNumber(5);
            Display();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            AddNumber(4);
            Display();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            AddNumber(3);
            Display();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            AddNumber(2);
            Display();
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            AddNumber(1);
            Display();
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            AddNumber(0);
            Display();
        }

        // operators

        private void button_addition_Click(object sender, EventArgs e)
        {
            Operator = '+';
            Display();
        }

        private void button_subtraction_Click(object sender, EventArgs e)
        {
            Operator = '-';
            Display();
        }

        private void button_multiplication_Click(object sender, EventArgs e)
        {
            Operator = '*';
            Display();
        }

        private void button_division_Click(object sender, EventArgs e)
        {
            Operator = '/';
            Display();
        }

        private void button_equation_Click(object sender, EventArgs e)
        {
            if (Operator == '/' && SecondNumber == 0)
            {
                textbox_number.Text = "Nice try...";
            }
            else
            {
                if (Operator == '+')
                {
                    Result = InitialNumber + SecondNumber;
                }
                if (Operator == '-')
                {
                    Result = InitialNumber - SecondNumber;
                }
                if (Operator == '*')
                {
                    Result = InitialNumber * SecondNumber;
                }
                if (Operator == '/')
                {
                    Result = InitialNumber / SecondNumber;
                }
                if (Operator == '^')
                {
                    Result = (float)Math.Pow(InitialNumber, SecondNumber);
                }
                if (Operator == '%')
                {
                    Result = InitialNumber % SecondNumber;
                }

            }
            Display();
            float temp = Result;
            C();
            InitialNumber = temp;
        }

        private void button_exponent_Click(object sender, EventArgs e)
        {
            Operator = '^';
            Display();
        }

        private void button_modulo_Click(object sender, EventArgs e)
        {
            Operator = '%';
            Display();
        }

    }
}
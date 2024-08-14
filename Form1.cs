namespace Binary2Decimal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            // Binary to Decimal Converter
            bool binaryOk = true;
            string reverseBinaryString = "";
            string? binaryNumber;

            do
            {
                binaryNumber = textBox1.Text;
                int myNum = binaryNumber.Length - 1;

                if (binaryNumber == "q")
                {
                    binaryOk = false;
                    break;
                }

                if (binaryNumber?.Length > 8)
                {
                    binaryOk = false;
                    label3.Text = "Number entered is greater than 8 digits.";
                    break;
                }

                for (int x = 0; x < binaryNumber?.Length - 1; x++)
                {
                    string? c = binaryNumber?.Substring(x, 1);
                    reverseBinaryString += binaryNumber?.Substring(myNum - x, 1); //Create the reversed string to calculate binary.

                    label3.Text = "Number entered is not a binary number.";
                }
            } while (!binaryOk);

            if (binaryOk)
            {
                reverseBinaryString += binaryNumber?[..1]; // Get last digit

                int sum = 0;

                for (int i = 0; i < reverseBinaryString.Length; i++)
                {
                    string str = reverseBinaryString.Substring(i, 1);
                    if (str == "1")
                    {
                        // Method uses raising 2 to the power of the index.
                        if (i == 0)
                        {
                            sum += 1;
                        }
                        else
                        {
                            sum += (int)Math.Pow(2, i);
                        }
                    }
                }

                label3.Text = ($"Binary number converted to decimal is: {sum:N0}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int decimalNumber = int.Parse(textBox2.Text);

            int remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }
            label4.Text = "Decimal number converted to Binary is: " + result;
        }
    }
}

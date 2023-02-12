using MathNet.Numerics.LinearAlgebra;

namespace HopfieldNetwork
{
    public partial class Form1 : Form
    {
        int[] inputVector = {-1, -1, -1, -1, -1, -1,-1 ,-1 ,-1};
        int[] outputVector = new int[9];
        int[] value = new int[9];

        private Matrix<float> weight = Matrix<float>.Build.DenseOfArray(new float[,]
            {
                { 0, 0, 2, -2, -2, -2, 2, 0, 2 },
                { 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                { 2, 0, 0, -2, -2, -2, 2, 0, 2 },
                { 2, 0, -2, 0, 2, 2, -2, 0 ,-2 },
                { 2, 0, -2, 2, 0, 2, -2, 0, -2 },
                { 2, 0, -2, 2, 2, 0, -2, 0, -2 },
                { 2, 0, 2, -2, -2, -2, 0, 0, 2},
                { 0, 2, 0, 0, 0, 0, 0, 0, 0},
                { 2, 0, 2, -2, -2, -2, 2, 0, 0 }
            });

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        public int boxClick(PictureBox pb) 
        {
            button1.Enabled = true;
            if(pb.BackColor == Color.Black)
            {
                pb.BackColor = Color.White;
                return -1;
            }
            else
            {
                pb.BackColor = Color.Black;
                return 1;
            }
        }

        public void reset()
        {
            pictureBox11.BackColor= Color.White;
            pictureBox12.BackColor = Color.White;
            pictureBox13.BackColor = Color.White;
            pictureBox14.BackColor = Color.White;
            pictureBox15.BackColor = Color.White;
            pictureBox16.BackColor = Color.White;
            pictureBox17.BackColor = Color.White;
            pictureBox18.BackColor = Color.White;
            pictureBox19.BackColor = Color.White;
            inputVector = Enumerable.Range(0, 9).Select(y => -1).ToArray();
        }

        public Color boxAssign(int num)
        {
            if (num >= 1)
            {
                return Color.Black;
            }
            return Color.White;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            inputVector[0] = boxClick(pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            inputVector[1] = boxClick(pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            inputVector[2] =  boxClick(pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            inputVector[3] = boxClick(pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            inputVector[4] = boxClick(pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            inputVector[5] = boxClick(pictureBox6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            inputVector[6] = boxClick(pictureBox7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            inputVector[7] = boxClick(pictureBox8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            inputVector[8] = boxClick(pictureBox9);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] plus = { -1, 1, -1, 1, 1, 1, -1, 1, -1 };
            int[] minus = { -1, -1, -1, 1, 1, 1, -1, -1, -1 };
            int recurred = 0;
            int temp;
            int sum;

            string inputVect = string.Empty;
            string outputVect = string.Empty;
            string valueText = string.Empty;
            outputVector = inputVector;

            button1.Enabled = false;

            foreach (var n in inputVector)
            {
                inputVect += n + ", ";
            }
            
            textBox1.Text = inputVect;

            while (recurred < 2)
            {
                for (int i = 0; i < inputVector.Length; i++)
                {
                    inputVector = outputVector;
                    sum = 0;

                    for (int j = 0; j < inputVector.Length; j++)
                    {
                        temp = (int)weight[i, j] * inputVector[j];
                        sum += temp;
                    }

                    value[i] = sum;

                    if (sum >= 1)
                    {
                        outputVector[i] = 1;
                    }
                    else
                    {
                        outputVector[i] = -1;
                    }
                }
                recurred++;
            }

            foreach (var n in value)
            {
                valueText += n + ", ";
            }
            textBox3.Text = valueText;

            if (Enumerable.SequenceEqual(outputVector, plus)  || Enumerable.SequenceEqual(outputVector, minus))
            {
                foreach (var n in outputVector)
                {
                    outputVect += n + ", ";
                }

                textBox2.Text = outputVect;

                pictureBox11.BackColor = boxAssign(outputVector[0]);
                pictureBox12.BackColor = boxAssign(outputVector[1]);
                pictureBox13.BackColor = boxAssign(outputVector[2]);
                pictureBox14.BackColor = boxAssign(outputVector[3]);
                pictureBox15.BackColor = boxAssign(outputVector[4]);
                pictureBox16.BackColor = boxAssign(outputVector[5]);
                pictureBox17.BackColor = boxAssign(outputVector[6]);
                pictureBox18.BackColor = boxAssign(outputVector[7]);
                pictureBox19.BackColor = boxAssign(outputVector[8]);
            }
            else
            {
                textBox2.Text = "Discrepancy occured";
                reset();
            }
        }
    }
}
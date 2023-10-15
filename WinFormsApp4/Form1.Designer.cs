namespace WinFormsApp4
{
    partial class Form1
    {
        int labelCount = 0; // Label-ın ardıcılıq nömrəsi
        Label currentLabel = null; // İşlənən Label
        bool mousePressed = false; // Sıçan düyməsi basılımı?

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousePressed = true;

                currentLabel = new Label();
                currentLabel.Location = new System.Drawing.Point(e.X, e.Y);
                currentLabel.Size = new System.Drawing.Size(10, 10);
                currentLabel.BorderStyle = BorderStyle.FixedSingle;
                currentLabel.Text = labelCount.ToString();

                this.Controls.Add(currentLabel);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                currentLabel.Size = new System.Drawing.Size(e.X - currentLabel.Left, e.Y - currentLabel.Top);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mousePressed)
            {
                mousePressed = false;

                if (currentLabel.Width < 10 || currentLabel.Height < 10)
                {
                    MessageBox.Show("Label minimal olculu olmalıdır.");
                    this.Controls.Remove(currentLabel);
                }
                else
                {
                    currentLabel = null;
                    labelCount++;
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (currentLabel != null)
                {
                    MessageBox.Show($"Label sahəsi: {currentLabel.Size.Width}x{currentLabel.Size.Height}, Koordinatlar: ({currentLabel.Left}, {currentLabel.Top})");
                }
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (currentLabel != null)
                {
                    // Labelı silmək
                    this.Controls.Remove(currentLabel);
                    currentLabel = null;
                }
            }
        }

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion
    }
}
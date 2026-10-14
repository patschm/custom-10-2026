namespace TestForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form f1 = new Form();
            f1.Text = "Hello";
            f1.Width = 600;
            f1.Height = 500;

            Button b1 = new Button();
            b1.Text = "Click me!";
            b1.Location = new Point(100, 200);
            b1.Width = 200;
            b1.Height = 70;
            f1.Controls.Add(b1);

            b1.Click += DoeIets;


            f1.ShowDialog();
        }

        private static void DoeIets(object? sender, EventArgs e)
        {
            Button? b1 = sender as Button;
            b1?.Parent?.BackColor = Color.Red;
        }
    }
}
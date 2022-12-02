using MathLibrary;

namespace MathApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Hier können entstehen 

                double zahl1 = double.Parse(textBox1.Text);
                double zahl2 = double.Parse(textBox2.Text);

                //Und ab hier müssen wir unsere Dll einkaufen 
                Calculator calculator = new Calculator();
                calculator.Division(zahl1, zahl2);
            }
            catch (FormatException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch (TeileDurchNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                //Ausnahmefehler die wir nicht auf dem Fokus haben 
            }
            finally 
            { 
                 //Aufräumarbeiten -> Freigeben von Ressoucren (wichtig bei Files, SqlConnection) 
                 //sqlConnection.Close();
                 //fileStream.Close()
            }


           
        }
    }
}
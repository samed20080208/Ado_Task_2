namespace Ado_Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataBase.com();
            DataBase.ReadUsersToDatabase();
            CarBox.DataSource = DataBase.cars;
        }

        private void searcbtn_Click(object sender, EventArgs e)
        {
            string text = txtBox.Text;
            if (ModelButton.Checked)
            {
                CarBox.DataSource = DataBase.FindModel(text);
            }
            else
            {
                CarBox.DataSource = DataBase.FindMarka(text);
            }
        }

        private void CarBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

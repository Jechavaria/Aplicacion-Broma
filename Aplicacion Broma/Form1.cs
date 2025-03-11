using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aplicacion_Broma
{
    public partial class frmFormatearEquipo : Form
    {
        private Random rnd = new Random();

        public frmFormatearEquipo()
        {
            InitializeComponent(); 
        }


        private void btnCancelar_MouseHover(object sender, EventArgs e)
        {
            btnCancelar.Location = new Point(
                rnd.Next(0, this.ClientSize.Width - btnCancelar.Width),
                rnd.Next(0, this.ClientSize.Height - btnCancelar.Height)
            );
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Location = new Point(
                rnd.Next(0, this.ClientSize.Width - btnCancelar.Width),
                rnd.Next(0, this.ClientSize.Height - btnCancelar.Height)
            );
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            FancyMessageBox.ShowFancy("Formateando equipo...");
            this.Close();
        }
    }

    public class FancyMessageBox : Form
    {
        public FancyMessageBox(string message)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(300, 150);
            this.BackColor = Color.FromArgb(30, 30, 30);


            Label lblMessage = new Label
            {
                Text = message,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Width = this.ClientSize.Width,
                Height = 60,
                Location = new Point(0, 0)
            };

            Button btnClose = new Button
            {
                Text = "Cerrar",
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(50, 50, 50),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(80, 30),
                Location = new Point((this.ClientSize.Width - 80) / 2, 80)
            };
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(lblMessage);
            this.Controls.Add(btnClose);


            this.Opacity = 0;
            Timer timer = new Timer { Interval = 50 };
            timer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.1;
                else
                    timer.Stop();
            };
            timer.Start();
        }


        public static void ShowFancy(string message)
        {

            FancyMessageBox box = new FancyMessageBox(message)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            box.ShowDialog();
        }
    }

}

/*
 * Creado por SharpDevelop.
 * Author Cesar Freitas Cespedes
 * E-mail cesar.freitas.dev@gmail.com
 * Fecha: 17/04/2018
 * Hora: 21:21
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace view
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		public Form1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		decimal minutos = 1;
		decimal segundos = 59;
		decimal milisegundos = 0; 
		
		DateTime time_game_start = new DateTime(1900,1,1,0,1,0,0);
		DateTime time_game_tmp = new DateTime();
		DateTime time_game_end = new DateTime(1900,1,1,0,0,0,0);
		
		void Form1Load(object sender, EventArgs e)
		{
			label1.Text = segundos.ToString();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			
			string resultado = "";
			time_game_start = time_game_start.AddMilliseconds(-1);
			time_game_start = time_game_start.AddSeconds(-1);
			//resultado = (segundos --).ToString();
			
			resultado = time_game_start.ToString("mm:ss:fff tt");
			
			label1.Text = resultado;
		}
		void Button1Click(object sender, EventArgs e)
		{
			timer1.Start();
		}
		
		string time = "00:01:00:00";
		
		private void Timer1_Tick(System.Object sender, System.EventArgs e)
		{
			
			string[] time_values = time.Split(':');
			
			int Vals3 = Convert.ToInt32(time_values[3]);
		    int Vals2 = Convert.ToInt32(time_values[2]);
		    int Vals1  = Convert.ToInt32(time_values[1]);
		    int Vals0 = Convert.ToInt32(time_values[0]);
		    Vals3 -= timer2.Interval;
		    if (Vals3 < 0)
		    {
		        Vals3 += 1000;
		        Vals2 -= 1;
		        if (Vals2 < 0)
		        {
		            Vals2 += 60;
		            Vals1 -= 1;
		            if (Vals1 < 0)
		            {
		                Vals1 += 60;
		                Vals0 -= 1;
		            }
		        }
		
		        if (Vals0 == 0 & Vals1 == 0 & Vals2 == 0 & Vals3 <= 0)
		        {
		            timer2.Enabled = false;
		            time = "00:00:00:00";
		            MessageBox.Show("Times up!");
		        }
		    }
			
		    string resultado = string.Format("{0}:{1}:{2}:{3}",Vals0,Vals1,Vals2,Vals3);
		    time = resultado;
		    label1.Text = resultado;
//		    TextBoxHours.Text = Vals0(0);
//		    TextBoxMinutes.Text = Vals1(1);
//		    TextBoxSeconds.Text = Vals2(2);
//		    TextBoxMilliseconds.Text = Vals3(3);
		}
		void Button2Click(object sender, EventArgs e)
		{
			timer2.Start();
		}
		//=======================================================
		//Service provided by Telerik (www.telerik.com)
		//Conversion powered by Refactoring Essentials.
		//Twitter: @telerik
		//Facebook: facebook.com/telerik
		//=======================================================
	}
}

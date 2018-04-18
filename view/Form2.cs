/*
 * Creado por SharpDevelop.
 * Author Cesar Freitas Cespedes
 * E-mail cesar.freitas.dev@gmail.com
 * Fecha: 17/04/2018
 * Hora: 22:47
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace view
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		
		TimeSpan cntDwnVal =  new TimeSpan();
		Stopwatch stpw = new Stopwatch();
		private void Button1_Click(System.Object sender, System.EventArgs e)
		{
		    int h, m, s, ms;
		
		    if (!Int32.TryParse(TextBox1.Text, out h))
            { 
             	h = 0;
            }
		
		    if (!Int32.TryParse(TextBox2.Text, out m))
            { 
             	m = 0;
            }
		
		    if (!Int32.TryParse(TextBox3.Text, out s))
            { 
             	s = 0;
            }
		
		    if (!Int32.TryParse(TextBox4.Text, out ms))
            { 
             	ms = 0;
            }
		
		    TimeSpan ts = new TimeSpan();
		    ts = TimeSpan.FromMilliseconds(ms);
		    cntDwnVal = new TimeSpan(h, m, s);
		    cntDwnVal = cntDwnVal.Add(ts);
		    Console.WriteLine(cntDwnVal.ToString());
		    stpw.Reset();
		    stpw.Start();
		    Timer1.Interval = 1;
		    Timer1.Start();
		}
		
		private void Timer1_Tick(System.Object sender, System.EventArgs e)
		{
		    if (Timer1.Interval != 100)
		        Timer1.Interval = 100;
		    TimeSpan foo = new TimeSpan();
		    foo = cntDwnVal - stpw.Elapsed;
		    TextBox5.Text = string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", foo.Hours, foo.Minutes, foo.Seconds, foo.Milliseconds);
		    if (stpw.ElapsedMilliseconds + 100 > cntDwnVal.TotalMilliseconds)
		    {
		        Timer1.Stop();
		    }
		}
	}
}

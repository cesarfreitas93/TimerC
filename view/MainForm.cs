/*
 * Creado por SharpDevelop.
 * Author Cesar Freitas Cespedes
 * E-mail cesar.freitas.dev@gmail.com
 * Fecha: 17/04/2018
 * Hora: 20:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace view
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		private readonly MicroTimer  control_microTimer;
		
			
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			control_microTimer = new MicroTimer();
            control_microTimer.MicroTimerElapsed += new MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);
		}
		
		private void OnTimedEvent(object sender, MicroTimerEventArgs timerEventArgs)
        {
            // Do something small that takes significantly less time than Interval.
            // BeginInvoke executes on the UI thread but this calling thread does not
            //  wait for completion before continuing (i.e. it executes asynchronously)
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    label1.Text = timerEventArgs.ElapsedMicroseconds.ToString("#,#");
                });
            }
        }
		
		decimal minutos = 1;
		decimal segundos = 5;
		decimal milisegundos = 0;
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		private DateTime StartTime;
		void Button1Click(object sender, EventArgs e)
		{
			long interval;

            // Read interval from form
            if (!long.TryParse("1000", out interval))
            {
                return;
            }

            // Set timer interval
            control_microTimer.Interval = interval;

            // Ignore event if late by half the interval
            control_microTimer.IgnoreEventIfLateBy = interval/2;

            // Start timer
            control_microTimer.Start();
            
//			timer1.Enabled = !timer1.Enabled;
//            button1.Text = timer1.Enabled ? "Stop" : "Start";
//            StartTime = DateTime.Now;
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			TimeSpan elapsed = DateTime.Now - StartTime;

            // Start with the days if greater than 0.
            string text = "";
            if (elapsed.Days > 0)
                text += elapsed.Days.ToString() + ".";
            
            // Convert milliseconds into tenths of seconds.
            int tenths = elapsed.Milliseconds / 100;

            // Compose the rest of the elapsed time.
            text +=
                elapsed.Hours.ToString("00") + ":" +
                elapsed.Minutes.ToString("00") + ":" +
                elapsed.Seconds.ToString("00") + "." +
                tenths.ToString("0");

            label1.Text = text;
			
			
		}
		void Button2Click(object sender, EventArgs e)
		{
			control_microTimer.StopAndWait();
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
	      if (!control_microTimer.StopAndWait(1000))
            {
                control_microTimer.Abort();
            }
		}
		void Button3Click(object sender, EventArgs e)
		{
			control_microTimer.Start();
		}
	}
}

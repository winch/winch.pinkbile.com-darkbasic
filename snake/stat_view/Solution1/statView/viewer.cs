using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
namespace theWinch
{
	class viewer : Form
	{
		protected int startTime, endTime, playTime, status, size, eats, 
			eat1, eat2, eat3, eat4, eat0, headx, heady,
			foodx, foody = 0;
		protected Label[] labels = new Label[13];
		public static void Main()
		{
			Application.Run(new viewer());
		}
		public viewer()
		{
			Text = "Snake Statview";
			Width = 190; Height = 250;
			Font fixedWidth = new Font("Courier new",10);
			for (int i = 0; i<13; i++)
			{
				labels[i]= new Label();
				labels[i].Height = fixedWidth.Height;
				labels[i].Font = fixedWidth;
				labels[i].Parent = this;
				labels[i].BringToFront();
				labels[i].Dock = DockStyle.Top;
			}
			this.Load += new EventHandler(viewer_Load);
			Timer timer = new Timer(); timer.Interval = 250;
			timer.Tick +=new EventHandler(TimerOnTick);
			timer.Enabled = true;
		}
		void updateLabels()
		{
			float percent, tot;
			tot = eats + eat0;
			labels[0].Text = "Playtime    :"+getTime(playTime);
			percent = ((float)size/3072F)*(100F/1F);
			labels[2].Text = "Size        :"+size.ToString()+" "+percent.ToString("N2")+"%";
			percent = ((float)eats/(float)tot)*(100F/1F);
			labels[3].Text = "Eats        :"+eats.ToString()+" "+percent.ToString("N0")+"%";
			percent = ((float)eat1/(float)tot)*(100F/1F);
			labels[4].Text = "Eat 1/1     :"+eat1.ToString()+" "+percent.ToString("N1")+"%";
			percent = ((float)eat2/(float)tot)*(100F/1F);
			labels[5].Text = "Eat 3/4     :"+eat2.ToString()+" "+percent.ToString("N1")+"%";
			percent = ((float)eat3/(float)tot)*(100F/1F);
			labels[6].Text = "Eat 1/2     :"+eat3.ToString()+" "+percent.ToString("N1")+"%";
			percent = ((float)eat4/(float)tot)*(100F/1F);
			labels[7].Text = "Eat 1/4     :"+eat4.ToString()+" "+percent.ToString("N1")+"%";
			percent = ((float)eat0/(float)tot)*(100F/1F);
			labels[8].Text = "Missed      :"+eat0.ToString()+" "+percent.ToString("N1")+"%";
			labels[10].Text = "Eat average :"+getTime(playTime/eats);
			//labels[11].Text = "";
			//labels[12].Text = "";
		}
		string getTime(int time)
		{
			string str;
			int mins,tens;
			tens = time / 100;
			time /= 1000;
			tens -= (10*time);
			if (time > 60)
				mins = time / 60;
			else
				mins = 0;
			if (mins > 0)
				time -= (60*mins);
			if (time > 0)
				if (time == 60)
				{
					time = 0;
					mins ++;
				}
			if (mins < 10)
				str = "0";
			else
				str = "";
			str += mins + ":";
			if (time < 10)
				str += "0";
			str += time.ToString()+"."+tens.ToString();
			return str;
		}
		void TimerOnTick(object obj, EventArgs ea)
		{
			try
			{
				StreamReader stat = new StreamReader("stat.txt");
				startTime = int.Parse(stat.ReadLine());
				endTime = int.Parse(stat.ReadLine());
				playTime = (endTime - startTime);
				status = int.Parse(stat.ReadLine());
				size = int.Parse(stat.ReadLine());
				eats = int.Parse(stat.ReadLine());
				eat1 = int.Parse(stat.ReadLine());
				eat2 = int.Parse(stat.ReadLine());
				eat3 = int.Parse(stat.ReadLine());
				eat4 = int.Parse(stat.ReadLine());
				eat0 = int.Parse(stat.ReadLine());
				headx = int.Parse(stat.ReadLine());
				heady = int.Parse(stat.ReadLine());
				foodx = int.Parse(stat.ReadLine());
				foody = int.Parse(stat.ReadLine());
				stat.Close();
				File.Delete("stat.txt");
				updateLabels();
				//check if startTime = -1 and exit if it does
				if (startTime == -1) 
					if (labels[0].Text != "Waiting for data...")
						Close();
			}
			catch
			{
				if (labels[0].Text == "")
					labels[0].Text = "Waiting for data...";
			}
		}

		private void viewer_Load(object sender, EventArgs ea)
		{
			File.Delete("stat.txt");
		}
	}
}
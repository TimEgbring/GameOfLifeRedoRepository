using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GameOfLifeRedo
{
    public partial class Form1 : Form
    {
        
        readonly Pen black = new Pen(Color.FromArgb(0, 0, 0));
        Graphics g = null;
        bool isrunning = false;
        byte[] bytegrid;
        Rectangle[] rect_grid;

        static int top_left_x, top_left_y;
        static int bottom_right_x, bottom_right_y;
        

        static int cell_count_x, cell_count_y;
        const int sizeofcell = 15;
        

        enum general_state { initializing };

        public Form1()
        {
            InitializeComponent();
            InitVariables();

            g = GridColorFlowPanel.CreateGraphics();
            
            
            
           
            

        }

        private void GenerationTimer_Tick(object sender, EventArgs e)
        {

        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (isrunning)
                StartGame();
            else
                PauseGame();
        }

        private void StartGame()
        {
            Start_Button.Text = "Pause";
            isrunning = true;
            
            GenerationTimer.Start();
        }
        private void PauseGame()
        {
            Start_Button.Text = "Start";
            GenerationTimer.Stop();
        }
        private void InitVariables()
        {
            top_left_x = GridColorFlowPanel.Location.X;
            top_left_y = GridColorFlowPanel.Location.Y;
            bottom_right_x = top_left_x + GridColorFlowPanel.Width;
            bottom_right_y = top_left_y + GridColorFlowPanel.Height - PanelBottom.Height;
            cell_count_x = (bottom_right_x - top_left_x) / sizeofcell;
            cell_count_x -= cell_count_x / sizeofcell ;  
            cell_count_y = (bottom_right_y - top_left_y) / sizeofcell;
            cell_count_y -= cell_count_y / sizeofcell;
            rect_grid = new Rectangle[cell_count_y* cell_count_x];
            for(int i = 0; i < cell_count_y; i++)
            {
                for(int j = 0; j< cell_count_x; j++)
                {
                    rect_grid[cell_count_x *i + j].X = top_left_x + j * 15 + j;
                    rect_grid[cell_count_x * i + j].Y = top_left_y + i * 15 + i;
                    rect_grid[cell_count_x * i + j].Size = new Size(15,15);
                   
                }
            }
        }
       

        private void GridColorFlowPanel_Paint(object sender, PaintEventArgs e)
        {
            
            InitLineGrid();
            g.FillRectangles(new SolidBrush(Color.Black), rect_grid);
            // e.Graphics.TranslateTransform(GridColorFlowPanel.AutoScrollPosition.X, GridColorFlowPanel.AutoScrollPosition.Y);
        }
        
        private void InitLineGrid()
        {
            for(int i = 0; i < cell_count_x; i++)
            {
                g.DrawLine(new Pen(Color.Red), rect_grid[i].X, top_left_y, rect_grid[i].X, bottom_right_y);

            }
            for(int i = 0; i < cell_count_y; i++)
            {
                g.DrawLine(new Pen(Color.Red), top_left_x, rect_grid[i*cell_count_x].Y, bottom_right_x, rect_grid[i * cell_count_x].Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitVariables();

            GridColorFlowPanel.Refresh();
        }
    }
}
